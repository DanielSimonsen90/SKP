using System;

namespace Muisc_Idea_Generator
{
    class Track
    {
        /// <summary>
        /// Aka Song
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Genre"></param>
        /// <param name="Artist"></param>
        public Track(string Name, string Genre, string Artist)
        {
            this.Name = Name;
            this.Genre = Genre;
            this.ArtistName = Artist;
        }

        #region Variables
        public string Name { get; set; }
        public string Genre { get; set; }
        public string AdditionalGenre { get; set; }
        public string ArtistName { get; set; }

        public bool GetReferenceTrack()
        {
            Console.WriteLine($"Reference Artist: {ArtistName}");
            Console.WriteLine($"Reference Track: {Name}");
            return true;
        }
        #endregion
    }
}