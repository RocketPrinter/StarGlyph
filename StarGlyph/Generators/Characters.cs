namespace StarGlyph.Generators;

internal static class Characters
{
    internal static void AddCharacter(this SvgFragment svg, char c, PointF point, StarGlyphOptions options)
    {
        SvgFragment fragment = new();
        if (options.attributeAnnotations)
            fragment.CustomAttributes.Add("letter",c.ToString());

        switch (char.ToLower(c))
        {
            #region vowels
            case 'a':
                fragment.AddV(point);
                break;
            case 'ă':
                fragment.AddV(point);
                fragment.AddBottomBar(point);
                break;
            case 'â':
                fragment.AddV(point);
                fragment.AddTopBar(point);
                break;

            case 'e':
                fragment.AddFork(point);
                break;

            case 'i':
                if (options.horizontalLines == false)
                    fragment.AddHarden(false, point);
                break;
            case 'î':
                if (options.horizontalLines == false)
                    fragment.AddHarden(false, point);
                fragment.AddTopBar(point);
                break;

            case 'o':
                fragment.AddDiamond(point);
                break;
            case 'u':
                fragment.AddTopO(point);
                break;
            #endregion

            #region consonants
            case 'b':
                fragment.AddTopLollipop(point);
                fragment.AddBottomLollipop(point);
                break;
            case 'f':
                fragment.AddTopLollipop(point);
                fragment.AddHarden(options.horizontalLines, point);
                break;
            case 'p':
                fragment.AddTopLollipop(point);
                break;
            case 'r':
                fragment.AddTopLollipop(point);
                fragment.AddAddition(point);
                break;
            case 'g':
                fragment.AddBottomLollipop(point);
                break;

            case 'c':
                fragment.AddDiamond(point);
                fragment.AddSubstraction(point);
                break;
            case 'd':
                fragment.AddDiamond(point);
                fragment.AddHarden(options.horizontalLines, point);
                break;
            case 'q':
                fragment.AddDiamond(point);
                fragment.AddAddition(point);
                break;
            case 'h':
                fragment.AddDiamond(point);
                fragment.AddSubstraction(point, 1);
                break;

            case 'j':
                fragment.AddI(point);
                break;
            case 'l':
                fragment.AddI(point);
                fragment.AddHarden(options.horizontalLines, point);
                break;
            case 't':
                fragment.AddDoubleI(point);
                break;
            case 'ț':
                fragment.AddDoubleI(point);
                fragment.AddBottomBar(point);
                break;

            case 'm':
                fragment.AddDoubleSlash(point);
                break;
            case 'n':
                fragment.AddDoubleSlash(point);
                fragment.AddSubstraction(point);
                break;
            case 's':
                fragment.AddSlash(point);
                break;
            case 'ș':
                fragment.AddSlash(point);
                fragment.AddBottomBar(point);
                break;
            case 'x':
                fragment.AddSlash(point);
                fragment.AddHarden(options.horizontalLines, point);
                fragment.AddSubstraction(point, 1);
                break;
            case 'y':
                fragment.AddSlash(point);
                fragment.AddHarden(options.horizontalLines, point);
                fragment.AddSubstraction(point, 0);
                break;
            case 'z':
                fragment.AddSlash(point);
                fragment.AddHarden(options.horizontalLines, point);
                break;

            case 'v':
                fragment.AddBottomO(point);
                break;
            case 'w':
                fragment.AddTopO(point);
                fragment.AddBottomO(point);
                break;
            case 'k':
                fragment.AddBottomO(point);
                fragment.AddI(point);
                break;
            #endregion

            #region numbers
            case '0':
                fragment.AddDiamond(point);
                fragment.AddAddition(point);
                fragment.AddSubstraction(point);
                break;
            case '1':
                fragment.AddSubstraction(point, 3);
                break;
            case '2':
                fragment.AddSubstraction(point, 2);
                break;
            case '3':
                fragment.AddSubstraction(point, 1);
                break;
            case '4':
                fragment.AddSubstraction(point, 0);
                break;
            case '5':
                fragment.AddAddition(point);
                fragment.AddSubstraction(point);
                break;
            case '6':
                fragment.AddAddition(point, 0);
                break;
            case '7':
                fragment.AddAddition(point, 1);
                break;
            case '8':
                fragment.AddAddition(point, 2);
                break;
            case '9':
                fragment.AddAddition(point, 3);
                break;
            #endregion

            #region special
            case ' ':
                fragment.AddS(point);
                break;

            case '+':
                fragment.AddS(point);
                fragment.AddAddition(point);
                break;
            case '-':
                fragment.AddS(point);
                fragment.AddSubstraction(point);
                break;
            case '*':
                fragment.AddS(point);
                fragment.AddAddition(point, 1);//todo: not happy with this one
                break;
            case '/':
                fragment.AddS(point);
                fragment.AddSubstraction(point, 1);//todo: not happy with this one
                break;
            case '=':
                fragment.AddS(point);
                fragment.AddAddition(point);
                fragment.AddSubstraction(point);
                break;

            #endregion

            default:
                throw new ArgumentNullException($"Invalid character '{c}' found.");
        }

        svg.Children.Add(fragment);
        //Console.WriteLine($"{c}   {fragment.Bounds.Height}");
    }
}
