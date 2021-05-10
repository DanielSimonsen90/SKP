using System;
using System.Collections.Generic;
using MIG.References.Reference;
using System.Linq;

namespace MIG.References.Data
{
    class Title
    {
        private static readonly List<string> Result = new List<string>();

        public override string ToString() => GetTitle();
        public static string GetTitle() => GetTitle(Dictionary);
        public static string GetTitle(string[] Dictionary)
        {
            //Result title & individual word
            string 
                Title = string.Empty, 
                Word;

            //Randomize amount of words
            for (int x = 0; x < new Random().Next(2, 4); x++)
                //Word = Random word from Dictionary array, returns true of Word is valid
                if (GetAvailabilityConditions(Title, Word = Dictionary[new Random().Next(Dictionary.Length)].ToLower()))
                    //Unless Word is "I", lowercase word
                    Title += (Word == "I") ? $"{Word} " : $"{Word.ToLower()} ";
                //If Word is invalid, go back a step to select new random Word
                else x--;

            //Return Title with capital first letter
            return Title.Substring(0, 1).ToUpper() + Title.ToLower().Substring(1, Title.Length - 1);
        }

        /// <summary>
        /// If <paramref name="Word"/> contains special character or <paramref name="Title"/> already contains <paramref name="Word"/>, return false else true
        /// </summary>
        private static bool GetAvailabilityConditions(string Title, string Word)
        {
            if (Title.Contains(Word)) return false;
            if (Names.BannedWords.Contains(Word)) return false;
            if (Word.Contains("(") || Word.Contains(")")) return false;
            if (Word.Contains("\"")) return false;
            if (Word.Contains("[") || Word.Contains("]")) return false;
            return true;
        }

        public static string[] Dictionary
        {
            get
            {
                foreach (Artist artist in Artist.GetData())
                {
                    GoThroughTracks(artist.Songs);

                    if (artist.Remixes != null)
                        GoThroughTracks(artist.Remixes);
                }
                return Result.ToArray();
            }
        }

        /// <summary> Used in <see cref="Dictionary"/> get{} </summary>
        private static void GoThroughTracks(Track[] tracks) => 
            Result.AddRange(
                from Track track in tracks
                from string Word in GetWords(track)
                where !Result.Contains(Word)
                select Word
            );

        /// <summary> Used in <see cref="GoThroughTracks(Track[])"/> </summary>
        private static List<string> GetWords(Track track)
        {
            List<string> Result = new List<string>();
            int FirstIndex = 0;
            for (int x = 0; x < track.Name.Length; x++)
                if (track.Name[x] == ' ')
                {
                    string Word = track.Name.Substring(FirstIndex, x - FirstIndex);
                    if (!Result.Contains(Word))
                        Result.Add(Word);
                    FirstIndex = x += 1;
                }
            return Result;
        }
    }
}