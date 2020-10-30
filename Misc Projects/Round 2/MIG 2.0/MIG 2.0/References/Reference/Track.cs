using System;
namespace MIG.References.Reference
{
    public class Track
    {
        #region Properties
        public string Name;
        public Genre Genre, SubGenre;
        public Genre[] Genres => 
            SubGenre is null ? 
                new Genre[] { Genre } : 
                new Genre[] { Genre, SubGenre };
        #endregion

        #region Constructors
        public Track(string name, string genre)
        {
            Name = name;
            Genre = FindGenre(genre);
        }
        public Track(string name, string genre, string Subgenre) : 
            this(name, genre) => SubGenre = FindGenre(Subgenre);
        #endregion

        private static Genre FindGenre(string Name)
        {
            foreach (Genre genre in Data.GetGenres())
                if (genre.Name.ToLower().Equals(Name.ToLower()))
                    return genre;
            throw new Exception($"Genre not found - Input: \"{Name}\"");
        }
        public override string ToString() => Name;
    }
}
