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

public class Player
{
  public int hp { get; set; }
  public int mana { get; set; }
  public string name { get; set; }
  public ConsoleColor nameColor { get; set; }
  public int[] charXY { get; set; }
  public Items[] itemInventory { get; set; }
  public Weapon[] weaponInventory { get; set; }
  public Weapon equip1 { get; set; }
  public Weapon equip2 { get; set; }

    public Player(int HP, string Name, int[] CharXY, ConsoleColor NameColor,
      int Mana, Items[] ItemInventory, Weapon[] WeaponInventory, Weapon Equip1,
      Weapon Equip2)
  {

      hp = HP;
      name = Name;
      charXY = CharXY;
      nameColor = NameColor;
      mana = Mana;
      itemInventory = ItemInventory;

  }

}