using System;

namespace MIG.References
{
    public class BPM
    {
        public int Value { get; }
        public int[] Ranges { get; }
        public string RangesText => $"{Ranges[0]} - {Ranges[1]}";

        public BPM(int[] Ranges)
        {
            this.Ranges = Ranges;
            Value = new Random().Next(Ranges[0], Ranges[1]);
        }
        public BPM(int Value) => this.Value = Value;
        public BPM(int[] Ranges, int Value) : this(Ranges) => this.Value = Value;
        public override string ToString() => Value.ToString();
    }
}