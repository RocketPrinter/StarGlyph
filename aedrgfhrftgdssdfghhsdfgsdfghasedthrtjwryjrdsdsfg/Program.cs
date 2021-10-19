using Svg;
using StarGlyph;

var document = SvgDocument.Open("test.svg");

StarGlyphGenerator.TestSVG().Write("output.svg");