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

namespace DragonHeartWithGit.DragonHeartReplit
{
    public class Items
    {
        public int amount { get; set; }
        public string type { get; set; }
        public string name { get; set; }


        public Items(int Amount, string Type, string Name)
        {
            amount = Amount;
            type = Type;
            name = Name;
        }
    }

    public class Weapon
    {
        public int durability { get; set; }
        public string type { get; set; }
        public string damage { get; set; }
        public string name { get; set; }
        public List<List<int>> range { get; set; }
        public bool equipped { get; set; }

        public Weapon(int Durability, string Type, string Name, string Damage,
            List<List<int>> Range, bool Equipped)
        {
            durability = Durability;
            type = Type;
            name = Name;
            damage = Damage;
            range = Range;
            equipped = Equipped;
        }

    }

    



}
