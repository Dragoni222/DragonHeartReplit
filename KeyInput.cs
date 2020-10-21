using System;
using System.Collections.Generic;
using static Player;
using static PlayClass;
using static ChangeMapClass;
using static ChangeNameClass;
using static ColorConverterClass;
using static DrawFrameClass;
using static KeyInputClass;
using static OnScreenTextAugmentClass;
using static PlayerMoveClass;
using static ReadMapInputClass;
using System.Text;

class KeyInputClass
{

public static ConsoleKeyInfo KeyInput()
    {

        ConsoleKeyInfo input = new ConsoleKeyInfo();

        int i = 0;

        while (Console.KeyAvailable == false && i < 1000)
        {
            i++;
        }


        input = Console.ReadKey(true);


        return input;





    }

    }