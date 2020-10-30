using System;

namespace PixelSpark
{
    public class Player : General.Commands.General
    {
        public Player(string Name)
        {
            this.Name = Name;
        }

        public string Name { get; set; }
        public object Rank { get; set; }

        public override void SendMessage(string Message)
        {
            Console.WriteLine($"[Player]: {Message}");
        }
    }
}