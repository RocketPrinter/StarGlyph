using System.Text;

namespace StarGlyph.Generators;

internal static class Structures
{
    internal static void AddTree(this SvgFragment svg, string s, PointF point, StarGlyphOptions options)
    {
        // parsing string into lines
        // todo: "abc?def" won't get split
        string[] tokens = s.Split(" ", StringSplitOptions.TrimEntries & StringSplitOptions.RemoveEmptyEntries);

        // forming tree lines
        int i = 0;
        int wordsPerLine = 0;
        List<string> lines = new() { "" };
        foreach (var token in tokens)
        {
            if (lines[i].Length == 0 || (wordsPerLine < options.maxWordsPerLine && token.Length + lines[i].Length <= options.maxLineLength))
            {
                if (lines[i].Length > 0)
                    lines[i] += ' ';
                wordsPerLine++;
                lines[i] += token;
            }
            else
            {
                lines.Add(token);
                i++;
                wordsPerLine = 1;
            }
        }

        if (lines[i] == "")
            lines.RemoveAt(i);

        svg.Children.Add(new SvgPolygon()
        {
            Points = new SvgPointCollection() { -100, 0, 0, -100, 100, 0 }.AddPoint(point)
        });
        svg.Children.Add(new SvgLine()
        {
            StartY = -100,
            EndY = -100 - lines.Count / 2 * 200
        }.AddPoint(point));

        for (i=0;i<lines.Count;i++)
            svg.AddLine(lines[i], (i + 3) % 4 <= 1, new PointF(point.X, -200 * (1 + i/2) + point.Y),options);
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
                EndX = s.Length * 100 * d,
            }
            .AddPoint(point)
            );

        for (int i=0;i<s.Length;i++)
        {
            fragment.AddCharacter(s[i], new PointF((i * 100 + 50) * d + point.X, point.Y),options);
        }

        svg.Children.Add(fragment);
    }
}
