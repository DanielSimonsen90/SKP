using System;

namespace PixelSpark
{
    class Program
    {
        private static object Login()
        {
            Console.Write("Playername: ");
            string PN = Console.ReadLine();
            Console.Write("Rank: ");
            string RankString = Console.ReadLine();
            object Rank = FindRankType(RankString, PN);
            if (Rank != null)
                return Rank;

            Console.Write("Rank Type: ");
            return FindRankType(RankString, Console.ReadLine(), PN);
        }
        private static object FindRankType(string Rank, string PN)
        {
            switch (Rank)
            {
                case "Trainer":
                    return new General.Trainer(PN);
                case "Pro":
                    return new Donations.Pro(PN);
                case "Ace":
                    return new Donations.Ace(PN);
                case "Ultra":
                    return new Donations.Ultra(PN);
                case "Master":
                    return new Donations.Master(PN);
                case "Legend":
                    return new Donations.Legend(PN);
                case "Mythic":
                    return new Donations.Mythic(PN);
            }
            return null;
        }
        private static object FindRankType(string Rank, string Type, string PN) 
        {
            switch (Rank)
            {
                case "Trio":
                    return new Donations.Trio(PN, Type);
                case "Duo":
                    return new Donations.Duo(PN, Type);
            }
            return null;
        }

        private static void Main()
        {
            Login();
            while (true)
            {
                Player.SendMessage(Console.ReadLine());
            }
        }

    }
}
