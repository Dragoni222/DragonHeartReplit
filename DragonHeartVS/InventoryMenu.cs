using System;
using System.Collections.Generic;
using static KeyInputClass;
using System.Threading;
namespace DragonHeartWithGit.DragonHeartReplit
{
    public class InventoryMenuClass
    {
        public static Player InventoryMenu(Player Player1, string[] onScreenText, List<string[]>[] onScreenTextColor, Entities otherEntity)
        {
            bool done = false;
            bool doneWeapons = false;
            bool doneOther = false;
            bool doneOtherWeapons = false;

            int selected = 1;
            int selectedSaved = 0;
            int selectedSavedTwo = 0;

            int selectedWeapons = 1;
            int selectedOther = 0;
            int selectedOtherWeapons = 1;

            while (done == false)
            {

                drawInventoryMenu(Player1, selected, onScreenText, onScreenTextColor, otherEntity,selectedOther,selectedSaved);

                ConsoleKey input = KeyInput().Key;
                if (selected <= Player1.itemInventory.Length && selected != 0)
                {
                    if (input == ConsoleKey.RightArrow )
                    {
                        selected++;
                        if(selected <= Player1.itemInventory.Length)
                        {
                            while (Player1.itemInventory[selected - 1].name == "empty")
                            {
                                selected++;
                            }
                        }
                        if(selected == Player1.itemInventory.Length&& Player1.itemInventory[selected - 1].name == "empty")
                        {
                            selected++;
                        }
                        
                    }
                    if (input == ConsoleKey.LeftArrow && selected > 1)
                    {
                        selected--;
                        selectedSavedTwo = selected + 1;
                        if (selected <= Player1.itemInventory.Length)
                        {
                            while (Player1.itemInventory[selected - 1].name == "empty" && selected - 1 != 0)
                            {
                                selected--;
                            }
                            if (Player1.itemInventory[selected - 1].name == "empty")
                            {
                                selected = selectedSavedTwo;
                            }
                        }
                        selectedSaved = 0;
                            
                    }
                    if (input == ConsoleKey.UpArrow && selected > 5)
                    {
                        selected -= 5;
                    }
                    if (input == ConsoleKey.DownArrow && selected + 4 < Player1.itemInventory.Length)
                    {
                        selected += 5;
                    }
                }
                if (selected > Player1.itemInventory.Length || selected == 0)
                {
                    if (selected != 0)
                    {
                        selectedSaved = selected - 1;
                        selected = 0;
                    }
                    
                    if (input == ConsoleKey.RightArrow && selectedOther < otherEntity.itemInventory.Length)
                    {
                        selectedOther++;
                        selectedSavedTwo = selectedOther - 1;
                        if (selected > Player1.itemInventory.Length)
                        {
                            while (otherEntity.itemInventory[selectedOther - 1].name == "empty" && selectedOther + 1 != otherEntity.itemInventory.Length)
                            {
                                selectedOther--;
                            }
                            if (otherEntity.itemInventory[selectedOther - 1].name == "empty")
                            {
                                selectedOther = selectedSavedTwo;
                            }
                            selectedSavedTwo = 0;
                        }
                    }
                    if (input == ConsoleKey.LeftArrow && selectedOther > 1)
                    {
                        selectedOther--;
                        if(selected >= 1)
                        {
                            while (otherEntity.itemInventory[selectedOther - 1].name == "empty")
                            {
                                selectedOther--;
                            }
                        }
                            
                        if(selectedOther == 1 && otherEntity.itemInventory[selectedOther - 1].name == "empty")
                        {
                            selectedOther--;
                        }
                        
                    }
                    else if(input == ConsoleKey.LeftArrow && selectedOther == 1)
                    {
                        selectedOther = 0;
                        selected = selectedSaved;
                    }
                    if (input == ConsoleKey.UpArrow && selectedOther > 5)
                    {
                        selectedOther -= 5;
                    }
                    if (input == ConsoleKey.DownArrow && selected + 4 < otherEntity.itemInventory.Length)
                    {
                        selectedOther += 5;
                    }

                }
               
                
                if (input == ConsoleKey.E)
                {
                    
                    bool leave = false;

                    

                    while (leave == false)
                    {
                        Console.Clear();
                        Console.WriteLine("(U)se, (D)iscard, or press esc to return to menu");
                        if(selected != 0)
                        {
                            Console.WriteLine(Player1.itemInventory[selected - 1].name + ": " + Player1.itemInventory[selected - 1].amount + "          ");
                            Console.WriteLine(Player1.itemInventory[selected - 1].type + "  ");
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
                                    if (Player1.itemInventory[selected - 1].amount < 1)
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
                                    if (Player1.itemInventory[selected - 1].amount < 1)
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
                                    if (Player1.itemInventory[selected - 1].amount < 1)
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

                        }
                        if(selected == 0)
                        {
                            Console.WriteLine(otherEntity.itemInventory[selectedOther - 1].name + ": " + otherEntity.itemInventory[selectedOther - 1].amount + "          ");
                            Console.WriteLine(otherEntity.itemInventory[selectedOther - 1].type + "  ");
                            input = KeyInput().Key;

                            if (input == ConsoleKey.U)
                            {
                                if (otherEntity.itemInventory[selectedOther - 1].name == "Health Potion")
                                {
                                    if (otherEntity.itemInventory[selectedOther - 1].amount >= 1)
                                    {
                                        Player1.hp += 25;
                                        otherEntity.itemInventory[selectedOther - 1].amount--;
                                    }
                                    if (otherEntity.itemInventory[selectedOther - 1].amount < 1)
                                    {
                                        otherEntity.itemInventory[selectedOther - 1] = new Items(0, "empty", "empty");
                                        leave = true;
                                    }
                                }

                                else if (otherEntity.itemInventory[selectedOther - 1].name == "Mana Potion")
                                {
                                    if (otherEntity.itemInventory[selectedOther - 1].amount >= 1)
                                    {
                                        Player1.mana += 25;
                                        otherEntity.itemInventory[selectedOther - 1].amount--;
                                    }
                                    if (otherEntity.itemInventory[selectedOther - 1].amount < 1)
                                    {
                                        otherEntity.itemInventory[selectedOther - 1] = new Items(0, "empty", "empty");
                                        leave = true;
                                    }

                                }
                                else if (otherEntity.itemInventory[selectedOther - 1].name == "Roll")
                                {
                                    if (otherEntity.itemInventory[selectedOther - 1].amount >= 1)
                                    {
                                        Player1.mana += 10;
                                        Player1.hp += 10;
                                        otherEntity.itemInventory[selectedOther - 1].amount--;
                                    }
                                    if(otherEntity.itemInventory[selectedOther - 1].amount < 1)
                                    {
                                        otherEntity.itemInventory[selectedOther - 1] = new Items(0, "empty", "empty");
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
                                otherEntity.itemInventory[selectedOther - 1] = new Items(0, "empty", "empty");
                            }

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
                                    inputWeapons = KeyInput().Key;
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
               

                if (input == ConsoleKey.Escape)
                {
                    done = true;
                }

                
            }
            return Player1;
        }




        public static void drawInventoryMenu(Player Player1, int selected, string[] onScreenText,
            List<string[]>[] onScreenTextColor, Entities otherEntity, int selectedOther, int selectedSaved)
        {
            Console.Clear();
            Console.WriteLine($"         Items:  \n (E) to choose item, (W) for Weapons                                                    {otherEntity.trueName}'s Inventory");
            

            for (int l = 0; l <= Player1.itemInventory.Length / 5; l++)
            {
                Console.WriteLine();
                for (int i = 0; i < 4; i++)
                {
                    if ((l * 5) + i + 1 <= Player1.itemInventory.Length && Player1.itemInventory[i].name != "empty")
                    {
                        if (i == selected - 1)
                            Console.BackgroundColor = ConsoleColor.DarkGreen;

                        Console.Write(Player1.itemInventory[i].name + ": " + Player1.itemInventory[i].amount + "          ");
                        Console.ResetColor();
                    }

                   
                }
                Console.Write("                 ");
                drawOtherMenu(Player1, selectedOther, onScreenText, onScreenTextColor, otherEntity, 1, l);
                Console.WriteLine();

                for (int k = 0; k < 4; k++)
                {
                    if ((l * 5) + k + 1 <= Player1.itemInventory.Length && Player1.itemInventory[k].name != "empty")
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
                Console.Write("                 ");
                drawOtherMenu(Player1, selectedOther, onScreenText, onScreenTextColor, otherEntity, 2, l);
            }
        }

        public static void drawOtherMenu(Player Player1, int selected, string[] onScreenText,
            List<string[]>[] onScreenTextColor, Entities otherEntity, int line, int l)
        {


            if (line == 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    if ((l * 5) + i + 1 <= otherEntity.itemInventory.Length && otherEntity.itemInventory[i].name != "empty")
                    {
                        if (i == selected - 1)
                            Console.BackgroundColor = ConsoleColor.DarkGreen;

                        Console.Write(otherEntity.itemInventory[i].name + ": " + otherEntity.itemInventory[i].amount + "          ");
                        Console.ResetColor();
                    }


                }
            }

            else if (line == 2)
            {
                for (int k = 0; k < 4; k++)
                {
                    if ((l * 5) + k + 1 <= otherEntity.itemInventory.Length && otherEntity.itemInventory[k].name != "empty")
                    {
                        Console.Write(otherEntity.itemInventory[k].type + "  ");

                        for (int j = 1; j <= otherEntity.itemInventory[k].name.Length +
                            otherEntity.itemInventory[k].amount.ToString().Length - otherEntity.itemInventory[k].type.Length; j++)
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

        public static void drawOtherWeaponsMenu(Player Player1, int selected, string[] onScreenText, List<string[]>[] onScreenTextColor, Entities otherEntity)
        {
            Console.Clear();
            Console.WriteLine("         Weapons:");

            for (int l = 0; l <= otherEntity.weaponInventory.Length / 5; l++)
            {
                Console.WriteLine();

                for (int i = 0; i < 4; i++)
                {
                    if ((l * 5) + i + 1 <= otherEntity.weaponInventory.Length)
                    {
                        if (i == selected - 1)
                            Console.BackgroundColor = ConsoleColor.DarkGreen;

                        Console.Write(otherEntity.weaponInventory[i].name + "          ");
                        Console.ResetColor();
                    }


                }
                Console.WriteLine();

                for (int k = 0; k < 4; k++)
                {
                    if ((l * 5) + k + 1 <= otherEntity.weaponInventory.Length)
                    {
                        Console.Write(otherEntity.weaponInventory[k].type);

                        for (int j = 1; j <= otherEntity.weaponInventory[k].name.Length
                            - otherEntity.weaponInventory[k].type.Length; j++)
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
