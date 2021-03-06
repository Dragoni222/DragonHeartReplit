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
using System.Threading;
using static DrawEntities;
using static Entities;
using static FindRangeStats;
using static RandomFunctions;
class PlayClass
{



    public static void Play(List<List<string>> fullMap,
        List<List<string>> fullMapOrig, string[] onScreenText,
        Player Player1, List<List<System.ConsoleColor>> fullMapColor,
        List<List<System.ConsoleColor>> fullMapColorOrig, List<List<System.ConsoleColor>> fullMapHighColor,
        List<List<System.ConsoleColor>> fullMapHighColorOrig)
    {

        Weapon fists = new Weapon(10000, "bludge", "Fists",
        "1d2 ", new List<List<int>>() { new List<int>(){0,1,0 },
        new List<int>() { 0,-1,0 }, new List<int>() { 0,0,0} }, true, 0, 1);


        Weapon woodenShortsword = new Weapon(50, "slash", "wooden shortsword",
        "1d6 ", new List<List<int>>{ new List<int>(){2, 2,2,2, 2},
        new List<int>() {2, 1, 1, 1, 2}, new List<int>() {1, 1, -1, 1, 1},
        new List<int>() {1, 0, 0, 0,1 }, new List<int>() { 0, 0, 0, 0, 0 } }, true, 0, 1);

        Weapon woodenClub = new Weapon(50, "bludge", "wooden club",
        "1d5 ", new List<List<int>>{ new List<int>(){1,2,1},
        new List<int>() { 0, -1, 0 }, new List<int>() { 0, 0, 0 } }, true, 0, 1);

        Weapon woodenKnife = new Weapon(50, "pierce", "wooden knife",
        "2d5 ", new List<List<int>>{ new List<int>(){0,2,0},
        new List<int>() { 0, -1, 0 }, new List<int>() { 0, 0, 0 } }, false, 0, 1);

        Weapon woodenBow = new Weapon(50, "ranged pierce", "wooden bow",
        "2d5 ", new List<List<int>>{ new List<int>(){0,2,0},
        new List<int>() { 0, -1, 0 }, new List<int>() { 0, 0, 0 } }, false, 1, 5);

        int[] colorChangeID = new int[14];

        Keybinds keybindsMapMaker = new Keybinds(ConsoleKey.Escape, ConsoleKey.W,
            ConsoleKey.S, ConsoleKey.A, ConsoleKey.D, ConsoleKey.T, ConsoleKey.Y,
            ConsoleKey.E, ConsoleKey.Q, ConsoleKey.L, ConsoleKey.J, ConsoleKey.K,
            ConsoleKey.V);

        List<Entities> allEntities = new List<Entities>();
        List<Hitbox> allHitboxes = new List<Hitbox>();

        allEntities.Add(new Entities(new List<Items>(),
            new List<Weapon>(), "E", new[] { 99, 99 }, 0,
            ConsoleColor.DarkYellow, " ", fists, fists, "object"));

        allEntities.Add(new Entities(new List<Items> { new Items(2, "Potion", "Health Potion"), new Items(2, "Potion", "Mana Potion"), new Items(4, "Food", "Roll") },
            new List<Weapon>{woodenKnife, woodenBow}, "C", new[] { 50, 52 }, 0,
            ConsoleColor.DarkYellow, "Chest", fists, fists, "object"));

        allEntities.Add(new Entities(new List<Items> { new Items(2, "Potion", "Health Potion"), new Items(2, "Potion", "Mana Potion"), new Items(4, "Food", "Roll") },
            new List<Weapon>{woodenClub}, "G", new[] { 40, 45 }, 15,
            ConsoleColor.Green, "Goblin", woodenClub, woodenClub, "Rush"));

        for (int o = 1; o <= colorChangeID.Length; o++)
        {
            colorChangeID[o - 1] = 0;
        }

        string debug = "";

        List<string[]>[] onScreenTextColor = new List<string[]>[14];

        //onScreenTextColor instantiator adds characters so the map doesn't run out of room
        onScreenTextColor = colorChangeIDReset1(onScreenTextColor);

        fullMapColorOrig = fullMapColor;
        fullMapHighColorOrig = fullMapHighColor;

        //the zoom of the map, in the length of one side, make sure it's odd
        int mapZoom = 21;
        bool onTitleScreen = true;
        bool ghost;

        while (onTitleScreen == true)
        {

            
            Console.WriteLine("Enter password for dev map maker, play to play, or settings for settings");
            
            string readLine = Console.ReadLine();

            //to skip
            if (readLine == "settings")
            {
                Console.WriteLine("    Settings\nInsert (m)ap\n(K)eybinds");
                ConsoleKey input = KeyInput().Key;
                if (input == ConsoleKey.M)
                {
                    Console.WriteLine("Paste Map input here:");
                    fullMap = readFullMap(fullMap, Console.ReadLine());
                    fullMapOrig = fullMap;

                    Console.WriteLine("Paste Color Map input here:");
                    fullMapColor = readFullMapColor(fullMapColor, Console.ReadLine());
                    fullMapColorOrig = fullMapColor;

                }
                else
                {
                    Console.WriteLine("not a valid input");
                }

            }

            //for devbuild map maker
            if (readLine == "10212005")
            {
                //prints map
                ghost = true;

                

                drawFrame(fullMap, Player1, mapZoom, fullMapColor, onScreenText,
                    onScreenTextColor, fullMapHighColor, allEntities);
                fullMapHighColor = new List<List<System.ConsoleColor>>();
                fullMapHighColorOrig = new List<List<System.ConsoleColor>>();
                for (int j = 0; j < 100; j++)
                {
                    fullMapHighColor.Add(new List<ConsoleColor>());

                    for (int i = 0; i < 100; i++)
                    {
                        fullMapHighColor[j].Add(ConsoleColor.Black);
                    }

                }
                

                bool placeBlock = false;
                bool placeColor = false;

                while (true)
                {
                    //fullMap = fullMapOrig;

                    //prioirty order for inputs: WASD, paint commands, explicit commands, unnamed command
                    var commandInput2 = KeyInput();
                    var commandInput = commandInput2.Key;

                    if (commandInput == keybindsMapMaker.up || commandInput == keybindsMapMaker.left || commandInput == keybindsMapMaker.down || commandInput == keybindsMapMaker.right)
                    {
                        //move
                        if (placeBlock == true)
                        {
                            fullMapOrig = mapAugment(fullMapOrig, Player1.charXY[0], Player1.charXY[1], Player1.name);
                            fullMap = mapAugment(fullMap, Player1.charXY[0], Player1.charXY[1], Player1.name);
                        }
                        if (placeColor == true)
                        {
                            fullMapColorOrig = mapAugmentColor(fullMapColorOrig, Player1.charXY[0], Player1.charXY[1], Player1.nameColor);
                            fullMapColor = mapAugmentColor(fullMapColor, Player1.charXY[0], Player1.charXY[1], Player1.nameColor);
                        }

                        int[] prevCharXY = {
              1,
              0
            };
                        prevCharXY[1] = Player1.charXY[1];
                        prevCharXY[0] = Player1.charXY[0];

                        Player1.charXY = charMove(Player1, commandInput, fullMap, ghost, keybindsMapMaker);

                        if (Player1.charXY[1] == prevCharXY[1] && Player1.charXY[0] == prevCharXY[0])
                        {
                            onScreenText = onScreenTextAugment(onScreenText, "you cannot move there", 13);
                            onScreenTextColor = onScreenTextColorAugment(onScreenTextColor, "red", 12, 1, 21, colorChangeID);
                        }

                        if (placeBlock == false)
                        {
                            fullMap = mapAugment(fullMap, prevCharXY[0], prevCharXY[1], fullMapOrig[prevCharXY[1]][prevCharXY[0]]);

                        }

                        if (placeColor == false)
                        {
                            fullMapColor = mapAugmentColor(fullMapColor, prevCharXY[0], prevCharXY[1], fullMapColorOrig[prevCharXY[1]][prevCharXY[0]]);

                        }

                        placeColor = false;
                        placeBlock = false;

                        fullMap = mapAugment(fullMap, Player1.charXY[0], Player1.charXY[1], Player1.name);

                        fullMapColor = mapAugmentColor(fullMapColor, Player1.charXY[0], Player1.charXY[1], Player1.nameColor);

                    }

                    else if (commandInput == keybindsMapMaker.changeName)
                    {
                        //set placeable block
                        Player1.name = changeName();
                        //redraw character
                        fullMap = mapAugment(fullMap, Player1.charXY[0], Player1.charXY[1], Player1.name);

                    }
                    else if (commandInput == keybindsMapMaker.changeNameColor)
                    {
                        //set paint
                        Player1.nameColor = changeNameColor();
                        //redraw character
                        fullMapColor = mapAugmentColor(fullMapColor, Player1.charXY[0], Player1.charXY[1], Player1.nameColor);

                    }
                    else if (commandInput == keybindsMapMaker.placeColor || commandInput == keybindsMapMaker.placeBlock)
                    {
                        //place/paint block
                        if (commandInput == keybindsMapMaker.placeBlock)
                        {
                            placeBlock = true;
                            placeColor = true;
                        }
                        if (commandInput == keybindsMapMaker.placeColor)
                        {
                            placeColor = true;
                        }

                    }

                    else if (commandInput == keybindsMapMaker.makeLineSquare)
                    {
                        int lineLength = 0;
                        int direction = 0;
                        // north = 1, east 2, south 3, west 0
                        Console.Clear();
                        Console.WriteLine("(L)ine and (R)ectangle Drawing.");

                        commandInput = KeyInput().Key;

                        if (commandInput == ConsoleKey.L)
                        {
                            Console.Write("input the length first, then the " + "direction of line. It will draw starting with " + "the square next to you. \n length: ");
                            lineLength = int.Parse(Console.ReadLine());
                            Console.Write("\n north = 1, east 2, south 3, west 0 direction: ");
                            direction = int.Parse(Console.ReadLine());
                            for (int i = 0; i < lineLength; i++)
                            {
                                if (direction == 0)
                                {
                                    fullMapOrig = mapAugment(fullMapOrig, Player1.charXY[0] - i, Player1.charXY[1], Player1.name);
                                    fullMapColorOrig = mapAugmentColor(fullMapColorOrig, Player1.charXY[0] - i, Player1.charXY[1], Player1.nameColor);

                                    fullMap = mapAugment(fullMap, Player1.charXY[0] - i, Player1.charXY[1], Player1.name);
                                    fullMapColor = mapAugmentColor(fullMapColor, Player1.charXY[0] - i, Player1.charXY[1], Player1.nameColor);
                                }
                                if (direction == 1)
                                {
                                    fullMapOrig = mapAugment(fullMapOrig, Player1.charXY[0], Player1.charXY[1] - i, Player1.name);
                                    fullMapColorOrig = mapAugmentColor(fullMapColorOrig, Player1.charXY[0], Player1.charXY[1] - i, Player1.nameColor);

                                    fullMap = mapAugment(fullMapOrig, Player1.charXY[0], Player1.charXY[1] - i, Player1.name);
                                    fullMapColor = mapAugmentColor(fullMapColorOrig, Player1.charXY[0], Player1.charXY[1] - i, Player1.nameColor);
                                }
                                if (direction == 2)
                                {
                                    fullMapOrig = mapAugment(fullMapOrig, Player1.charXY[0] + i, Player1.charXY[1], Player1.name);
                                    fullMapColorOrig = mapAugmentColor(fullMapColorOrig, Player1.charXY[0] + i, Player1.charXY[1], Player1.nameColor);

                                    fullMap = mapAugment(fullMap, Player1.charXY[0] + i, Player1.charXY[1], Player1.name);
                                    fullMapColor = mapAugmentColor(fullMapColor, Player1.charXY[0] + i, Player1.charXY[1], Player1.nameColor);
                                }
                                if (direction == 3)
                                {
                                    fullMapOrig = mapAugment(fullMapOrig, Player1.charXY[0] + i, Player1.charXY[1] - i, Player1.name);
                                    fullMapColorOrig = mapAugmentColor(fullMapColorOrig, Player1.charXY[0], Player1.charXY[1] - i, Player1.nameColor);

                                    fullMap = mapAugment(fullMap, Player1.charXY[0] + i, Player1.charXY[1] - i, Player1.name);
                                    fullMapColor = mapAugmentColor(fullMapColor, Player1.charXY[0], Player1.charXY[1] - i, Player1.nameColor);
                                }
                            }
                        }
                        else if (commandInput == ConsoleKey.R)
                        {
                            int width;
                            int hight;
                            Console.WriteLine("Input the width first, then the " + "hight. It will start to the right of you.\n width: ");
                            width = int.Parse(Console.ReadLine());
                            Console.Write("\n Hight: ");
                            hight = int.Parse(Console.ReadLine());

                            for (int i = 0; i < width; i++)
                            {
                                for (int j = 0; j < hight; j++)
                                {
                                    fullMap = mapAugment(fullMap, Player1.charXY[0] + i, Player1.charXY[1] + j, Player1.name);
                                    fullMapOrig = mapAugment(fullMapOrig, Player1.charXY[0] + i, Player1.charXY[1] + j, Player1.name);

                                    fullMapColor = mapAugmentColor(fullMapColor, Player1.charXY[0] + i, Player1.charXY[1] + j, Player1.nameColor);
                                    fullMapColorOrig = mapAugmentColor(fullMapColor, Player1.charXY[0] + i, Player1.charXY[1] + j, Player1.nameColor);

                                }
                            }

                        }

                    }

                    else if (commandInput == keybindsMapMaker.menu)
                    {
                        bool backToMenu = true;
                        while (backToMenu == true)
                        {
                            Console.Clear();
                            Console.WriteLine("(P)rint \n" + "Print (C)olor \n" + "(K)eybinds \n (I)nvenotry");

                            //menu
                            commandInput2 = KeyInput();
                            commandInput = commandInput2.Key;

                            if (commandInput == ConsoleKey.P)
                            {
                                Console.Clear();
                                Console.WriteLine("The current map printout is: ");
                                Console.Write("{");
                                for (int i = 1; i <= fullMap.Count; i++)
                                {
                                    Console.Write("{");
                                    for (int j = 1; j <= fullMap[0].Count; j++)
                                    {
                                        Console.Write($"\"{fullMapOrig[j - 1][i - 1]}\",");
                                    }
                                    Console.Write("},");
                                }
                                Console.WriteLine("};");
                                bool returnFromLoop = false;
                                while (returnFromLoop == false)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("etc to return to game");

                                    commandInput2 = KeyInput();
                                    commandInput = commandInput2.Key;

                                    if (commandInput == ConsoleKey.Escape) returnFromLoop = true;
                                    else Console.WriteLine("incorrect input");
                                }

                            }

                            if (commandInput == ConsoleKey.C)
                            {
                                Console.Clear();
                                Console.WriteLine("The current color map printout is: ");
                                Console.Write("{");
                                for (int i = 1; i <= fullMapColor.Count; i++)
                                {
                                    Console.Write("{");
                                    for (int j = 1; j <= fullMapColor[0].Count; j++)
                                    {
                                        Console.Write($"\"{convertColorToString(fullMapColorOrig[j - 1][i - 1])}\", ");
                                    }
                                    Console.Write("}, ");
                                }
                                Console.WriteLine("};");
                                bool returnFromLoop = false;
                                while (returnFromLoop == false)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("etc to return to game");

                                    commandInput2 = KeyInput();
                                    commandInput = commandInput2.Key;

                                    if (commandInput == ConsoleKey.Escape) returnFromLoop = true;
                                    else Console.WriteLine("incorrect input");
                                }

                            }
                            if (commandInput == ConsoleKey.K)
                            {
                                keybindsMapMaker = ChangeKeybinds(keybindsMapMaker);
                            }

                            if (commandInput == ConsoleKey.I)
                            {
                                Player1 = InventoryMenu(Player1, onScreenText, onScreenTextColor, allEntities[0]);
                            }
                            
                        }
                    }
                    //what is written below the map
                    //combat log inputs
                    onScreenText = onScreenTextAugment(onScreenText, commandInput.ToString(), 13);

                    //debug
                    onScreenText = onScreenTextAugment(onScreenText, debug, 14);

                    //player stats
                    onScreenText = onScreenTextAugment(onScreenText, $"HP: {Player1.hp} " +  $"Mana: {Player1.mana}", 1);

                    //keybinds 1
                    onScreenText = onScreenTextAugment(onScreenText, "Keybinds: open menu     change block      change block color    place block    paint block   make line/square", 2);

                    //keybinds 2
                    onScreenText = onScreenTextAugment(onScreenText, $"            {keybindsMapMaker.menu.ToString()}           {keybindsMapMaker.changeName.ToString()}                       {keybindsMapMaker.changeNameColor.ToString()}                  {keybindsMapMaker.placeBlock.ToString()}               {keybindsMapMaker.placeColor.ToString()}              {keybindsMapMaker.makeLineSquare.ToString()}", 3);


                    //what color the things below the map are (original, color, priority, start, end, colorChangeID)
                    onScreenTextColor = onScreenTextColorAugment(onScreenTextColor, "red", 1, 5, 4 + Player1.hp.ToString().Length, colorChangeID);
                    colorChangeID[0]++;

                    onScreenTextColor = onScreenTextColorAugment(onScreenTextColor, "blue", 1, 12 + Player1.hp.ToString().Length, 12 + Player1.hp.ToString().Length + 4 + Player1.hp.ToString().Length, colorChangeID);
                    colorChangeID[0]++;

                    drawFrame(fullMap, Player1, mapZoom, fullMapColor, onScreenText, onScreenTextColor, fullMapHighColor, allEntities);
                    fullMapHighColor = new List<List<System.ConsoleColor>>();
                    fullMapHighColorOrig = new List<List<System.ConsoleColor>>();
                    for (int j = 0; j < 100; j++)
                    {
                        fullMapHighColor.Add(new List<ConsoleColor>());

                        for (int i = 0; i < 100; i++)
                        {
                            fullMapHighColor[j].Add(ConsoleColor.Black);
                        }

                    }

                    onScreenTextColor = colorChangeIDReset1(onScreenTextColor);
                    colorChangeID = colorChangeIDReset2(colorChangeID);

                }
            }

