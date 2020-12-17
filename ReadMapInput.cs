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
        int arrayY = 0;
        bool inQuote = false;

        for (int i = 0; i <= newString.Length - 1; i++)
        {


                if (newString[i].ToString() == "\"")
                {
                    if (inQuote == false)
                    {
                        inQuote = true;
                    }

                    else if (inQuote == true)
                    {
                        inQuote = false;
                    }

                }

                else if (newString[i].ToString() == "}")
                {
                    arrayX++;
                    arrayY = 0;
                }

                else if (newString[i].ToString() == ",")
                    arrayY++;

                else if (inQuote == true && newString[i].ToString() != " " && newString[i].ToString() != ";")
                {
                    original[arrayX][arrayY] = newString[i].ToString();

                }
                else if (newString[i].ToString() == "{")
                    arrayY = 0;

        }

        return original;
    }

    public static List<List<ConsoleColor>> readFullMapColor(List<List<ConsoleColor>> original, string newString)
    {
        int arrayX = 0;
        int arrayY = 0;
        bool inQuote = false;
        string addedTogether = "";
        StringBuilder sb = new StringBuilder(addedTogether, 50);


        for (int i = 0; i <= newString.Length - 1; i++)
        {
        
        if (newString[i].ToString() == "\"")
        {
                if (inQuote == false)
            {
                inQuote = true;
            }

            else if (inQuote == true)
            {

                addedTogether = sb.ToString();
                inQuote = false;
                original[arrayX][arrayY] = convertColorToConsoleColor(addedTogether);
                sb = new StringBuilder();
                
            }
        }
        
        else if (newString[i].ToString() == "}")
        {
            arrayX++;
            arrayY = -1;
        }
        else if (newString[i].ToString() == ",")
            arrayY++;

        else if (inQuote == true &&  newString[i].ToString() != " "&& newString[i].ToString() != ";")
        {
            
            sb.Append(newString[i]);
              
            
        }

        else if (newString[i].ToString() == "{")
                arrayY = 0;
        }

        return original;
    }

}