namespace PixelSpark.Donations
{
    public class Ace : Pro
    {
        public Ace(string Name) : base(Name)
        {
            Prefix = new General.Prefix("Ace", "2", "a", "f");
            Kits[1] = DonatorCommands.SetAceKit();
            SetHomes = 5;
            Rank = new Ace(Name);
        }
    }
}
