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

class ReadMapInputClass
{

public static List<List<string>> readFullMap(List<List<string>> original, string newString)

{
    int arrayX = 0;

    bool inQuote = false;

    for (int i = 0; i <= newString.Length - 1; i++)
    {
        if (newString[i].ToString() == "{")
        {
            if (i != 0)
                arrayX++;
        }

        else if (newString[i].ToString() == "\"")
        {
            if (inQuote == false)
            {
                inQuote = true;
            }

            if (inQuote == true)
            {
                inQuote = false;
            }

        }

        else if (inQuote == true && newString[i].ToString() != "," && newString[i].ToString() == " ")
        {
            original[arrayX][i] = newString[i].ToString();
        }
    }

    return original;
}

public static List<List<ConsoleColor>> readFullMapColor(List<List<ConsoleColor>> original, string newString)
{
    int arrayX = 0;
    bool inQuote = false;
    string addedTogether = "";
    string addedTogetherConvertable = "                            ";
    int pos1;
    int pos2;

    for (int i = 0; i <= newString.Length - 1; i++)
    {
        if (newString[i].ToString() == "{")
        {
            if (i != 0)
                arrayX++;
        }
        else if (newString[i].ToString() == "\"")
        {
             if (inQuote == false)
            {
                inQuote = true;
            }

            if (inQuote == true)
            {
              
              for(int j = 1; j <= pos2-pos1; j++)
              {
                addedTogetherConvertable[i] = addedTogether[j+13];
              }

              addedTogetherConvertable = addedTogether[13].ToLower() + addedTogetherConvertable;
                inQuote = false;
                original[arrayX, i] = convertColorToConsoleColor(addedTogetherConvertable);
            }
        }
        


        else if (newString[i].ToString() != "," && newString[i].ToString() == " ")
        {
            if (inQuote == true)
                addedTogether += newString[i];
        }
    }

    return original;
}

}