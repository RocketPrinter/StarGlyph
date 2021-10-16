using Svg;
using System.Drawing;
namespace StarGlyph.Generators;

internal static class Characters
{
    internal static void AddCharacter(this SvgFragment svg, char c, PointF point, StarGlyphOptions options)
    {
        switch (char.ToLower(c))
        {
            #region vowels
            case 'a':
                svg.AddV(point);
                break;
            case 'ă':
                svg.AddV(point);
                svg.AddBottomBar(point);
                break;
            case 'â':
                svg.AddV(point);
                svg.AddTopBar(point);
                break;

            case 'e':
                svg.AddFork(point);
                break;

            case 'i':
                if (options.horizontalLines == false)
                    svg.AddHarden(point, false);
                break;
            case 'î':
                if (options.horizontalLines == false)
                    svg.AddHarden(point, false);
                svg.AddTopBar(point);
                break;

            case 'o':
                svg.AddDiamond(point);
                break;
            case 'u':
                svg.AddTopO(point);
                break;
            #endregion

            #region consonants
            case 'b':
                svg.AddTopLollipop(point);
                svg.AddBottomLollipop(point);
                break;
            case 'f':
                svg.AddTopLollipop(point);
                svg.AddHarden(point, options.horizontalLines);
                break;
            case 'p':
                svg.AddTopLollipop(point);
                break;
            case 'r':
                svg.AddTopLollipop(point);
                svg.AddAddition(point);
                break;
            case 'g':
                svg.AddBottomLollipop(point);
                break;

            case 'c':
                svg.AddDiamond(point);
                svg.AddSubstraction(point);
                break;
            case 'd':
                svg.AddDiamond(point);
                svg.AddHarden(point, options.horizontalLines);
                break;
            case 'q':
                svg.AddDiamond(point);
                svg.AddAddition(point);
                break;
            case 'h':
                svg.AddDiamond(point);
                svg.AddSubstraction(point,1);
                break;

            case 'j':
                svg.AddI(point);
                break;
            case 'l':
                svg.AddI(point);
                svg.AddHarden(point, options.horizontalLines);
                break;
            case 't':
                svg.AddDoubleI(point);
                break;
            case 'ț':
                svg.AddDoubleI(point);
                svg.AddBottomBar(point);
                break;

            case 'm':
                svg.AddDoubleSlash(point);
                break;
            case 'n':
                svg.AddDoubleSlash(point);
                svg.AddSubstraction(point);
                break;
            case 's':
                svg.AddSlash(point);
                break;
            case 'ș':
                svg.AddSlash(point);
                svg.AddBottomBar(point);
                break;
            case 'x':
                svg.AddSlash(point);
                svg.AddHarden(point, options.horizontalLines);
                svg.AddSubstraction(point,1);
                break;
            case 'y':
                svg.AddSlash(point);
                svg.AddHarden(point, options.horizontalLines);
                svg.AddSubstraction(point, 0);
                break;
            case 'z':
                svg.AddSlash(point);
                svg.AddHarden(point, options.horizontalLines);
                break;

            case 'v':
                svg.AddBottomO(point);
                break;
            case 'w':
                svg.AddTopO(point);
                svg.AddBottomO(point);
                break;
            case 'k':
                svg.AddBottomO(point);
                svg.AddI(point);
                break;
            #endregion

            #region numbers
            case '0':
                svg.AddDiamond(point);
                svg.AddAddition(point);
                svg.AddSubstraction(point);
                break;
            case '1':
                svg.AddSubstraction(point, 3);
                break;
            case '2':
                svg.AddSubstraction(point, 2);
                break;
            case '3':
                svg.AddSubstraction(point, 1);
                break;
            case '4':
                svg.AddSubstraction(point, 0);
                break;
            case '5':
                svg.AddAddition(point);
                svg.AddSubstraction(point);
                break;
            case '6':
                svg.AddAddition(point, 0);
                break;
            case '7':
                svg.AddAddition(point, 1);
                break;
            case '8':
                svg.AddAddition(point, 2);
                break;
            case '9':
                svg.AddAddition(point, 3);
                break;
            #endregion

            #region special
            case ' ':
                svg.AddS(point);
                break;

            case '+':
                svg.AddS(point);
                svg.AddAddition(point);
                break;
            case '-':
                svg.AddS(point);
                svg.AddSubstraction(point);
                break;
            case '*':
                svg.AddS(point);
                svg.AddAddition(point, 1);//todo: not happy with this one
                break;
            case '/':
                svg.AddS(point);
                svg.AddSubstraction(point,1)//todo: not happy with this one
                break;
            case '=':
                svg.AddS(point);
                svg.AddAddition(point);
                svg.AddSubstraction(point);
                break;

            #endregion

            default:
                throw new ArgumentNullException($"Invalid character '{c}' found.");
        }
    }
}
