/// TODO:
/// implement the thing itself
/// CLI tool
/// GUI tool (in Blazor)
/// make repo public
/// nuget pkg
/// switch to SvgPoint or Vector2 from System.Numberics

global using Svg;
global using System.Drawing;

using StarGlyph.Generators;
using System.Text;

namespace StarGlyph;

public record class StarGlyphOptions(bool horizontalLines = false, StarGlyphLayout defaultLayout = StarGlyphLayout.Tree, bool attributeAnnotations = true, int maxLineLength = 10, int maxWordsPerLine=2, bool throwOnInvalidChars = true);

public enum StarGlyphLayout
{
    Default,
    Tree,
    Linear
}

public static class StarGlyphGenerator
{
    public static readonly StarGlyphOptions defaultOptions = new StarGlyphOptions();
    // dumb fix, *every* coordinate must be over 0
    internal static readonly PointF rootPos = new PointF(10_000-9000f, 10_000-9000f);

    /// <summary>
    /// Valid characters, uses a HashSet under the hood.
    /// </summary>
    public static readonly IReadOnlySet<char> ValidChars = new HashSet<char>()
    {
        'a', 'ă', 'â', 'e','i', 'î', 'o', 'u',
        'b','c','d', 'f', 'g', 'h','j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 'ș', 't', 'ț', 'v','w', 'x', 'y', 'z',
        '0','1','2','3','4','5','6','7','8','9',
        ' ','+','-','*','/','='
    };

    public static SvgDocument CharToSVG(char c, StarGlyphOptions? options = null)
    {
        options ??= defaultOptions;

        SvgDocument document = CreateDocument(options);

        document.AddLine(c.ToString(), true, new PointF(0, 0), options);

        document.FinalizeDocument();
        return document;
    }

    public static SvgDocument StringToSVG(string s, StarGlyphLayout layout = StarGlyphLayout.Default, StarGlyphOptions? options = null)
    {
        options ??= defaultOptions;

        if (layout == StarGlyphLayout.Default)
            layout = options.defaultLayout;

        s = s.ToLower();

        SvgDocument document = CreateDocument(options);

        if (layout == StarGlyphLayout.Tree)
            document.AddTree(s, rootPos, options);
        else
            document.AddLine(s, true, rootPos, options); //todo: not good

        document.FinalizeDocument();
        return document;
    }

    public static SvgDocument TestSVG(StarGlyphOptions? options = null)
    {
        options ??= defaultOptions;

        var document = CreateDocument(options);

        document.AddLine(ValidChars.Aggregate(new StringBuilder(), (sb, x) => sb.Append(x)).ToString(), true, rootPos, options);
        document.AddLine(ValidChars.Aggregate(new StringBuilder(), (sb, x) => sb.Append(x)).ToString(), true, new PointF(rootPos.X,rootPos.Y + 200), options with { horizontalLines=true});


        document.FinalizeDocument();
        return document;
    }



    private static SvgDocument CreateDocument(StarGlyphOptions options)
    {
        SvgDocument document = new()
        {
            Width = new SvgUnit(SvgUnitType.Percentage,100),
            Height = new SvgUnit(SvgUnitType.Percentage,100),
            Fill = SvgPaintServer.None,
            Stroke = new SvgColourServer(Color.Black),
            StrokeWidth = 5f
        };
        if (options.attributeAnnotations)
            document.CustomAttributes.Add("about", "Made with: https://github.com/RocketPrinter/StarGlyph");
        return document;
    }

    private static void FinalizeDocument(this SvgDocument document)
    {
        // dumb fix, *every* coordinate must be over 0
        document.ViewBox = new(document.Bounds.X, document.Bounds.Y, document.Bounds.Width*2, document.Bounds.Height+2000);
    }
}