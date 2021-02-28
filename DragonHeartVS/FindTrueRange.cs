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

    public static List<List<int>> FindTrueRange(int direction, List<List<int>> range )
    {

        List<List<int>> savedRange = new List<List<int>>();

        

            for (int i = 0; i <= range.Count - 1; i++)
            {
                savedRange.Add(new List<int>());
                for (int j = 0; j <= range[0].Count - 1; j++)
                {
                    savedRange[i].Add(0);
                }
            }
            if (direction == 1)
            {
                for (int i = 0; i <= range.Count - 1; i++)
                {
                    for (int j = 0; j <= range[0].Count - 1; j++)
                    {

                        savedRange[j][i] = range[j][i];

                    }
                }
            }
            else if (direction == 2)
            {
                for (int i = 0; i <=   range.Count - 1; i++)
                {
                    for (int j = 0; j <=   range[0].Count - 1; j++)
                    {

                        savedRange[j][(  range[0].Count - 1) - i] =   range[i][j];

                    }
                }
            }
            else if ( direction == 4)
            {
                for (int i = 0; i <=   range.Count - 1; i++)
                {
                    for (int j = 0; j <=   range[0].Count - 1; j++)
                    {

                        savedRange[(  range[0].Count - 1) - i][j] =   range[i][j];

                    }
                }
            }
            else if ( direction == 3)
            {
                for (int i = 0; i <=   range.Count - 1; i++)
                {
                    for (int j = 0; j <=   range[0].Count - 1; j++)
                    {

                        savedRange[j][i] =   range[i][j];

                    }
                }
            }






        



        return savedRange;
    }

    public static int IsInRange(List<List<int>> savedRange, int[] xyAttack, int[] xyDefend)
    {
        int playerX = 1;
        int playerY = 1;

        for (int y = 0; y < savedRange.Count; y++)
        {
            for (int x = 0; x < savedRange[y].Count; x++)
            {
                if (savedRange[y][x] == -1)
                {
                    playerX = x;
                    playerY = y;
                }

            }
        }

        for (int y = 0; y <= savedRange.Count - 1; y++)
        {
            for (int x = 0; x <= savedRange[y].Count - 1; x++)
            {

                
                    if (xyDefend[0] ==
                        xyAttack[0] + (x - playerX) &&
                        xyDefend[1] ==
                        xyAttack[1] + (y - playerY) && savedRange[y][x] == 1)
                    {
                        return 1;
                    }

                    if (xyDefend[0] ==
                        xyAttack[0] + (x - playerX) &&
                        xyDefend[1] ==
                        xyAttack[1] + (y - playerY) && savedRange[y][x] == 2)
                    {
                        return 2;
                    }
                

            }
        }

        return 0;
    }
}
