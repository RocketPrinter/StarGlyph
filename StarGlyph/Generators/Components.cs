using Svg.Pathing;

namespace StarGlyph.Generators;

internal static class Components
{
    #region bases
    internal static void AddV(this SvgFragment svg) =>
        svg.Children.Add(new SvgPolyline()
        {
            Points = new SvgPointCollection() { 30, 80, 50, 120, 70, 80 }
        });

    internal static void AddDiamond(this SvgFragment svg) =>
        svg.Children.Add(new SvgPolygon()
        {
            Points = new SvgPointCollection() { 50, 50, 20, 100, 50, 150, 80, 100 }
        });

    internal static void AddS(this SvgFragment svg) =>
        svg.Children.Add(new SvgPath()
        {
            PathData = new SvgPathSegmentList()
            {
                new SvgMoveToSegment(new PointF(50,50)),
                new SvgCubicCurveSegment(new PointF(50,50),new PointF(10,55),new PointF(10,85),new PointF(50,100)),
                new SvgCubicCurveSegment(new PointF(50,100),new PointF(90,115),new PointF(90,145),new PointF(50,150))
            }
        });

    internal static void AddI(this SvgFragment svg) =>
        svg.Children.Add(new SvgLine()
        {
            StartX = 50,
            EndX = 50,
            StartY = 30,
            EndY = 170
        });

    internal static void AddDoubleI(this SvgFragment svg)
    {
        svg.Children.Add(new SvgLine()
        {
            StartX = 30,
            EndX = 30,
            StartY = 50,
            EndY = 150
        });
        svg.Children.Add(new SvgLine()
        {
            StartX = 70,
            EndX = 70,
            StartY = 50,
            EndY = 150
        });
    }

    internal static void AddSlash(this SvgFragment svg) =>
        svg.Children.Add(new SvgLine()
        {
            StartX = 0,
            EndX = 100,
            StartY = 50,
            EndY = 150
        });

    internal static void AddDoubleSlash(this SvgFragment svg) =>
        svg.Children.Add(new SvgPolyline()
        {
            Points = new SvgPointCollection() { 0, 0, 100, 100, 0, 200 }
        });

    internal static void AddTopO(this SvgFragment svg) =>
        svg.Children.Add(new SvgCircle()
        {
            CenterX = 50,
            CenterY = 50,
            Radius = 20
        });

    internal static void AddBottomO(this SvgFragment svg) =>
        svg.Children.Add(new SvgCircle()
        {
            CenterX = 50,
            CenterY = 150,
            Radius = 20
        });

    internal static void AddFork(this SvgFragment svg) =>
        svg.Children.Add(new SvgPolyline()
        {
            Points = new SvgPointCollection() { 50, 50, 0, 100, 50, 150 }
        });

    internal static void AddTopLollipop(this SvgFragment svg)
    {
        svg.Children.Add(new SvgLine()
        {
            StartX = 0,
            EndX = 55.85786437627f,
            StartY = 100,
            EndY = 44.1421356237f
        });

        svg.Children.Add(new SvgCircle()
        {
            CenterX = 70,
            CenterY = 30,
            Radius = 20
        });
    }

    internal static void AddBottomLollipop(this SvgFragment svg)
    {
        svg.Children.Add(new SvgLine()
        {
            StartX = 0,
            EndX = 55.85786437627f,
            StartY = 100,
            EndY = 155.8578643763f
        });

        svg.Children.Add(new SvgCircle()
        {
            CenterX = 70,
            CenterY = 170,
            Radius = 20
        });
    }
    #endregion

    #region modifiers
    internal static void AddTopBar(this SvgFragment svg) =>
        svg.Children.Add(new SvgLine()
        {
            StartX = 0,
            EndX = 100,
            StartY = 30,
            EndY = 30
        });

    internal static void AddBottomBar(this SvgFragment svg) =>
        svg.Children.Add(new SvgLine()
        {
            StartX = 0,
            EndX = 100,
            StartY = 170,
            EndY = 170
        });

    internal static void AddHarden(this SvgFragment svg, bool horizontalLine)
    {
        if (horizontalLine)
            //todo: not happy with this one
            svg.Children.Add(new SvgPolygon()
            {
                Points = new SvgPointCollection() { 35, 75, 65, 75, 65, 125, 35, 125 }
            });
        else
            svg.Children.Add(new SvgLine()
            {
                StartX = 0,
                EndX = 100,
                StartY = 100,
                EndY = 100
            });
    }

    // level: 0->3
    internal static void AddAddition(this SvgFragment svg, int level = 0)
    {
        svg.Children.Add(new SvgPolyline()
        {
            Points = new SvgPointCollection() { 70, 0, 100, 0, 100, 30 }
        });

        if (level != 0)
            svg.Children.Add(new SvgPolyline()
            {
                Points = (level switch
                {
                    1 => new SvgPointCollection() { 100, 0, 50, 50 },
                    2 => new SvgPointCollection() { 100, 0, 50, 50, 50, 150 },
                    3 => new SvgPointCollection() { 100, 0, 50, 50, 50, 150, 0, 200 },
                    _ => throw new ArgumentException("level is not in the correct range")
                })
                
            });
    }

    // level: 0->3
    internal static void AddSubstraction(this SvgFragment svg, int level = 0)
    {
        svg.Children.Add(new SvgPolyline()
        {
            Points = new SvgPointCollection() { 30, 200, 0, 200, 0, 170 }
        });

        if (level != 0)
            svg.Children.Add(new SvgPolyline()
            {
                Points = (level switch
                {
                    1 => new SvgPointCollection() { 0, 200, 50, 150 },
                    2 => new SvgPointCollection() { 0, 200, 50, 150, 50, 50 },
                    3 => new SvgPointCollection() { 0, 200, 50, 150, 50, 50, 100, 0 },
                    _ => throw new ArgumentException("level is not in the correct range")
                })
                
            });
    }
    #endregion
}