            if(readLine == "Play")
            {
                //prints map
                ghost = false;


                drawFrame(fullMap, Player1, mapZoom, fullMapColor, onScreenText,
                    onScreenTextColor, fullMapHighColor, allEntities);
                fullMapHighColor = new List<List<System.ConsoleColor>>();
                fullMapHighColorOrig = new List<List<System.ConsoleColor>>();
                for (int j = 0; j < 100; j++)
                {
                    fullMapHighColor.Add(new List<ConsoleColor>());

                    for (int i = 0; i < 100; i++)
                    {
                        fullMapHighColor[j].Add(ConsoleColor.Black);
                    }

                }

                List<double> energy = Player1.maxEnergy;
                bool isEnemyTurn = true;

                while (true)
                {
                    fullMap = fullMapOrig;
                    fullMap = DrawAllEntities(fullMap, allEntities, Player1);
                    fullMapColor = DrawAllEntitiesColor(fullMapColor, allEntities, Player1);

                    if(energy.Sum() <= 0)
                    {
                        isEnemyTurn = true;
                        energy = Player1.maxEnergy;
                    }
                    while (isEnemyTurn == true)
                    {
                        for (int i = 0; i <= allEntities.Count - 1; i++)
                        {
                            
                            if (allEntities[i].entityAI == "Rush" && allEntities[i].hp > 0)
                            {
                                int[] directionOptions = {0, 0};
                                if (allEntities[i].entityXY[0] - Player1.charXY[0]
                                    < 5 && allEntities[i].entityXY[1] - Player1.charXY[1] < 5)
                                {
                                    bool swingWeapon = false;
                                    int savedDirection = 1;


                                    if (allEntities[i].entityXY[0] > Player1.charXY[0])
                                    {
                                        directionOptions[0] = 4;

                                        
                                    }
                                    if (allEntities[i].entityXY[0] < Player1.charXY[0])
                                    {
                                        if(directionOptions[0] == 0)
                                        {
                                            directionOptions[0] = 2;
                                        }
                                        else
                                        {
                                            directionOptions[1] = 2;
                                        }

                                        
                                    }
                                    if (allEntities[i].entityXY[1] > Player1.charXY[1])
                                    {
                                        if (directionOptions[0] == 0)
                                        {
                                            directionOptions[0] = 1;
                                        }
                                        else
                                        {
                                            directionOptions[1] = 1;
                                        }
                                        
                                    }
                                    if (allEntities[i].entityXY[1] < Player1.charXY[1])
                                    {
                                        if (directionOptions[0] == 0)
                                        {
                                            directionOptions[0] = 3;
                                        }
                                        else
                                        {
                                            directionOptions[1] = 3;
                                        }
                                        
                                    }

                                    if(IsInRange(FindTrueRange(directionOptions[0], allEntities[i].equip1.range), allEntities[i].entityXY, Player1.charXY) > 0)
                                    {
                                        swingWeapon = true;
                                        savedDirection = directionOptions[0];
                                    }
                                    else if(IsInRange(FindTrueRange(directionOptions[1], allEntities[i].equip1.range), allEntities[i].entityXY, Player1.charXY) > 0)
                                    {
                                        swingWeapon = true;
                                        savedDirection = directionOptions[1];
                                    }
                                    else
                                    {
                                        swingWeapon = false;
                                        if (FindDistanceInDirection(directionOptions[0], allEntities[i].entityXY, Player1.charXY) >
                                            FindDistanceInDirection(directionOptions[1], allEntities[i].entityXY, Player1.charXY))
                                        {
                                            savedDirection = directionOptions[0];
                                        }
                                        else
                                        {
                                            savedDirection = directionOptions[1];
                                        }
                                        
                                    }


                                    if (swingWeapon == false)
                                    {
                                        int savedEntityX = allEntities[i].entityXY[0];
                                        int savedEntityY = allEntities[i].entityXY[1];

                                        allEntities[i].entityXY = entMove(allEntities[i], fullMap, false, savedDirection);

                                        if (savedEntityX == allEntities[i].entityXY[0] && savedEntityY == allEntities[i].entityXY[1])
                                        {
                                            if (allEntities[i].entityXY[0] >= Player1.charXY[0] && savedDirection != 4)
                                            {
                                                savedDirection = 4;

                                                if (IsInRange(FindTrueRange(savedDirection, allEntities[i].equip1.range), allEntities[i].entityXY, Player1.charXY) > 0)
                                                {
                                                    swingWeapon = true;
                                                }
                                            }
                                            else if (allEntities[i].entityXY[0] <= Player1.charXY[0] && savedDirection != 2)
                                            {
                                                savedDirection = 2;

                                                if (IsInRange(FindTrueRange(savedDirection, allEntities[i].equip1.range), allEntities[i].entityXY, Player1.charXY) > 0)
                                                {
                                                    swingWeapon = true;
                                                }
                                            }
                                            else if (allEntities[i].entityXY[1] >= Player1.charXY[1] && savedDirection != 1)
                                            {
                                                savedDirection = 1;
                                                if (IsInRange(FindTrueRange(savedDirection, allEntities[i].equip1.range), allEntities[i].entityXY, Player1.charXY) > 0)
                                                {
                                                    swingWeapon = true;
                                                }
                                            }
                                            else if (allEntities[i].entityXY[1] <= Player1.charXY[1] && savedDirection != 3)
                                            {
                                                savedDirection = 3;
                                                if (IsInRange(FindTrueRange(savedDirection, allEntities[i].equip1.range), allEntities[i].entityXY, Player1.charXY) > 0)
                                                {
                                                    swingWeapon = true;
                                                }
                                            }
                                            allEntities[i].entityXY = entMove(allEntities[i], fullMap, false, savedDirection);
                                            
                                        }
                                    }

                                    if (swingWeapon == true)
                                    {

                                        allEntities[i] = SwingEntityWeapon1(allEntities[i], 1);


                                        allHitboxes.Add(new Hitbox(allEntities[i].equip1.type,
                                            allEntities[i].equip1.name, allEntities[i].equip1.damage,
                                            allEntities[i].equip1.range, allEntities[i].equip1.shotSpeed,
                                            savedDirection, new int[]
                                            {allEntities[i].entityXY[0],
                                                allEntities[i].entityXY[1]}, false,
                                            allEntities[i].equip1.actionsAlive));


                                        if (allEntities[i].equip1.durability == 0)
                                        {
                                            Player1.equip1 = fists;
                                        }

                                        swingWeapon = false;
                                    }



                                }
                            }


                        }
                        isEnemyTurn = false;
                    }
                    for (int i = 0; i <= allHitboxes.Count - 1; i++)
                    {

                        if (allHitboxes[i].isPlayerHitbox == false)
                        {
                            if (allHitboxes[i].speed >= 1)
                            {
                                allHitboxes[i].hitboxXY = hitboxMove(allHitboxes[i], fullMap, false, allHitboxes[i].direction);
                            }

                            fullMap = SwingWeapon2(allHitboxes[i], fullMap, SwingWeapon3(allHitboxes[i], fullMapHighColor));
                            fullMapHighColor = SwingWeapon3(allHitboxes[i], fullMapHighColor);

                            if (IsInRange(FindTrueRange(allHitboxes[i].direction, allHitboxes[i].range), allHitboxes[i].hitboxXY, Player1.charXY) == 1)
                            {
                                Player1.hp -= DamageRandom(allHitboxes[i].damage, 1, 0);
                            }


                            if (IsInRange(FindTrueRange(Player1.direction, Player1.equip1.range), Player1.charXY, Player1.charXY) == 2)
                            {
                                Player1.hp -= DamageRandom(allHitboxes[i].damage, 2, 0);
                            }

                            allHitboxes[i].distance--;

                            if (allHitboxes[i].distance <= 0)
                            {
                                allHitboxes.RemoveAt(i);
                            }
                        }







                    }



                    onScreenTextColor = onScreenTextColorAugment(onScreenTextColor, "red", 1, 5, 4 + Player1.hp.ToString().Length, colorChangeID);
                    colorChangeID[0]++;

                    onScreenTextColor = onScreenTextColorAugment(onScreenTextColor, "blue", 1, 12 + Player1.hp.ToString().Length, 12 + Player1.hp.ToString().Length + 4 + Player1.hp.ToString().Length, colorChangeID);
                    colorChangeID[0]++;

                    fullMap = fullMapOrig;

                    drawFrame(fullMap, Player1, mapZoom, fullMapColor, onScreenText,
                    onScreenTextColor, fullMapHighColor, allEntities);

                    Thread.Sleep(500);

                    //prioirty order for inputs: WASD, paint commands, explicit commands, unnamed command

                    var commandInput = KeyInput().Key;

                    for(int i = 0; i <= allEntities.Count - 1; i++)
                    {
                        if(allEntities[i].hp <= 0 && allEntities[i].trueName != "Chest")
                        {

                            if (allEntities[i].trueName.Contains("(dead)")==false)
                            {
                                allEntities[i].trueName += " (dead)";
                            }

                            allEntities[i].hp = 0;
                            allEntities[i].nameColor = ConsoleColor.Blue;
                        }
                    }

                    if (commandInput == keybindsMapMaker.up || commandInput == keybindsMapMaker.left || commandInput == keybindsMapMaker.down || commandInput == keybindsMapMaker.right)
                    {
                        //move
                        

                        int[] prevCharXY = { 1, 0 };

                        prevCharXY[1] = Player1.charXY[1];
                        prevCharXY[0] = Player1.charXY[0];
                        
                        Player1.charXY = charMove(Player1, commandInput, fullMap, ghost, keybindsMapMaker);
                        if(commandInput == keybindsMapMaker.up)
                        {
                            Player1.direction = 1;
                        }
                        if (commandInput == keybindsMapMaker.right)
                        {
                            Player1.direction = 2;
                        }
                        if (commandInput == keybindsMapMaker.left)
                        {
                            Player1.direction = 3;
                        }
                        if (commandInput == keybindsMapMaker.down)
                        {
                            Player1.direction = 4;
                        }

                        if (Player1.charXY[1] == prevCharXY[1] && Player1.charXY[0] == prevCharXY[0])
                        {
                            onScreenText = onScreenTextAugment(onScreenText, "you cannot move there", 13);
                            onScreenTextColor = onScreenTextColorAugment(onScreenTextColor, "red", 12, 1, 21, colorChangeID);
                        }
                        

                    }
                    else if (commandInput == keybindsMapMaker.interact)
                    {
                        
                        for(int i = 0; i <= allEntities.Count-1; i++)
                        {
                            
                            if (allEntities[i].entityXY[1] == Player1.charXY[1] && allEntities[i].entityXY[0] == Player1.charXY[0] && allEntities[i].hp<=0)
                            {
                                
                                Player1 = InventoryMenu(Player1, onScreenText, onScreenTextColor, allEntities[i]);
                            }
                        }
                        
                    }

                    else if (commandInput == keybindsMapMaker.changeName)
                    {
                        //set placeable block
                        Player1.name = changeName();
                        //redraw character
                        fullMap = mapAugment(fullMap, Player1.charXY[0], Player1.charXY[1], Player1.name);

                        //set paint
                        Player1.nameColor = changeNameColor();
                        //redraw character
                        fullMapColor = mapAugmentColor(fullMapColor, Player1.charXY[0], Player1.charXY[1], Player1.nameColor);

                    }
                    
                    else if(commandInput == keybindsMapMaker.swingWeapon1)
                    {
                       
                        Player1 = SwingWeapon1(Player1, 1);

                        Console.Clear();
                        Console.WriteLine(Player1.direction);
                        Thread.Sleep(500);

                        allHitboxes.Add(new Hitbox(Player1.equip1.type,
                            Player1.equip1.name, Player1.equip1.damage,
                            Player1.equip1.range, Player1.equip1.shotSpeed,
                            Player1.direction, new int[]
                            { Player1.charXY[0], Player1.charXY[1]}, true,
                            Player1.equip1.actionsAlive));

                        if (Player1.equip1.durability == 0)
                        {
                            onScreenText = onScreenTextAugment(onScreenText, $"Your {Player1.equip1.name} broke.", 13);
                            onScreenTextColor = onScreenTextColorAugment(onScreenTextColor, "darkred", 12, 1, 100, colorChangeID);
                            Player1.equip1 = fists;
                        }

                        fullMap = mapAugment(fullMap, Player1.charXY[0], Player1.charXY[1], Player1.name);
                        fullMapColor = mapAugmentColor(fullMapColor, Player1.charXY[0], Player1.charXY[1], Player1.nameColor);
                    }
                    else if (commandInput == keybindsMapMaker.swingWeapon2)
                    {
                        Player1 = SwingWeapon1(Player1, 2);

                        allHitboxes.Add(new Hitbox(Player1.equip2.type,
                            Player1.equip2.name, Player1.equip2.damage,
                            Player1.equip2.range, Player1.equip2.shotSpeed,
                            Player1.direction, new int[]
                            { Player1.charXY[0], Player1.charXY[1]}, true,
                            Player1.equip2.actionsAlive));

                        if (Player1.equip2.durability == 0)
                        {
                            onScreenText = onScreenTextAugment(onScreenText, $"Your {Player1.equip2.name} broke.", 13);
                            onScreenTextColor = onScreenTextColorAugment(onScreenTextColor, "darkred", 12, 1, 100, colorChangeID);
                            Player1.equip2 = fists;
                        }

                        fullMap = mapAugment(fullMap, Player1.charXY[0], Player1.charXY[1], Player1.name);
                        fullMapColor = mapAugmentColor(fullMapColor, Player1.charXY[0], Player1.charXY[1], Player1.nameColor);
                    }

                    else if (commandInput == keybindsMapMaker.menu)
                    {
                        Console.Clear();
                        Console.WriteLine("(P)rint \n" + "Print (C)olor \n" + "(K)eybinds \n (I)nvenotry");

                        //menu
                        
                        commandInput = KeyInput().Key;

                        if (commandInput == ConsoleKey.P)
                        {
                            Console.Clear();
                            Console.WriteLine("The current map printout is: ");
                            Console.Write("{");
                            for (int i = 1; i <= fullMap.Count; i++)
                            {
                                Console.Write("{");
                                for (int j = 1; j <= fullMap[0].Count; j++)
                                {
                                    Console.Write($"\"{fullMapOrig[j - 1][i - 1]}\",");
                                }
                                Console.Write("},");
                            }
                            Console.WriteLine("};");
                            bool returnFromLoop = false;
                            while (returnFromLoop == false)
                            {
                                Console.WriteLine();
                                Console.WriteLine("etc to return to game");

                               
                                commandInput = KeyInput().Key;

                                if (commandInput == ConsoleKey.Escape) returnFromLoop = true;
                                else Console.WriteLine("incorrect input");
                            }

                        }

                        if (commandInput == ConsoleKey.C)
                        {
                            Console.Clear();
                            Console.WriteLine("The current color map printout is: ");
                            Console.Write("{");
                            for (int i = 1; i <= fullMapColor.Count; i++)
                            {
                                Console.Write("{");
                                for (int j = 1; j <= fullMapColor[0].Count; j++)
                                {
                                    Console.Write($"\"{convertColorToString(fullMapColorOrig[j - 1][i - 1])}\", ");
                                }
                                Console.Write("}, ");
                            }
                            Console.WriteLine("};");
                            bool returnFromLoop = false;
                            while (returnFromLoop == false)
                            {
                                Console.WriteLine();
                                Console.WriteLine("etc to return to game");

                                
                                commandInput = KeyInput().Key;

                                if (commandInput == ConsoleKey.Escape) returnFromLoop = true;
                                else Console.WriteLine("incorrect input");
                            }

                        }
                        if (commandInput == ConsoleKey.K)
                        {
                            keybindsMapMaker = ChangeKeybinds(keybindsMapMaker);
                        }

                        if (commandInput == ConsoleKey.I)
                        {
                            Player1 = InventoryMenu(Player1, onScreenText, onScreenTextColor, allEntities[0]);
                        }

                    }

                    //draws and activates all player hitboxes
                    
                    for(int i = 0; i <= allHitboxes.Count - 1; i++)
                    {

                        if (allHitboxes[i].isPlayerHitbox == true)
                        {

                            if (allHitboxes[i].speed >= 1)
                            {
                                allHitboxes[i].hitboxXY = hitboxMove(allHitboxes[i], fullMap, false, allHitboxes[i].direction);
                            }

                            fullMap = SwingWeapon2(allHitboxes[i], fullMap, SwingWeapon3(allHitboxes[i], fullMapHighColor));
                            fullMapHighColor = SwingWeapon3(allHitboxes[i], fullMapHighColor);

                            for (int z = 0; z < allEntities.Count; z++)
                            {

                                if (IsInRange(FindTrueRange(allHitboxes[i].direction, allHitboxes[i].range), allHitboxes[i].hitboxXY, allEntities[z].entityXY) == 1)
                                {
                                    allEntities[z].hp -= DamageRandom(allHitboxes[i].damage, 1, 0);
                                }


                                if (IsInRange(FindTrueRange(Player1.direction, Player1.equip1.range), Player1.charXY, allEntities[z].entityXY) == 2)
                                {
                                    allEntities[z].hp -= DamageRandom(allHitboxes[i].damage, 2, 0);
                                }

                            }

                            

                            allHitboxes[i].distance--;

                            if (allHitboxes[i].distance <= 0)
                            {
                                allHitboxes.RemoveAt(i);
                            }
                        }

                        
                    }
                    

                    string keybinds2 = "";
                    string addSpaces = "";
                    for (int i = 1; i <= 4; i++){
                        if(i == 1)
                        {
                            keybinds2 += "          " + keybindsMapMaker.menu.ToString();
                        }
                        if (i == 2)
                        {
                            for(int j = 1; j <= 14 - keybindsMapMaker.menu.ToString().Length; j++)
                            {
                                addSpaces += " ";
                            }
                            keybinds2 += addSpaces + keybindsMapMaker.changeName.ToString();
                            addSpaces = "";
                        }
                        if (i == 3)
                        {
                            for (int j = 1; j <= 17 - keybindsMapMaker.changeName.ToString().Length; j++)
                            {
                                addSpaces += " ";
                            }
                            keybinds2 += addSpaces + keybindsMapMaker.changeNameColor.ToString();
                            addSpaces = "";
                        }
                        if (i == 4)
                        {
                            for (int j = 1; j <= 21 - keybindsMapMaker.changeNameColor.ToString().Length; j++)
                            {
                                addSpaces += " ";
                            }
                            keybinds2 += addSpaces + keybindsMapMaker.swingWeapon1.ToString() + "/" + keybindsMapMaker.swingWeapon2.ToString();
                            addSpaces = "";
                        }
                    }

                    //what is written below the map
                    //combat log inputs
                    onScreenText = onScreenTextAugment(onScreenText, commandInput.ToString(), 13);

                    //debug
                    onScreenText = onScreenTextAugment(onScreenText, Player1.direction.ToString(), 14);

                    //player stats
                    onScreenText = onScreenTextAugment(onScreenText, $"HP: {Player1.hp} " + $"Mana: {Player1.mana}", 1);

                    //keybinds 1
                    onScreenText = onScreenTextAugment(onScreenText, "Keybinds: open menu     change name      change name color    swing weapon 1/2", 2);

                    //keybinds 2
                    onScreenText = onScreenTextAugment(onScreenText, keybinds2, 3);


                    //what color the things below the map are (original, color, priority, start, end, colorChangeID)
                    onScreenTextColor = onScreenTextColorAugment(onScreenTextColor, "red", 1, 5, 4 + Player1.hp.ToString().Length, colorChangeID);
                    colorChangeID[0]++;

                    onScreenTextColor = onScreenTextColorAugment(onScreenTextColor, "blue", 1, 12 + Player1.hp.ToString().Length, 12 + Player1.hp.ToString().Length + 4 + Player1.hp.ToString().Length, colorChangeID);
                    colorChangeID[0]++;

                    drawFrame(fullMap, Player1, mapZoom, fullMapColor, onScreenText, onScreenTextColor, fullMapHighColor, allEntities);

                    fullMapHighColor = new List<List<System.ConsoleColor>>();
                    fullMapHighColorOrig = new List<List<System.ConsoleColor>>();
                    if (fullMapHighColor.Count == 0)
                    {
                        for (int j = 0; j < 100; j++)
                        {
                            fullMapHighColor.Add(new List<ConsoleColor>());

                            for (int i = 0; i < 100; i++)
                            {
                                fullMapHighColor[j].Add(ConsoleColor.Black);
                            }

                        }
                    }
                    
                    onScreenTextColor = colorChangeIDReset1(onScreenTextColor);
                    colorChangeID = colorChangeIDReset2(colorChangeID);

                }
            }

        }
    }
}