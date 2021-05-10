using System;

namespace Muisc_Idea_Generator
{
    class Drums
    {
        public Drums(string Kick, string Clap, string HiHat, string OpenHat, string Snare, bool Tom, bool Crash, bool Ride, bool Percussion)
        {
            this.Kick = Kick;
            this.Clap = Clap;
            this.HiHat = HiHat;
            this.OpenHat = OpenHat;
            this.Snare = Snare;
            this.Tom = Tom;
            this.Crash = Crash;
            this.Ride = Ride;
            this.Percussion = Percussion;
        }

        /// <summary>
        /// All Drum presets
        /// </summary>
        public string[,] AllDrums { get; set; }

        #region Basic Drums
        private string Kick { get; set; }
        private string Clap { get; set; }
        private string HiHat { get; set; }
        private string OpenHat { get; set; }
        private string Snare { get; set; }
        #endregion

        #region Mediary Drums idk
        private bool Tom { get; set; }
        private bool Crash { get; set; }
        private bool Ride { get; set; }
        private bool Percussion { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Write all drums
        /// </summary>
        /// <param name="SongName">Name of Song</param>
        public void GetDrums()
        {
            Console.WriteLine("-=: Drums :=-");
            GetBasicDrums();
            GetMediaryDrums();
        }

        /// <summary>
        /// Randomize drums so you don't get the same output if you sort after specific genre
        /// </summary>
        public Drums RandomizeDrums()
        {
            Random rand = new Random();
            int RandomPercentage = 50;

            #region Basic
            if (rand.Next(100) <= RandomPercentage)
                Kick = AllDrums[0, rand.Next(5)];
            if (rand.Next(100) <= RandomPercentage)
                Clap = AllDrums[1, rand.Next(2)];
            if (rand.Next(100) <= RandomPercentage)
                HiHat = AllDrums[2, rand.Next(3)];
            if (rand.Next(100) <= RandomPercentage)
                OpenHat = AllDrums[3, rand.Next(2)];
            if (rand.Next(100) <= RandomPercentage)
                Snare = AllDrums[4, rand.Next(5)];
            #endregion

            #region Mediary
            if (rand.Next(100) <= RandomPercentage)
                if (Tom)
                    Tom = false;
                else
                    Tom = true;
            if (rand.Next(100) <= RandomPercentage)
                if (Crash)
                    Crash = false;
                else
                    Crash = true;
            if (rand.Next(100) <= RandomPercentage)
                if (Ride)
                    Ride = false;
                else
                    Ride = true;
            if (rand.Next(100) <= RandomPercentage)
                if (Percussion)
                    Percussion = false;

                else
                    Percussion = true;
            #endregion

            return new Drums(Kick, Clap, HiHat, OpenHat, Snare, Tom, Crash, Ride, Percussion);
        }
        /// <summary>
        /// Write basic drums (Kick, Clap, HiHat, OpenHat, Snare)
        /// </summary>
        private void GetBasicDrums()
        {
            Console.WriteLine($"Kick: {Kick}");
            Console.WriteLine($"Clap: {Clap}");
            Console.WriteLine($"Hi Hat: {HiHat}");
            Console.WriteLine($"Open Hat: {OpenHat}");
            Console.WriteLine($"Snare: {Snare}");
        }
        /// <summary>
        /// Write mediary drums (Tom, Crash, Ride, Percussion)
        /// </summary>
        /// <param name="SongName">Name of Song</param>
        private void GetMediaryDrums()
        {
            if (Percussion)
                Console.WriteLine("It needs Percussions");
            if (Ride)
                Console.WriteLine("It needs Ride");
            if (Crash)
                Console.WriteLine("It needs Crash");
            if (Tom)
                Console.WriteLine("It needs Toms");
        }
        #endregion
    }
}