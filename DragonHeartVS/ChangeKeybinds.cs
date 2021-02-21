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
using DragonHeartWithGit.DragonHeartReplit;

namespace DragonHeartWithGit.DragonHeartReplit
{
    public class ChangeKeybindsClass
    {
        public static Keybinds ChangeKeybinds(Keybinds keybindsMapMaker)
        {
            ConsoleKey input;
            ConsoleKey keyUsed = ConsoleKey.Z;
            ConsoleKey originalKey = ConsoleKey.Z;

            bool done = false;
            while (done == false)
            {
                Console.Clear();
                Console.WriteLine("Keybinds: open (m)enu     change (b)lock      change block (c)olor    (p)lace block    p(a)int block   make (l)ine/square");
                Console.WriteLine($"             {keybindsMapMaker.menu.ToString()}            {keybindsMapMaker.changeName.ToString()}                        {keybindsMapMaker.changeNameColor.ToString()}                   {keybindsMapMaker.placeBlock.ToString()}                {keybindsMapMaker.placeColor.ToString()}               {keybindsMapMaker.makeLineSquare.ToString()}");
                Console.Write("Type the letter of the bind you want to change, or press escape if done: ");
                input = KeyInput().Key;
                Console.Write("\n Input the key you want to replace it with: ");

                if(input == ConsoleKey.M)
                {
                    originalKey = keybindsMapMaker.menu;
                    input = KeyInput().Key;
                    keybindsMapMaker.menu = input;
                    keyUsed = ConsoleKey.M;
                }

                else if (input == ConsoleKey.B)
                {
                    originalKey = keybindsMapMaker.changeName;
                    input = KeyInput().Key;
                    keybindsMapMaker.changeName = input;
                    keyUsed = ConsoleKey.B;
                }

                else if (input == ConsoleKey.C)
                {
                    originalKey = keybindsMapMaker.changeNameColor;
                    input = KeyInput().Key;
                    keybindsMapMaker.changeNameColor = input;
                    keyUsed = ConsoleKey.C;
                }

                else if (input == ConsoleKey.P)
                {
                    originalKey = keybindsMapMaker.placeBlock;
                    input = KeyInput().Key;
                    keybindsMapMaker.placeBlock = input;
                    keyUsed = ConsoleKey.P;
                }

                else if (input == ConsoleKey.A)
                {
                    originalKey = keybindsMapMaker.placeColor;
                    input = KeyInput().Key;
                    keybindsMapMaker.placeColor = input;
                    keyUsed = ConsoleKey.A;
                }

                else if (input == ConsoleKey.L)
                {
                    originalKey = keybindsMapMaker.makeLineSquare;
                    input = KeyInput().Key;
                    keybindsMapMaker.makeLineSquare = input;
                    keyUsed = ConsoleKey.L;
                }
                else if (input == ConsoleKey.Escape)
                {
                    done = true;
                }




                if (keybindsMapMaker.menu == input && keyUsed != ConsoleKey.M)
                {
                    Console.WriteLine("WARNING: That key is already assigned. " +
                        "Changed previous key with new key. Enter to continue.");
                    Console.ReadLine();

                    keybindsMapMaker.menu = originalKey;
                }

                if (keybindsMapMaker.changeName == input && keyUsed != ConsoleKey.B)
                {
                    Console.WriteLine("WARNING: That key is already assigned. " +
                        "Changed previous key with new key.");
                    Console.ReadLine();

                    keybindsMapMaker.changeName = originalKey;
                }
                if (keybindsMapMaker.changeNameColor == input && keyUsed != ConsoleKey.C)
                {
                    Console.WriteLine("WARNING: That key is already assigned. " +
                        "Changed previous key with new key.");
                    Console.ReadLine();

                    keybindsMapMaker.changeNameColor = originalKey;
                }
                if (keybindsMapMaker.placeBlock == input && keyUsed != ConsoleKey.P)
                {
                    Console.WriteLine("WARNING: That key is already assigned. " +
                        "Changed previous key with new key.");
                    Console.ReadLine();

                    keybindsMapMaker.placeBlock = originalKey;
                }
                if (keybindsMapMaker.placeColor == input && keyUsed != ConsoleKey.A)
                {
                    Console.WriteLine("WARNING: That key is already assigned. " +
                        "Changed previous key with new key.");
                    Console.ReadLine();

                    keybindsMapMaker.placeColor = originalKey;
                }
                if (keybindsMapMaker.makeLineSquare == input && keyUsed != ConsoleKey.L)
                {
                    Console.WriteLine("WARNING: That key is already assigned. " +
                        "Changed previous key with new key.");
                    Console.ReadLine();

                    keybindsMapMaker.makeLineSquare = originalKey;
                }


            }
            return keybindsMapMaker;
        }
    }
}
