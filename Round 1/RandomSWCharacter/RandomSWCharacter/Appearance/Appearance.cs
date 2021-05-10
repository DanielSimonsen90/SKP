using System;

namespace RandomSWCharacter
{
    /// <summary>
    /// The Appearance of <see cref="Character"/>
    /// </summary>
    public class Appearance
    {
        /// <summary>
        /// Gets Clothes to <see cref="Character"/>
        /// </summary>
        /// <param name="AppearanceItems">[ClothingItem][Different variants]</param>
        public Appearance(string[][] AppearanceItems)
        {
            Items = FindClothes(AppearanceItems);
        }
        /// <summary>
        /// Contains all Clothes items, {Head, Face, Neck, Shirt, Hand, Leg, Foot}, set via <see cref="FindClothes(string[][])"/> whereas string[][] is set in ctor
        /// </summary>
        public string[] Items { get; private set; }
        /// <summary>
        /// Sets <see cref="Items"/>
        /// </summary>
        /// <param name="AppearanceItems">Specified in ctor</param>
        /// <returns></returns>
        private static string[] FindClothes(string[][] AppearanceItems)
        {
            Random Rand = new Random();
            string[] Result = new string[7];

            for (int x = 0; x < AppearanceItems.Length; x++)
                Result[x] = AppearanceItems[x][Rand.Next(AppearanceItems[x].Length)];
            return Result;
        }
    }
}
