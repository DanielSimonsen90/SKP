using DanhoLibrary;
using MIG.References;
using MIG.References.Reference;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MIG
{
    class LFArtist
    {
        /// <summary>
        /// Returns artist to look for
        /// </summary>
        /// <param name="ArtistData">All artist data - used in <see cref="GetPages(Artist[])"/></param>
        public static Artist GetAllArtists(Artist[] ArtistData) =>
            ArtistData.Length > 9 ?
                GetUI(GetPages(ArtistData), "A - G", "H - N", "O - U", "V - Z", "Misc") :
                GetUI(ArtistData.ToList());

        #region GetPages
        /// <summary>
        /// Goes through all <paramref name="ArtistData"/> and sorts into alphabetical ordered list
        /// </summary>
        /// <param name="ArtistData"><see cref="Data.GetArtists"/></param>
        /// <returns>Alphabetical lists</returns>
        private static List<Artist>[] GetPages(Artist[] ArtistData)
        {
            List<Artist>
                AG = new List<Artist>(),
                HN = new List<Artist>(),
                OU = new List<Artist>(),
                VZ = new List<Artist>(),
                Misc = new List<Artist>();

            foreach (Artist artist in ArtistData)
                if (!AddArtist(artist, ref AG, "abcdefg") &&
                    !AddArtist(artist, ref HN, "hijklmn") &&
                    !AddArtist(artist, ref OU, "opqrstu") &&
                    !AddArtist(artist, ref VZ, "vwxyz"))
                    Misc.Add(artist);

            return new List<Artist>[] { AG, HN, OU, VZ, Misc };
        }
        /// <summary>
        /// Supports <see cref="GetPages(Artist[])"/>
        /// </summary>
        /// <param name="artist">Artist to add to <paramref name="ArtistList"/></param>
        /// <param name="ArtistList">List of artists?</param>
        /// <param name="Contains">First letter of <paramref name="artist"/>.Name</param>
        /// <returns></returns>
        private static bool AddArtist(Artist artist, ref List<Artist> ArtistList, string Contains)
        {
            if (!Contains.Contains(artist.Name.Substring(0, 1).ToLower()))
                return false;

            ArtistList.Add(artist);
            return true;
        }
        #endregion

        #region GetUI
        private static Artist GetUI(List<Artist>[] Data, params string[] PageNames)
        {
            for (int Page = 0; Page < Data.Length; Page++)
            {
                Console.WriteLine(PageNames[Page]);
                Console.WriteLine("Are you looking for any of the following?:");
                Console.WriteLine();
                for (int Names = 0; Names < Data[Page].Count; Names++)
                    Console.WriteLine($"[{Names + 1}]: {Data[Page][Names].Name}");
                Console.WriteLine();

                string Response = Console.ReadLine();
                try { return Data[Page][int.Parse(Response) - 1]; }
                catch (ArgumentOutOfRangeException) { if (int.Parse(Response) != 0) throw new Exception(); return null; }
                catch { Console.Clear(); }
            }
            return GetUI(Data, PageNames);
        }
        private static Artist GetUI(List<Artist> Data)
        {
            Console.WriteLine("Which of the following are you looking for?:");
            for (int Page = 0; Page < Data.Count; Page++)
                Console.WriteLine($"[{Page + 1}]: {Data[Page]}");
            Console.WriteLine();

            string Response = Console.ReadLine();
            try { return Data[int.Parse(Response) - 1]; }
            catch (ArgumentOutOfRangeException) { if (int.Parse(Response) != 0) throw new Exception(); return null; }
            catch { Console.Clear(); }
            return GetUI(Data);
        }
        #endregion

        #region GetBPM
        internal static Artist GetBPM(BPM BPM) =>
            GetAllArtists(
                SortList((
                    from Artist artist in Data.GetArtists() 
                    from Track release in artist.Releases 
                    where LFGenre.GetGenres(BPM).ContainsAny(release.Genres) 
                    select artist).ToList()
                )
            );
        /// <summary>
        /// Removes any duplicate names
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        private static Artist[] SortList(List<Artist> Data)
        {
            Artist PreviousArtist = Data[0];
            for (int x = 1; x < Data.Count; x++)
                if (PreviousArtist.Name.Equals(Data[x].Name)) Data.RemoveAt(x--);
                else PreviousArtist = Data[x];
            return Data.ToArray();
        }
        #endregion

        internal static Artist GetGenre(Genre genre) =>
            GetUI(
            (
                from Artist artist in Data.GetArtists()
                where artist.Genres.Contains(genre.Name)
                select artist
            ).ToList());
    }
}