namespace PixelSpark.Donations
{
    public class Mythic : Legend 
    {
        public Mythic(string Name) : base(Name)
        {
            Prefix = new General.Prefix("Mythic", "5", "d", "f");
            Kits[5] = DonatorCommands.SetMythicKit();
            MythicKey = true;
            Rank = new Mythic(Name);
        }
    }
}
