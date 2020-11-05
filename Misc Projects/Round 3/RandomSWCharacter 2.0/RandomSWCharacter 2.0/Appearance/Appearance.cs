using DanhoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomSWCharacter_2._0
{
    public class Appearance : IGetInfo
    {
        #region Property Options
        public List<string> Heads => new List<string>{ "Hat", "Hair", "Bald", "Hood", "Helmet" };
        public List<string> Faces => new List<string>{ "Clean", "Moustache", "Beard", "Glasses" };
        public List<string> Necks => new List<string>{ "None", "Necklace", "Scarf", "Jetpack", "Coat", "Cape" };
        public List<string> Shirts => new List<string>{ "Tank Top", "T-Shirt", "Shirt", "Hoodie", "Jacket", "Armor" };
        public List<string> Hands => new List<string>{ "Bare", "Glove", "Robotic" };
        public List<string> Pants => new List<string>{ "None", "Shorts", "Pants" };
        public List<string> Shoes => new List<string>{ "Shoes", "Sandals", "Boots", "Bare" };
        #endregion

        private readonly string Head, Face, Neck, Shirt, Hand, Pant, Shoe;
        private Species Species { get; }

        public Appearance(Species species)
        {
            this.Species = species;
            SetSpecieSpecific();
            SetPlanetSpecific();

            Head = Heads.GetRandomItem();
            Face = Faces.GetRandomItem();
            Neck = Necks.GetRandomItem();
            Shirt = Shirts.GetRandomItem();
            Hand = Hands.GetRandomItem();
            Pant = Pants.GetRandomItem();
            Shoe = Shoes.GetRandomItem();
        }

        private void SetSpecieSpecific()
        {
            switch (Species.Type)
            {
                case "Wookie":
                    Heads.Remove("Bald");
                    Faces.Remove("Clean");
                    Hands.Remove("Bare");
                    Shoes.Remove("Bare");
                    break;
                case "Jawa": 
                    Heads.Remove("Hat");
                    Heads.Remove("Hair");
                    Heads.Remove("Helmet");
                    break;
                case "Zabrak (Darth Maul)": Heads.Add("Horns"); Faces.AddRange(new string[] { "Red facepaint", "Yellow facepaint" }); break;
                case "Togruta (Ashoka)": Heads.Add("Tentacle things"); break;
                case "Gungan (Jar Jar)": Heads.Add("Long ears UwU"); break;
                case "Mandalorian": 
                    Heads.Remove("Hood");
                    Faces.Remove("Glasses"); 
                    break;
            }
        }
        private void SetPlanetSpecific()
        {
            switch (Species.Planet)
            {
                case "Tatooine": 
                    Necks.Remove("Scarf");
                    Shirts.Remove("Hoodie");
                    Shoes.Remove("Boots");
                    break;
                case "Hoth": Remove("Tank Top", "T-Shirt", "Shorts", "Sandals", "Bare");
                    Shirts.Remove("Tank Top");
                    Shirts.Remove("T-Shirt");
                    Pants.Remove("Shorts");
                    Shoes.Remove("Sandals");
                    Shoes.Remove("Bare");
                    break;
            }
        }
        private void Remove(params string[] arr)
        {
            var properties = new List<List<string>>() { Heads, Faces, Necks, Shirts, Hands, Pants, Shoes };

            for (int i = 0; i < properties.Count; i++)
                foreach (string item in properties[i])
                    if (arr.Contains(item))
                        properties[i].Remove(item);
        }

        public string GetInfo() => new string[]
        {
            "-- == Appearance == --",
            $"Head: {Head}",
            $"Face: {Face}",
            $"Neck: {Neck}",
            $"Shirt: {Shirt}",
            $"Hand: {Hand}",
            $"Pant: {Pant}",
            $"Shoe: {Shoe}"
        }.ToBigBoiString("\n");
    }
}