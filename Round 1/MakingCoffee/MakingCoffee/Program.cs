using System;

namespace MakingCoffee
{
    class Program
    {
        #region Variables
        /// <summary>
        /// Reads <see cref="Answer"/> as a true/false statement
        /// </summary>
        static bool BoolAnswer;
        /// <summary>
        /// User choice
        /// </summary>
        static string Answer;
        /// <summary>
        /// Current time
        /// </summary>
        static readonly DateTime Time = DateTime.Now;
        /// <summary>
        /// Our Noodle <3
        /// </summary>
        static readonly Noodle Noodle = new Noodle();
        #endregion

        #region Methods
        /// <summary>
        /// "Oi you thinkin 'bout making sum nigrjuice?" - yes
        /// </summary>
        /// <returns></returns>
        static string NoodleJuice()
        {
            if (!TimeForNigrJuice())
                return "Unfortunately, there's no time for nigrjuice :(";

            Console.WriteLine("Does Dan know you want to make nigrjuice?");
            string Answer = Console.ReadLine().ToLower();

            if (Answer == "yes")
                return Noodle.MakeCoffee(true);
            else
                return Noodle.MakeCoffee(false);
        }
        /// <summary>
        /// Do you even drink nigrjuice? - yes
        /// </summary>
        /// <returns></returns>
        static string DanJuice()
        {
            Console.WriteLine("Do you want some nigrjuice?");
            Answer = Console.ReadLine().ToLower();

            if (Answer == "yes")
                BoolAnswer = true;
            else
                BoolAnswer = false;

            while (!BoolAnswer)
            {
                Console.WriteLine("Are you sure about that?");
                Answer = Console.ReadLine().ToLower();

                if (Answer == "no")
                    break;
            }

            string[] Reasons = {
                "That's too bad because Noodle doesn't want to make you some",
                "Luckily for you, Noodle wants some too!"};
            Random rand = new Random();

            if (!TimeForNigrJuice())
                return "Unfortunately, there's no time for nigrjuice :(";

            if (Noodle.TakingADump())
                return "Unfortunately, Noodle is out shitting again";
            else
                return Reasons[rand.Next(Reasons.Length)];
        }
        /// <summary>
        /// Asks if User even likes nigrjuice
        /// </summary>
        /// <returns></returns>
        static bool DoYouEvenNigrJuiceBro()
        {
            Console.WriteLine("Do you even drink nigrjuice?");
            Answer = Console.ReadLine().ToLower();

            if (Answer == "yes")
                return true;
            else
                return false;
        }
        /// <summary>
        /// Is it ok to make nigrjuice, with the current time in mind?
        /// </summary>
        /// <returns></returns>
        static bool TimeForNigrJuice()
        {
            if (Time.Hour == 8 && Time.Minute >= 30 ||
                Time.Hour == 11 ||
                Time.Hour == 14 && Time.Minute >= 30)
                return false;
            else
                return true;
        }
        #endregion

        static void Main()
        {
            Console.Title = "Coffee Time";
            while (true)
            {
                Console.WriteLine("Oi you thinkin 'bout making sum nigrjuice?");
                Answer = Console.ReadLine().ToLower();

                if (Answer == "yes")
                    Console.WriteLine(NoodleJuice());
                else
                {
                    if (DoYouEvenNigrJuiceBro())
                        Console.WriteLine(DanJuice());
                    else
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

    }
}