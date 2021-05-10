using System;

namespace PixelSpark.Donations
{
    public class Pro : General.Trainer
    {
        public Pro(string Name) : base(Name)
        {
            Prefix = new General.Prefix("Pro", "4", "c", "f");
            Kits[0] = DonatorCommands.SetProKit();
            SetHomes = 3;
            DonatorCommands.EnderChest = true;
            DonatorCommands.Pokeheal = true;
            DonatorCommands.Nick = true;
            Rank = new Pro(Name);
        }

        public General.Item[][] Kits = new General.Item[8][];

        #region Keys
        public bool LegendKey = true;
        public bool MythicKey = false;
        public bool AuraKey = true;
        public void RedeemKey(string Key)
        {
            string[] KeyList = { "Legend", "Mythic", "Aura" };
            bool[] BoolList = { LegendKey, MythicKey, AuraKey };

            for (int x = 0; x < KeyList.Length; x++)
                if (Key == KeyList[x] && BoolList[x])
                    Console.WriteLine($"Redeemed {Key}.");
        }
        #endregion
    }
}
