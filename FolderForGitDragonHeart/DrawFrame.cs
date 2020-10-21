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

class DrawFrameClass
{

public static void drawFrame(List<List<string>> fullMap, Player Player1,
      int zoom, List<List<ConsoleColor>> fullColorMap, string[] textString, List<string[]>[] onScreenTextColor)
  {


  Console.Clear();
  mapPrint(zoom, fullMap, Player1, fullColorMap);

  onScreenTextPrint(textString, onScreenTextColor);



}


public static void mapPrint(int zoom, List<List<string>> fullMap,
      Player Player1, List<List<System.ConsoleColor>> fullColorMap)
  {
      //another i counter
      int j = 0;

      //writing map
      for (int i = 0; (i + 1) * (j + 1) <= zoom * zoom; i++)
      {

          //checks if page wrap
          if (i != zoom)
          {
              //checks if is outside or array range

              if (j + 1 <= fullMap.Count)
              {

                  if (i < fullMap[j].Count)
                  {
                      Console.ForegroundColor = fullColorMap[Player1.charXY[1] + j - ((zoom - 1) / 2)][Player1.charXY[0] + i - ((zoom - 1) / 2)];

                      Console.Write(fullMap[Player1.charXY[1] + j - ((zoom - 1) / 2)][Player1.charXY[0] + i - ((zoom - 1) / 2)] + " ");

                      Console.ResetColor();


                  }

              }
          }
          else
          {
              //resets and goes to next line
              j++;
              i = 0;
              Console.WriteLine();

              //Make sure J doesn't go out of bounds

              if (j + 1 <= fullMap.Count)
              {

                  if (i < fullMap[j].Count)
                  {
                      Console.ForegroundColor = fullColorMap[Player1.charXY[1] + j - ((zoom - 1) / 2)][Player1.charXY[0] + i - ((zoom - 1) / 2)];

                      Console.Write(fullMap[j + Player1.charXY[1] - ((zoom - 1) / 2)][i + Player1.charXY[0] - ((zoom - 1) / 2)] + " ");

                      Console.ResetColor();

                  }

              }
          }





      }

      Console.WriteLine();
  }



  public static void onScreenTextPrint(string[] textString1, List<string[]>[] colorList)
{
  List<string> colorLetter;

  string[] textString = new string[14];

  for (int l = 0; l <= textString1.Length - 1; l++)
      if (textString1[l] != null)
          textString[l] = textString1[l];

      else
          textString[l] = "none";

  for (int i = 1; i <= textString.Length; i++)
  {
      colorLetter = new List<string>();

      if (colorList.Length >= i)
      {
          for (int j = 0; j <= colorList[i - 1].Count - 1; j++)
          {
              for (int k = 1; k <= textString[i - 1].Length; k++)
              {
                  Console.ResetColor();
                  if (!IsDigitsOnly(colorList[i - 1][j][0]))
                      colorList[i - 1][j][0] = "0";

                  if (!IsDigitsOnly(colorList[i - 1][j][1]))
                      colorList[i - 1][j][1] = "0";

                  if (int.Parse(colorList[i - 1][j][0]) <= k && int.Parse(colorList[i - 1][j][1]) >= k)
                  {
                      for (int m = 1; m <= int.Parse(colorList[i - 1][j][0]); m++)
                      {
                          if (colorLetter.Count < int.Parse(colorList[i - 1][j][0]) - 1)
                          {
                              colorLetter.Add("none");
                          }
                      }

                      colorLetter.Add(colorList[i - 1][j][2]);


                  }

              }





          }

      }


      for (int k = 1; k <= textString[i - 1].Length; k++)
      {
          if (colorLetter.Count >= k)
          {
              if (colorLetter[k - 1] != "none")
                  Console.BackgroundColor = convertColorToConsoleColor(colorLetter[k - 1]);

          }
          Console.Write(textString[i - 1][k - 1]);
          Console.ResetColor();

      }
      Console.WriteLine();

      Console.ResetColor();

  }
}
public static bool IsDigitsOnly(string str)
{
  foreach (char c in str)
  {
      if (c < '0' || c > '9')
          return false;
  }

  return true;
}

}