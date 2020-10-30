namespace PixelSpark.Donations
{
    public class Legend : Master
    {
        public Legend(string Name) : base(Name)
        {
            Prefix = new General.Prefix("Legend", "e", "6", "f");
            Kits[4] = DonatorCommands.SetLegendKit();
            SetHomes = 9999;
            DonatorCommands.Fly = true;
            Rank = new Legend(Name);
        }
    }
}
