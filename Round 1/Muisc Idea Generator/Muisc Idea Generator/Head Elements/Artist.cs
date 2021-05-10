using System;

namespace Muisc_Idea_Generator
{
    class Artist
    {
        /// <summary>
        /// Reference Artist
        /// </summary>
        /// <param name="Name">Name of Artist</param>
        /// <param name="Tracks">Songs <see cref="Name"/> has made</param>
        public Artist(string Name, Track[] Tracks)
        {
            this.Name = Name;
            this.Tracks = Tracks;
        }

        public string Name { get; set; }
        /// <summary>
        /// Tracks created by <see cref="Name"/>
        /// </summary>
        public Track[] Tracks { get; set; }

        /// <summary>
        /// Find a random Reference Track from the artist
        /// </summary>
        /// <param name="Genre">Genre to search for</param>
        /// <returns>Reference Track</returns>
        public Track GetReferenceTrack()
        {
            Random Rand = new Random();
            return Tracks[Rand.Next(Tracks.Length)];
        }
    }

}