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
    public int maxHp { get; set; }
    public int mana { get; set; }
    public int maxMp { get; set; }
    public int direction { get; set; }
  public string name { get; set; }
  public ConsoleColor nameColor { get; set; }
  public int[] charXY { get; set; }
  public List<Items> itemInventory { get; set; }
  public List<Weapon> weaponInventory { get; set; }
  public Weapon equip1 { get; set; }
  public Weapon equip2 { get; set; }
    public List<double> maxEnergy { get; set; }


    public Player(int HP, string Name, int Direction,int[] CharXY, ConsoleColor NameColor,
      int Mana, List<Items> ItemInventory, List<Weapon> WeaponInventory, Weapon Equip1,
      Weapon Equip2, List<double> MaxEnergy)
  {

      hp = HP;
      name = Name;
        direction = Direction;
      charXY = CharXY;
      nameColor = NameColor;
      mana = Mana;
      itemInventory = ItemInventory;
        weaponInventory = WeaponInventory;
        equip1 = Equip1;
        equip2 = Equip2;
        maxHp = 100;
        maxMp = 100;
        maxEnergy = MaxEnergy;

  }

} 