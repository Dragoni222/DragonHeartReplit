using System;

class KeyInputClass
{

public static ConsoleKeyInfo KeyInput()
{

    ConsoleKeyInfo input = new ConsoleKeyInfo();

    int i = 0;

    while (Console.KeyAvailable == false && i < 1000)
    {
        i++;
    }


    input = Console.ReadKey(true);


    return input;





}

}