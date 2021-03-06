﻿using System;
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
    public int shotSpeed { get; set; }
    public bool equipped { get; set; }
    public int actionsAlive { get; set; }

    public Weapon(int Durability, string Type, string Name, string Damage,
        List<List<int>> Range, bool Equipped, int ShotSpeed, int ActionsAlive)
    {
        durability = Durability;
        type = Type;
        name = Name;
        damage = Damage;
        range = Range;
        equipped = Equipped;
        shotSpeed = ShotSpeed;
        actionsAlive = ActionsAlive;
    }

}

public class Hitbox
{
    public int speed { get; set; }
    public string type { get; set; }
    public string damage { get; set; }
    public string name { get; set; }
    public List<List<int>> range { get; set; }
    public int direction { get; set; }
    public int[] hitboxXY { get; set; }
    public bool isPlayerHitbox { get; set; }
    public int distance { get; set; }

    public Hitbox( string Type, string Name, string Damage,
        List<List<int>> Range, int Speed, int Direction, int[] HitboxXY
        ,bool IsPlayerHitbox, int Distance)
    {
        
        type = Type;
        name = Name;
        damage = Damage;
        range = Range;
        speed = Speed;
        direction = Direction;
        hitboxXY = HitboxXY;
        isPlayerHitbox = IsPlayerHitbox;
        distance = Distance;
        
    }

}

   
