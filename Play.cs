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

class PlayClass
{

  public static void Play(List<List<string>> fullMap,
    List<List<string>> fullMapOrig, string[] onScreenText, Player Player1,
    List<List<System.ConsoleColor>> fullMapColor, List<List<System.ConsoleColor>> fullMapColorOrig)
  {
    int[] colorChangeID = new int[14];

    for (int o = 1; o <= colorChangeID.Length; o++)
    {
        colorChangeID[o - 1] = 0;
    }

    string debug = "";




    List<string[]>[] onScreenTextColor = new List<string[]>[14];


    //onScreenTextColor instantiator adds characters so the map doesn't run out of room
    onScreenTextColor = colorChangeIDReset1(onScreenTextColor);

    fullMapColorOrig = fullMapColor;

    //the zoom of the map, in the length of one side, make sure it's odd
    int mapZoom = 21;
    bool onTitleScreen = true;
    bool ghost;

    while(onTitleScreen == true)
    {
      Console.WriteLine("Enter password for dev map maker, or settings for settings");
      string readLine = Console.ReadLine();

      //to skip
      if (readLine == "settings")
      {
        Console.WriteLine("    Settings\nInsert (m)ap\n(K)eybinds");
        ConsoleKey input = KeyInput().Key;
        if(input == ConsoleKey.M)
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

          fullMap = mapAugment(fullMapOrig, Player1.charXY[0], Player1.charXY[1], Player1.name);
          fullMapColor = mapAugmentColor(fullMapColorOrig, Player1.charXY[0], Player1.charXY[1], Player1.nameColor);

          drawFrame(fullMap, Player1, mapZoom, fullMapColor, onScreenText, onScreenTextColor);

          bool placeBlock = false;
          bool placeColor = false;

          while (true)
          {
              fullMap = fullMapOrig;

              //prioirty order for inputs: WASD, paint commands, explicit commands, unnamed command
              var commandInput2 = KeyInput();
              var commandInput = commandInput2.Key;

              if (commandInput == ConsoleKey.W || commandInput == ConsoleKey.A ||
                  commandInput == ConsoleKey.S || commandInput == ConsoleKey.D)
              {
                  //move

                  if (placeBlock == true)
                  {
                      fullMapOrig = mapAugment(fullMapOrig, Player1.charXY[0], Player1.charXY[1], Player1.name);
                  }
                  if (placeColor == true)
                  {
                      fullMapColorOrig = mapAugmentColor(fullMapColorOrig, Player1.charXY[0], Player1.charXY[1], Player1.nameColor);
                  }

                  int[] prevCharXY = { 1, 0 };
                  prevCharXY[1] = Player1.charXY[1];
                  prevCharXY[0] = Player1.charXY[0];
    
                  Player1.charXY = charMove(Player1, commandInput, fullMap, ghost);

                  if (Player1.charXY[1] == prevCharXY[1] && Player1.charXY[0] == prevCharXY[0])
                  {
                       onScreenText = onScreenTextAugment(onScreenText, "you cannot move there", 13);
                       onScreenTextColor = onScreenTextColorAugment(onScreenTextColor, "red", 12, 1, 21, colorChangeID);
                  }

                  if (placeBlock == false)
                  {
                       fullMap = mapAugment(fullMap, prevCharXY[0], prevCharXY[1],
                        fullMapOrig[prevCharXY[1]][prevCharXY[0]]);
                            
                        
                  }

                  if (placeColor == false)
                  {
                      fullMapColor = mapAugmentColor(fullMapColor, prevCharXY[0], prevCharXY[1],
                          fullMapColorOrig[prevCharXY[1]][prevCharXY[0]]);

                  }

                  

                  placeColor = false;
                  placeBlock = false;

                  fullMap = mapAugment(fullMap, Player1.charXY[0], Player1.charXY[1], Player1.name);

                  fullMapColor = mapAugmentColor(fullMapColor, Player1.charXY[0], Player1.charXY[1], Player1.nameColor);



              }

              else if (commandInput == ConsoleKey.T)
              {
                  //set placeable block
                  Player1.name = changeName();
                  //redraw character
                  fullMap = mapAugment(fullMap, Player1.charXY[0], Player1.charXY[1], Player1.name);

              }
              else if (commandInput == ConsoleKey.Y)
              {
                  //set paint
                  Player1.nameColor = changeNameColor();
                  //redraw character
                  fullMapColor = mapAugmentColor(fullMapColor, Player1.charXY[0], Player1.charXY[1], Player1.nameColor);

              }
              else if (commandInput == ConsoleKey.Q || commandInput == ConsoleKey.E)
              {
                        //place/paint block

                  if (commandInput == ConsoleKey.E)
                  {
                            placeBlock = true;
                            placeColor = true;
                  }
                  if (commandInput == ConsoleKey.Q)
                  {
                      placeColor = true;
                  }
                  

              }

              else if (commandInput == ConsoleKey.L)
              {
                        int lineLength = 0;
                        int direction = 0;
                        // north = 1, east 2, south 3, west 0

                        Console.Clear();
                        Console.WriteLine("(L)ine and (S)quare Drawing.");

                        commandInput = KeyInput().Key;

                        if(commandInput == ConsoleKey.L)
                        {
                            Console.Write("input the length first, then the " +
                                "direction of line. It will draw starting with " +
                                "the square next to you. \n length: ");
                            lineLength = int.Parse(Console.ReadLine());
                            Console.Write("\n north = 1, east 2, south 3, west 0 direction: ");
                            direction = int.Parse(Console.ReadLine());
                            for(int i = 0; i < lineLength; i++)
                            {
                                if (direction == 0)
                                {
                                    fullMapOrig = mapAugment(fullMapOrig, Player1.charXY[0] - i,
                                        Player1.charXY[1], Player1.name);
                                    fullMapColorOrig = mapAugmentColor(fullMapColorOrig,
                                        Player1.charXY[0] - i, Player1.charXY[1], Player1.nameColor);
                                }
                                if (direction == 1)
                                {
                                    fullMapOrig = mapAugment(fullMapOrig, Player1.charXY[0],
                                        Player1.charXY[1] - i, Player1.name);
                                    fullMapColorOrig = mapAugmentColor(fullMapColorOrig,
                                        Player1.charXY[0], Player1.charXY[1] - i, Player1.nameColor);
                                }
                                if (direction == 2)
                                {
                                    fullMapOrig = mapAugment(fullMapOrig, Player1.charXY[0] + i,
                                        Player1.charXY[1], Player1.name);
                                    fullMapColorOrig = mapAugmentColor(fullMapColorOrig,
                                        Player1.charXY[0] + i, Player1.charXY[1], Player1.nameColor);
                                }
                                if (direction == 3)
                                {
                                    fullMapOrig = mapAugment(fullMapOrig, Player1.charXY[0] + i,
                                        Player1.charXY[1] - i, Player1.name);
                                    fullMapColorOrig = mapAugmentColor(fullMapColorOrig,
                                        Player1.charXY[0], Player1.charXY[1] - i, Player1.nameColor);
                                }
                            }


                        }
              }
              else if (commandInput == ConsoleKey.Escape)
              {
                  Console.Clear();
                  Console.WriteLine("(P)rint \n" +
                                    "Print (C)olor \n" +
                                    "");

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
                              Console.Write($"\"{fullMap[j - 1][i - 1]}\",");
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

                          if (commandInput == ConsoleKey.Escape)
                              returnFromLoop = true;
                          else
                              Console.WriteLine("incorrect input");
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
                              Console.Write($"\"{convertColorToString(fullMapColor[j - 1][i - 1])}\", ");
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

                          if (commandInput == ConsoleKey.Escape)
                              returnFromLoop = true;
                          else
                              Console.WriteLine("incorrect input");
                      }

                  }

              }
              //what is written below the map
              onScreenText = onScreenTextAugment(onScreenText, commandInput.ToString(), 13);

              onScreenText = onScreenTextAugment(onScreenText, debug, 14);

              onScreenText = onScreenTextAugment(onScreenText, $"HP: {Player1.hp} " +
                  $"Mana: {Player1.mana}", 1);

              //what color the things below the map are (original, color, priority, start, end, colorChangeID)
              onScreenTextColor = onScreenTextColorAugment(onScreenTextColor,
                  "red", 1, 5, 4 + Player1.hp.ToString().Length, colorChangeID);
              colorChangeID[0]++;

              onScreenTextColor = onScreenTextColorAugment(onScreenTextColor,
                  "blue", 1, 12 + Player1.hp.ToString().Length, 12 +
                  Player1.hp.ToString().Length + 4 + Player1.hp.ToString().Length, colorChangeID);
              colorChangeID[0]++;

              drawFrame(fullMap, Player1, mapZoom, fullMapColor, onScreenText, onScreenTextColor);

              onScreenTextColor = colorChangeIDReset1(onScreenTextColor);
              colorChangeID = colorChangeIDReset2(colorChangeID);

          }
      }

    }
  }
}