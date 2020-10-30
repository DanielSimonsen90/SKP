using System;

namespace MIG.SongElements
{
    public class Instruments : IGetInfoInterface
    {
        public readonly bool[] ContainsInstruments;
        private readonly string[] Names = { "Piano", "Guitar", "Horn", "Strings" };
        public Instruments(bool Piano, bool Guitar, bool Horn, bool Strings) =>
            ContainsInstruments = new bool[] { Piano, Guitar, Horn, Strings };

        public void GetInfo()
        {
            Console.WriteLine("Instrument Information");
            for (int x = 0; x < ContainsInstruments.Length; x++)
                Console.WriteLine($"{Names[x]}: {ContainsInstruments[x]}");
        }
    }
}
