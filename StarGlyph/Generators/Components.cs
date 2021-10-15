using System.Drawing;
using System.Text;

namespace StarGlyph.Generators;

internal static class Components
{
    #region bases
    internal static void AddV(this StringBuilder sb, PointF point)
    {

    }

    internal static void AddDiamond(this StringBuilder sb, PointF point)
    {

    }

    internal static void AddS(this StringBuilder sb, PointF point)
    {

    }

    internal static void AddI(this StringBuilder sb, PointF point)
    {

    }

    internal static void AddDoubleI(this StringBuilder sb, PointF point)
    {

    }

    internal static void AddSlash(this StringBuilder sb, PointF point)
    {

    }

    internal static void AddDoubleSlash(this StringBuilder sb, PointF point)
    {

    }

    internal static void AddTopO(this StringBuilder sb, PointF point)
    {

    }

    internal static void AddBottomO(this StringBuilder sb, PointF point)
    {

    }

    internal static void AddFork(this StringBuilder sb, PointF point)
    {

    }

    internal static void AddTopLollipop(this StringBuilder sb, PointF point)
    {

    }

    internal static void AddBottomLollipop(this StringBuilder sb, PointF point)
    {

    }
    #endregion

    #region modifiers
    internal static void AddTopBar(this StringBuilder sb, PointF point)
    {

    }

    internal static void AddBottomBar(this StringBuilder sb, PointF point)
    {

    }

    internal static void AddHarden(this StringBuilder sb, PointF point, bool horizontalLine)
    {

    }

    // level: 0->3
    internal static void AddAddition(this StringBuilder sb, PointF point, int level = 0)
    {

    }

    // level: 0->3
    internal static void AddSubstraction(this StringBuilder sb, PointF point, int level = 0)
    {

    }
    #endregion
}
