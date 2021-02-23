using System;
using System.Collections.Generic;
using static KeyInputClass;

namespace DragonHeartWithGit.DragonHeartReplit
{
    public class InventoryMenuClass
    {
        public static Player InventoryMenu(Player Player1, string[] onScreenText, List<string[]>[] onScreenTextColor)
        {
            bool done = false;
            bool doneWeapons = false;
            int selected = 1;
            int selectedWeapons = 1;

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
                if (input == ConsoleKey.DownArrow && selected + 4 < Player1.itemInventory.Length)
                {
                    selected += 5;
                }
                if (input == ConsoleKey.E)
                {
                    
                    bool leave = false;

                    

                    while (leave == false)
                    {
                        Console.Clear();
                        Console.WriteLine("(U)se, (D)iscard, or press esc to return to menu");

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
                if(input == ConsoleKey.W)
                {
                    doneWeapons = false;
                    while (doneWeapons == false)
                    {
                        drawWeaponMenu(Player1, selectedWeapons, onScreenText, onScreenTextColor);

                        ConsoleKey inputWeapons = KeyInput().Key;

                        if (inputWeapons == ConsoleKey.RightArrow && selectedWeapons < Player1.weaponInventory.Length)
                        {
                            selectedWeapons++;
                        }
                        if (inputWeapons == ConsoleKey.LeftArrow && selectedWeapons > 1)
                        {
                            selectedWeapons--;
                        }
                        if (inputWeapons == ConsoleKey.UpArrow && selectedWeapons > 5)
                        {
                            selectedWeapons -= 5;
                        }
                        if (inputWeapons == ConsoleKey.DownArrow && selectedWeapons + 4 < Player1.weaponInventory.Length)
                        {
                            selectedWeapons += 5;
                        }
                        if (inputWeapons == ConsoleKey.E)
                        {

                            bool leaveWeapons = false;



                            while (leaveWeapons == false)
                            {
                                Console.Clear();
                                if(Player1.weaponInventory[selectedWeapons - 1].equipped == false)
                                {
                                    Console.WriteLine("(E)quip, (D)iscard, or press esc to return to menu");

                                    if (inputWeapons == ConsoleKey.D)
                                    {
                                        if (Player1.weaponInventory[selectedWeapons - 1].equipped == false)
                                        {
                                            Player1.weaponInventory[selectedWeapons - 1] =
                                                new Weapon(10000, "bludge", "Fists",
                                                "1d2", new List<List<int>>() { new List<int>(){0,1,0 },
                                        new List<int>() { 0,-1,0 }, new List<int>() { 0,0,0} }, false);
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("You are currently " +
                                                "using this weapon, so you may not discard it. Enter to continue.");
                                            Console.ReadLine();
                                            Console.Clear();
                                        }
                                    }

                                    if (inputWeapons == ConsoleKey.E)
                                    {

                                        if (Player1.weaponInventory[selectedWeapons - 1].equipped == false)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Which hand do you want to equip this weapon in?(L or R)");
                                            inputWeapons = KeyInput().Key;
                                            Console.Clear();
                                            if (inputWeapons == ConsoleKey.L)
                                            {
                                                for (int weapon = 0; weapon < Player1.weaponInventory.Length; weapon++)
                                                {
                                                    if (Player1.weaponInventory[weapon].equipped == true &&
                                                        Player1.weaponInventory[weapon].name == Player1.equip1.name)
                                                    {
                                                        Player1.weaponInventory[weapon].equipped = false;
                                                    }
                                                }
                                                Player1.weaponInventory[selectedWeapons - 1].equipped = true;
                                                Player1.equip1 = Player1.weaponInventory[selectedWeapons - 1];

                                            }
                                            if (inputWeapons == ConsoleKey.R)
                                            {
                                                for (int weapon = 0; weapon < Player1.weaponInventory.Length; weapon++)
                                                {
                                                    if (Player1.weaponInventory[weapon].equipped == true &&
                                                        Player1.weaponInventory[weapon].name == Player1.equip2.name)
                                                    {
                                                        Player1.weaponInventory[weapon].equipped = false;
                                                    }
                                                }
                                                Player1.weaponInventory[selectedWeapons - 1].equipped = true;
                                                Player1.equip2 = Player1.weaponInventory[selectedWeapons - 1];
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("You are currently using " +
                                                "this weapon, so you may not equip it. Enter to continue.");
                                            Console.ReadLine();
                                            Console.Clear();
                                        }
                                    }
                                }
                                else if (Player1.weaponInventory[selectedWeapons - 1].name == "Fists")
                                {
                                    Console.WriteLine("These are your fists. You can't do much with them.");
                                }
                                else
                                {
                                    Console.WriteLine("(U)nequip, or press esc to return to menu");
                                    if (inputWeapons == ConsoleKey.U)
                                    {
                                        if (Player1.weaponInventory[selectedWeapons - 1].name == Player1.equip1.name)
                                        {
                                            Player1.equip1 = new Weapon(10000, "bludge", "Fists",
                                    "1d2 ", new List<List<int>>() { new List<int>(){0,1,0 },
                                    new List<int>() { 0,-1,0 }, new List<int>() { 0,0,0} }, true);
                                        }
                                        else if (Player1.weaponInventory[selectedWeapons - 1].name == Player1.equip2.name)
                                        {
                                            Player1.equip2 = new Weapon(10000, "bludge", "Fists",
                                    "1d2 ", new List<List<int>>() { new List<int>(){0,1,0 },
                                    new List<int>() { 0,-1,0 }, new List<int>() { 0,0,0} }, true);
                                        }

                                        Player1.weaponInventory[selectedWeapons - 1].equipped = false;
                                    }
                                }

                                Console.WriteLine(Player1.weaponInventory[selectedWeapons - 1].name + "          ");
                                Console.WriteLine(Player1.weaponInventory[selectedWeapons - 1].type + "  ");
                                inputWeapons = KeyInput().Key;



                                
                                
                                
                                if (inputWeapons == ConsoleKey.Escape)
                                {
                                    leaveWeapons = true;
                                }

                            }
                            
                        }
                        if (inputWeapons == ConsoleKey.Escape)
                        {
                            doneWeapons = true;
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
            Console.WriteLine("         Items:  \n (E) to choose item, (W) for Weapons");

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
        }


        
        public static void drawWeaponMenu(Player Player1, int selected, string[] onScreenText, List<string[]>[] onScreenTextColor)
        {
            Console.Clear();
            Console.WriteLine("         Weapons:");

            for (int l = 0; l <= Player1.weaponInventory.Length / 5; l++)
            {
                Console.WriteLine();
                
                for (int i = 0; i < 4; i++)
                {
                    if ((l * 5) + i + 1 <= Player1.weaponInventory.Length)
                    {
                        if (i == selected - 1)
                            Console.BackgroundColor = ConsoleColor.DarkGreen;

                        Console.Write(Player1.weaponInventory[i].name + "          ");
                        Console.ResetColor();
                    }


                }
                Console.WriteLine();

                for (int k = 0; k < 4; k++)
                {
                    if ((l * 5) + k + 1 <= Player1.weaponInventory.Length)
                    {
                        Console.Write(Player1.weaponInventory[k].type);

                        for (int j = 1; j <= Player1.weaponInventory[k].name.Length
                            - Player1.weaponInventory[k].type.Length; j++)
                        {
                            Console.Write(" ");
                        }

                        Console.Write("          ");
                    }

                }
            }
        }
        
    }
}
