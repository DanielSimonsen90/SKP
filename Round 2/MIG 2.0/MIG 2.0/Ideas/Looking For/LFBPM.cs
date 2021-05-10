using MIG.References;
using MIG.References.Reference;
using System;
using System.Linq;

namespace MIG
{
    class LFBPM
    {
        public static BPM GetBPM() => GetBPM(70, 200);
        private static BPM GetBPM(int Min, int Max)
        {
            Console.WriteLine($"Pick a BPM from {Min} - {Max}.");
            string Response = Console.ReadLine();
            return new BPM(ResponseParse(Response, Min, Max));
        }

        private static int ResponseParse(string Response, params int[] Values)
        {
            try
            {
                int BPMNumber = int.Parse(Response);
                if (Values.CanContain(BPMNumber)) return BPMNumber;
                else if (BPMNumber == 0) return 0;
                throw new Exception("Invalid BPM");
            }
            catch (Exception e)
            {
                try { if (e.Message.Equals("Invalid BPM")) return new Random().Next(Values[0], Values[1]); }
                catch { throw new Exception("Error occurred. " + e.Message); }
            }
            return -1;
        }

        public static BPM GetGenre(Genre genre) => GetBPM(genre.BPM.Ranges[0], genre.BPM.Ranges[1]);
        public static BPM GetArtist(Artist Artist) =>
            GetBPM((from Track track in Artist.Releases
                    select track.Genre.BPM.Ranges[0]).ToList().Min(),
                   (from Track track in Artist.Releases
                    select track.Genre.BPM.Ranges[1]).ToList().Max());
    }
}