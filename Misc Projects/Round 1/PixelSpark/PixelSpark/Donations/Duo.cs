using PixelSpark.General;

namespace PixelSpark.Donations
{
    public class Duo : Trio
    {
        public Duo(string Name, string AdditionalRank) : base(Name, AdditionalRank)
        {
            Prefix = SetPrefix(AdditionalRank);
            Kits[7] = DonatorCommands.SetDuoKit();
            DonatorCommands.Jump = true;
            DonatorCommands.Speed = true;
            DonatorCommands.Top = true;
            DonatorCommands.Hatch = true;
            Rank = new Duo(Name, AdditionalRank);
        }

        private Prefix SetPrefix(string AdditionalType)
        {
            switch (AdditionalType)
            {
                case "Sun":
                    return new Prefix("Sun", "6", "e", "e");
                case "Moon":
                    return new Prefix("Moon", "d", "9", "d");
            }
            return null;
        }
    }
}
