using System;

namespace PixelSpark.General
{
    public class Trainer : Player
    {
        public Trainer(string Name) : base(Name)
        {
            Prefix = new Prefix("Trainer", "7", "f", "f");
            SetHomes = DonatorCommands.SetHomes;
            Rank = new Trainer(Name);
        }

        public Commands.Donations DonatorCommands = new Commands.Donations();
        public Prefix Prefix { get; set; }
        public int SetHomes { get; set; }

        public override void SendMessage(string Message)
        {
            Console.ForegroundColor = Prefix.Bracket;
            Console.Write("[");

            Console.ForegroundColor = Prefix.PrefixColor;
            Console.Write(Prefix.PrefixString);

            Console.ForegroundColor = Prefix.Bracket;
            Console.Write("]");

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(": ");

            Console.ForegroundColor = Prefix.TextColor;
            Console.WriteLine(Message);
        }
    }
}
