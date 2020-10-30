using DanhoLibrary;
using System;

namespace MIG.SongElements.Synths
{
    public class Synths : IGetInfoInterface
    {
        public Synth Lead, Chords, Bass, Arp;
        /// <summary>
        /// Lead, Chords, Bass, Arp
        /// </summary>
        private readonly Synth[] ClassSynths;

        public Synths(bool Lead, bool Chords, bool Bass, bool Arp)
        {
            if (Lead) this.Lead = new Synth();
            if (Chords) this.Chords = new Synth();
            if (Bass) this.Bass = new Synth();
            if (Arp) this.Arp = new Synth();

            ClassSynths = new Synth[] { this.Lead, this.Chords, this.Bass, this.Arp };
        }
        public void GetInfo()
        {
            string[] SynthNames = { "Lead", "Chords", "Bass", "Arp" };
            Console.WriteLine("Synth Information");
            if (ClassSynths.AllNull())
            {
                Console.WriteLine("None");
                return;
            }

            for (int x = 0; x < SynthNames.Length; x++)
            {
                string CurrentSynth = ClassSynths[x] != null ? ClassSynths[x].ToString() : "None";
                Console.WriteLine($"{SynthNames[x]}: {CurrentSynth}");
            }
        }
    }
}
