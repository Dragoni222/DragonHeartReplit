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
using System.Text;
using DragonHeartWithGit.DragonHeartReplit;


namespace DragonHeartWithGit.DragonHeartReplit
{
    public class SwingWeaponClass
    {
        public static Player SwingWeapon1(Player Player1, int weapon)
        {
            //makes sure any cost to the player is applied
            
            if (weapon == 1)
            {
                if (Player1.equip1.name == "Excalibur")
                {

                }
                else
                {
                    Player1.equip1.durability --;
                }

                if(Player1.equip1.durability == 0)
                {
                    
                }

            }

            if (weapon == 2)
            {
                if (Player1.equip2.name == "Excalibur")
                {

                }
                else
                {
                    Player1.equip2.durability--;
                }

            }

            

            return Player1;
        }

        public static List<List<string>> SwingWeapon2(Player Player1,
            int weapon, List<List<string>> fullMap)
        {
            //applies map changes for the crazyer weapons
            return fullMap;
        }

        public static List<List<System.ConsoleColor>> SwingWeapon3(Player Player1,
            int weapon, List<List<System.ConsoleColor>> fullMapColor)
        {
            //applies the color on the map with crazier changes, along with the range indicator.
            int playerX = 1;
            int playerY = 1;

            

            if (weapon == 1)
            {
                List<List<int>> savedRange = new List<List<int>>();
                for(int i = 0; i <= Player1.equip1.range.Count - 1; i++)
                {
                    savedRange.Add(new List<int>());
                    for (int j = 0; j <= Player1.equip1.range[0].Count - 1; j++)
                    {
                        savedRange[i].Add(0);
                    }
                }
                if (Player1.direction == 1)
                {

                }
                else if (Player1.direction == 2)
                {
                    for (int i = 0; i <= Player1.equip1.range.Count-1; i++)
                    {
                        for (int j = 0; j <= Player1.equip1.range[0].Count-1; j++)
                        {
                            if (Player1.equip1.range[i][j] == 0)
                            {

                            }
                            else
                            {
                                savedRange[j][(Player1.equip1.range[0].Count)-i] = Player1.equip1.range[i][j];
                            }
                        }
                    }
                }
                else if (Player1.direction == 3)
                {
                    for (int i = 0; i <= Player1.equip1.range.Count - 1; i++)
                    {
                        for (int j = 0; j <= Player1.equip1.range[0].Count - 1; j++)
                        {
                            if (Player1.equip1.range[i][j] == 0)
                            {

                            }
                            else
                            {
                                savedRange[(Player1.equip1.range[0].Count)- i][j] = Player1.equip1.range[i][j];
                            }
                        }
                    }
                }
                else if (Player1.direction == 4)
                {
                    for (int i = 0; i <= Player1.equip1.range.Count - 1; i++)
                    {
                        for (int j = 0; j <= Player1.equip1.range[0].Count - 1; j++)
                        {
                            if (Player1.equip1.range[i][j] == 0)
                            {

                            }
                            else
                            {
                                savedRange[j][i] = Player1.equip1.range[i][j];
                            }
                        }
                    }
                }

                Player1.equip1.range = savedRange;
                for (int y = 0; y < Player1.equip1.range.Count; y++)
                {
                    for (int x = 0; x < Player1.equip1.range[y].Count; x++)
                    {
                        if (Player1.equip1.range[y][x] == -1)
                        {
                            playerX = x;
                            playerY = y;
                        }

                    }
                }
                for (int y = 0; y < Player1.equip1.range.Count; y++)
                {
                    for (int x = 0; x < Player1.equip1.range[y].Count; x++)
                    {
                        if (Player1.equip1.range[y][x] == 1)
                        {
                            fullMapColor = mapAugmentColor(fullMapColor,
                                Player1.charXY[0] + (x - playerX),
                                Player1.charXY[1] + (y - playerY), ConsoleColor.Green);
                        }
                        else if (Player1.equip1.range[y][x] == 2)
                        {
                            fullMapColor = mapAugmentColor(fullMapColor,
                                Player1.charXY[0] + (x - playerX),
                                Player1.charXY[1] + (y - playerY), ConsoleColor.DarkGreen);
                        }

                    }
                }

            }

            if (weapon == 2)
            {
                List<List<int>> savedRange = new List<List<int>>();
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

                }
                else if (Player1.direction == 2)
                {
                    for (int i = 0; i <= Player1.equip2.range.Count - 1; i++)
                    {
                        for (int j = 0; j <= Player1.equip2.range[0].Count - 1; j++)
                        {
                            if (Player1.equip2.range[i][j] == 0)
                            {

                            }
                            else
                            {
                                savedRange[j][(Player1.equip2.range[0].Count) - i] = Player1.equip2.range[i][j];
                            }
                        }
                    }
                }
                else if (Player1.direction == 3)
                {
                    for (int i = 0; i <= Player1.equip2.range.Count - 1; i++)
                    {
                        for (int j = 0; j <= Player1.equip2.range[0].Count - 1; j++)
                        {
                            if (Player1.equip2.range[i][j] == 0)
                            {

                            }
                            else
                            {
                                savedRange[(Player1.equip2.range[0].Count) - i][j] = Player1.equip2.range[i][j];
                            }
                        }
                    }
                }
                else if (Player1.direction == 4)
                {
                    for (int i = 0; i <= Player1.equip2.range.Count - 1; i++)
                    {
                        for (int j = 0; j <= Player1.equip2.range[0].Count - 1; j++)
                        {
                            if (Player1.equip2.range[i][j] == 0)
                            {

                            }
                            else
                            {
                                savedRange[j][i] = Player1.equip2.range[i][j];
                            }
                        }
                    }
                }

                Player1.equip2.range = savedRange;
                for (int y = 0; y < Player1.equip2.range.Count; y++)
                {
                    for (int x = 0; x < Player1.equip2.range[y].Count; x++)
                    {
                        if (Player1.equip2.range[y][x] == -1)
                        {
                            playerX = x;
                            playerY = y;
                        }

                    }
                }


                for (int y = 0; y < Player1.equip2.range.Count; y++)
                {
                    for (int x = 0; x < Player1.equip2.range[y].Count; x++)
                    {
                        if (Player1.equip2.range[y][x] == -1)
                        {
                            playerX = x;
                            playerY = y;
                        }

                    }
                }
                for (int y = 0; y < Player1.equip2.range.Count; y++)
                {
                    for (int x = 0; x < Player1.equip2.range[y].Count; x++)
                    {
                        if (Player1.equip2.range[y][x] == 1)
                        {
                            fullMapColor = mapAugmentColor(fullMapColor,
                                Player1.charXY[0] + (x - playerX),
                                Player1.charXY[1] + (y - playerY), ConsoleColor.Green);
                        }
                        else if (Player1.equip2.range[y][x] == 2)
                        {
                            fullMapColor = mapAugmentColor(fullMapColor,
                                Player1.charXY[0] + (x - playerX),
                                Player1.charXY[1] + (y - playerY), ConsoleColor.DarkGreen);
                        }

                    }
                }

            }



            return fullMapColor;
        }


    }
}
