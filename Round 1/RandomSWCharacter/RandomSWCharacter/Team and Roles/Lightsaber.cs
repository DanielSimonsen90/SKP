using System;

namespace RandomSWCharacter
{
    public class Lightsaber : IWeapon
    {
        public Lightsaber(string color)
        {
            Color = color;
        }
        public string Name = "Lightsaber";
        public string Color { get; set; }
        public bool DualWield { private get; set; }
        public string RandomizeColor()
        {
            Random rand = new Random();
            string[] Colors = { "Blue", "Green", "Blue", "Green", "Blue", "Purple", "White", "Yellow" };
            return Color = Colors[rand.Next(Colors.Length)];
        }
        public void IsDual()
        {
            Random rand = new Random();
            DualWield = (rand.Next(100) < 5) ? true : false;
            if (DualWield)
            {
                Console.WriteLine("Lightsaber is dual wielded.");
                Console.WriteLine();
            }
        }
    }
}