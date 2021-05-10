using System;
using DanhoLibrary;

namespace CleanEmotes
{
    class Christoffer
    {
        public bool NogetAtLave { get; set; }
        public void CleanEmotes()
        {
            Console.Write("Currently cleaning emotes");
            ConsoleItems.Waiting(3, 1000);
            Console.WriteLine();
            Console.WriteLine("AFK!");
            Console.ReadKey();
        }
    }
    class Program
    {
        static void Main()
        {
            Christoffer Christoffer = new Christoffer();

            if (Christoffer.NogetAtLave)
                Christoffer.CleanEmotes();
            else if (!Christoffer.NogetAtLave)
                Christoffer.CleanEmotes();
            else
                Christoffer.CleanEmotes();
        }
    }
}