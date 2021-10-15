/// TODO:
/// implement the thing itself
/// CLI tool
/// GUI tool (in Blazor)
/// make repo public
/// nuget pkg

using StarGlyph.Generators;

namespace StarGlyph;

public record class StarGlyphOptions(bool horizontalLines = false, Layout defaultLayout = Layout.Phrase);

public class StarGlyph
{
    public enum Layout
    {
        Default,
        Phrase, 
        Equation
    }

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

    StarGlyphOptions settings;
    public StarGlyph()
    {
        settings = new();
    }
    public StarGlyph(StarGlyphOptions settings)
    {
        this.settings = settings;
        if (settings.defaultLayout == Layout.Default)
            throw new ArgumentException("defaultLayout shouldn't be Default");
    }

    public string CharToSVG(char c)
        => throw new NotImplementedException();

    public string StringToSVG(string s, Layout layout = Layout.Default)
    {
        if (layout == Layout.Default)
            layout = settings.defaultLayout;
        throw new NotImplementedException();
    }
}