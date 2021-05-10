using DanhoLibrary;
using System.Collections.Generic;

namespace RandomSWCharacter_2._0.Weapons
{
    class Lightsaber
    {
        private string Color { get; }
        public Lightsaber(LightsaberType type)
        {
            List<string> Primary = new List<string>();
            if (type == LightsaberType.Random) 
                type = ConsoleItems.RandomNumber(2) == 1 ? LightsaberType.Good : LightsaberType.Bad;
            Primary.AddRange(
                type == LightsaberType.Bad ?
                    new string[] { "Red" } :
                    new string[] { "Blue", "Green" }
            );
            Color = SetColor(Primary);
        }
        private string SetColor(List<string> primary)
        {
            primary.AddRange(new string[] { "Purple", "Orange", "Black", "White" });
            return primary.GetRandomItem();
        }

        public override string ToString() => Color;
    }

    public enum LightsaberType { Good, Bad, Random }
}
