using Svg.Pathing;

namespace StarGlyph;

internal static class Extensions
{
    //for dumb fix
    internal static SvgPointCollection AddPoint(this SvgPointCollection collection, PointF point)
    {
        SvgPointCollection newCollection = new();
        bool flip = true;
        foreach (var unit in collection)
        {
            newCollection.Add(unit.Value + (flip ? point.X : point.Y));
            flip = !flip;
        }
        return newCollection;
    }

    //for dumb fix
    internal static SvgLine AddPoint(this SvgLine line, PointF point)
    {
        line.StartX += point.X;
        line.EndX += point.X;

        line.StartY += point.Y;
        line.EndY += point.Y;

        return line;
    }

    //for dumb fix
    internal static SvgCircle AddPoint(this SvgCircle circle, PointF point)
    {
        circle.CenterX += point.X;
        circle.CenterY += point.Y;

        return circle;
    }

    //for dumb fix
    internal static SvgCubicCurveSegment AddPoint(this SvgCubicCurveSegment segment, PointF point)
    {
        SizeF size = new(point);
        segment.Start += size;
        segment.FirstControlPoint += size;
        segment.SecondControlPoint += size;
        segment.End += size;
        return segment;
    }
}
