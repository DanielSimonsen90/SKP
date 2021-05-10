using System.Collections.Generic;
using System.Linq;

namespace MIG.References.Reference
{
    public class Artist
    {
        /// <summary>
        /// All artists
        /// </summary>
        /// <returns></returns>
        public static Artist[] GetData() => Data.GetArtists();

        public readonly Track[] Remixes, Songs;
        public Track[] Releases
        {
            get
            {
                List<Track> temp = Songs.ToList();
                if (Remixes != null) temp.AddRange(Remixes.ToList());
                return temp.ToArray();
            }
        }
        public string Name { get; }
        public string[] Genres
        {
            get
            {
                List<string> TempList = new List<string>();
                foreach (Track song in Songs)
                    if (!TempList.Contains(song.Genre.Name))
                        TempList.Add(song.Genre.Name);
                if (Remixes != null)
                    foreach (Track remix in Remixes)
                        if (!TempList.Contains(remix.Genre.Name))
                            TempList.Add(remix.Genre.Name);
                return TempList.ToArray();
            }
        }

        public Artist(string name, Track[] songs)
        {
            Name = name;
            Songs = songs;
        }
        public Artist(string name, Track[] songs, Track[] Remixes) :
            this(name, songs) => this.Remixes = Remixes;

        public override string ToString() => Name;
    }
}
