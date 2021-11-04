namespace StarGlyph.Generators;

internal static class Structures
{
    internal static void AddPhrase(this SvgFragment svg, string s, PointF offset, StarGlyphOptions options, out SizeF bounds)
    {
        SvgFragment fragment = new()
        {
            X = offset.X,
            Y = offset.Y
        };

        // parse the string and calculate bounds
        ParsePhrase(s, options, out var parseReult, out bounds, out int rootX);

        // draw sentences
        bool first = true;
        float h = bounds.Height;
        foreach (List<string> sentence in parseReult)
        {
            // separators
            h -= 100;
            if (first)
            {
                first = false;
                fragment.Children.Add(new SvgPolygon()
                {
                    Points = new SvgPointCollection() { 0, 100, 100, 0, 200, 100 }
                        .AddPoint(new PointF(rootX - 100, h))
                });
            }
            else
                fragment.Children.Add(new SvgPolygon()
                {
                    Points = new SvgPointCollection() { 0, 50, 100, 0, 200, 50, 100, 100 }
                        .AddPoint(new PointF(rootX - 100, h))
                });

            // draw branches
            int i=0;
            foreach (string branch in sentence)
            {
                if (i % 2 == 0)
                    h-= 200;

                bool leftBranch = (i+1)%4<=1;
                fragment.AddLine(branch,leftBranch,new PointF(leftBranch?rootX-branch.Length*100:rootX,h), options, out _);

                i++;
            }
        }

        fragment.Children.Add(new SvgLine()
        {
            StartX = rootX,
            EndX = rootX,
            StartY = 0,
            EndY = bounds.Height
        });

        svg.Children.Add(fragment);
    }

    private static void ParsePhrase(string s, StarGlyphOptions options, out List<List<string>> parseResult, out SizeF bounds, out int rootX)
    {
        parseResult = new();
        bounds = new();
        rootX = 0;

        // parsing phrase into sentences
        var sentences = s.Split(StarGlyphGenerator.sentenceSeparators, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        foreach (var sentence in sentences)
        {
            // parsing sentence into branches
            string[] tokens = sentence.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            // forming branches
            int i = 0;
            int wordsPerLine = 0;
            List<string> branches = new() { "" };
            foreach (var token in tokens)
            {
                if (branches[i].Length == 0 || (wordsPerLine < options.maxWordsPerLine && token.Length + branches[i].Length <= options.maxLineLength))
                {
                    // add word to current branch
                    if (branches[i].Length > 0)
                        branches[i] += ' ';
                    branches[i] += token;
                    wordsPerLine++;
                }
                else
                {
                    // create new branch
                    branches.Add(token);
                    i++;
                    wordsPerLine = 1;
                }
            }
            parseResult.Add(branches);

            // calculating bounds
            int leftMax=0, rightMax=0;
            for (int j = 0; j < branches.Count; j++)
            {
                bool leftBranch = (j + 1) % 4 <= 1;
                if (leftBranch)
                    leftMax = Math.Max(leftMax, branches[j].Length);
                else
                    rightMax = Math.Max(branches[j].Length, rightMax);
            }

            bounds = new(Math.Max(bounds.Width, (leftMax+rightMax) * 100), 100 + bounds.Height + 200 * (branches.Count / 2 + branches.Count % 2));
            rootX = Math.Max(rootX,leftMax*100);
        }
    }

    internal static void AddLine(this SvgFragment svg, string s, bool reverse, PointF offset, StarGlyphOptions options, out SizeF bounds)
    {
        float d = (reverse ? 1 : -1);

        SvgFragment fragment = new()
        {
            X = offset.X,
            Y = offset.Y
        };
        if (options.attributeAnnotations)
            fragment.CustomAttributes.Add("line", s);

        if (options.horizontalLines)
            fragment.Children.Add(new SvgLine()
            {
                StartX = 0,
                EndX = s.Length * 100,
                StartY = 100,
                EndY = 100
            }
            );

        for (int i = 0; i < s.Length; i++)
        {
            fragment.AddCharacter(s[reverse?s.Length-i-1:i], new PointF(i * 100 ,0), options);
        }

        bounds = new(s.Length*100, 200);

        svg.Children.Add(fragment);
    }
}
