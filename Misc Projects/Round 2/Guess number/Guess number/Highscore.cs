using System;
using System.IO;

namespace Guess_number
{
    class Highscore
    {
        internal string Data = "../../../HighscoreData.txt";
        public void View()
        {
            if (File.Exists(Data))
            {
                string[] Lines = File.ReadAllLines(Data),
                    yeet = { "Highscore", "Streak", "Combined Attempts" };
                for (int x = 0; x < Lines.Length; x++)
                    Console.WriteLine($"{yeet[x]}: {Lines[x]}");
                Console.ReadKey(true);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("You do not have a highscore yet.\nGo play!");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
        public void Save(Game game)
        {
            if (File.Exists(Data))
            {
                try
                {
                    string[] Highscore = File.ReadAllLines(Data);
                    if (Convert.ToInt32(Highscore[0]) < game.Score &&
                        Convert.ToInt32(Highscore[2]) < game.Streak.CombinedAttempts)
                        File.Delete(Data);
                    else return;
                }
                catch { File.Delete(Data); }
            }
            File.Create(Data).Close();
            string[] yeet = { game.Score.ToString(), game.Streak.StreakCount.ToString(), game.Streak.CombinedAttempts.ToString() };
            File.WriteAllLines(Data, yeet);
        }
    }
}