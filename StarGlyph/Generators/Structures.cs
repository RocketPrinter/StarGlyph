using System.Text;

namespace StarGlyph.Generators;

internal static class Structures
{
    internal static void AddTree(this SvgFragment svg, string s, PointF point, StarGlyphOptions options)
    {
        int h=0;
        foreach (string sentence in s.Split(StarGlyphGenerator.sentenceSeparators, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries))
        {
            // separators
            if (h == 0)
                svg.Children.Add(new SvgPolygon()
                {
                    Points = new SvgPointCollection() { -100, 0, 0, -100, 100, 0 }.AddPoint(point)
                });
            else
                svg.Children.Add(new SvgPolygon()
                {
                    Points = new SvgPointCollection() {0,0, -100, -50, 0, -100, 100, -50 }.AddPoint(new PointF(point.X,point.Y - h*100))
                });
            h++;

            h += AddSentence(sentence,h);
        }

        svg.Children.Add(new SvgLine()
        {
            StartY = -100,
            EndY = - h * 100
        }.AddPoint(point));

        // returns the height of the sentence
        int AddSentence(string sentence, int hOffset)
        {
            // parsing string into lines
            // todo: "abc?def" won't get split
            string[] tokens = sentence.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            // forming branches
            int i = 0;
            int wordsPerLine = 0;
            List<string> branches = new() { "" };
            foreach (var token in tokens)
            {
                if (branches[i].Length == 0 || (wordsPerLine < options.maxWordsPerLine && token.Length + branches[i].Length <= options.maxLineLength))
                {
                    if (branches[i].Length > 0)
                        branches[i] += ' ';
                    wordsPerLine++;
                    branches[i] += token;
                }
                else
                {
                    branches.Add(token);
                    i++;
                    wordsPerLine = 1;
                }
            }

            for (i=0;i< branches.Count;i++)
                svg.AddLine(branches[i], (i + 3) % 4 <= 1, new PointF(point.X, - 100 - 200 * (i/2) - 100 * hOffset + point.Y),options);

            return (branches.Count-1)/2*2 + 2;
        }
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
