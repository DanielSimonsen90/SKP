using System;
using System.Threading;

namespace Guess_number
{
    class Program
    {
        static readonly Game Game = new Game();
        static void Main()
        {
            while(true)
            {
                switch (MainMenu())
                {
                    default: Game.Play(); break;
                    case 2: Game.Highscore.View(); break;
                    case 3: HowToPlay(); break;
                    case 4: Exit(); break;
                }
                Console.Clear();
            }
        }

        private static int MainMenu()
        {
            string[] Options = { "Play", "View Highscore", "How to play", "Exit" };
            for (int x = 0; x < Options.Length; x++)
                Console.WriteLine($"[{x + 1}]: {Options[x]}");
            for (int x = 0; x < 2; x++)
                Console.WriteLine();
            var Request = Console.ReadLine();
            Console.Clear();
            try { return Convert.ToInt32(Convert.ToInt32(Request)); }
            catch { return MainMenu(); }
        }
        private static void HowToPlay()
        {
            Console.WriteLine("To play, all you have to do is insert a number between 1 - 10. Simply insert your guess, and navigate yourself towards the correct answer.");
            Console.WriteLine("You're able to view your highscores so you can remember how good you are ;)");
            Console.WriteLine("Have fun!");
            Console.ReadKey(true);
        }
        private static void Exit()
        {
            Console.WriteLine("Thank you for playing!");
            for (int x = 0; x < 3; x++)
                Console.WriteLine();
            Console.WriteLine("Have a good one!");
            Thread.Sleep(3000);
            Environment.Exit(0);
        }
    }
}
