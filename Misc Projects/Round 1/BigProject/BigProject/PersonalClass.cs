using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigProject
{
    class PersonalClass
    {
        public PersonalClass(string className, int level, int rank)
        {
            className = ClassName;
            level = Level;
            rank = Rank;
        }

        #region General Class elements
        public string ClassName { get; set; }
        public int Level { get; set; }
        public int Rank { get; set; }
        public int Strength { get; set; }
        public int Smarts { get; set; }
        public int execSpeed { get; set; }
        public int moveSpeed { get; set; }
        #endregion

        public void generalStats()
        {
            Console.WriteLine("Class: " + ClassName);
            Console.WriteLine("Level: " + Level);
            Console.WriteLine("Rank: " + Rank);
            Console.WriteLine();
            Console.WriteLine("Strength: " + Strength);
            Console.WriteLine("Smarts: " + Smarts);
            Console.WriteLine("Execution Speed: " + execSpeed);
            Console.WriteLine("Movement Speed: " + moveSpeed);
        }

        #region Combat
        public int Short { get; set; }
        public int Mid { get; set; }
        public int Long { get; set; }
        #endregion

        public void combatStats(int shortRange, int midRange, int longRange)
        {
            Short = Rank * (Level * shortRange + execSpeed * moveSpeed);
            Mid = Rank * (Level * midRange + execSpeed * moveSpeed);
            Long = Rank * (Level * longRange + execSpeed * moveSpeed);
        }
        public void combatStatsGetInfo()
        {
            Console.WriteLine("Short: " + Short);
            Console.WriteLine("Mid: " + Mid);
            Console.WriteLine("Long: " + Long);
        }

        #region Armor
        public int Helmet { get; set; }
        public int Chestplate { get; set; }
        public int Leggings { get; set; }
        public int Boots { get; set; }
        public int Shield { get; set; }
        public int InvisibleBarrier { get; set; }
        #endregion

        public double protectionStats(int armorHelmet, int armorChestplate, int armorLeggings, int armorBoots, int armorShield, int armorBarrier)
        {
            double Armor = Helmet + Chestplate + Leggings + Boots * 1.75;
            double finalShield = Shield * execSpeed * 1.5;
            double Barrier = InvisibleBarrier * 1.25;
            return Armor + finalShield + Barrier;
        }
        public void protectionStatsGetInfo()
        {
            Console.WriteLine("Helmet: " + Helmet);
            Console.WriteLine("Chestpalte: " + Chestplate);
            Console.WriteLine("Leggings: " + Leggings);
            Console.WriteLine("Boots: " + Boots);
            Console.WriteLine("----------");
            double Armor = Helmet + Chestplate + Leggings + Boots * 1.75;
            Console.WriteLine("Combined armor: " + Armor);
            Console.WriteLine();
            Console.WriteLine("Shield: " + Shield);
            Console.WriteLine("----------");
            double finalShield = Shield * execSpeed * 1.5;
            Console.WriteLine("Shield Protection: " + finalShield);
            Console.WriteLine();
            Console.WriteLine("Invisible Barrier: " + InvisibleBarrier);
            Console.WriteLine("----------");
            double Barrier = InvisibleBarrier * 1.25;
            Console.WriteLine("Barrier Protection: " + Barrier);
            Console.WriteLine();
            double TAP = Armor + finalShield + Barrier;
            Console.WriteLine("Total Armor Protection: " + TAP);
            Console.WriteLine("----------");
        }


    }
}
