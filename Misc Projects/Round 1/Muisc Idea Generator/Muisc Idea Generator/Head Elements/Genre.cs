using System;
using System.Collections.Generic;

namespace Muisc_Idea_Generator
{
    class Genre
    {
        public Genre(string Genre, int MinBPM, int MaxBPM, Drums Drums, Synths Synths, Instruments Instruments, string TypicalScale, List<Track> Songs)
        {
            GenreName = Genre;
            this.MinBPM = MinBPM;
            this.MaxBPM = MaxBPM;
            this.Drums = Drums;
            this.Synths = Synths;
            this.Instruments = Instruments;
            this.TypicalScale = TypicalScale;
            this.Songs = Songs;
        }

        #region Helpers
        private readonly Random Rand = new Random();
        public string GenreName { get; set; }
        public bool ContainsSynths = true;
        #endregion

        #region BPM
        public int MinBPM { get; set; }
        public int MaxBPM { get; set; }
        #endregion

        #region Scale
        public string TypicalScale { get; set; }
        #endregion

        #region Elements
        /// <summary>
        /// Typical drums of the Genre
        /// </summary>
        public Drums Drums { get; set; }
        /// <summary>
        /// Typical synths of the Genre
        /// </summary>
        public Synths Synths { get; set; }
        /// <summary>
        /// Typical instruments of the Genre
        /// </summary>
        public Instruments Instruments { get; set; }
        /// <summary>
        /// Randomize if the song has synth elements
        /// </summary>
        /// <param name="Synth">Synth class</param>
        /// <param name="Percentage">Percentage of ContainsSynth change</param>
        /// <returns></returns>
        public Synths RandomSynth(int Percentage, Synths Synth)
        {
            if (Rand.Next(100) > 15)
                return Synth;

            bool ContainsSynth;
            if (Rand.Next(100) < Percentage)
                ContainsSynth = true;
            else
                ContainsSynth = false;
            return new Synths(ContainsSynth, ContainsSynth, ContainsSynth, ContainsSynth);
        }
        /// <summary>
        /// List of songs in genre
        /// </summary>
        public List<Track> Songs { get; set; }
        #endregion
    }
}