using MIG.References;
using MIG.References.Data;
using MIG.References.Reference;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MIG
{
    class LFGenre
    {
        #region GetAllGenres
        /// <summary>
        /// Goes through all Genres from <see cref="Data.Playlist"/>
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static Genre GetAllGenres(Category category)
        {
            while (true)
            {
                int CategoryCount = GenreOptions(category); //Last index on screen
                string Response = Console.ReadLine();
                Console.Clear();
                try
                {
                    int Conversion = int.Parse(Response) - 1; //-1 to get [0] for [1] (on screen) etc

                    //If Category has genre && CategoryCount is below Genres.Count, return Genre
                    if (category.Genres != null && Conversion <= category.Genres.Count)
                        return category.Genres[Conversion];

                    //If Category has genre, CategoryCount is above Genres.Count, it's a category
                    else if (category.Genres != null && CategoryCount > category.Genres.Count)
                    {
                        Conversion -= category.Genres.Count - 1;
                        return GetAllGenres(category.SubCategories[Conversion]);
                    }

                    //Else there is no genre, so find Genre with category
                    return GetAllGenres(category.SubCategories[Conversion]);
                }
                catch
                {
                    if (Response == "0") return null;
                    if (category.Genres is null) return GetAllGenres(category);

                    foreach (Genre genre in category.Genres)
                        if (genre.Name == Response)
                            return genre;
                    foreach (Category sub in category.SubCategories)
                        if (sub.ToString() == Response)
                            return GetAllGenres(category);
                }
            }
        }

        /// <summary>
        /// Displays Genre/Category UI
        /// </summary>
        /// <param name="category">Category's .Categories & .Genres to display</param>
        /// <returns></returns>
        private static int GenreOptions(Category category)
        {
            int Index = 1;
            bool DoingGenre = true;

            #region Categories & Genres not null
            if (category.SubCategories != null && category.Genres != null)
                for (int x = 0; Index < category.Genres.Count + category.SubCategories.Count; x++)
                    if (x != category.Genres.Count && DoingGenre)
                        Console.WriteLine($"Genre[{Index++}]: {category.Genres[x]}");
                    else if (x == category.Genres.Count && DoingGenre)
                    {
                        Console.WriteLine();
                        DoingGenre = false;
                        x = 0;
                    }
                    else Console.WriteLine($"Category[{Index++}]: {category.SubCategories[x]}");
            #endregion

            #region Genres not null
            else if (category.Genres != null)
                for (int x = 0; x < category.Genres.Count; x++)
                    Console.WriteLine($"Genre[{Index++}]: {category.Genres[x]}");
            #endregion

            #region Categories not null
            else if (category.SubCategories != null)
                for (int x = 0; x < category.SubCategories.Count; x++)
                    Console.WriteLine($"Category[{Index++}]: {category.SubCategories[x]}");
            #endregion

            Console.WriteLine();
            return Index - 1;
        }
        #endregion

        #region GetDependingOnBools
        public static Genre GetBoth(Artist Artist, BPM BPM) => FindGenre(GetGenres(Artist, BPM));
        public static Genre GetBPM(BPM BPM) => FindGenre(GetGenres(BPM));
        public static Genre GetArtist(Artist Artist) => FindGenre(GetGenres(Artist.Releases));

        private static Genre FindGenre(Genre[] GenreList)
        {
            //Pages check
            List<Genre[]> Pages = GenreList.Length > 9 ? GenreList.Split(10) : null;
            if (Pages != null) return GoThroughPages(Pages);

            //Print all Genre names
            for (int x = 0; x < GenreList.Length; x++)
                Console.WriteLine($"[{x + 1}]: {GenreList[x]}");

            //await response 
            var Response = ConvertResponse(GenreList);

            return Response is null ? FindGenre(GenreList) : Response;
        }
        private static Genre GoThroughPages(List<Genre[]> Pages)
        {
            foreach (Genre[] Page in Pages)
            {
                for (int x = 0; x < Page.Length; x++)
                    Console.WriteLine($"[{x + 1}]: {Page[x]}");
                Console.WriteLine("Press any key for next page");

                var Response = ConvertResponse(Page);
                if (Response != null) return Response;
            }
            return GoThroughPages(Pages);
        }

        /// <summary>
        /// Attempts to return the LFGenre
        /// </summary>
        private static Genre ConvertResponse(Genre[] GenreList)
        {
            string Response = Console.ReadLine();

            //Reponse is int.Parseable
            try { return GenreList[int.Parse(Response) - 1]; }

            //Response is string - maybe name of Genre
            catch (InvalidOperationException)
            {
                foreach (Genre genre in GenreList
                    .Where(genre => genre.Name.ToLower() == Response.ToLower())
                    .Select(genre => genre))
                { return genre; }
            }
            //Any other mistake
            catch { Console.Clear(); }
            return null;
        }
        
        #region GetGenres
        private static Genre[] GetGenres(Track[] releases)
        {
            List<Genre> GenreList = new List<Genre>();

            foreach (Track release in releases)
                if (!GenreList.Contains(release.Genre))
                    GenreList.Add(release.Genre);
                else if (!GenreList.Contains(release.SubGenre) && release.SubGenre != null)
                    GenreList.Add(release.SubGenre);

            return GenreList.ToArray();
        }

        /// <summary>
        /// Collects all genres where Genre.BPM.Ranges can contain <paramref name="BPM"/>.Value
        /// </summary>
        /// <param name="BPM"></param>
        /// <returns></returns>
        internal static Genre[] GetGenres(BPM BPM) =>
        (
            from Genre genre in Data.GetGenres()
            where genre.BPM.Ranges.CanContain(BPM.Value)
            select genre
        ).ToArray();
        internal static Genre[] GetGenres(Artist Artist, BPM BPM) =>
        (
            from Genre genre in GetGenres(BPM)
            where GetGenres(Artist.Releases).Contains(genre)
            select genre
        ).ToArray();
        #endregion

        #endregion
    }
}