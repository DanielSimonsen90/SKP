using System;
using System.Linq;
using DanhoLibrary;
using MIG.References;

namespace MIG
{
    class LFScale
    {
        private static readonly Scale InternScale = new Scale(50);

        public static Scale Menu()
        {
            ConsoleItems.ListOptions(out int Response, "Set Key", "Set Scale", "Set both");
            Console.Clear();

            switch (Response)
            {
                case 0: return null;
                case 1: SetKey(); break;
                case 2: SetScale(); break;
                case 3: SetKey(); Console.Clear();  SetScale(); break;
            }
            return InternScale;
        }
        private static void Menu(string item, string[] collection)
        {
            Console.WriteLine($"Pick a {item}");
            ConsoleItems.ListOptions(collection);
        }

        private static void SetKey()
        {
            Menu("Key", Scale.Keys);

            var Response = Console.ReadLine().ToUpper();

            InternScale.SpecificKey = true;
            if (int.TryParse(Response, out int NumResult))
                InternScale.Key = Scale.Keys[NumResult - 1];
            else if (Scale.Keys.Contains(Response))
                InternScale.Key = Response;
            else InternScale.SpecificKey = false;
        }
        private static void SetScale()
        {
            Menu("Scale", Scale.Types);

            var Response = Console.ReadLine().ToLower();

            InternScale.SpecificType = true;
            if (int.TryParse(Response, out int NumResult))
                InternScale.Type = Scale.Types[NumResult - 1];
            else if (Scale.Types.Contains(Response))
                InternScale.Type = Response;
            else InternScale.SpecificType = false;
        }
    }
}