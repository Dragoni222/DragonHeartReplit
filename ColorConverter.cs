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

class ColorConverterClass
{

public static string convertColorToString(ConsoleColor color)
{
    string endColor = "none";

    if (color == ConsoleColor.Black)
        endColor = "black";

    else if (color == ConsoleColor.DarkBlue)
        endColor = "darkblue";

    else if (color == ConsoleColor.DarkCyan)
        endColor = "darkcyan";

    else if (color == ConsoleColor.DarkGreen)
        endColor = "darkgreen";

    else if (color == ConsoleColor.DarkRed)
        endColor = "darkred";

    else if (color == ConsoleColor.DarkMagenta)
        endColor = "darkmagenta";

    else if (color == ConsoleColor.DarkYellow)
        endColor = "darkyellow";

    else if (color == ConsoleColor.Gray)
        endColor = "grey";

    else if (color == ConsoleColor.DarkGray)
        endColor = "darkgrey";

    else if (color == ConsoleColor.Blue)
        endColor = "blue";

    else if (color == ConsoleColor.Green)
        endColor = "green";

    else if (color == ConsoleColor.Cyan)
        endColor = "cyan";

    else if (color == ConsoleColor.Red)
        endColor = "red";

    else if (color == ConsoleColor.Yellow)
        endColor = "yellow";

    else if (color == ConsoleColor.Magenta)
        endColor = "magenta";

    else if (color == ConsoleColor.White)
        endColor = "white";


    return endColor;
}

public static ConsoleColor convertColorToConsoleColor(string color)
{
    ConsoleColor EndColor = ConsoleColor.White;

    if (color == "black")
        EndColor = ConsoleColor.Black;

    else if (color == "darkblue")
        EndColor = ConsoleColor.DarkBlue;

    else if (color == "darkcyan")
        EndColor = ConsoleColor.DarkCyan;

    else if (color == "darkgreen")
        EndColor = ConsoleColor.DarkGreen;

    else if (color == "darkred")
        EndColor = ConsoleColor.DarkRed;

    else if (color == "darkmagenta")
        EndColor = ConsoleColor.DarkMagenta;

    else if (color == "darkyellow")
        EndColor = ConsoleColor.DarkYellow;

    else if (color == "grey")
        EndColor = ConsoleColor.Gray;

    else if (color == "darkgrey")
        EndColor = ConsoleColor.DarkGray;

    else if (color == "blue")
        EndColor = ConsoleColor.Blue;

    else if (color == "green")
        EndColor = ConsoleColor.Green;

    else if (color == "cyan")
        EndColor = ConsoleColor.Cyan;

    else if (color == "red")
        EndColor = ConsoleColor.Red;

    else if (color == "yellow")
        EndColor = ConsoleColor.Yellow;

    else if (color == "magenta")
        EndColor = ConsoleColor.Magenta;

    else if (color == "white")
        EndColor = ConsoleColor.White;
    return EndColor;
}

}