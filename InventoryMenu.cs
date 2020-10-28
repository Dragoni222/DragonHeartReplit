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
    public class InventoryMenuClass
    {
        public static Player InventoryMenu(Player Player1, string[] onScreenText, List<string[]>[] onScreenTextColor)
        {
            bool done = false;
            int selected = 1;

            while (done == false)
            {

                drawInventoryMenu(Player1, selected, onScreenText, onScreenTextColor);

                ConsoleKey input = KeyInput().Key;

                if (input == ConsoleKey.RightArrow && selected < Player1.itemInventory.Length)
                {
                    selected++;
                }
                if (input == ConsoleKey.LeftArrow && selected > 1)
                {
                    selected--;
                }
                if (input == ConsoleKey.UpArrow && selected > 5)
                {
                    selected -= 5;
                }
                if (input == ConsoleKey.RightArrow && selected + 4 < Player1.itemInventory.Length)
                {
                    selected += 5;
                }
                if (input == ConsoleKey.E)
                {
                    
                    bool leave = false;

                    

                    while (leave == false)
                    {
                        Console.Clear();
                        Console.WriteLine("(U)se, (D)iscard, or press esc to return to inventory");

                        Console.WriteLine(Player1.itemInventory[selected-1].name + ": " + Player1.itemInventory[selected-1].amount + "          ");
                        Console.WriteLine(Player1.itemInventory[selected-1].type + "  ");
                        input = KeyInput().Key;

                        if (input == ConsoleKey.U)
                        {
                            if (Player1.itemInventory[selected - 1].name == "Health Potion")
                            {
                                if (Player1.itemInventory[selected - 1].amount >= 1)
                                {
                                    Player1.hp += 25;
                                    Player1.itemInventory[selected - 1].amount--;
                                }
                                else
                                {
                                    Player1.itemInventory[selected - 1] = new Items(0, "empty", "empty");
                                    leave = true;
                                }
                            }

                            else if (Player1.itemInventory[selected - 1].name == "Mana Potion")
                            {
                                if (Player1.itemInventory[selected - 1].amount >= 1)
                                {
                                    Player1.mana += 25;
                                    Player1.itemInventory[selected - 1].amount--;
                                }
                                else
                                {
                                    Player1.itemInventory[selected - 1] = new Items(0, "empty", "empty");
                                    leave = true;
                                }

                            }
                            else if (Player1.itemInventory[selected - 1].name == "Roll")
                            {
                                if (Player1.itemInventory[selected - 1].amount >= 1)
                                {
                                    Player1.mana += 10;
                                    Player1.hp += 10;
                                    Player1.itemInventory[selected - 1].amount--;
                                }
                                else
                                {
                                    Player1.itemInventory[selected - 1] = new Items(0, "empty", "empty");
                                    leave = true;
                                }

                            }
                            else
                            {
                                Console.WriteLine("Uh, pretty sure using nothing is not your best option here. If this is an item, it's broken.");
                            }
                        }
                        else if (input == ConsoleKey.D)
                        {
                            Player1.itemInventory[selected - 1] = new Items(0, "empty", "empty");
                        }
                        else if (input == ConsoleKey.Escape)
                        {
                            leave = true;
                        }
                        
                    }

                }
                if(input == ConsoleKey.Escape)
                {
                    done = true;
                }

                
            }
            return Player1;
        }




        public static void drawInventoryMenu(Player Player1, int selected, string[] onScreenText, List<string[]>[] onScreenTextColor)
        {
            Console.Clear();
            Console.WriteLine("         Items:");

            for (int l = 0; l <= Player1.itemInventory.Length / 5; l++)
            {
                Console.WriteLine();
                for (int i = 0; i < 4; i++)
                {
                    if ((l * 5) + i + 1 <= Player1.itemInventory.Length)
                    {
                        if (i == selected - 1)
                            Console.BackgroundColor = ConsoleColor.DarkGreen;

                        Console.Write(Player1.itemInventory[i].name + ": " + Player1.itemInventory[i].amount + "          ");
                        Console.ResetColor();
                    }


                }
                Console.WriteLine();

                for (int k = 0; k < 4; k++)
                {
                    if ((l * 5) + k + 1 <= Player1.itemInventory.Length)
                    {
                        Console.Write(Player1.itemInventory[k].type + "  ");

                        for (int j = 1; j <= Player1.itemInventory[k].name.Length +
                            Player1.itemInventory[k].amount.ToString().Length - Player1.itemInventory[k].type.Length; j++)
                        {
                            Console.Write(" ");
                        }

                        Console.Write("          ");
                    }

                }
            }
            onScreenTextPrint(onScreenText, onScreenTextColor);
        }
    }
}
