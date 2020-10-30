using System;

namespace RandomSWCharacter
{
    class Program
    {
        /// <summary>
        /// Get random string[] being: {Name, Age, Sex}
        /// </summary>
        /// <returns></returns>
        static string[] RandomBackground()
        {
            string[] Names = { "Danhoe", "Noodle", "Slothman", "Stubbe", "Kid", "JesPaPa", "Peter" },
                Sex = { "Male" };
            Random rand = new Random();

            return new string[]
            {
                Names[rand.Next(Names.Length)], //Name
                rand.Next(18, 50).ToString(), //Age
                Sex[rand.Next(Sex.Length)], //Sex
            };
        }
        /// <summary>
        /// Collect all species from <see cref="Species.GetAllSpecies"/>, and returns random from array
        /// </summary>
        /// <returns>Random <see cref="Species"/></returns>
        static Species RandomSpecies()
        {
            var AllSpecies = new Species().GetAllSpecies();
            Random rand = new Random();
            return AllSpecies[rand.Next(AllSpecies.Length)];
        }
        static void Main()
        {
            while (true)
            {
                Character character = new Character(RandomBackground(), RandomSpecies());
                character.GetInfo();
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
