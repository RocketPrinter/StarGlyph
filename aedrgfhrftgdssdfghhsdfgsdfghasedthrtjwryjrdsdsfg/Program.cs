using Svg;
using StarGlyph;

var document = SvgDocument.Open("test.svg");

var options = StarGlyphGenerator.defaultOptions with { maxWordsPerLine=1, throwOnInvalidChars = false };
StarGlyphGenerator.TestSVG().Write("output.svg");
StarGlyphGenerator.StringToSVG("This is a test. A very testy test. So testy.", options:options).Write("output2.svg");