namespace StarGlyph.Generators;

internal static class Structures
{
    internal static void AddTree(this SvgFragment svg, string s, PointF point, StarGlyphOptions options)
    {
        svg.Children.Add(new SvgPolygon()
        {
            Points = new SvgPointCollection() { -1, 0, 1, 0, 0, 1 }.AddPoint(point)
        });
    }

    // direction == false <-
    // direction == true ->
    internal static void AddLine(this SvgFragment svg, string s, bool direction, PointF point, StarGlyphOptions options)
    {
        float d = (direction ? 1 : -1);

        SvgFragment fragment = new();
        if (options.attributeAnnotations)
            fragment.CustomAttributes.Add("line",s);

        if (options.horizontalLines)
            fragment.Children.Add(new SvgLine()
            {
                EndX = s.Length * d,
            }
            .AddPoint(point)
            );

        for (int i=0;i<s.Length;i++)
        {
            fragment.AddCharacter(s[i], new PointF((i + 0.5f) * d + point.X, point.Y),options);
        }

        svg.Children.Add(fragment);
    }
}
