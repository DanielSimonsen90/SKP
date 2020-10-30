using DanhoLibrary;
using System.Collections.Generic;
using System.Linq;

namespace MIG.References.Reference
{
    /// <summary>
    /// Contains randomized Reference Artist and Reference Track
    /// </summary>
    public class Reference
    {
        public Artist Artist { get; }
        public Track Track { get; }

        public Reference(Genre genre)
        {
            List<Artist> ValidArtists = (from Artist artist in Artist.GetData()
                                         where artist.Genres.Contains(genre.Name)
                                         select artist).ToList();

            try { Artist = ValidArtists.GetRandomItem();
                  Track = GetTrack(genre.Name); }
            catch { }
        }
        public Reference(Artist artist)
        {
            Artist = artist;
            Track = Artist.Songs.GetRandomItem();
        }
        public Reference(Genre genre, Artist artist)
        {
            Artist = artist;
            Track = GetTrack(genre.Name);
        }

        private Track GetTrack(string Genre)
        {
            List<Track> Result = new List<Track>();
            foreach (Track track in Artist.Releases)
                if (track.Genre.Name == Genre ||
                    track.SubGenre != null && track.SubGenre.Name == Genre)
                    Result.Add(track);
            return Result.GetRandomItem();
        }
    }
}