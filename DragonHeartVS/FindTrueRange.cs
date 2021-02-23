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
using static DragonHeartWithGit.DragonHeartReplit.ChangeKeybindsClass;
using static DragonHeartWithGit.DragonHeartReplit.InventoryMenuClass;
using static DragonHeartWithGit.DragonHeartReplit.SwingWeaponClass;
using System.Text;
using DragonHeartWithGit.DragonHeartReplit;
public class FindRangeStats
{

    public static List<List<int>> FindTrueRange(Player Player1, int weapon)
    {

        List<List<int>> savedRange = new List<List<int>>();

        if (weapon == 1)
        {

            for (int i = 0; i <= Player1.equip1.range.Count - 1; i++)
            {
                savedRange.Add(new List<int>());
                for (int j = 0; j <= Player1.equip1.range[0].Count - 1; j++)
                {
                    savedRange[i].Add(0);
                }
            }
            if (Player1.direction == 1)
            {
                for (int i = 0; i <= Player1.equip1.range.Count - 1; i++)
                {
                    for (int j = 0; j <= Player1.equip1.range[0].Count - 1; j++)
                    {

                        savedRange[j][i] = Player1.equip1.range[j][i];

                    }
                }
            }
            else if (Player1.direction == 2)
            {
                for (int i = 0; i <= Player1.equip1.range.Count - 1; i++)
                {
                    for (int j = 0; j <= Player1.equip1.range[0].Count - 1; j++)
                    {

                        savedRange[j][(Player1.equip1.range[0].Count - 1) - i] = Player1.equip1.range[i][j];

                    }
                }
            }
            else if (Player1.direction == 4)
            {
                for (int i = 0; i <= Player1.equip1.range.Count - 1; i++)
                {
                    for (int j = 0; j <= Player1.equip1.range[0].Count - 1; j++)
                    {

                        savedRange[(Player1.equip1.range[0].Count - 1) - i][j] = Player1.equip1.range[i][j];

                    }
                }
            }
            else if (Player1.direction == 3)
            {
                for (int i = 0; i <= Player1.equip1.range.Count - 1; i++)
                {
                    for (int j = 0; j <= Player1.equip1.range[0].Count - 1; j++)
                    {

                        savedRange[j][i] = Player1.equip1.range[i][j];

                    }
                }
            }






        }

        if (weapon == 2)
        {

            for (int i = 0; i <= Player1.equip2.range.Count - 1; i++)
            {
                savedRange.Add(new List<int>());
                for (int j = 0; j <= Player1.equip2.range[0].Count - 1; j++)
                {
                    savedRange[i].Add(0);
                }
            }
            if (Player1.direction == 1)
            {
                for (int i = 0; i <= Player1.equip2.range.Count - 1; i++)
                {
                    for (int j = 0; j <= Player1.equip2.range[0].Count - 1; j++)
                    {

                        savedRange[j][i] = Player1.equip2.range[j][i];

                    }
                }
            }
            else if (Player1.direction == 2)
            {
                for (int i = 0; i <= Player1.equip2.range.Count - 1; i++)
                {
                    for (int j = 0; j <= Player1.equip2.range[0].Count - 1; j++)
                    {

                        savedRange[j][(Player1.equip2.range[0].Count - 1) - i] = Player1.equip2.range[i][j];

                    }
                }
            }
            else if (Player1.direction == 4)
            {
                for (int i = 0; i <= Player1.equip2.range.Count - 1; i++)
                {
                    for (int j = 0; j <= Player1.equip2.range[0].Count - 1; j++)
                    {

                        savedRange[(Player1.equip2.range[0].Count - 1) - i][j] = Player1.equip2.range[i][j];

                    }
                }
            }
            else if (Player1.direction == 3)
            {
                for (int i = 0; i <= Player1.equip2.range.Count - 1; i++)
                {
                    for (int j = 0; j <= Player1.equip2.range[0].Count - 1; j++)
                    {

                        savedRange[j][i] = Player1.equip2.range[i][j];

                    }
                }
            }
            
        }

        return savedRange;
    }
}
