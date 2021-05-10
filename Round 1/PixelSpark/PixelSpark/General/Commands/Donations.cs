namespace PixelSpark.General.Commands
{
    public class Donations
    {
        private readonly Kit KitItems = new Kit();

        #region General
        public int SetHomes = 1;
        public bool Pokeheal = false;
        public bool Nick = false;
        public bool EnderChest = false;
        public bool Fly = false;
        public bool Triochat = false;
        public bool Jump = false;
        public bool Speed = false;
        public bool Top = false;
        public bool Hatch = false;
        #endregion

        #region Donation kits
        #region General
        public Item[] SetProKit()
        {
            Kit KitItems = new Kit();
            KitItems.Pokéball.Amount = 5;
            KitItems.OakWood.Amount = 64;
            KitItems.RareCandy.Amount = 1;

            return new Item[] { KitItems.Pokéball, KitItems.OakWood, KitItems.RareCandy };
        }
        public Item[] SetAceKit()
        {
            KitItems.RareCandy.Amount = 4;
            KitItems.Pokéball.Amount = 5;
            KitItems.GreatBall.Amount = 5;
            KitItems.FriendBall.Amount = 5;
            KitItems.OakWood.Amount = 64;
            return new Item[] { KitItems.RareCandy, KitItems.Pokéball, KitItems.GreatBall, KitItems.FriendBall, KitItems.OakWood };
        }
        public Item[] SetUltraKit()
        {
            KitItems.RareCandy.Amount = 9;
            KitItems.Pokéball.Amount = 5;
            KitItems.GreatBall.Amount = 5;
            KitItems.UltraBall.Amount = 10;
            KitItems.FriendBall.Amount = 5;
            KitItems.OakWood.Amount = 64;
            return new Item[] { KitItems.RareCandy, KitItems.Pokéball, KitItems.GreatBall, KitItems.UltraBall, KitItems.FriendBall, KitItems.OakWood };
        }
        public Item[] SetMasterKit()
        {
            KitItems.RareCandy.Amount = 19;
            KitItems.Pokéball.Amount = 5;
            KitItems.GreatBall.Amount = 5;
            KitItems.UltraBall.Amount = 20;
            KitItems.MasterBall.Amount = 1;
            KitItems.FriendBall.Amount = 5;
            KitItems.OakWood.Amount = 64;
            return new Item[] { KitItems.RareCandy, KitItems.Pokéball, KitItems.GreatBall, KitItems.UltraBall, KitItems.MasterBall, KitItems.FriendBall, KitItems.OakWood };
        }
        public Item[] SetLegendKit()
        {
            KitItems.Pokéball.Amount = 5;
            KitItems.GreatBall.Amount = 5;
            KitItems.UltraBall.Amount = 20;
            KitItems.FriendBall.Amount = 5;
            KitItems.LevelBall.Amount = 5;
            KitItems.Diamond.Amount = 1;
            KitItems.OakWood.Amount = 64;
            return new Item[] { KitItems.Pokéball, KitItems.GreatBall, KitItems.UltraBall, KitItems.FriendBall, KitItems.LevelBall, KitItems.Diamond, KitItems.OakWood };
        }
        public Item[] SetMythicKit()
        {
            KitItems.Pokéball.Amount = 5;
            KitItems.GreatBall.Amount = 5;
            KitItems.UltraBall.Amount = 35;
            KitItems.FriendBall.Amount = 5;
            KitItems.LevelBall.Amount = 5;
            KitItems.HealBall.Amount = 5;
            KitItems.Diamond.Amount = 6;
            KitItems.OakWood.Amount = 64;
            return new Item[] { KitItems.Pokéball, KitItems.GreatBall, KitItems.UltraBall, KitItems.FriendBall, KitItems.LevelBall, KitItems.HealBall, KitItems.Diamond, KitItems.OakWood };
        }
        public Item[] SetTrioKit()
        {
            KitItems.Pokéball.Amount = 5;
            KitItems.GreatBall.Amount = 5;
            KitItems.UltraBall.Amount = 50;
            KitItems.FriendBall.Amount = 5;
            KitItems.LevelBall.Amount = 5;
            KitItems.HealBall.Amount = 5;
            KitItems.DuskBall.Amount = 5;
            KitItems.DiveBall.Amount = 5;
            KitItems.CherishBall.Amount = 5;
            KitItems.Diamond.Amount = 11;
            KitItems.DiamondBlock.Amount = 1;
            KitItems.OakWood.Amount = 64;
            return new Item[]
            {
                KitItems.Pokéball, KitItems.GreatBall, KitItems.UltraBall, KitItems.FriendBall, KitItems.LevelBall, KitItems.HealBall, KitItems.DuskBall, KitItems.DiveBall,
                KitItems.CherishBall, KitItems.Diamond, KitItems.DiamondBlock, KitItems.OakWood
            };
        }
        public Item[] SetDuoKit()
        {
            KitItems.Pokéball.Amount = 5;
            KitItems.GreatBall.Amount = 5;
            KitItems.UltraBall.Amount = 75;
            KitItems.FriendBall.Amount = 5;
            KitItems.LevelBall.Amount = 5;
            KitItems.HealBall.Amount = 5;
            KitItems.DuskBall.Amount = 5;
            KitItems.DiveBall.Amount = 5;
            KitItems.CherishBall.Amount = 5;
            KitItems.Diamond.Amount = 21;
            KitItems.DiamondBlock.Amount = 1;
            KitItems.GoldBlock.Amount = 1;
            KitItems.CoalBlock.Amount = 1;
            KitItems.OakWood.Amount = 64;
            return new Item[]
            {
                KitItems.Pokéball, KitItems.GreatBall, KitItems.UltraBall, KitItems.FriendBall, KitItems.LevelBall, KitItems.HealBall, KitItems.DuskBall, KitItems.DiveBall,
                KitItems.CherishBall, KitItems.Diamond, KitItems.DiamondBlock, KitItems.GoldBlock, KitItems.CoalBlock, KitItems.OakWood
            };
        }
        #endregion

        #region Other Kits
        public Item[] SetLegendaryKeyKit()
        {
            return new Item[] { KitItems.LegendaryKey };
        }
        public Item[] SetMythicKeyKit()
        {
            return new Item[] { KitItems.MythicKey };
        }
        public Item[] SetAuraKit()
        {
            return new Item[] { KitItems.AuraKey };
        }
        #endregion
        #endregion
    }
}