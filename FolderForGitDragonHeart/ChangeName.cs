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

class ChangeNameClass
{

public static string changeName()
  {
      string name;

      Console.Clear();

      Console.WriteLine("What is your name (one character only)");

      ConsoleKeyInfo cki = KeyInput();

      if ((cki.Modifiers & ConsoleModifiers.Shift) != 0)
      {
          char uncapped = cki.KeyChar;
          name = char.ToUpper(uncapped).ToString();
      }
      else
      {
          name = cki.KeyChar.ToString();
      }
      return name;
  }


  public static ConsoleColor changeNameColor()
  {
      ConsoleColor nameColor = ConsoleColor.DarkGreen;

      string name;

      bool isActualColor = false;
      while (isActualColor == false)
      {
          Console.Clear();

          Console.WriteLine("What is your Color? ");

          ConsoleKeyInfo cki = KeyInput();

          name = cki.KeyChar.ToString();



          if (name == "b")
          {
              nameColor = ConsoleColor.DarkBlue;
              isActualColor = true;
          }
          else if (name == "g")
          {
              nameColor = ConsoleColor.DarkGreen;
              isActualColor = true;
          }
          else if (name == "r")
          {
              nameColor = ConsoleColor.DarkRed;
              isActualColor = true;
          }
          else if (name == "m")
          {
              nameColor = ConsoleColor.DarkMagenta;
              isActualColor = true;
          }
          else if (name == "y")
          {
              nameColor = ConsoleColor.DarkYellow;
              isActualColor = true;
          }
          else if (name == "c")
          {
              nameColor = ConsoleColor.DarkCyan;
              isActualColor = true;
          }
          else
          {
              Console.WriteLine("that's not an acceptable color");
          }
      }

      return nameColor;
  }

  }