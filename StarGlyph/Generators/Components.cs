using Svg;
using System.Drawing;

namespace StarGlyph.Generators;

internal static class Components
{
    #region bases
    internal static void AddV(this SvgFragment svg) =>
        svg.Children.Add(new SvgPolygon()
        {
            Points = new SvgPointCollection() { -0.2f, -0.2f, 0, 0.2f, 0.2f, -0.2f }
        });

    internal static void AddDiamond(this SvgFragment svg) =>
        svg.Children.Add(new SvgPolygon()
        {
            Points = new SvgPointCollection(){ 0,-0.5f, -0.3f,0, 0,0.5f, 0.3f,0}
        });

    internal static void AddS(this SvgFragment svg)
    {

    }

    internal static void AddI(this SvgFragment svg) =>
        svg.Children.Add(new SvgLine()
        {
            StartY = -0.5f,
            EndY = 0.5f
        });

    internal static void AddDoubleI(this SvgFragment svg)
    {
        svg.Children.Add(new SvgLine()
        {
            StartX = -0.2f,
            EndX = -0.2f,
            StartY = -0.5f,
            EndY = 0.5f
        });
        svg.Children.Add(new SvgLine()
        {
            StartX = 0.2f,
            EndX = 0.2f,
            StartY = -0.5f,
            EndY = 0.5f
        });
    }

    internal static void AddSlash(this SvgFragment svg) =>
        svg.Children.Add(new SvgLine()
        {
            StartX = -0.5f,
            StartY = -0.5f,
            EndX = -0.5f,
            EndY = 0.5f
        });

    internal static void AddDoubleSlash(this SvgFragment svg) =>
        svg.Children.Add(new SvgPolygon()
        {
            Points = new SvgPointCollection() { -0.5f, -1f,  0.5f, 0,   0.5f, 1 }
        });

    internal static void AddTopO(this SvgFragment svg) =>
        svg.Children.Add(new SvgCircle()
        {
            CenterY = 0.5f,
            Radius = 0.2f
        });

    internal static void AddBottomO(this SvgFragment svg) =>
        svg.Children.Add(new SvgCircle()
        {
            CenterY = -0.5f,
            Radius = 0.2f
        });

    internal static void AddFork(this SvgFragment svg) =>
        svg.Children.Add(new SvgPolygon()
        {
            Points = new SvgPointCollection() { 0, -0.5f, -0.5f, 0, 0, 0.5f }
        });

    internal static void AddTopLollipop(this SvgFragment svg)
    {

    }

    internal static void AddBottomLollipop(this SvgFragment svg)
    {

    }
    #endregion

    #region modifiers
    internal static void AddTopBar(this SvgFragment svg) =>
        svg.Children.Add(new SvgLine()
        {
            StartX = -0.5f,
            EndX = 0.5f,
            StartY = -0.4f,
            EndY = -0.4f
        });

    internal static void AddBottomBar(this SvgFragment svg) =>
        svg.Children.Add(new SvgLine()
        {
            StartX = -0.5f,
            EndX = 0.5f,
            StartY = 0.4f,
            EndY = 0.4f
        });

    internal static void AddHarden(this SvgFragment svg, bool horizontalLine)
    {

    }

    // level: 0->3
    internal static void AddAddition(this SvgFragment svg, int level = 0)
    {

    }

    // level: 0->3
    internal static void AddSubstraction(this SvgFragment svg, int level = 0)
    {

    }
    #endregion
}
