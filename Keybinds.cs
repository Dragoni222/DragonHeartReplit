using System;
namespace DragonHeartWithGit.DragonHeartReplit
{
    public class Keybinds
    {
        public ConsoleKey menu { get; set; }

        public ConsoleKey up { get; set; }
        public ConsoleKey down { get; set; }
        public ConsoleKey left { get; set; }
        public ConsoleKey right { get; set; }

        public ConsoleKey changeName { get; set; }
        public ConsoleKey changeNameColor { get; set; }

        public ConsoleKey placeBlock { get; set; }
        public ConsoleKey placeColor { get; set; }
        public ConsoleKey makeLineSquare { get; set; }

        public ConsoleKey swingWeapon1 { get; set; }
        public ConsoleKey swingWeapon2 { get; set; }

        public Keybinds(ConsoleKey Menu, ConsoleKey Up, ConsoleKey Down,
            ConsoleKey Left, ConsoleKey Right, ConsoleKey ChangeName,
            ConsoleKey ChangeNameColor, ConsoleKey PlaceBlock,
            ConsoleKey PlaceColor, ConsoleKey MakeLineSquare,
            ConsoleKey SwingWeapon1, ConsoleKey SwingWeapon2)
        {
            menu = Menu;
            up = Up;
            down = Down;
            left = Left;
            right = Right;
            changeName = ChangeName;
            changeNameColor = ChangeNameColor;
            placeBlock = PlaceBlock;
            placeColor = PlaceColor;
            makeLineSquare = MakeLineSquare;
            swingWeapon1 = SwingWeapon1;
            swingWeapon2 = SwingWeapon2;

        }

    }
}
