using PixelSpark.General;

namespace PixelSpark.Donations
{
    public class Trio : Mythic
    {
        public Trio(string Name, string AdditionalRank) : base(Name)
        {
            Prefix = SetPrefix(AdditionalRank);
            Kits[6] = DonatorCommands.SetTrioKit();
            DonatorCommands.Triochat = true;
            Rank = new Trio(Name, AdditionalRank);
        }

        private Prefix SetPrefix(string AdditionalType)
        {
            switch (AdditionalType)
            {
                case "Ruby":
                    return new Prefix("Ruby", "c", "4", "c");
                case "Sapphire":
                    return new Prefix("Sapphire", "9", "1", "9");
                case "Emerald":
                    return new Prefix("Emerald", "2", "a", "f");
            }
            return null;
        }
    }
}
