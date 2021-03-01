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
using DragonHeartWithGit.DragonHeartReplit;
using System.Text;
using System.Threading;
class PlayerMoveClass
{

    public static int[] charMove(Player Player1, ConsoleKey input, List<List<string>> fullMap, bool ghost, Keybinds keybind)
    {


        //Checks input and moves accordingly
        if (input == keybind.up)
        {
            if (Player1.charXY[1] >= 1)
            {
                if (fullMap[Player1.charXY[1] - 1][Player1.charXY[0]] != "0" || ghost == true)
                    Player1.charXY[1] -= 1;
            }
        }
        else if (input == keybind.left)
        {
            if (Player1.charXY[0] >= 1)
            {
                if (fullMap[Player1.charXY[1]][Player1.charXY[0] - 1] != "0" || ghost == true)
                    Player1.charXY[0] -= 1;
            }
        }
        else if (input == keybind.down)
        {
            if (Player1.charXY[1] < fullMap.Count-1)
            {
                if (fullMap[Player1.charXY[1] + 1][Player1.charXY[0]] != "0" || ghost == true)
                    Player1.charXY[1] += 1;
            }
        }
        else if (input == keybind.right)
        {
            if (Player1.charXY[0] < fullMap[0].Count-1)
            {
                if (fullMap[Player1.charXY[1]][Player1.charXY[0] + 1] != "0" || ghost == true)
                    Player1.charXY[0] += 1;
            }
        }

        


        return Player1.charXY;
    }

    public static int[] entMove(Entities Player1, List<List<string>> fullMap, bool ghost, int direction)
    {



        if (Player1.entityXY[1] >= 1 && direction == 1)
        {
            if (fullMap[Player1.entityXY[1] - 1][Player1.entityXY[0]] != "0" || ghost == true)
                Player1.entityXY[1] -= 1;
        }


        if (Player1.entityXY[0] >= 1 && direction == 4)
        {
            if (fullMap[Player1.entityXY[1]][Player1.entityXY[0] - 1] != "0" || ghost == true)
                Player1.entityXY[0] -= 1;
        }


        if (Player1.entityXY[1] < fullMap.Count - 1 && direction == 3)
        {
            if (fullMap[Player1.entityXY[1] + 1][Player1.entityXY[0]] != "0" || ghost == true)
                Player1.entityXY[1] += 1;
        }


        if (Player1.entityXY[0] < fullMap[0].Count - 1 && direction == 2)
        {
            if (fullMap[Player1.entityXY[1]][Player1.entityXY[0] + 1] != "0" || ghost == true)
                Player1.entityXY[0] += 1;
        }





        return Player1.entityXY;


    }
}


