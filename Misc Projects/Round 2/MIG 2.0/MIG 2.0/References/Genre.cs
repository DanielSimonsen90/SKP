using System;
using System.Linq;
using MIG.SongElements;
using MIG.SongElements.Drums;
using MIG.SongElements.Synths;

namespace MIG.References
{
    public class Genre
    {
        #region Variables
        public string Name { get; }
        public Scale Scale;
        public BPM BPM { get; set; }
        public Drums Drums { get; }
        public Synths Synths { get; }
        public Instruments Instruments { get; }
        private readonly IGetInfoInterface[] Elements;
        #endregion

        public Genre(string name, int[] BPMRange, Drums drums, Synths synths, Instruments instruments)
        {
            Name = name;
            Scale = new Scale(50);
            BPM = new BPM(BPMRange);
            Drums = drums;
            Synths = synths;
            Instruments = instruments;
            Elements = new IGetInfoInterface[] { Drums, Synths, Instruments };
        }

        public void GetInfo(bool GetBPM)
        {
            Console.WriteLine($"Genre {Name}");
            if (GetBPM) Console.WriteLine($"BPM: {BPM}");
            Console.WriteLine($"BPM Range: {BPM.Ranges.Min()} - {BPM.Ranges.Max()}");
            Console.WriteLine("Scale: " + Scale);
            Console.WriteLine();

            for (int x = 0; x < Elements.Length; x++)
                GetInfo(Elements[x]);
        }
        /// <summary>
        /// Runs through every element's GetInfo()
        /// </summary>
        /// <param name="Element"></param>
        private void GetInfo(IGetInfoInterface Element)
        {
            Element.GetInfo();
            Console.WriteLine();
        }
        public override string ToString() => Name;
    }
}
