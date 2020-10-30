using System;

namespace RandomSWCharacter
{
    /// <summary>
    /// The Species of <see cref="Character"/>
    /// </summary>
    public class Species
    {
        /// <summary>
        /// Only used to <see cref="Species.GetAllSpecies"/> - don't use!
        /// </summary>
        public Species()
        {

        }
        /// <summary>
        /// Instance of Species to get background information
        /// </summary>
        /// <param name="name">Name of <see cref="Species"/></param>
        /// <param name="Males">All males that could be the father</param>
        /// <param name="Females">All females that could be the mother</param>
        /// <param name="Planets">All planets that could be HomePlanet</param>
        /// <param name="Appearance">What <see cref="Species"/> generalyl looks like - all listed in <see cref="Species.GetAllSpecies"/></param>
        public Species(string name, string[] Males, string[] Females, string[] Planets, Appearance Appearance)
        {
            Ancestors = GetAncestors(Males, Females);
            this.Appearance = Appearance;

            Items = new string[] { name, GetHomePlanet(Planets)};
        }

        /// <summary>
        /// {Male, Female}
        /// </summary>
        public string[] Ancestors { get; private set; }
        /// <summary>
        /// {Name, HomePlanet}
        /// </summary>
        public string[] Items { get; private set; }
        /// <summary>
        /// Items[]{Head, Face, Neck, Chest, Hand, Leg, Foot}
        /// </summary>
        public Appearance Appearance { get; set; }

