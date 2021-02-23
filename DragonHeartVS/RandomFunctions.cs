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
using System.Threading;

public class RandomFunctions
{
    public static int DamageRandom(string damage, int critMulti, int critAdd)
    {
        var rand = new Random();
        int totalDamage = 0;
        bool isInt = true;
        int totalInts = -1;
        int totalIntsFirstNumber = -1;
        string damageRoll = "         ";
        int addToTotalDamage = 0;
        int[] test = new int[2];
        int[] testFirstNumber = new int[2];
        string rollCount = "          ";
        int trueRollCount = 0;
        while (isInt == true)
        {
            isInt = Int32.TryParse(damage[totalInts + 3].ToString(),
                out test[totalInts + 1]);
            totalInts++;


        }
        for (int i = 0; i <= totalInts-1; i++)
        {
            damageRoll += test[i].ToString();
        }

        isInt = true;

        while (isInt == true)
        {
            isInt = Int32.TryParse(damage[totalIntsFirstNumber + 1].ToString(),
                out testFirstNumber[totalIntsFirstNumber + 1]);
            totalIntsFirstNumber++;


        }
        for (int i = 0; i <= totalIntsFirstNumber - 1; i++)
        {
            rollCount += testFirstNumber[i].ToString();
        }

        Int32.TryParse(rollCount, out trueRollCount);

        for (int i = 0; i <= trueRollCount - 1; i++)
        {
            Int32.TryParse(damageRoll, out addToTotalDamage);
            totalDamage += rand.Next(1, addToTotalDamage); 
            addToTotalDamage = 0;
        }
        
        totalDamage += critAdd;
        totalDamage = totalDamage * critMulti;

        return totalDamage;


	}
}
