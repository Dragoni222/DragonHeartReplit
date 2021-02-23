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



    
public class Entities 
{
    public string name { get; set; }
    public Items[] itemInventory { get; set; }
    public Weapon[] weaponInventory { get; set; }
    public int[] entityXY { get; set; }
    public int hp { get; set; }
    public ConsoleColor nameColor { get; set; }
    public string trueName { get; set; }

    public Entities(Items[] ItemInventory, Weapon[] WeaponInventory, string Name,
        int[] EntityXY, int Hp, ConsoleColor NameColor, string TrueName)
    {
        name = Name;
        trueName = TrueName;
        itemInventory = ItemInventory;
        weaponInventory = WeaponInventory;
        entityXY = EntityXY;
        hp = Hp;
        nameColor = NameColor;
    }
}

class DrawEntities
{
    public static List<List<string>> DrawAllEntities(List<List<string>> fullMap,
        List<Entities> allEntities, Player Player1)
    {
        fullMap = mapAugment(fullMap, Player1.charXY[0], Player1.charXY[1],
            Player1.name);

        for(int i = 0; i < allEntities.Count; i++)
        {
            fullMap = mapAugment(fullMap, allEntities[i].entityXY[0],
                allEntities[i].entityXY[1], allEntities[i].name);
        }

        return fullMap;
    }

    public static List<List<ConsoleColor>> DrawAllEntitiesColor(List<List<ConsoleColor>> fullMapColor,
        List<Entities> allEntities, Player Player1)
    {
        fullMapColor = mapAugmentColor(fullMapColor, Player1.charXY[0],
            Player1.charXY[1], Player1.nameColor);

        for (int i = 0; i < allEntities.Count; i++)
        {
            fullMapColor = mapAugmentColor(fullMapColor, allEntities[i].entityXY[0],
                allEntities[i].entityXY[1], allEntities[i].nameColor);
        }

        return fullMapColor;
    }
};


