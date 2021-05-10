using System;
using MIG.References.Data;
using DanhoLibrary;

namespace MIG
{
    internal class LFTitle
    {
        public string Result;
        public string LF => innerLF;
        private static string innerLF;

        public LFTitle() => Result = Generate();
        internal string Generate()
        {
            string[] UserWantedWords = GetWords(), //User inserted words to string[]
                GeneratedTitle = Title.GetTitle().Split(' '), //Generate new random title
                NewTitle = CustomExtender.GetArray(GeneratedTitle, UserWantedWords); //Ensures NewTitle can contain all elements of UserWantedWords

            if (UserWantedWords is null) return null;

            while (!NewTitle.ContainsAll(UserWantedWords)) //While NewTitle doesn't have all elements from UserWantedWords
                NewTitle[new Random().Next(NewTitle.Length)] = UserWantedWords[new Random().Next(UserWantedWords.Length)]; //Pick a random item from NewTitle and replace it with a random item from UserWantedWords
            //-- Once NewTitle has all words User requested, loop will break

            return ConsoleItems.ToString(NewTitle); //Return the new title array into one singular string
        }

        /// <summary>
        /// Returns user inserted words
        /// </summary>
        private static string[] GetWords()
        {
            Console.WriteLine("Insert the words you want in your title, seperated by comma..");
            innerLF = Console.ReadLine();
            if (innerLF == "0") return null;
            return innerLF.Contains(",") ? innerLF.Split(',') : new string[] { innerLF };
        }
    }
}