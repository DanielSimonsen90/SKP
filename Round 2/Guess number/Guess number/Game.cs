using System;
using System.Collections.Generic;

namespace Guess_number
{
    internal class Game
    {
        #region Variables
        public readonly Highscore Highscore = new Highscore();
        public readonly Streak Streak = new Streak();
        public User User = new User();
        public int Score;
        internal Interface UI;
        internal int Number;
        internal bool Answer;
        #endregion

        public Game() => UI = new Interface(this);

        public void Play()
        {
            Reset();
            Guess();
            if (Answer)
            {
                Streak.StreakCount += 1;
                Streak.CombinedAttempts += User.AttemptsLeft;
                Highscore.Save(this);
            }
            else 
            {
                Streak.StreakCount = 0;
                Streak.CombinedAttempts = 0;
                Score = 0;
            }
            if (Streak.GetStreak(User.AttemptsLeft)) Play();
        }
        private void Guess()
        {
            do 
            {
                Console.Clear();
                UI.GetUI();
                try { User.Guess = int.Parse(Console.ReadLine()); }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Please insert a proper number...");
                    Console.ReadKey(true);
                    Console.Clear();
                    Guess();
                    return;
                }
                Answer = GetAnswer();
                UI.Guesses.Add(User.Guess);
                if (!Answer) User.AttemptsLeft--;
            } while (User.AttemptsLeft != 0 && !Answer);

            //When User has used all attmepts or guessed the number
            if (!Answer) Console.WriteLine($"The answer was {Number}");
            else { Console.WriteLine("Your guess was CORRECT!"); Score += User.AttemptsLeft % 3; }
            UI.Guesses = new List<int>();
            Console.ReadKey(true);
        }

        private bool GetAnswer()
        {
            Console.WriteLine();
            return UI.GetHighLow(User.Guess) == "CORRECT";
        }
        private void Reset()
        {
            Number = new Random().Next(101);
            User.AttemptsLeft += (User.AttemptsLeft == 0) ? 5 : 1;
            Console.Clear();
        }
    }
}