namespace StarGlyph.Generators;

internal static class Components
{
    #region bases
    internal static void AddV(this SvgFragment svg, PointF point)
    {

    }

    internal static void AddDiamond(this SvgFragment svg, PointF point) =>
        svg.Children.Add(new SvgPolygon()
        {
            Points = new SvgPointCollection() { 0, -0.5f, -0.3f, 0, 0, 0.5f, 0.3f, 0 }.AddPoint(point)
        });

    internal static void AddS(this SvgFragment svg, PointF point)
    {

    }

    internal static void AddI(this SvgFragment svg, PointF point) =>
        svg.Children.Add(new SvgLine()
        {
            StartY = -0.5f,
            EndY = 0.5f
        }.AddPoint(point));

    internal static void AddDoubleI(this SvgFragment svg, PointF point)
    {
        svg.Children.Add(new SvgLine()
        {
            StartX = -0.2f,
            EndX = -0.2f,
            StartY = -0.5f,
            EndY = 0.5f
        }.AddPoint(point));
        svg.Children.Add(new SvgLine()
        {
            StartX = 0.2f,
            EndX = 0.2f,
            StartY = -0.5f,
            EndY = 0.5f
        }.AddPoint(point));
    }

    internal static void AddSlash(this SvgFragment svg, PointF point) =>
        svg.Children.Add(new SvgLine()
        {
            StartX = -0.5f,
            StartY = -0.5f,
            EndX = -0.5f,
            EndY = 0.5f
        }.AddPoint(point));

    internal static void AddDoubleSlash(this SvgFragment svg, PointF point) =>
        svg.Children.Add(new SvgPolygon()
        {
            Points = new SvgPointCollection() { -0.5f, -1f, 0.5f, 0, 0.5f, 1f }.AddPoint(point)
        });

    internal static void AddTopO(this SvgFragment svg, PointF point) =>
        svg.Children.Add(new SvgCircle()
        {
            CenterY = 0.5f,
            Radius = 0.2f
        }.AddPoint(point));

    internal static void AddBottomO(this SvgFragment svg, PointF point) =>
        svg.Children.Add(new SvgCircle()
        {
            CenterY = -0.5f,
            Radius = 0.2f
        }.AddPoint(point));

    internal static void AddFork(this SvgFragment svg, PointF point) =>
        svg.Children.Add(new SvgPolygon()
        {
            Points = new SvgPointCollection() { 0, -0.5f, -0.5f, 0, 0, 0.5f }.AddPoint(point)
        });

    internal static void AddTopLollipop(this SvgFragment svg, PointF point)
    {

    }

    internal static void AddBottomLollipop(this SvgFragment svg, PointF point)
    {

    }
    #endregion

    #region modifiers
    internal static void AddTopBar(this SvgFragment svg, PointF point) =>
        svg.Children.Add(new SvgLine()
        {
            StartX = -0.5f,
            EndX = 0.5f,
            StartY = -0.4f,
            EndY = -0.4f
        }.AddPoint(point));

    internal static void AddBottomBar(this SvgFragment svg, PointF point) =>
        svg.Children.Add(new SvgLine()
        {
            StartX = -0.5f,
            EndX = 0.5f,
            StartY = 0.4f,
            EndY = 0.4f
        }.AddPoint(point));

    internal static void AddHarden(this SvgFragment svg, bool horizontalLine, PointF point)
    {
        if (horizontalLine)
            throw new NotImplementedException();
        else
            svg.Children.Add(new SvgLine()
            {
                StartX = -0.5f,
                EndX = 0.5f
            }.AddPoint(point));
    }

    // level: 0->3
    internal static void AddAddition(this SvgFragment svg, PointF point, int level = 0)
    {
        svg.Children.Add(new SvgPolygon()
        {
            Points = new SvgPointCollection() { 0.2f, 1f, 0.5f, 1f, 0.5f, 0.7f }.AddPoint(point)
        });

        if (level != 0)
            svg.Children.Add(new SvgPolygon()
            {
                Points = (level switch
                {
                    1 => new SvgPointCollection() { 0.5f, 1f, 0f, 0.5f },
                    2 => new SvgPointCollection() { 0.5f, 1f, 0f, 0.5f, 0f, -0.5f },
                    3 => new SvgPointCollection() { 0.5f, 1f, 0f, 0.5f, 0f, -0.5f, -0.5f, -1f },
                    _ => throw new ArgumentException("level is not in the correct range")
                })
                .AddPoint(point)
            });
    }

    // level: 0->3
    internal static void AddSubstraction(this SvgFragment svg, PointF point, int level = 0)
    {
        svg.Children.Add(new SvgPolygon()
        {
            Points = new SvgPointCollection() { -0.2f, -1f, -0.5f, -1f, -0.5f, -0.7f }.AddPoint(point)
        });

        if (level != 0)
            svg.Children.Add(new SvgPolygon()
            {
                Points = (level switch
                {
                    1 => new SvgPointCollection() { -0.5f, -1f, 0f, -0.5f },
                    2 => new SvgPointCollection() { -0.5f, -1f, 0f, -0.5f, 0f, 0.5f },
                    3 => new SvgPointCollection() { -0.5f, -1f, 0f, -0.5f, 0f, 0.5f, 0.5f, 1f },
                    _ => throw new ArgumentException("level is not in the correct range")
                })
                .AddPoint(point)
            });
    }
    #endregion
}
