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

/*
  (☞ﾟヮﾟ)☞ ☜(ﾟヮﾟ☜)
*/


  class MainClass
  {

      //main
      public static void Main(string[] args)
      {

          List<List<string>> fullMap = new List<List<string>>();
          List<List<string>> fullMapOrig = new List<List<string>>();

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
                          fullMap[j].Add("#");
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



          Player Player1 = new Player(100, "Y", new int[] { 50, 50 }, ConsoleColor.DarkGreen, 100);

          List<List<System.ConsoleColor>> fullMapColor = new List<List<System.ConsoleColor>>();
          List<List<System.ConsoleColor>> fullMapColorOrig = new List<List<System.ConsoleColor>>();



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
          //plays the game
          Play(fullMap, fullMapOrig, onScreenText, Player1, fullMapColor, fullMapColorOrig);




      }


      //the ingame function
      

      //move character pos with an input of character x and y in an array
      

      //writes the map onscreen everytime called
      






      //changes the map on a specified coord
      



      



      //short program that when called detects what key is being pressed
      

      

  //changes name
  

  

  

  




}







