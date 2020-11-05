using DanhoLibrary;
using System.Collections.Generic;
using System.Linq;

namespace RandomSWCharacter_2._0
{
    public class Anchestors : IGetInfo
    {
        private string Mother { get; }
        private string Father { get; }

        public Anchestors(Species species)
        {
            List<string> femaleNames = Gender.Female.Names.ToList(), maleNames = Gender.Male.Names.ToList();
            List<string> speciesNamesFemale = GetSpeciesNames(species, "female"), speciesNamesMale = GetSpeciesNames(species, "male");

            if (speciesNamesFemale != null) femaleNames.AddRange(speciesNamesFemale);
            if (speciesNamesMale != null) maleNames.AddRange(speciesNamesMale);
            femaleNames.Add("Unknown");
            maleNames.Add("Unknown");

            Mother = femaleNames.GetRandomItem();
            Father = maleNames.GetRandomItem();
        }

        private List<string> GetSpeciesNames(Species species, string gender) =>
            species.Type switch
            {
                "Human" => gender == "male" ?
                    new List<string>() { "Qui-Gon", "Anakin", "Obi-Wan", "Luke", "Han", "Lando", "Kylo Ren", "Unknown" } :
                    new List<string>() { "Padmé", "Leia", "Shmi", "Rey", "Unknown" },
                "Wookie" => gender == "male" ? new List<string>() { "Chewbacca" } : null,
                "Yoda" => gender == "male" ? new List<string>() { "Yoda" } : null,
                "Zabrak (Darth Maul)" => gender == "male" ? new List<string>() { "Maul" } : null,
                "Togruta (Ashoka)" => gender == "male" ? null : new List<string>() { "Ashoka" },
                "Gungan (Jar Jar)" => gender == "male" ? new List<string>() { "Jar Jar" } : null,
                "Mandalorian" => gender == "male" ? new List<string>() { "Mando" } : null,
                _ => null,
            };


        public string GetInfo() => new string[]
        {
            "-- == Anchestors == --",
            $"Mother: {Mother}",
            $"Father {Father}"
        }.ToBigBoiString("\n");
    }
}