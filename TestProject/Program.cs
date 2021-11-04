using StarGlyph;
using Svg;

var document = SvgDocument.Open("test.svg");

var options = StarGlyphGenerator.defaultOptions with { maxWordsPerLine = 2, throwOnInvalidChars = false };
StarGlyphGenerator.TestSVG().Write("output.svg");
StarGlyphGenerator.StringToSVG("This is some text written in StarGlyph", options: options).Write("output2.svg");
// not fully displaying!!!
StarGlyphGenerator.StringToSVG(File.ReadAllText("lorem_ipsum.txt"), options: options).Write("output3.svg");