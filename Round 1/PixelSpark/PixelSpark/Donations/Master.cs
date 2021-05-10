namespace PixelSpark.Donations
{
    public class Master : Ultra
    {
        public Master(string Name) : base(Name)
        {
            Prefix = new General.Prefix("Master", "d", "5", "f");
            Kits[3] = DonatorCommands.SetMasterKit();
            SetHomes = 9;
            Rank = new Master(Name);
        }
    }
}
