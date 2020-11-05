using DanhoLibrary;

namespace RandomSWCharacter_2._0
{
    public class Species : IGetInfo
    {
        public static string[] Types => new string[]
        {
            "Human", "Wookie", "Yoda", "Jawa", "Zabrak (Darth Maul)",
            "Togruta (Ashoka)", "Mon Calamari (It's a trap!)", 
            "Gungan (Jar Jar)", "Mandalorian"
        };
        private static string[] Planets => new string[]
        {
            "Earth", "Naboo", "Tatooine", "Coruscant", "Alderaan", "Bespin",
            "Kashyyyk", "Dagobah", "Mandalore", "Kamino", "Hoth", "Endor",
            "Geonosis", 
        };

        public string Type { get; }
        public string Planet { get; }
        private Appearance Appearance { get; }

        public Species()
        {
            Type = Types.GetRandomItem();
            Planet = Planets.GetRandomItem();
            Appearance = new Appearance(this);
        }

        public string GetInfo() => new string[]
        {
            "-- == Species == --",
            $"Type: {Type}",
            $"Planet: {Planet}",


        }.ToBigBoiString("\n");
    }
}