        /// <summary>
        /// Sets Items[1]
        /// </summary>
        /// <param name="Planets">Array of planets</param>
        /// <returns>Returns HomePlanet, <see cref="Items"/>[1]</returns>
        private string GetHomePlanet(string[] Planets)
        {
            Random rand = new Random();
            return Planets[rand.Next(Planets.Length)];
        }
        /// <summary>
        /// Sets <see cref="Ancestors"/>
        /// </summary>
        /// <param name="Males">Males array</param>
        /// <param name="Females">Females array</param>
        /// <returns></returns>
        private static string[] GetAncestors(string[] Males, string[] Females)
        {
            Random rand = new Random();
            return new string[] { Females[rand.Next(Females.Length)], Males[rand.Next(Males.Length)] };
        }
        /// <summary>
        /// Sets all specific <see cref="Species"/>
        /// </summary>
        /// <returns>AllSpecies array</returns>
        public Species[] GetAllSpecies()
        {
            return new Species[]
            {
                new Species("Human",
                    new string[] { "Qui-Gon", "Anakin", "Obi-Wan", "Luke", "Han", "Lando", "Unknown" },
                    new string[] { "Padmé", "Leia", "Shmi", "Unknown"},
                    new string[]{"Earth", "Naboo", "Tatooine", "Coruscant", "Alderaan", "Bespin"},
                    new Appearance(new string[][]
                    {
                        new string[]{"Hat", "Hair", "Bald", "Hood", "Fez"},
                        new string[]{"Clean", "Moustache", "Beard", "Glasses"},
                        new string[]{"Necklace", "None", "Scarf", "Bowtie", "Tie"},
                        new string[]{"Tank top", "T-Shirt", "Shirt", "Hoodie", "Jacket"},
                        new string[]{"Bare", "Glove", "Robotic" },
                        new string[]{"Shorts", "Pants" },
                        new string[]{"Shoes", "Sandals", "Boots"}
                    })),
                new Species("Wookie",
                    new string[]{"Chewbacca", "Unknown"},
                    new string[]{"Unknown"},
                    new string[]{ "Kashyyyk" },
                    new Appearance(new string[][]
                    {
                        new string[]{"Hair"},
                        new string[]{"More hair"},
                        new string[]{"Belt thingy"},
                        new string[]{"Even more hair"},
                        new string[]{"Hairy hand? :thonk:", "Robotic hand uwu"},
                        new string[]{"Oh look I'm not the only one with hairy legs"},
                        new string[]{"Hair"}
                    })),
                new Species("Yoda",
                    new string[]{"Yoda", "Unknown" },
                    new string[]{"Unknown" },
                    new string[]{"Dagobah"},
                    new Appearance(new string[][]
                    {
                        new string[]{"Hair", "Bald"},
                        new string[]{"Clean", "Moustache", "Beard", "Glasses"},
                        new string[]{"Cape", "None"},
                        new string[]{ "Tank top", "T-Shirt", "Shirt", "Hoodie", "Jacket"},
                        new string[]{"Bare", "Glove", "Robotic"},
                        new string[]{"Pants"},
                        new string[]{"Shoes", "Sandals"}
                    })),
                new Species("Jawa",
                    new string[]{"Unknown" },
                    new string[]{"Unknown" },
                    new string[]{"Tatooine"},
                    new Appearance(new string[][]
                    {
                        new string[]{"Hood" },
                        new string[]{"Bright eyes" },
                        new string[]{"Cape", "None" },
                        new string[]{"Shirt", "Jacket" },
                        new string[]{"Glove"},
                        new string[]{"Pants"},
                        new string[]{"Shoes"}
                    })),
                new Species("Zabrak (Darth Maul)",
                    new string[]{"Darth Maul", "Unknown" },
                    new string[]{"Unknown"},
                    new string[]{"Unknown"},
                    new Appearance(new string[][]
                    {
                        new string[]{"Horns", "Hood"},
                        new string[]{"Red Facepaint", "Yellow Facepaint", "Clean"},
                        new string[]{"Cape", "None"},
                        new string[]{"Coat", "Jacket", "Shirt"},
                        new string[]{"Bare", "Robotic", "Glove"},
                        new string[]{"Pants"},
                        new string[]{"Shoes"}
                    })),
                new Species("Togruta",
                    new string[]{"Unknown"},
                    new string[]{"Ashoka", "Unknown"},
                    new string[]{"Corusant"},
                    new Appearance(new string[][]
                    {
                        new string[]{"Hood", "Those tentacle things"},
                        new string[]{"Facepaint", "Clean"},
                        new string[]{"Necklace", "None"},
                        new string[]{"Tank top", "Shirt", "Coat"},
                        new string[]{"Bare", "Robotic", "Glove"},
                        new string[]{"Shorts", "Pants"},
                        new string[]{"Shoes", "Sandals"}
                    })),
                new Species("Mon Calamari (It's a trap!)",
                    new string[]{"Unknown"},
                    new string[]{"Unknown"},
                    new string[]{"Unknown"},
                    new Appearance(new string[][]
                    {
                        new string[]{"Bare"},
                        new string[]{"Clean"},
                        new string[]{"None"},
                        new string[]{"Shirt, T-Shirt", "Jacket"},
                        new string[]{"Bare", "Robotic", "Glove"},
                        new string[]{"Pants", "Shorts"},
                        new string[]{"Shoes"}
                    })),
                new Species("Gungan (Jar Jar)",
                    new string[]{"Jar Jar Binks", "Unknown"},
                    new string[]{"Unknown"},
                    new string[]{"Naboo"},
                    new Appearance(new string[][]
                    {
                        new string[]{"Long Ears UwU"},
                        new string[]{"Clean"},
                        new string[]{"Necklace", "None"},
                        new string[]{"Shirt"},
                        new string[]{"Bare", "Robotic"},
                        new string[]{"Pants", "Shorts"},
                        new string[]{"Bare footed"}
                    })),
                new Species("Time-Lord",
                    new string[]{"The Doctor", "Rory", "The Master", "Unknown" },
                    new string[]{"The Doctor", "River Song", "Amy Pond", "The Mistress", "Unknown" },
                    new string[]{"Earth", "Gallifrey" },
                    new Appearance(new string[][]
                    {
                        new string[]{"Hair", "Bald", "Wig", "Fez"},
                        new string[]{"Beard", "Moustache", "Clean", "Glasses"},
                        new string[]{"Necklace", "None", "Scarf", "Bowtie"},
                        new string[]{"Shirt", "T-Shirt", "Jacket", "Coat"},
                        new string[]{"Bare", "Robotic", "Glove"},
                        new string[]{"Pants"},
                        new string[]{"Shoes", "Sandals"}
                    }))
            };
        }
    }
}
