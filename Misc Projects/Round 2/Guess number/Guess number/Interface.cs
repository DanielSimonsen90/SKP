using System;
using System.Collections.Generic;

namespace Guess_number
{
    internal class Interface
    {
        internal Game game;
        internal List<int> Guesses = new List<int>();
        public Interface(Game game) => this.game = game;
        public void GetUI()
        {
            GetUpperUI();
            GetGuesses();
            Console.WriteLine("Enter a number between 0 - 100");
            Console.WriteLine();
            Console.Write("My guess is: ");
        }

        /// <summary> Goes through all guesses and tells user if they were higher or lower </summary>
        private void GetGuesses()
        {
            for (int x = 0; x < Guesses.Count; x++)
                Console.WriteLine($"{Guesses[x]}: {GetHighLow(Guesses[x])}");
        }

        internal string GetHighLow(int Guess) => Guess < game.Number ? "HIGHER" : (Guess > game.Number) ? "LOWER" : "CORRECT";

        /// <summary> Shows streak and attempts left </summary>
        private void GetUpperUI()
        {
            string UI = string.Empty;
            if (game.Streak.GetStreak(game.User.AttemptsLeft) && game.Streak.StreakCount != 0)
                UI = $"ON STREAK! [{game.Streak.StreakCount}]   |   ";
            UI += $"Attemps left: {game.User.AttemptsLeft}";
            Console.WriteLine(UI);
        }
    }
}