using Svg;
using Svg.DataTypes;
using System.Drawing;

namespace StarGlyph.Generators;

internal static class Structures
{
    internal static void AddTree(this SvgFragment svg, string s, PointF point, StarGlyphOptions options)
    {
        svg.Children.Add( new SvgPolygon()
        {
            Points = new() { -1, 0, 1, 0, 0, 1 }
        });
    }

    // direction == false <-
    // direction == true ->
    internal static void AddLinear(this SvgFragment svg, string s, bool direction, PointF point, StarGlyphOptions options)
    {
        if (options.horizontalLines)
            svg.Children.Add(new SvgLine()
            {
                StartX = point.X - 0.5f,
                StartY = point.Y,
                EndX = point.X - 0.5f + s.Length,
                EndY = point.Y,
            });

        for (int i=0;i<s.Length;i++)
        {
            svg.AddCharacter(s[i], point + (direction ? 1 : -1) * new Size(i,0),options);
        }
    }
}
