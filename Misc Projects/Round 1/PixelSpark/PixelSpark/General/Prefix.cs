using System;

namespace PixelSpark.General
{
    public class Prefix
    {
        public Prefix(string Prefix, string Bracket, string PrefixColor, string TextColor)
        {
            this.Bracket = SetPresetColors(Bracket);
            this.PrefixColor = SetPresetColors(PrefixColor);
            PrefixString = Prefix;
            this.TextColor = SetPresetColors(TextColor);
        }

        public string PrefixString { get; set; }
        public ConsoleColor Bracket { get; set; }
        public ConsoleColor PrefixColor { get; set; }
        public ConsoleColor TextColor { get; set; }

        private ConsoleColor SetPresetColors(string Color)
        {
            Color = Color.ToLower();

            switch (Color)
            {
                case "0":
                    return ConsoleColor.Black;
                case "1":
                    return ConsoleColor.DarkBlue;
                case "2":
                    return ConsoleColor.DarkGreen;
                case "3":
                    return ConsoleColor.DarkCyan;
                case "4":
                    return ConsoleColor.DarkRed;
                case "5":
                    return ConsoleColor.DarkMagenta;
                case "6":
                    return ConsoleColor.DarkYellow;
                case "7":
                    return ConsoleColor.Gray;
                case "8":
                    return ConsoleColor.DarkGray;
                case "9":
                    return ConsoleColor.Blue;
                case "a":
                    return ConsoleColor.Green;
                case "b":
                    return ConsoleColor.Cyan;
                case "c":
                    return ConsoleColor.Red;
                case "d":
                    return ConsoleColor.Magenta;
                case "e":
                    return ConsoleColor.Yellow;
                case "f":
                    return ConsoleColor.White;
                default:
                    return ConsoleColor.White;
            }
        }
    }
}