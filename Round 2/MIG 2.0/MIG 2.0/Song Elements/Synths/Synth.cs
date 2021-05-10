using System;

namespace MIG.SongElements.Synths
{
    public class Synth
    {
        public string WaveType, Effect;
        public Synth()
        {
            WaveType = GetWaveType();
            Effect = GetEffects();
        }
        public override string ToString() => $"{WaveType} with {Effect}.";

        private string GetWaveType()
        {
            //All basic wavetypes
            string[] WaveTypes = { "Sine", "Saw", "Square", "Pulse", "HPulse", "Triangle" };
            int LastIndex = RandomNumbers(0, WaveTypes.Length, out int CurrentIndex);

            //50/50 chance of 2 wavetypes or 1
            return (new Random().Next(0, 2) == 1) ?
                $"{WaveTypes[CurrentIndex]} with a mixture of a {WaveTypes[LastIndex]} wave" :
                WaveTypes[CurrentIndex];
        }
        private string GetEffects()
        {
            //If no effects
            string Result = string.Empty;
            if (new Random().Next(0, 5) == 1)
                return "No effects";

            //Get them variables ready
            string[] Effects = { "Reverb", "Delay", "Flanger", "Phaser", "Distorted", "Chorus" };
            int MaxSynths = new Random().Next(1, 3),
                LastIndex = RandomNumbers(0, Effects.Length, out int CurrentIndex);

            //Determine whether 1 effect or multiple
            for (int x = 0; x < MaxSynths; x++)
                Result += (x >= 1) ? $" & {Effects[CurrentIndex]}" : Effects[LastIndex];

            return Result;
        }

        private int RandomNumbers(int Min, int Max, out int Num2)
        {
            int Num1 = new Random().Next(Min, Max);
            Num2 = new Random().Next(Min, Max);

            while (Num1 == Num2)
                Num2 = new Random().Next(Min, Max);
            return Num1;
        }
    }
}