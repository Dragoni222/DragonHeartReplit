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

class ChangeMapClass
{

    public static List<List<string>> mapAugment(List<List<string>> fullMap, int x, int y, string change)
    {
        List<List<string>> newFullMap = new List<List<string>>();

        //map instantiator adds characters so the map doesn't run out of room)
        for (int m = 0; m < 100; m++)
        {
            newFullMap.Add(new List<string>());

            for (int i = 0; i < 100; i++)
            {
                newFullMap[m].Add("#");

            }

        }

        int j = 0;

        //writing to newFullMap (yes this is nessisary it breaks otherwise)
        for (int i = 0;
        (i + 1) * (j + 1) <= fullMap.Count * fullMap[0].Count; i++)
        {

            //checks if page wrap
            if (i + 1 != fullMap[0].Count)
            {
                //checks if is outside or array range
                if (j + 1 <= fullMap.Count)
                {

                    if (i < fullMap[j].Count)
                    {
                        newFullMap[j][i] = fullMap[j][i];

                    }

                }
            }
            else
            {
                //resets and goes to next line
                j++;
                i = 0;

                //Make sure J doesn't go out of bounds
                if (j + 1 <= fullMap.Count)
                {

                    if (i < fullMap[j].Count)
                    {
                        newFullMap[j][i] = fullMap[j][i];
                    }

                }
            }

        }

        newFullMap[y][x] = change;

        return newFullMap;
    }

    public static List<List<ConsoleColor>> mapAugmentColor(List<List<ConsoleColor>> fullMapColor, int x, int y, ConsoleColor change)
    {
        List<List<ConsoleColor>> newFullMapColor = new List<List<ConsoleColor>>();

        //map instantiator adds characters so the map doesn't run out of room)
        for (int m = 0; m < 100; m++)
        {
            newFullMapColor.Add(new List<ConsoleColor>());

            for (int i = 0; i < 100; i++)
            {
                newFullMapColor[m].Add(ConsoleColor.Yellow);

            }

        }

        int j = 0;

        //writing to newFullMap (yes this is nessisary it breaks otherwise)
        for (int i = 0;
        (i + 1) * (j + 1) <= fullMapColor.Count * fullMapColor[0].Count; i++)
        {

            //checks if page wrap
            if (i + 1 != fullMapColor[0].Count)
            {
                //checks if is outside or array range
                if (j + 1 <= fullMapColor.Count)
                {

                    if (i < fullMapColor[j].Count)
                    {
                        newFullMapColor[j][i] = fullMapColor[j][i];

                    }

                }
            }
            else
            {
                //resets and goes to next line
                j++;
                i = 0;

                //Make sure J doesn't go out of bounds
                if (j + 1 <= fullMapColor.Count)
                {

                    if (i < fullMapColor[j].Count)
                    {
                        newFullMapColor[j][i] = fullMapColor[j][i];
                    }

                }
            }

        }

        newFullMapColor[y][x] = change;

        return newFullMapColor;
    }

}