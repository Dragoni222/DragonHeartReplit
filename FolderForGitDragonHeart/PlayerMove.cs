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

class PlayerMoveClass
{

public static int[] charMove(Player Player1, ConsoleKey input)
    {


        //Checks input and moves accordingly
        if (input == ConsoleKey.W)
        {
            Player1.charXY[1] -= 1;
        }
        else if (input == ConsoleKey.A)
        {
            Player1.charXY[0] -= 1;
        }
        else if (input == ConsoleKey.S)
        {
            Player1.charXY[1] += 1;
        }
        else if (input == ConsoleKey.D)
        {
            Player1.charXY[0] += 1;
        }
        else
        {
            Console.WriteLine("uh, you didn't input anything");
        }



        return Player1.charXY;
    }
    }