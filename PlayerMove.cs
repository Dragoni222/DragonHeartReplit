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

public static int[] charMove(Player Player1, ConsoleKey input, List<List<string>> fullMap, bool ghost)
    {


        //Checks input and moves accordingly
        if (input == ConsoleKey.W)
        {
            if (Player1.charXY[1] >= 1)
            {
                if (fullMap[Player1.charXY[0]][Player1.charXY[1] - 1] != "0" || ghost == true)
                    Player1.charXY[1] -= 1;
            }
        }
        else if (input == ConsoleKey.A)
        {
            if (Player1.charXY[0] >= 1)
            {
                if (fullMap[Player1.charXY[0] - 1][Player1.charXY[1]] != "0" || ghost == true)
                    Player1.charXY[0] -= 1;
            }
        }
        else if (input == ConsoleKey.S)
        {
            if (Player1.charXY[1] < fullMap.Count-1)
            {
                if (fullMap[Player1.charXY[0]][Player1.charXY[1] + 1] != "0" || ghost == true)
                    Player1.charXY[1] += 1;
            }
        }
        else if (input == ConsoleKey.D)
        {
            if (Player1.charXY[0] < fullMap[0].Count-1)
            {
                if (fullMap[Player1.charXY[0] + 1][Player1.charXY[1]] != "0" || ghost == true)
                    Player1.charXY[0] += 1;
            }
        }
        



        return Player1.charXY;
    }
    }