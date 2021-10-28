namespace StarGlyph.Generators;

internal static class Characters
{
    // point represents the top left corner of the character
    internal static void AddCharacter(this SvgFragment svg, char c, PointF point, StarGlyphOptions options)
    {
        SvgFragment fragment = new()
        {
            X = point.X,
            Y = point.Y
        };
        if (options.attributeAnnotations)
            fragment.CustomAttributes.Add("letter", c.ToString());

        switch (char.ToLower(c))
        {
            #region vowels
            case 'a':
                fragment.AddV();
                break;
            case 'ă':
                fragment.AddV();
                fragment.AddBottomBar();
                break;
            case 'â':
                fragment.AddV();
                fragment.AddTopBar();
                break;

            case 'e':
                fragment.AddFork();
                break;

            case 'i':
                if (options.horizontalLines == false)
                    fragment.AddHarden(false);
                break;
            case 'î':
                if (options.horizontalLines == false)
                    fragment.AddHarden(false);
                fragment.AddTopBar();
                break;

            case 'o':
                fragment.AddDiamond();
                break;
            case 'u':
                fragment.AddTopO();
                break;
            #endregion

            #region consonants
            case 'b':
                fragment.AddTopLollipop();
                fragment.AddBottomLollipop();
                break;
            case 'f':
                fragment.AddTopLollipop();
                fragment.AddHarden(options.horizontalLines);
                break;
            case 'p':
                fragment.AddTopLollipop();
                break;
            case 'r':
                fragment.AddTopLollipop();
                fragment.AddAddition();
                break;
            case 'g':
                fragment.AddBottomLollipop();
                break;

            case 'c':
                fragment.AddDiamond();
                fragment.AddSubstraction();
                break;
            case 'd':
                fragment.AddDiamond();
                fragment.AddHarden(options.horizontalLines);
                break;
            case 'q':
                fragment.AddDiamond();
                fragment.AddAddition();
                break;
            case 'h':
                fragment.AddDiamond();
                fragment.AddSubstraction( 1);
                break;

            case 'j':
                fragment.AddI();
                break;
            case 'l':
                fragment.AddI();
                fragment.AddHarden(options.horizontalLines);
                break;
            case 't':
                fragment.AddDoubleI();
                break;
            case 'ț':
                fragment.AddDoubleI();
                fragment.AddBottomBar();
                break;

            case 'm':
                fragment.AddDoubleSlash();
                break;
            case 'n':
                fragment.AddDoubleSlash();
                fragment.AddSubstraction();
                break;
            case 's':
                fragment.AddSlash();
                break;
            case 'ș':
                fragment.AddSlash();
                fragment.AddBottomBar();
                break;
            case 'x':
                fragment.AddSlash();
                fragment.AddHarden(options.horizontalLines);
                fragment.AddSubstraction( 1);
                break;
            case 'y':
                fragment.AddSlash();
                fragment.AddHarden(options.horizontalLines);
                fragment.AddSubstraction( 0);
                break;
            case 'z':
                fragment.AddSlash();
                fragment.AddHarden(options.horizontalLines);
                break;

            case 'v':
                fragment.AddBottomO();
                break;
            case 'w':
                fragment.AddTopO();
                fragment.AddBottomO();
                break;
            case 'k':
                fragment.AddBottomO();
                fragment.AddI();
                break;
            #endregion

            #region numbers
            case '0':
                fragment.AddDiamond();
                fragment.AddAddition();
                fragment.AddSubstraction();
                break;
            case '1':
                fragment.AddSubstraction( 3);
                break;
            case '2':
                fragment.AddSubstraction( 2);
                break;
            case '3':
                fragment.AddSubstraction( 1);
                break;
            case '4':
                fragment.AddSubstraction( 0);
                break;
            case '5':
                fragment.AddAddition();
                fragment.AddSubstraction();
                break;
            case '6':
                fragment.AddAddition( 0);
                break;
            case '7':
                fragment.AddAddition( 1);
                break;
            case '8':
                fragment.AddAddition( 2);
                break;
            case '9':
                fragment.AddAddition( 3);
                break;
            #endregion

            #region special
            case ' ':
                fragment.AddS();
                break;

            case '+':
                fragment.AddS();
                fragment.AddAddition();
                break;
            case '-':
                fragment.AddS();
                fragment.AddSubstraction();
                break;
            case '*':
                fragment.AddS();
                fragment.AddAddition( 1);//todo: not happy with this one
                break;
            case '/':
                fragment.AddS();
                fragment.AddSubstraction( 1);//todo: not happy with this one
                break;
            case '=':
                fragment.AddS();
                fragment.AddAddition();
                fragment.AddSubstraction();
                break;

            #endregion

            default:
                if (options.throwOnInvalidChars)
                    throw new ArgumentNullException($"Invalid character '{c}' found.");
                break;
        }

        svg.Children.Add(fragment);
        //Console.WriteLine($"{c}   {fragment.Bounds.Height}");
    }
}
