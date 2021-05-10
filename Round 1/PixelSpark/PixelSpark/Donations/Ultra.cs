namespace PixelSpark.Donations
{
    public class Ultra : Ace
    {
        public Ultra(string Name) : base(Name)
        {
            Prefix = new General.Prefix("Ultra", "3", "b", "f");
            Kits[2] = DonatorCommands.SetUltraKit();
            SetHomes = 7;
            Rank = new Ultra(Name);
        }
    }
}
