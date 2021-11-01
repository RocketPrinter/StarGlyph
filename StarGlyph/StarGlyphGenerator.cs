global using Svg;
global using System.Drawing;

using StarGlyph.Generators;
using System.Text;

namespace StarGlyph;

public record class StarGlyphOptions(bool horizontalLines = false, bool attributeAnnotations = true, int maxLineLength = 6, int maxWordsPerLine = 2, bool throwOnInvalidChars = true);

public static class StarGlyphGenerator
{
    public static readonly StarGlyphOptions defaultOptions = new();
    const float strokeWidth = 5;
    readonly static PointF defaultOffset = new (strokeWidth, strokeWidth);

    /// <summary>
    /// Valid characters, uses a HashSet under the hood.
    /// Invalid charcaters will throw ArgumentOutOfRangeException if throwOnInvalidChars==true
    /// </summary>
    public static readonly IReadOnlySet<char> ValidChars = new HashSet<char>()
    {
        'a', 'ă', 'â', 'e','i', 'î', 'o', 'u',
        'b','c','d', 'f', 'g', 'h','j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 'ș', 't', 'ț', 'v','w', 'x', 'y', 'z',
        '0','1','2','3','4','5','6','7','8','9',
        ' ','+','-','*','/','='
    };
    public static readonly char[] sentenceSeparators = new[] { '.', '?', '!' };

    public static SvgDocument CharToSVG(char c, StarGlyphOptions? options = null)
    {
        options ??= defaultOptions;

        SvgDocument document = CreateDocument(options);

        document.AddLine(c.ToString(), true, defaultOffset, options, out var bounds);

        document.FinalizeDocument(bounds);
        return document;
    }

    public static SvgDocument StringToSVG(string s, StarGlyphOptions? options = null)
    {
        options ??= defaultOptions;

        s = s.ToLower();

        SvgDocument document = CreateDocument(options);

        document.AddPhrase(s, defaultOffset, options, out var bounds);

        document.FinalizeDocument(bounds);
        return document;
    }

    public static SvgDocument TestSVG(StarGlyphOptions? options = null)
    {
        options ??= defaultOptions;

        var document = CreateDocument(options);

        string alphabet = ValidChars.Aggregate(new StringBuilder(), (sb, x) => sb.Append(x)).ToString();
        document.AddLine(alphabet, false, defaultOffset, options, out _);
        document.AddLine(alphabet, false, new PointF(defaultOffset.X, defaultOffset.Y + 200), options with { horizontalLines = true }, out _);


        document.FinalizeDocument(new SizeF(alphabet.Length*100, 400));
        return document;
    }



    private static SvgDocument CreateDocument(StarGlyphOptions options)
    {
        SvgDocument document = new()
        {
            Width = new SvgUnit(SvgUnitType.Percentage, 100),
            Height = new SvgUnit(SvgUnitType.Percentage, 100),
            Fill = SvgPaintServer.None,
            Stroke = new SvgColourServer(Color.Black),
            StrokeWidth = strokeWidth
        };
        if (options.attributeAnnotations)
            document.CustomAttributes.Add("about", "Made with: https://github.com/RocketPrinter/StarGlyph");
        return document;
    }

    private static void FinalizeDocument(this SvgDocument document, SizeF bounds)
    {
        document.ViewBox = new(0, 0, bounds.Width + strokeWidth * 2, bounds.Height + strokeWidth * 2);
    }
}