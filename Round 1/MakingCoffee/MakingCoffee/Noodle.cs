using System;

namespace MakingCoffee
{
    class Noodle
    {
        /// <summary>
        /// Will Noodle make coffee?
        /// </summary>
        /// <param name="DoesDanKnow">Literally the answer if Noodle wants to make coffee</param>
        /// <returns>Coffee OwO</returns>
        public string MakeCoffee(bool DoesDanKnow)
        {
            if (DoesDanKnow)
                return "You made coffee and you are both very happy!";
            else
                return "Dan is very upset because you didn't make him nigrjuice ;(";
        }

        /// <summary>
        /// Randomized if Noodle is out shitting
        /// </summary>
        /// <returns>No coffee :(</returns>
        public bool TakingADump()
        {
            Random rand = new Random();

            if (rand.Next(100) > 75)
                return true;
            else
                return false;
        }
    }
}