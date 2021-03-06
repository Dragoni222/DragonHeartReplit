using System;
using static ItemEffect;
public class UseItemClass
{
    public static Player UseItem(Items item, Player Player1)
    {
        if(item.name == "Health Potion")
        {
            Player1 = Heal(Player1, 25);
        }

        if(item.name == "Mana Potion")
        {
            Player1 = ManaHeal(Player1, 25);
        }
        if(item.name == "Roll")
        {
            Player1 = ManaHeal(Player1, 10);
            Player1 = Heal(Player1, 10);
        }

        return Player1;
    }
}

public class ItemEffect
{
    public static Player Heal(Player target, int amount)
    {
        if(target.hp + amount <= target.maxHp)
            target.hp += amount;
        else
        {
            target.hp = target.maxHp;
        }
        return target;
    }
    public static Player ManaHeal(Player target, int amount)
    {
        if (target.mana + amount <= target.maxMp)
            target.mana += amount;
        else
        {
            target.mana = target.maxMp;
        }
        return target;
    }


    public ItemEffect()
    {

    }

}

