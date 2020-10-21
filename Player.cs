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

public class Player
{
  public int hp { get; set; }
  public int mana { get; set; }
  public string name { get; set; }
  public ConsoleColor nameColor { get; set; }
  public int[] charXY { get; set; }

  public Player(int HP, string Name, int[] CharXY, ConsoleColor NameColor,
      int Mana)
  {

      hp = HP;
      name = Name;
      charXY = CharXY;
      nameColor = NameColor;
      mana = Mana;
  }

}