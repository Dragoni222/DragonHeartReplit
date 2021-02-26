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

            int selected = 1;
            int selectedSaved = 0;
            int selectedSavedWeapons = 0;
            int selectedSavedTwo = 0;

            int selectedWeapons = 1;
            int selectedOther = 0;
            int selectedOtherWeapons = 0;

            bool itemTaken = false;

            while (done == false)
            {

                drawInventoryMenu(Player1, selected, onScreenText, onScreenTextColor, otherEntity,selectedOther,selectedSaved);
                if(otherEntity.itemInventory.Count < 1&&selected == 0)
                {
                    selected = Player1.itemInventory.Count - 1;
                }

                if (otherEntity.weaponInventory.Count < 1 && selectedWeapons == 0)
                {
                    selectedWeapons = Player1.weaponInventory.Count - 1;
                }
                ConsoleKey input = KeyInput().Key;
                if (selected <= Player1.itemInventory.Count && selected != 0)
                {
                    if (input == ConsoleKey.RightArrow )
                    {
                        if (otherEntity.itemInventory.Count >= 1 || selected != Player1.itemInventory.Count)
                        {
                            selected++;
                        }
                        
  
                    }
                    if (input == ConsoleKey.LeftArrow && selected > 1)
                    {
                        selected--;
                        selectedSavedTwo = selected + 1;
                        if (selected <= Player1.itemInventory.Count)
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
                    if (input == ConsoleKey.DownArrow && selected + 4 < Player1.itemInventory.Count)
                    {
                        selected += 5;
                    }
                }
                if ((selected > Player1.itemInventory.Count || selected == 0)&&otherEntity.trueName != " ")
                {
                    if (selected != 0)
                    {
                        selectedSaved = selected - 1;
                        selected = 0;
                    }
                    
                    if (input == ConsoleKey.RightArrow && selectedOther < otherEntity.itemInventory.Count)
                    {
                        selectedOther++;
                        selectedSavedTwo = selectedOther - 1;
                        if (selected > Player1.itemInventory.Count)
                        {
                            while (otherEntity.itemInventory[selectedOther - 1].name == "empty" && selectedOther + 1 != otherEntity.itemInventory.Count)
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
                    if (input == ConsoleKey.DownArrow && selected + 4 < otherEntity.itemInventory.Count)
                    {
                        selectedOther += 5;
                    }

                }
                else if((selected > Player1.itemInventory.Count || selected == 0) && otherEntity.trueName == " ")
                {
                    selected--;
                }
                
                if (input == ConsoleKey.E)
                {
                    
                    bool leave = false;

                    

                    while (leave == false)
                    {
                        Console.Clear();
                        Console.WriteLine("(U)se, (D)iscard, (T)ake or press esc to return to menu");
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
                                        Player1.itemInventory.RemoveAt(selected-1);
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
                                        Player1.itemInventory.RemoveAt(selected - 1);
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
                                        Player1.itemInventory.RemoveAt(selected - 1);
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
                                Player1.itemInventory.RemoveAt(selected - 1);
                                leave = true;
                            }
                            else if (input == ConsoleKey.Escape)
                            {
                                leave = true;
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
                                        otherEntity.itemInventory.RemoveAt(selectedOther - 1);
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
                                        otherEntity.itemInventory.RemoveAt(selectedOther - 1);
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
                                        otherEntity.itemInventory.RemoveAt(selectedOther - 1);
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
                                otherEntity.itemInventory.RemoveAt(selectedOther - 1);
                                leave = true;
                            }
                            else if(input == ConsoleKey.T)
                            {
                                for(int i = 0; i <= Player1.itemInventory.Count-1; i++)
                                {
                                    if(Player1.itemInventory[i].name == otherEntity.itemInventory[selectedOther-1].name)
                                    {
                                        Player1.itemInventory[i].amount += otherEntity.itemInventory[selectedOther-1].amount;
                                        itemTaken = true;
                                    }
                                }
                                if (itemTaken == false)
                                {
                                    Player1.itemInventory.Add(otherEntity.itemInventory[selectedOther - 1]);
                                }
                                otherEntity.itemInventory.RemoveAt(selectedOther - 1);
                                leave = true;
                                selectedSaved++;
                                itemTaken = false;
                            }
                            else if (input == ConsoleKey.Escape)
                            {
                                leave = true;
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
                        drawWeaponsMenu(Player1, selectedWeapons, onScreenText, onScreenTextColor, otherEntity, selectedOtherWeapons, selectedSaved);

                        ConsoleKey inputWeapons = KeyInput().Key;
                        if (selectedWeapons <= Player1.weaponInventory.Count && selectedWeapons != 0)
                        {
                            if (inputWeapons == ConsoleKey.RightArrow)
                            {
                                if (otherEntity.weaponInventory.Count >= 1 || selectedWeapons != Player1.weaponInventory.Count)
                                {
                                    selectedWeapons++;
                                }
                            }
                            if (inputWeapons == ConsoleKey.LeftArrow && selectedWeapons > 1)
                            {
                                selectedWeapons--;
                                selectedSavedTwo = selectedWeapons + 1;
                                if (selectedWeapons <= Player1.weaponInventory.Count)
                                {
                                    while (Player1.weaponInventory[selectedWeapons - 1].name == "empty" && selectedWeapons - 1 != 0)
                                    {
                                        selectedWeapons--;
                                    }
                                    if (Player1.weaponInventory[selectedWeapons - 1].name == "empty")
                                    {
                                        selectedWeapons = selectedSavedTwo;
                                    }
                                }
                                selectedSavedWeapons = 0;

                            }
                            if (inputWeapons == ConsoleKey.UpArrow && selectedWeapons > 5)
                            {
                                selectedWeapons -= 5;
                            }
                            if (inputWeapons == ConsoleKey.DownArrow && selectedWeapons + 4 < Player1.weaponInventory.Count)
                            {
                                selectedWeapons += 5;
                            }
                        }
                        if ((selectedWeapons > Player1.weaponInventory.Count || selectedWeapons == 0) && otherEntity.trueName != " ")
                        {
                            if (selectedWeapons != 0)
                            {
                                selectedSavedWeapons = selectedWeapons - 1;
                                selectedWeapons = 0;
                            }

                            if (inputWeapons == ConsoleKey.RightArrow && selectedOtherWeapons < otherEntity.weaponInventory.Count)
                            {
                                selectedOtherWeapons++;
                                selectedSavedTwo = selectedOtherWeapons - 1;
                                if (selectedWeapons > Player1.weaponInventory.Count)
                                {
                                    while (otherEntity.weaponInventory[selectedOtherWeapons - 1].name == "empty" && selectedOtherWeapons + 1 != otherEntity.weaponInventory.Count)
                                    {
                                        selectedOtherWeapons--;
                                    }
                                    if (otherEntity.weaponInventory[selectedOtherWeapons - 1].name == "empty")
                                    {
                                        selectedOtherWeapons = selectedSavedTwo;
                                    }
                                    selectedSavedTwo = 0;
                                }
                            }
                            if (inputWeapons == ConsoleKey.LeftArrow && selectedOtherWeapons > 1)
                            {
                                selectedOtherWeapons--;
                                if (selectedWeapons >= 1)
                                {
                                    while (otherEntity.weaponInventory[selectedOtherWeapons - 1].name == "empty")
                                    {
                                        selectedOtherWeapons--;
                                    }
                                }

                                if (selectedOtherWeapons == 1 && otherEntity.weaponInventory[selectedOtherWeapons - 1].name == "empty")
                                {
                                    selectedOtherWeapons--;
                                }

                            }
                            else if (inputWeapons == ConsoleKey.LeftArrow && selectedOtherWeapons == 1)
                            {
                                selectedOtherWeapons = 0;
                                selectedWeapons = selectedSavedWeapons;
                            }
                            if (inputWeapons == ConsoleKey.UpArrow && selectedOtherWeapons > 5)
                            {
                                selectedOtherWeapons -= 5;
                            }
                            if (inputWeapons == ConsoleKey.DownArrow && selectedWeapons + 4 < otherEntity.weaponInventory.Count)
                            {
                                selectedOtherWeapons += 5;
                            }

                        }
                        else if ((selectedWeapons > Player1.weaponInventory.Count || selectedWeapons == 0) && otherEntity.trueName == " ")
                        {
                            selectedWeapons--;
                        }

                        if (inputWeapons == ConsoleKey.E)
                        {

                            bool leaveWeapons = false;



                            while (leaveWeapons == false)
                            {
                                Console.Clear();
                                
                                if (selectedWeapons != 0)
                                {
                                    Console.WriteLine("(E)quip, (D)iscard, or press esc to return to menu");
                                    Console.WriteLine(Player1.weaponInventory[selectedWeapons - 1].name + "          ");
                                    Console.WriteLine(Player1.weaponInventory[selectedWeapons - 1].type + "  ");
                                    inputWeapons = KeyInput().Key;

                                    if (inputWeapons == ConsoleKey.E)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Which hand do you want to equip this in? (L)eft (R)ight");
                                        input = KeyInput().Key;
                                        for (int i = 0; i< Player1.itemInventory.Count; i++)
                                        {
                                            if(input == ConsoleKey.L)
                                            {
                                                if (Player1.weaponInventory[i].name == Player1.equip1.name&&Player1.weaponInventory[i].equipped == true)
                                                {
                                                    Player1.weaponInventory[i].equipped = false;
                                                }
                                                Player1.weaponInventory[selectedWeapons - 1].equipped = true;
                                                Player1.equip1 = Player1.weaponInventory[selectedWeapons - 1];
                                            }

                                            if (input == ConsoleKey.R)
                                            {
                                                if (Player1.weaponInventory[i].name == Player1.equip2.name && Player1.weaponInventory[i].equipped == true)
                                                {
                                                    Player1.weaponInventory[i].equipped = false;
                                                }
                                                Player1.weaponInventory[selectedWeapons - 1].equipped = true;
                                                Player1.equip2 = Player1.weaponInventory[selectedWeapons - 1];
                                            }

                                        }
                                    }
                                    else if (inputWeapons == ConsoleKey.D)
                                    {
                                        Player1.weaponInventory.RemoveAt(selectedWeapons - 1);
                                        leaveWeapons = true;
                                    }
                                    else if (inputWeapons == ConsoleKey.Escape)
                                    {
                                        leaveWeapons = true;
                                    }

                                }
                                if (selectedWeapons == 0)
                                {
                                    Console.WriteLine("(E)quip, (D)iscard, (T)ake, or press esc to return to menu");
                                    Console.WriteLine(otherEntity.weaponInventory[selectedOtherWeapons - 1].name + "          ");
                                    Console.WriteLine(otherEntity.weaponInventory[selectedOtherWeapons - 1].type + "  ");
                                    inputWeapons = KeyInput().Key;

                                    if (inputWeapons == ConsoleKey.E)
                                    {
                                       

                                        Console.Clear();
                                        Console.WriteLine("Which hand do you want to equip this in? (L)eft (R)ight");
                                        input = KeyInput().Key;
                                        for (int i = 0; i < Player1.itemInventory.Count; i++)
                                        {
                                            if (input == ConsoleKey.L)
                                            {
                                                otherEntity.weaponInventory[selectedOtherWeapons - 1].equipped = true;
                                                Player1.equip1 = otherEntity.weaponInventory[selectedOtherWeapons - 1];
                                            }

                                            if (input == ConsoleKey.R)
                                            {
                                                otherEntity.weaponInventory[selectedOtherWeapons - 1].equipped = true;
                                                Player1.equip2 = otherEntity.weaponInventory[selectedOtherWeapons - 1];
                                            }

                                        }

                                        Player1.weaponInventory.Add(otherEntity.weaponInventory[selectedOtherWeapons - 1]);
                                        otherEntity.weaponInventory.RemoveAt(selectedOtherWeapons - 1);
                                        leaveWeapons = true;
                                        selectedSavedWeapons++;
                                    }
                                    else if (inputWeapons == ConsoleKey.D)
                                    {
                                        otherEntity.weaponInventory.RemoveAt(selectedOtherWeapons - 1);
                                        leaveWeapons = true;
                                    }
                                    else if (inputWeapons == ConsoleKey.T)
                                    {

                                        Player1.weaponInventory.Add(otherEntity.weaponInventory[selectedOtherWeapons - 1]);
                                        otherEntity.weaponInventory.RemoveAt(selectedOtherWeapons - 1);
                                        leaveWeapons = true;
                                        selectedSavedWeapons++;

                                    }
                                    else if (inputWeapons == ConsoleKey.Escape)
                                    {
                                        leaveWeapons = true;
                                    }
                                }
                                if (inputWeapons == ConsoleKey.Escape)
                                {
                                    leaveWeapons = true;
                                }

                            }

                        }
                        if (inputWeapons == ConsoleKey.I)
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
            if (otherEntity.trueName != " ")
            {
                Console.WriteLine($"Items:  \n(E) to choose item, (W) for Weapons                                                    {otherEntity.trueName}'s Inventory");
            }
            else
            {
                Console.WriteLine($"Items:  \n(E) to choose item, (W) for Weapons");
            }
            int inventoryStringLength = 0;
            

            for (int l = 0; l <= Player1.itemInventory.Count / 5; l++)
            {
                Console.WriteLine();
                for (int i = 0; i < 4; i++)
                {
                    if ((l * 5) + i + 1 <= Player1.itemInventory.Count && Player1.itemInventory[i].name != "empty")
                    {
                        if (i == selected - 1)
                            Console.BackgroundColor = ConsoleColor.DarkGreen;

                        Console.Write(Player1.itemInventory[i].name + ": " + Player1.itemInventory[i].amount + "          ");
                        inventoryStringLength += Player1.itemInventory[i].name.Length + 13 + Player1.itemInventory[i].amount.ToString().Length;
                        Console.ResetColor();
                    }

                   
                }

                for (int i = 0; i <= 90 - inventoryStringLength; i++)
                {
                    Console.Write(" ");
                }
                inventoryStringLength = 0;

                drawOtherMenu(Player1, selectedOther, onScreenText, onScreenTextColor, otherEntity, 1, l);
                Console.WriteLine();

                for (int k = 0; k < 4; k++)
                {
                    if ((l * 5) + k + 1 <= Player1.itemInventory.Count && Player1.itemInventory[k].name != "empty")
                    {
                        Console.Write(Player1.itemInventory[k].type + "  ");
                        inventoryStringLength += Player1.itemInventory[k].type.Length + 2;

                        for (int j = 1; j <= Player1.itemInventory[k].name.Length +
                            Player1.itemInventory[k].amount.ToString().Length - Player1.itemInventory[k].type.Length; j++)
                        {
                            Console.Write(" ");
                            inventoryStringLength++;
                        }

                        Console.Write("          ");
                        inventoryStringLength += 10;
                    }
                    
                    
                }
                for(int i = 0; i < 90 - inventoryStringLength; i++)
                {
                    Console.Write(" ");
                }
                
                inventoryStringLength = 0;
                

                
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
                    if ((l * 5) + i + 1 <= otherEntity.itemInventory.Count && otherEntity.itemInventory[i].name != "empty")
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
                    if ((l * 5) + k + 1 <= otherEntity.itemInventory.Count && otherEntity.itemInventory[k].name != "empty")
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




        public static void drawWeaponsMenu(Player Player1, int selected, string[] onScreenText,
            List<string[]>[] onScreenTextColor, Entities otherEntity, int selectedOther, int selectedSaved)
        {
            Console.Clear();
            if (otherEntity.trueName != " ")
            {
                Console.WriteLine($"Weapons:  \n(E) to choose weapons,(I) to return to items                                         {otherEntity.trueName}'s Inventory");
            }
            else
            {
                Console.WriteLine($"Weapons:  \n(E) to choose weapons,(I) to return to items");
            }
            int inventoryStringLength = 0;


            for (int l = 0; l <= Player1.weaponInventory.Count / 5; l++)
            {
                Console.WriteLine();
                for (int i = 0; i < 4; i++)
                {
                    if ((l * 5) + i + 1 <= Player1.weaponInventory.Count && Player1.weaponInventory[i].name != "empty")
                    {
                        if (i == selected - 1)
                            Console.BackgroundColor = ConsoleColor.DarkGreen;

                        Console.Write(Player1.weaponInventory[i].name + "          ");
                        inventoryStringLength += Player1.weaponInventory[i].name.Length + 12;
                        Console.ResetColor();
                    }


                }

                for (int i = 0; i <= 90 - inventoryStringLength; i++)
                {
                    Console.Write(" ");
                }
                inventoryStringLength = 0;

                drawOtherWeaponsMenu(Player1, selectedOther, onScreenText, onScreenTextColor, otherEntity, 1, l);
                Console.WriteLine();

                for (int k = 0; k < 4; k++)
                {
                    if ((l * 5) + k + 1 <= Player1.weaponInventory.Count && Player1.weaponInventory[k].name != "empty")
                    {
                        Console.Write(Player1.weaponInventory[k].type + "  ");
                        inventoryStringLength += Player1.weaponInventory[k].type.Length + 2;

                        for (int j = 1; j <= Player1.weaponInventory[k].name.Length - Player1.weaponInventory[k].type.Length; j++)
                        {
                            Console.Write(" ");
                            inventoryStringLength++;
                        }

                        Console.Write("        ");
                        inventoryStringLength += 10;
                    }


                }
                for (int i = 0; i < 90 - inventoryStringLength; i++)
                {
                    Console.Write(" ");
                }
                inventoryStringLength = 0;



                drawOtherWeaponsMenu(Player1, selectedOther, onScreenText, onScreenTextColor, otherEntity, 2, l);
            }
        }

        public static void drawOtherWeaponsMenu(Player Player1, int selected, string[] onScreenText,
            List<string[]>[] onScreenTextColor, Entities otherEntity, int line, int l)
        {


            if (line == 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    if ((l * 5) + i + 1 <= otherEntity.weaponInventory.Count && otherEntity.weaponInventory[i].name != "empty")
                    {
                        if (i == selected - 1)
                            Console.BackgroundColor = ConsoleColor.DarkGreen;

                        Console.Write(otherEntity.weaponInventory[i].name + "          ");
                        Console.ResetColor();
                    }


                }
            }

            else if (line == 2)
            {
                for (int k = 0; k < 4; k++)
                {
                    if ((l * 5) + k + 1 <= otherEntity.weaponInventory.Count && otherEntity.weaponInventory[k].name != "empty")
                    {
                        Console.Write(otherEntity.weaponInventory[k].type + "  ");

                        for (int j = 1; j <= otherEntity.weaponInventory[k].name.Length - otherEntity.weaponInventory[k].type.Length; j++)
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
