using System.Drawing;
using System.Text;

namespace StarGlyph.Generators;

internal static class Characters
{
    internal static void AddCharacter(this StringBuilder sb, char c, PointF point, StarGlyphOptions options)
    {
        switch (char.ToLower(c))
        {
            #region vowels
            case 'a':
                sb.AddV(point);
                break;
            case 'ă':
                sb.AddV(point);
                sb.AddBottomBar(point);
                break;
            case 'â':
                sb.AddV(point);
                sb.AddTopBar(point);
                break;

            case 'e':
                sb.AddFork(point);
                break;

            case 'i':
                sb.AddHarden(point, false);
                break;
            case 'î':
                sb.AddHarden(point, false);
                sb.AddTopBar(point);
                break;

            case 'o':
                sb.AddDiamond(point);
                break;
            case 'u':
                sb.AddTopO(point);
                break;
            #endregion

            #region consonants

            #endregion

            #region numbers
            case '0':
                sb.AddDiamond(point);
                sb.AddAddition(point);
                sb.AddSubstraction(point);
                break;
            case '1':
                sb.AddSubstraction(point, 3);
                break;
            case '2':
                sb.AddSubstraction(point, 2);
                break;
            case '3':
                sb.AddSubstraction(point, 1);
                break;
            case '4':
                sb.AddSubstraction(point, 0);
                break;
            case '5':
                sb.AddAddition(point);
                sb.AddSubstraction(point);
                break;
            case '6':
                sb.AddAddition(point, 0);
                break;
            case '7':
                sb.AddAddition(point, 1);
                break;
            case '8':
                sb.AddAddition(point, 2);
                break;
            case '9':
                sb.AddAddition(point, 3);
                break;
            #endregion

            #region special
            case ' ':
                sb.AddS(point);
                break;

            case '+':
                sb.AddS(point);
                sb.AddAddition(point);
                break;
            case '-':
                sb.AddS(point);
                sb.AddSubstraction(point);
                break;
            case '*':
                sb.AddS(point);
                sb.AddAddition(point, 1);//todo: not happy with this one
                break;
            case '/':
                sb.AddS(point);
                sb.AddSubstraction(point,1)//todo: not happy with this one
                break;
            case '=':
                sb.AddS(point);
                sb.AddAddition(point);
                sb.AddSubstraction(point);
                break;

            #endregion

            default:
                throw new ArgumentNullException($"Invalid character '{c}' found.");
        }
    }
}
