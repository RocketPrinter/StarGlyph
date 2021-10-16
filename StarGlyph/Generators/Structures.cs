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
        float d = (direction ? 1 : -1);

        SvgFragment fragment = new()
        {
            X = point.X,
            Y = point.Y
        };

        if (options.horizontalLines)
            fragment.Children.Add(new SvgLine()
            {
                EndX = point.X + s.Length * d,
            });

        for (int i=0;i<s.Length;i++)
        {
            fragment.AddCharacter(s[i], new PointF((i + 0.5f) * d, 0),options);
        }

        svg.Children.Add(fragment);
    }
}
