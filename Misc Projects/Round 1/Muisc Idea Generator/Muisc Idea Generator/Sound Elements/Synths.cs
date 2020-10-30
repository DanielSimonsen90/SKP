using System;

namespace Muisc_Idea_Generator
{
    class Synths
    {
        public Synths(bool SynthChords, bool SynthLeads, bool SynthBass, bool SynthArps)
        {
            Chords = SynthChords;
            Leads = SynthLeads;
            Bass = SynthBass;
            Arps = SynthArps;
        }

        #region Variables
        private bool Chords { get; set; }
        private bool Leads { get; set; }
        private bool Bass { get; set; }
        private bool Arps { get; set; }
        private readonly Random Rand = new Random();
        #endregion

        /// <summary>
        /// Get all Synths with waves & effects
        /// </summary>
        public void GetSynths(bool ContainsSynths)
        {
            if (!ContainsSynths)
                return;

            bool[] Synths = { Chords, Leads, Bass, Arps };
            string[] SynthNames = { "Chords", "Leads", "Bass", "Arps" };

            Console.WriteLine("-=: Synths :=-");

            for (int x = 0; x < Synths.Length; x++)
                if (Synths[x])
                    Console.WriteLine($"It needs a {WaveType(SynthNames[x])} with {EffectType()} Effect.");
                else if (SynthNames[x] == "Bass" && ContainsSynths)
                    Console.WriteLine($"It needs an 808 bass");
        }
        /// <summary>
        /// Get the wave type(s) of the synth
        /// </summary>
        /// <returns></returns>
        private string WaveType(string SynthName)
        {
            string[] WaveTypes = { "Sine", "Saw", "Square", "Pulse", "HPulse", "Triangle" };
            if (Rand.Next(2) == 1)
                return $"{WaveTypes[Rand.Next(WaveTypes.Length)]} {SynthName} with a mixture of a {WaveTypes[Rand.Next(WaveTypes.Length)]} wave";
            return WaveTypes[Rand.Next(WaveTypes.Length)] + " " + SynthName;
        }
        /// <summary>
        /// Get the effect(s) of the synth
        /// </summary>
        /// <returns></returns>
        private string EffectType()
        {
            string Result = "No";
            string[] Effects = { "Reverb", "Delay", "Flanger", "Phaser", "Distorted" };
            int Length = Rand.Next(1, 3);

            if (Rand.Next(1, 5) == 1)
                return Result;

            int LastIndex = Rand.Next(Effects.Length), CurrentIndex = Rand.Next(Effects.Length);
            while (CurrentIndex == LastIndex)
                CurrentIndex = Rand.Next(Effects.Length);

            for (int x = 0; x < Length; x++)
            {
                if (x >= 1)
                    Result += $" & {Effects[CurrentIndex]}";
                else
                    Result = Effects[LastIndex];
            }
            return Result;
        }
    }
}