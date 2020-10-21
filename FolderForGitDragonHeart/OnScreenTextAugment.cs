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

class OnScreenTextAugmentClass
{

public static string[] onScreenTextAugment(string[] original,
    string added, int priority)
{

    /*
      *Order of priority:
      *1  Hp/mana/stats/name
      *2  Keybinds
      *3  Keybinds 2
      *4  Equipment
      *5  Equipemnt stats 1
      *6  Equipment stats 2
      *7  Overall area description
      *8  Specific area description
      *9  Combat/movement log
      *10 Combat/movement log 2
      *11  Combat/movement log 3
      *12  Combat/movement log 4
      *13  Combat/movement log 5
      *14  Debug
    */
    if (priority <= 8)
    {
        original[priority - 1] = added;
    }
    else if (priority >= 9 && priority <= 13)
    {
        for (int i = 0; i <= 3; i++)
        {
            original[i + 8] = original[i + 9];


        }
        original[12] = added;
    }
    else if (priority == 14)
    {
        original[13] = "debug: " + added;
    }
    return original;

}

public static List<string[]>[] onScreenTextColorAugment(List<string[]>[] original,
    string added, int priority, int start, int end, int[] colorChangeID)
{

    /*
      *Order of priority:
      *1  Hp/mana/stats/name
      *2  Keybinds
      *3  Keybinds 2
      *4  Equipment
      *5  Equipemnt stats 1
      *6  Equipment stats 2
      *7  Overall area description
      *8  Specific area description
      *9  Combat/movement log
      *10 Combat/movement log 2
      *11  Combat/movement log 3
      *12  Combat/movement log 4
      *13  Combat/movement log 5
      *14  Debug
      *
      *onScreenTextColor:
      *
      *start
      *end
      *color 
    */
    //original [array1 aka priority].Add([array2 aka changes description]) = added;


    original[priority - 1][colorChangeID[priority - 1]][0] = start.ToString();
    original[priority - 1][colorChangeID[priority - 1]][1] = end.ToString();
    original[priority - 1][colorChangeID[priority - 1]][2] = added;
    return original;

}



public static List<string[]>[] colorChangeIDReset1(List<string[]>[] colorList)
{
    for (int j = 0; j < 14; j++)
    {
        colorList[j] = new List<string[]>();

        for (int i = 0; i < 100; i++)
        {
            colorList[j].Add(new string[] { "", "", "" });

            for (int k = 0; k <= 2; k++)
                colorList[j][i][k] = "none";





        }

    }
    return colorList;
}

public static int[] colorChangeIDReset2(int[] colorID)
{
    for (int i = 0; i <= colorID.Length - 1; i++)
    {
        colorID[i] = 0;
    }
    return colorID;
}

}