using DanhoLibrary;
using MIG.Ideas;
using MIG.Ideas.LookingFor;
using MIG.SQL;
using System;
using System.Collections.Generic;

namespace MIG
{
    class Menu
    {
        private static string Title => "Music Idea Generator 2.0 - pre-3.5";

        /// <summary>
        /// Sets the UI
        /// </summary>
        /// <returns>(Generate) ? true : false</returns>
        public static bool UI(ref LFIdea LFIdea)
        {
            Console.Title = Title;
            ConsoleItems.Title(Title, "What exciting projects will we find today?");
            ListOptions(LFIdea, out int Conversion, "Generate", "Specific", "View past ideas");
            Console.Clear();
            switch (Conversion)
            {
                default: return true;
                case 0: return false;
                case 2: GetMenuChoice(ref LFIdea); return false;
                case 3: SQLData.ViewPastIdeas(GetID()); return false;
            }
        }

        private static int GetID()
        {
            foreach (Idea[] arr in SQLData.MIG_V2_Ideas["Idea"].GetDataList<Idea>().ToArray().Split(10))
            {
                foreach (Idea idea in arr)
                    Console.WriteLine($"[{idea.ID}]: \"{idea.Title}\" - {idea.Genre.Name}, {idea.Genre.BPM}, {idea.Genre.Scale}");

                if (!int.TryParse(Console.ReadLine(), out int num))
                    continue;

                foreach (Idea idea in arr)
                    if (idea.ID == num)
                        return num;
            }
            return -1;
        }

        /// <summary>
        /// Calls <paramref name="LFIdea"/>.Set<specific>()
        /// </summary>
        private static void GetMenuChoice(ref LFIdea LFIdea)
        {
            ConsoleItems.Title(Title, "What specifics would you like to make?");
            ConsoleItems.ListOptions(out int Conversion, "Genre", "Artist", "BPM", "Scale", "Title");
            Console.Clear();

            object item = new object();
            switch (Conversion)
            {
                case 0: item = null; break;
                case 1: LFIdea.SetGenre(); item = LFIdea.Genre; break;
                case 2: LFIdea.SetArtist(); item = LFIdea.Artist; break;
                case 3: LFIdea.SetBPM(); item = LFIdea.BPM.Value > 0 ? LFIdea.BPM : null; break;
                case 4: LFIdea.SetScale(); item = LFIdea.Scale; break;
                case 5: LFIdea.SetTitle(); item = LFIdea.Title.LF != "0" ? LFIdea.Title : null; break;
            }
            if (Conversion != 0 && item != null) LFIdea.Used[Conversion - 1] = true;
        }

        private static void ListOptions(LFIdea LFIdea, out int Conversion, params string[] Options)
        {
            for (int x = 0; x < Options.Length; x++)
                Console.WriteLine($"[{x + 1}]: {Options[x]}");
            Console.WriteLine();
            LFIdea.GetSpecifics();
            Console.WriteLine();
            try { Conversion = int.Parse(Console.ReadLine()); }
            catch { Conversion = -1; }
        }
    }
}
