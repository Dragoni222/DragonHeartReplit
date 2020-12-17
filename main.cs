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
using DragonHeartWithGit.DragonHeartReplit;
using System.Text;

/*
  (☞ﾟヮﾟ)☞ ☜(ﾟヮﾟ☜)
*/


  class MainClass
  {

      //main
      public static void Main(string[] args)
      {
        Weapon woodenShortsword = new Weapon(100, "slash", "wooden shortsword",
            "1d6", new List<List<int>>{ new List<int>(){1,2,1},
                new List<int>() { 0, 1, 0 }, new List<int>() { 0, 0, 0 } });

        Weapon woodenClub = new Weapon(100, "bludge", "wooden club",
            "1d5", new List<List<int>>{ new List<int>(){1,2,1},
                new List<int>() { 0, 1, 0 }, new List<int>() { 0, 0, 0 } });



        List<List<string>> fullMap = new List<List<string>>();
          List<List<string>> fullMapOrig = new List<List<string>>();

        Items[] playerStartingItems = { new Items(1, "Potion", "Health Potion"), new Items(2, "Potion", "Mana Potion"), new Items(4, "Food", "Roll") };

        Weapon[] playerStartingWeapons = { woodenShortsword, woodenClub };
        //if not, add a base map color so the game doesn't break
        if (fullMap.Count == 0)
          {
              for (int j = 0; j < 100; j++)
              {
                  fullMap.Add(new List<string>());

                  for (int i = 0; i < 100; i++)
                  {
                      if (i % ((j % 2) + 1) == 0)
                      {
                          fullMap[j].Add(" ");
                      }
                      else
                      {
                          fullMap[j].Add("0");
                      }
                  }

              }
          }
          fullMapOrig = fullMap;
          string[] onScreenText = new string[14];



          Player Player1 = new Player(100, "Y", 1, new int[] { 50, 50 },
              ConsoleColor.DarkGreen, 100, playerStartingItems, playerStartingWeapons,
              playerStartingWeapons[0], playerStartingWeapons[1]);
        

        List<List<System.ConsoleColor>> fullMapColor = new List<List<System.ConsoleColor>>();
          List<List<System.ConsoleColor>> fullMapColorOrig = new List<List<System.ConsoleColor>>();

        List<List<System.ConsoleColor>> fullMapHighColor = new List<List<System.ConsoleColor>>();
        List<List<System.ConsoleColor>> fullMapHighColorOrig = new List<List<System.ConsoleColor>>();

        

        //if not, add a base map so the game doesn't break
        if (fullMapColor.Count == 0)
          {
              for (int j = 0; j < 100; j++)
              {
                  fullMapColor.Add(new List<ConsoleColor>());

                  for (int i = 0; i < 100; i++)
                  {
                      if (i % ((j % 2) + 1) == 0)
                      {
                          fullMapColor[j].Add(ConsoleColor.Black);

                      }
                      else
                      {
                          fullMapColor[j].Add(ConsoleColor.White);
                      }
                  }

              }
          }

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
        //plays the game
        Play(fullMap, fullMapOrig, onScreenText, Player1, fullMapColor, fullMapColorOrig, fullMapHighColor, fullMapHighColorOrig);




      }


      //the ingame function
      

      //move character pos with an input of character x and y in an array
      

      //writes the map onscreen everytime called
      






      //changes the map on a specified coord
      



      



      //short program that when called detects what key is being pressed
      

      

  //changes name
  

  

  

  




}






