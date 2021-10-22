using Svg.Pathing;

namespace StarGlyph.Generators;

internal static class Components
{
    #region bases
    internal static void AddV(this SvgFragment svg, PointF point) =>
        svg.Children.Add(new SvgPolyline()
        {
            Points = new SvgPointCollection() { -20, -20, 0, 20, 20, -20 }.AddPoint(point)
        });

    internal static void AddDiamond(this SvgFragment svg, PointF point) =>
        svg.Children.Add(new SvgPolygon()
        {
            Points = new SvgPointCollection() { 0, -50, -30, 0, 0, 50, 30, 0 }.AddPoint(point)
        });

    internal static void AddS(this SvgFragment svg, PointF point) =>
        svg.Children.Add( new SvgPath()
        {
            PathData = new SvgPathSegmentList()
            {
                
            }
        });

    internal static void AddI(this SvgFragment svg, PointF point) =>
        svg.Children.Add(new SvgLine()
        {
            StartY = -70,
            EndY = 70
        }.AddPoint(point));

    internal static void AddDoubleI(this SvgFragment svg, PointF point)
    {
        svg.Children.Add(new SvgLine()
        {
            StartX = -20,
            EndX = -20,
            StartY = -50,
            EndY = 50
        }.AddPoint(point));
        svg.Children.Add(new SvgLine()
        {
            StartX = 20,
            EndX = 20,
            StartY = -50,
            EndY = 50
        }.AddPoint(point));
    }

    internal static void AddSlash(this SvgFragment svg, PointF point) =>
        svg.Children.Add(new SvgLine()
        {
            StartX = -50,
            StartY = -50,
            EndX = 50,
            EndY = 50
        }.AddPoint(point));

    internal static void AddDoubleSlash(this SvgFragment svg, PointF point) =>
        svg.Children.Add(new SvgPolyline()
        {
            Points = new SvgPointCollection() { -50, -100, 50, 0, -50, 100 }.AddPoint(point)
        });

    internal static void AddTopO(this SvgFragment svg, PointF point) =>
        svg.Children.Add(new SvgCircle()
        {
            CenterY = -50,
            Radius = 20
        }.AddPoint(point));

    internal static void AddBottomO(this SvgFragment svg, PointF point) =>
        svg.Children.Add(new SvgCircle()
        {
            CenterY = 50,
            Radius = 20
        }.AddPoint(point));

    internal static void AddFork(this SvgFragment svg, PointF point) =>
        svg.Children.Add(new SvgPolyline()
        {
            Points = new SvgPointCollection() { 0, -50, -50, 0, 0, 50 }.AddPoint(point)
        });

    internal static void AddTopLollipop(this SvgFragment svg, PointF point)
    {
        svg.Children.Add(new SvgLine()
        {
            StartX = -50,
            EndX = 5.85786437627f,
            EndY = -55.8578643763f
        }.AddPoint(point));

        svg.Children.Add(new SvgCircle()
        {
            CenterX = 20,
            CenterY = -70,
            Radius = 20
        }.AddPoint(point));
    }

    internal static void AddBottomLollipop(this SvgFragment svg, PointF point)
    {
        svg.Children.Add(new SvgLine()
        {
            StartX = -50,
            EndX = 5.85786437627f,
            EndY = 55.8578643763f
        }.AddPoint(point));

        svg.Children.Add(new SvgCircle()
        {
            CenterX = 20,
            CenterY = 70,
            Radius = 20
        }.AddPoint(point));
    }
    #endregion

    #region modifiers
    internal static void AddTopBar(this SvgFragment svg, PointF point) =>
        svg.Children.Add(new SvgLine()
        {
            StartX = -50,
            EndX = 50,
            StartY = -70,
            EndY = -70
        }.AddPoint(point));

    internal static void AddBottomBar(this SvgFragment svg, PointF point) =>
        svg.Children.Add(new SvgLine()
        {
            StartX = -50,
            EndX = 50,
            StartY = 70,
            EndY = 70
        }.AddPoint(point));

    internal static void AddHarden(this SvgFragment svg, bool horizontalLine, PointF point)
    {
        if (horizontalLine)
            //todo: not happy with this one
            svg.Children.Add(new SvgPolygon()
            {
                Points = new SvgPointCollection() { -15, -25, 15, -25, 15, 25, -15, 25 }.AddPoint(point)
            });
        else
            svg.Children.Add(new SvgLine()
            {
                StartX = -50,
                EndX = 50
            }.AddPoint(point));
    }

    // level: 0->3
    internal static void AddAddition(this SvgFragment svg, PointF point, int level = 0)
    {
        svg.Children.Add(new SvgPolyline()
        {
            Points = new SvgPointCollection() { 20, -100, 50, -100, 50, -70 }.AddPoint(point)
        });

        if (level != 0)
            svg.Children.Add(new SvgPolyline()
            {
                Points = (level switch
                {
                    1 => new SvgPointCollection() { 50, -100, 0, -50 },
                    2 => new SvgPointCollection() { 50, -100, 0, -50, 0, 50 },
                    3 => new SvgPointCollection() { 50, -100, 0, -50, 0, 50, -50, 100 },
                    _ => throw new ArgumentException("level is not in the correct range")
                })
                .AddPoint(point)
            });
    }

    // level: 0->3
    internal static void AddSubstraction(this SvgFragment svg, PointF point, int level = 0)
    {
        svg.Children.Add(new SvgPolyline()
        {
            Points = new SvgPointCollection() { -20, 100, -50, 100, -50, 70 }.AddPoint(point)
        });

        if (level != 0)
            svg.Children.Add(new SvgPolyline()
            {
                Points = (level switch
                {
                    1 => new SvgPointCollection() { -50, 100, 0, 50 },
                    2 => new SvgPointCollection() { -50, 100, 0, 50, 0, -50 },
                    3 => new SvgPointCollection() { -50, 100, 0, 50, 0, -50, 50, -100 },
                    _ => throw new ArgumentException("level is not in the correct range")
                })
                .AddPoint(point)
            });
    }
    #endregion
}
