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

public class RandomFunctions
{
	public static int DamageRandom(string damage)
	{
		var rand = new Random();
		int totalDamage = 0;
		bool isInt = true;
		int totalInts = -1;
		string damageRoll = "";
		int addToTotalDamage = 0;
		int test;

		while(isInt == true)
        {
			isInt = Int32.TryParse(damage[totalInts + 3].ToString(), out test);
			totalInts++;
			damageRoll.Insert(totalInts, test.ToString());
			
        }
		for(int i = 0; i<=totalInts; i++)
        {
			
        }
		for(int i = 0; i<=damage[0] - 1; i++)
        {
			Int32.TryParse(damageRoll, out addToTotalDamage);
			addToTotalDamage = rand.Next(1, addToTotalDamage);
			totalDamage += addToTotalDamage;
			addToTotalDamage = 0;
        }

		return totalDamage;
	}
}
