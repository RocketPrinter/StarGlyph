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

public record class StarGlyphOptions(PointF? offsetOverride = null, bool horizontalLines = false, bool attributeAnnotations = true, int maxLineLength = 6, int maxWordsPerLine=2, bool throwOnInvalidChars = true);

public static class StarGlyphGenerator
{
    public static readonly StarGlyphOptions defaultOptions = new StarGlyphOptions();
    // needed because of svg qurikyness I don't understand
    public static readonly PointF defaultOffset = new PointF(1000, 5000);

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
    public static readonly char[] sentenceSeparators = new[] {'.', '?', '!'};

    public static SvgDocument CharToSVG(char c, StarGlyphOptions? options = null)
    {
        options ??= defaultOptions;

        SvgDocument document = CreateDocument(options);

        document.AddLine(c.ToString(), true, options.offsetOverride ?? defaultOffset, options);

        document.FinalizeDocument();
        return document;
    }

    public static SvgDocument StringToSVG(string s, StarGlyphOptions? options = null)
    {
        options ??= defaultOptions;

        s = s.ToLower();

        SvgDocument document = CreateDocument(options);

        document.AddTree(s, options.offsetOverride ?? defaultOffset, options);

        document.FinalizeDocument();
        return document;
    }

    public static SvgDocument TestSVG(StarGlyphOptions? options = null)
    {
        options ??= defaultOptions;

        var document = CreateDocument(options);

        document.AddLine(ValidChars.Aggregate(new StringBuilder(), (sb, x) => sb.Append(x)).ToString(), true, defaultOffset, options);
        document.AddLine(ValidChars.Aggregate(new StringBuilder(), (sb, x) => sb.Append(x)).ToString(), true, new PointF(defaultOffset.X,defaultOffset.Y + 200), options with { horizontalLines=true});


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
        document.ViewBox = new(document.Bounds.X, document.Bounds.Y, document.Bounds.Right, document.Bounds.Bottom);
    }
}