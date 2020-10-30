using System;

namespace RandomREEE
{
    class Program
    {
        static string CarColor(string choiceOfColor)
        {
            return "Your car color is: " + choiceOfColor;
        }
        static string CarColor(string randomChoice1, string randomChoice2)
        {
            Random randomColor = new Random();
            int Random = randomColor.Next(2);
            string result = "";
            if (Random == 1)
                result = randomChoice1;
            else
                result = randomChoice2;
            return "Your random choice of colors is: " + result;
        }
        static string CarColor(string[] Colors)
        {
            Random rand = new Random();
            return "Using the inserted CarColors array, the random color chosen for the car is: " + Colors[rand.Next(Colors.Length)];
        }
        static void Main()
        {
            while (true)
            {
                Console.Clear();

                #region System.Random testing
                Console.WriteLine("I will tell you a random number.");
                Random rand = new Random();
                Console.WriteLine("The first random number, is between 0 and 8: " + rand.Next(0, 9));
                string[] randomString = { "din", "mor", "er", "en", "Ching", "chong" };
                Console.WriteLine("The second random number is just the length of the string[]: " + rand.Next(randomString.Length));
                Console.WriteLine("The third random number is just a 3: " + rand.Next(3));
                #endregion

                Console.WriteLine();

                #region Same method, different parameters testing
                Console.WriteLine(CarColor("White")); //Test 1, CarColor(string)

                Console.WriteLine(CarColor("White", "Black")); //Test 2, CarColor(string1, string2)

                string[] CarColors = {
                    "Black", "Dark Gray", "Light Gray",
                    "White", "Red", "Orange", "Yellow",
                    "Green", "Blue", "Purple", "Pink" }; //Test 3, CarColor(string[])

                Console.WriteLine(CarColor(CarColors));
                #endregion

                Console.ReadKey();

            }
        }
    }
}
