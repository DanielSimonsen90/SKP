using System;
using DanhoLibrary;
using MIG.References;
using MIG.References.Reference;

namespace MIG.Ideas
{
    class Idea
    {
        public Genre Genre;
        public Reference References;
        public string Title;
        public int ID;

        public Idea(Genre genre) : this() => References = new Reference(Genre = genre);
        public Idea()
        {
            References = new Reference(Genre = Data.GetGenres().GetRandomItem());
            Title = MIG.References.Data.Title.GetTitle();
        }

        internal static int Generate() => new Idea(Data.GetGenres().GetRandomItem()).GetInfo();
        public int GetInfo()
        {
            Console.Clear();
            if (References.Artist != null) ConsoleItems.Title(Title, $"Referencing {References.Artist}'s \"{References.Track}\"");
            else ConsoleItems.Title(Title.ToString());
            Genre.GetInfo(true);
            Console.WriteLine($"Idea #{ID = SQL.SQLData.Length}");
            try { return int.Parse(Console.ReadKey(true).Key.ToString()); }
            catch { return 1; }
        }
    }
}
