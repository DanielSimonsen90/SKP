using System;
using System.Collections.Generic;
using System.Text;

namespace RandomSWCharacter_2._0
{
    class Gender
    {
        public static Gender Male = new Gender("Male", 
            "Frost", "Andreas", "xny", "Bello", "Christoffer",
            "CookieKid", "Omidreza", "Spag", "Colakitty",
            "Mathias", "Daniel", "Fuchyy", "Anders", "Alex",
            "Rasmus", "Samuel", "Gidda", "Niels", "Ironshark",
            "Emil", "Nikolai", "Kippy", "Mikkel", "August",
            "Jacob", "Elliot", "Jesper", "Maarten", "Lasse",
            "Viktor", "Tim", "Tobias", "Mads", "Waterslide",
            "Thomas");
        public static Gender Female = new Gender("Female", 
            "Emilie", "Emma", "Freja", "Maria", "Spice",
            "Mette");

        public string[] Names { get; }
        public string Value { get; }

        public Gender(string value, params string[] names)
        {
            this.Value = value;
            this.Names = names;
        }

        public override string ToString() => Value;
    }
}
