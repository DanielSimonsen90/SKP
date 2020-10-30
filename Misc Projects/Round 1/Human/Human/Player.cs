using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human
{
    class Player 
    {
        public Player(string playername, int age, string occupation, string hobby)
        {
            Playername = playername;
            Age = age;
            Occupation = occupation;
            Hobby = hobby;
        }

        #region Global Variables
        public string Playername { get; set; }
        public int Age { get; set; }
        public string Occupation { get; set; }
        public string Hobby { get; set; }
        public string PlayerType { get; set; }
        public int Money { get; set; }
        public int Loneliness { get; set; }
        public int SinMeter { get; set; }
        #endregion

        #region Public methods
        public void GetInfo()
        {
            Console.WriteLine("Name: " + Playername);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("Occupation: " + Occupation);
            Console.WriteLine("Hobby: " + Hobby);
            Console.WriteLine();
            Console.WriteLine("Money:" + Money);
        }
        public int GetStarterMoney()
        {
            Random rand = new Random();
            Money = rand.Next(500, 1500);
            return Money;
        }
        public int EarnMoney()
        {
            //Work
            return Money;
        }
        #endregion
    }
}
