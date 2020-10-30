using System;

namespace MIG.SongElements.Drums
{
    public class Drums : IGetInfoInterface
    {
        public string Kick, Clap, HiHat, OpenHat, Snare;
        private readonly string[] ClassDrums;
        public bool Tom, Crash, Ride, Percussion;
        private readonly bool[] ClassElements;

        /// <param name="Drums">Kick, Clap, HiHat, OpenHat, Snare, Percussion, Tom, Crash, Ride</param>
        /// <param name="OtherElements">Tom, Crash, Ride, Percussion</param>
        public Drums(string Kick, string Clap, string HiHat, string OpenHat, string Snare, bool Tom, bool Crash, bool Ride, bool Percussion)
        {
            this.Kick = Kick;
            this.Clap = Clap;
            this.HiHat = HiHat;
            this.OpenHat = OpenHat;
            this.Snare = Snare;
            ClassDrums = new string[] { this.Kick, this.Clap, this.HiHat, this.OpenHat, this.Snare };

            this.Tom = Tom;
            this.Crash = Crash;
            this.Ride = Ride;
            this.Percussion = Percussion;
            ClassElements = new bool[] { Tom, Crash, Ride, Percussion };
        }

        public void GetInfo()
        {
            string[] DrumElements = { "Kick", "Clap", "Hi Hat", "Open Hat", "Snare"};
            Console.WriteLine("Drum Information");
            for (int x = 0; x < ClassDrums.Length; x++)
                if (ClassDrums[x] != null)
                    Console.WriteLine($"{DrumElements[x]}: {ClassDrums[x]}");

            Console.WriteLine();

            string[] OtherDrumElements = { "Tom", "Crash", "Ride", "Percussion" };
            for (int x = 0; x < ClassElements.Length; x++)
                Console.WriteLine($"{OtherDrumElements[x]}: {ClassElements[x]}");
        }
    }
}
