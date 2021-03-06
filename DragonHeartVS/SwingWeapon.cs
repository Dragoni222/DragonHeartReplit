using System;
using System.Collections.Generic;
using static ChangeMapClass;
using static RandomFunctions;
using static FindRangeStats;
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
                if (Player1.name == "Excalibur")
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

        public static List<List<string>> SwingWeapon2(Hitbox Player1,
            List<List<string>> fullMap, List<List<ConsoleColor>> trueRange)
        {
            var rand = new Random();
            int playerX = 1;
            int playerY = 1;

            List<List<int>> savedRange = FindTrueRange(Player1.direction, Player1.range);


            
            


            for (int y = 0; y < Player1.range.Count; y++)
            {
                for (int x = 0; x < Player1.range[y].Count; x++)
                {
                    if (Player1.range[y][x] == -1)
                    {
                        playerX = x;
                        playerY = y;
                    }

                }
            }

            for (int y = 0; y <= Player1.range.Count - 1; y++)
            {
                for (int x = 0; x <= Player1.range[y].Count - 1; x++)
                {
                    if(fullMap[Player1.hitboxXY[0] + (x - playerX)]
                        [Player1.hitboxXY[1] + (y - playerY)] == "0")
                    {
                        if (savedRange[y][x] == 1)
                        {
                            if(DamageRandom(Player1.damage, 1, 0) >= 5)
                            fullMap = mapAugment(fullMap,
                                Player1.hitboxXY[0] + (x - playerX),
                                Player1.hitboxXY[1] + (y - playerY), " ");
                        }
                        else if (savedRange[y][x] == 2)
                        {
                            if (DamageRandom(Player1.damage, 2, 0) >= 5)
                                fullMap = mapAugment(fullMap,
                                    Player1.hitboxXY[0] + (x - playerX),
                                    Player1.hitboxXY[1] + (y - playerY), " ");
                        }
                    }
                        

                }
            }

            






            

            

            


            return fullMap;
        }

        public static List<List<System.ConsoleColor>> SwingWeapon3(Hitbox Player1,
            List<List<System.ConsoleColor>> fullMapHighColor)
        {
            //applies the color on the map with crazier changes, along with the range indicator.
            List<List<int>> savedRange = new List<List<int>>();
            
            savedRange = FindTrueRange(Player1.direction, Player1.range);
            
            int playerX = 1;
            int playerY = 1;

            

            for (int y = 0; y < Player1.range.Count; y++)
            {
                for (int x = 0; x < Player1.range[y].Count; x++)
                {
                    if (Player1.range[y][x] == -1)
                    {
                        playerX = x;
                        playerY = y;
                    }

                }
            }

            for (int y = 0; y <= Player1.range.Count - 1; y++)
            {
                for (int x = 0; x <= Player1.range[y].Count - 1; x++)
                {
                    if(Player1.isPlayerHitbox == true)
                    {
                        if (savedRange[y][x] == 1)
                        {
                            fullMapHighColor = mapAugmentColor(fullMapHighColor,
                                Player1.hitboxXY[0] + (x - playerX),
                                Player1.hitboxXY[1] + (y - playerY), ConsoleColor.Green);
                        }
                        else if (savedRange[y][x] == 2)
                        {
                            fullMapHighColor = mapAugmentColor(fullMapHighColor,
                                Player1.hitboxXY[0] + (x - playerX),
                                Player1.hitboxXY[1] + (y - playerY), ConsoleColor.DarkGreen);
                        }
                    }
                    else
                    {
                        if (savedRange[y][x] == 1)
                        {
                            fullMapHighColor = mapAugmentColor(fullMapHighColor,
                                Player1.hitboxXY[0] + (x - playerX),
                                Player1.hitboxXY[1] + (y - playerY), ConsoleColor.Red);
                        }
                        else if (savedRange[y][x] == 2)
                        {
                            fullMapHighColor = mapAugmentColor(fullMapHighColor,
                                Player1.hitboxXY[0] + (x - playerX),
                                Player1.hitboxXY[1] + (y - playerY), ConsoleColor.DarkRed);
                        }
                    }
                    

                }
            }

            


            return fullMapHighColor;
        }



        public static Entities SwingEntityWeapon1(Entities Player1, int weapon)
        {
            //makes sure any cost to the player is applied

            if (weapon == 1)
            {
                if (Player1.equip1.name == "Excalibur")
                {

                }
                else
                {
                    Player1.equip1.durability--;
                }

                if (Player1.equip1.durability == 0)
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

        


    }
}
