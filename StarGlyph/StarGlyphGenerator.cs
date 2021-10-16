/// TODO:
/// implement the thing itself
/// CLI tool
/// GUI tool (in Blazor)
/// make repo public
/// nuget pkg

using Svg;
using Svg.Transforms;
using StarGlyph.Generators;
using System.Drawing;
using System.Text;

namespace StarGlyph;

public record class StarGlyphOptions(bool horizontalLines = false, StarGlyphLayout defaultLayout = StarGlyphLayout.Tree, float scale=100);

public enum StarGlyphLayout
{
    Default,
    Tree, 
    Linear
}

public class StarGlyphGenerator
{
    /// <summary>
    /// Valid characters, uses a HashSet under the hood.
    /// </summary>
    public static readonly IReadOnlySet<char> ValidChars = new HashSet<char>()
    {
        'a', 'ă', 'â' , 'e','i', 'î', 'o', 'u', 'v',
        'b','c','d', 'f', 'g', 'h','j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 'ș', 't', 'ț', 'w', 'x', 'y', 'z',
        '0','1','2','3','4','5','6','7','8','9',
        ' ','+','-','*','/','='
    };

    StarGlyphOptions options;
    public StarGlyphGenerator()
    {
        options = new();
    }
    public StarGlyphGenerator(StarGlyphOptions settings)
    {
        this.options = settings;
        if (settings.defaultLayout == StarGlyphLayout.Default)
            throw new ArgumentException("defaultLayout shouldn't be Default");
    }

    public SvgDocument CharToSVG(char c)
    {
        SvgDocument document = new();
        document.Transforms = new() { new SvgScale(options.scale, options.scale) };

        document.AddLinear(c.ToString(),true,new PointF(0,0),options);

        return document;
    }

    public SvgDocument StringToSVG(string s, StarGlyphLayout layout = StarGlyphLayout.Default)
    {
        if (layout == StarGlyphLayout.Default)
            layout = options.defaultLayout;

        s = s.ToLower();

        SvgDocument document = new();
        document.Transforms = new() { new SvgScale(options.scale, options.scale) };

        if (layout == StarGlyphLayout.Tree)
            document.AddTree(s, new PointF(0, 0), options);
        else
            document.AddLinear(s, true, new PointF(0,0), options);

        return document;
    }

    public SvgDocument TestSVG()
    {
        SvgDocument document = new();
        document.Transforms= new() { new SvgScale(options.scale, options.scale) };
        
        document.AddLinear(ValidChars.Aggregate(new StringBuilder(), (sb,x)=> sb.Append(x)).ToString(),true,new PointF(0,0),options);

        return document;
    }
}