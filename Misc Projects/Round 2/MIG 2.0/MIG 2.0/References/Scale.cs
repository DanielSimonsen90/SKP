using System;

namespace MIG.References
{
    public class Scale
    {
        public static string[] 
            Keys = { "A", "A#/Bb", "B", "C", "C#/Db", "D", "D#/Eb", "E", "F", "F#/Gb", "G" },
            Types = { "Major", "Minor" };
        internal string Type, Key;
        public readonly int Percentage;
        public bool SpecificType, SpecificKey;

        /// <param name="Percentage">Percentage to get Major</param>
        public Scale(int Percentage)
        {
            Type = GenerateType(this.Percentage = Percentage);
            Key = GenerateKey();
        }

        private string GenerateType(int percentage) => new Random().Next(100) <= percentage ? "Major" : "Minor";
        private string GenerateKey() => Keys[new Random().Next(Keys.Length)];

        public override string ToString() => $"{Key} {Type}";
        public string GetSpecifics() =>
            SpecificKey && SpecificType ? $"{Key} {Type}" :
            SpecificKey ? Key :
            Type;
    }
}
