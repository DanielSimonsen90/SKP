using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokémon_I_guess
{
    class Program
    {
        static void Main()
        {

        }
    }
}
namespace General
{
    class Types
    {
        public Types[] Resistance { get; set; }
        public Types[] Amplify { get; set; }
        public Types ImmuneType { get; set; }
        public Types SecondImmuneType { get; set; }

        public Types[] SetResistance(Types[] TypeResistance)
        {
            Resistance = TypeResistance;
            return Resistance;
        }
        public Types[] SetAmplify(Types[] TypeAmplify)
        {
            Amplify = TypeAmplify;
            return Amplify;
        }
        public Types SetImmunity (Types ImmunityType)
        {
            ImmuneType = ImmunityType;
            return ImmuneType;
        }
        public int GetDamage(Moves MoveUsed, Types EnemyType)
        {
            
        }
    }
    class Nature
    {
        public Nature(string nature)
        {
            PokémonNature = nature;
        }
        string PokémonNature { get; set; }

        public Stats GetStats()
        {
            Stats stats = new Stats(0, 0, 0, 0, 0, 0);
            //Neutral
            if (PokémonNature == "Hardy" || PokémonNature == "Docile" || PokémonNature == "Bashful" || PokémonNature == "Quirky" || PokémonNature == "Serious")
                stats = new Stats(0, 0, 0, 0, 0, 0);
            //Up Attack
            else if (PokémonNature == "Lonely")
                stats = new Stats(0, 1, -1, 0, 0, 0);
            else if (PokémonNature == "Adamant")
                stats = new Stats(0, 1, 0, -1, 0, 0);
            else if (PokémonNature == "Naughty")
                stats = new Stats(0, 1, 0, 0, -1, 0);
            else if (PokémonNature == "Brave")
                stats = new Stats(0, 1, 0, 0, 0, -1);
            //Up Defense
            else if (PokémonNature == "Bold")
                stats = new Stats(0, -1, 1, 0, 0, 0);
            else if (PokémonNature == "Impish")
                stats = new Stats(0, 0, 1, -1, 0, 0);
            else if (PokémonNature == "Lax")
                stats = new Stats(0, 0, 1, 0, -1, 0);
            else if (PokémonNature == "Relaxed")
                stats = new Stats(0, 0, 1, 0, 0, -1);
            //Up Special Attack
            else if (PokémonNature == "Modest")
                stats = new Stats(0, -1, 0, 1, 0, 0);
            else if (PokémonNature == "Mild")
                stats = new Stats(0, 0, -1, 1, 0, 0);
            else if (PokémonNature == "Rash")
                stats = new Stats(0, 0, 0, 1, -1, 0);
            else if (PokémonNature == "Quiet")
                stats = new Stats(0, 0, 0, 1, 0, -1);
            //Up Special Defense
            else if (PokémonNature == "Calm")
                stats = new Stats(0, -1, 0, 0, 1, 0);
            else if (PokémonNature == "Gentle")
                stats = new Stats(0, 0, -1, 0, 1, 0);
            else if (PokémonNature == "Careful")
                stats = new Stats(0, 0, 0, -1, 1, 0);
            else if (PokémonNature == "Sassy")
                stats = new Stats(0, 0, 0, 0, 1, -1);
            //Up Speed
            else if (PokémonNature == "Timid")
                stats = new Stats(0, -1, 0, 0, 0, 1);
            else if (PokémonNature == "Hasty")
                stats = new Stats(0, 0, -1, 0, 0, 1);
            else if (PokémonNature == "Jolly")
                stats = new Stats(0, 0, 0, -1, 0, 1);
            else if (PokémonNature == "Naive")
                stats = new Stats(0, 0, 0, 0, -1, 1);
            else
                stats = new Stats(100, 100, 100, 100, 100, 100);

            return stats;
        }
    }
    class Stats
    {
        public Stats(int HP, int Atk, int Def, int SpA, int SpD, int Spe)
        {
            HealthPoints = HP;
            Attack = Atk;
            Defense = Def;
            SpecialAttack = SpA;
            SpecialDefense = SpD;
            Speed = Spe;
        }
        static int HealthPoints { get; set; }
        static int Attack { get; set; }
        static int Defense { get; set; }
        static int SpecialAttack { get; set; }
        static int SpecialDefense { get; set; }
        static int Speed { get; set; }

        public Stats LevelUp(Species.Pokémon PokémonKilled)
        {
            Stats NewStats = new Stats(HealthPoints, Attack, Defense, SpecialAttack, SpecialDefense, Speed);



            return NewStats;
        }
    }
    class Pokéball
    {
        public Pokéball(string ballType, double catchBonus)
        {
            BallType = ballType;
            CatchBonus = catchBonus;
        }
        string BallType { get; set; }
        double CatchBonus { get; set; }
    }
    class Moves
    {
        public Moves(string moveName, string moveDescription, int moveDamage, int movePP, string moveType, int statusPercentage, string statusType)
        {
            Name = moveName;
            Description = moveDescription;
            Damage = moveDamage;
            PP = movePP;
            Type = moveType;
            StatusPercent = statusPercentage;
            StatusType = statusType;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Damage { get; set; }
        public int PP { get; set; }
        public string Type { get; set; }
        public int StatusPercent { get; set; }
        public string StatusType { get; set; }

    }
}
namespace Species
{
    class Pokémon
    {
        public Pokémon(string pokémon, bool hasNickname, string nickname, General.Types type1, General.Types type2, int level, General.Pokéball pokéball)
        {
            try
            {
                Species = pokémon;
                HasNickname = hasNickname;
                Nickname = nickname;
                Type1 = type1;
                Type2 = type2;
                Level = level;
                Pokéball = pokéball;
                TypeValid(Type1, Type2);
            }
            catch
            {
                Console.WriteLine("Something went wrong in creating the Pokémon.");
            }
        }
        public string Species { get; set; }
        public bool HasNickname { get; set; }
        public string Nickname { get; set; }
        public General.Types Type1 { get; set; }
        public General.Types Type2 { get; set; }
        public int Level { get; set; }
        public General.Stats Stats { get; set; }
        public General.Pokéball Pokéball { get; set; }
        public General.Nature Nature { get; set; }

        static General.Types[] AllTypes()
        {
            //New Types

            //Resistance
            General.Types[] BugResistance = { Fighting, Grass, Ground };
            General.Types[] DarkResistance = { Dark, Ghost };
            General.Types[] DragonResistance = { Electric, Fire, Grass, Water };
            General.Types[] ElectricResistance = { Electric, Flying, Steel };
            General.Types[] FairyResistance = { Bug, Dark, Fighting };
            General.Types[] FightingResistance = { Bug, Dark, Rock };
            General.Types[] FireResistance = { Bug, Fairy, Fire, Grass, Ice, Steel };
            General.Types[] FlyingResistance = { Bug, Fighting, Grass };
            General.Types[] GhostResistance = { Bug, Poison };
            General.Types[] GrassResistance = { Electric, Grass, Ground, Water };
            General.Types[] GroundResistance = { Poison, Rock };
            General.Types[] IceResistance = { Ice };
            General.Types[] PoisonResistance = { Bug, Fairy, Fighting, Grass, Poison };
            General.Types[] PsychicResistance = { Fighting, Psychic };
            General.Types[] RockResistance = { Fire, Flying, Normal, Poison };
            General.Types[] SteelResistance = { Bug, Dragon, Fairy, Flying, Grass, Ice, Normal, Psychic, Rock, Steel };
            General.Types[] WaterResistance = { Fire, Ice, Steel, Water };

            //Amplify
            General.Types[] BugAmplify = { Psychic, Ground, Dark };
            General.Types[] DarkAmplify = { Ghost, Psychic };
            General.Types[] DragonAmplify = { Dragon };
            General.Types[] ElectricAmplify = { Flying, Water };
            General.Types[] FairyAmplify = { Dark, Dragon, Fighting };
            General.Types[] FightingAmplify = { Dark, Ice, Normal, Rock, Steel };
            General.Types[] FireAmplify = { Bug, Grass, Ice, Steel };
            General.Types[] FlyingAmplify = { Bug, Fighting, Grass };
            General.Types[] GhostAmplify = { Ghost, Psychic };
            General.Types[] GrassAmplify = { Ground, Rock, Water };
            General.Types[] GroundAmplify = { Electric, Fire, Poison, Rock, Steel };
            General.Types[] IceAmplify = { Dragon, Flying, Grass, Ground };
            General.Types[] PoisonAmplify = { Grass, Fairy };
            General.Types[] PsychicAmplify = { Fighting, Poison };
            General.Types[] RockAmplify = { Bug, Fire, Flying, Ice };
            General.Types[] SteelAmplify = { Fairy, Ice, Rock };
            General.Types[] WaterAmplify = { Fire, Ground, Rock };

            //Set Resistance
            Bug.SetResistance(BugResistance);
            Dark.SetResistance(DarkResistance);
            Dragon.SetResistance(DragonResistance);
            Electric.SetResistance(ElectricResistance);
            Fairy.SetResistance(FairyResistance);
            Fighting.SetResistance(FightingResistance);
            Fire.SetResistance(FireResistance);
            Flying.SetResistance(FlyingResistance);
            Ghost.SetResistance(GhostResistance);
            Grass.SetResistance(GrassResistance);
            Ground.SetResistance(GroundResistance);
            Ice.SetResistance(IceResistance);
            Poison.SetResistance(PoisonResistance);
            Psychic.SetResistance(PsychicResistance);
            Rock.SetResistance(RockResistance);
            Steel.SetResistance(SteelResistance);
            Water.SetResistance(WaterResistance);

            //Set Amplify
            Bug.SetAmplify(BugAmplify);
            Dark.SetAmplify(DarkAmplify);
            Dragon.SetAmplify(DragonAmplify);
            Electric.SetAmplify(ElectricAmplify);
            Fairy.SetAmplify(FairyAmplify);
            Fighting.SetAmplify(FightingAmplify);
            Fire.SetAmplify(FireAmplify);
            Flying.SetAmplify(FlyingAmplify);
            Ghost.SetAmplify(GhostAmplify);
            Grass.SetAmplify(GrassAmplify);
            Ground.SetAmplify(GroundAmplify);
            Ice.SetAmplify(IceAmplify);
            Poison.SetAmplify(PoisonAmplify);
            Psychic.SetAmplify(PsychicAmplify);
            Rock.SetAmplify(RockAmplify);
            Steel.SetAmplify(SteelAmplify);
            Water.SetAmplify(WaterAmplify);

            //Set Immune
            Dark.ImmuneType = Psychic;
            Fairy.ImmuneType = Dragon;
            Flying.ImmuneType = Ground;
            Ghost.ImmuneType = Normal;
            Ghost.SecondImmuneType = Fighting;
            Ground.ImmuneType = Electric;
            Normal.ImmuneType = Ghost;
            Steel.ImmuneType = Poison;

            //Wait what were we actually looking for again?
            General.Types[] allTypes = { Bug, Dark, Dragon, Electric, Fairy, Fighting, Fire, Flying, Ghost, Grass, Ground, Ice, Normal, Poison, Psychic, Rock, Steel, Water };

            return allTypes;
        }
        static bool TypeValid(General.Types main, General.Types off)
        {
            General.Types[] allTypes = AllTypes();
            bool Type1 = false, Type2 = false;
            for (int x = 0; x < allTypes.Length; x++)
                if (allTypes[x] == main)
                    Type1 = true;
                else if (allTypes[x] == off)
                    Type2 = true;
            if (Type1 && Type2)
                return true;
            else
                return false;
        }
        public int HealthLost(General.Moves enemyMove)
        {
            int healthLost = 0;
            double damageFromEnemy = enemyMove.Damage;

            //If Type1 is hit by enemyMove.Type (using damageFromEnemy as equal to enemyMove.Type)
            //If damageFromEnemy is 2x than enemyMove.Damage but Type2 resists
            //If Type1 is immune to enemyMove.Type

            return healthLost;
        }
        public General.Stats GetStats(int HP, int Atk, int Def, int SpA, int SpD, int Spe)
        {
            General.Stats PokémonStats = new General.Stats(HP, Atk, Def, SpA, SpD, Spe);
            return PokémonStats;
        }
        public General.Nature GetNature(string neededNature)
        {
            General.Nature PokémonNature = new General.Nature(neededNature);
            General.Stats derpStats = new General.Stats(0, 0, 0, 0, 0, 0);
            if (PokémonNature.GetStats() != derpStats)
            {
                Nature = PokémonNature;
                return PokémonNature;
            }
            else
                return null;
        }

        public Pokémon[] PokéDex = new Pokémon[151];
        public Pokémon[] setPokéDex(Pokémon[] PokeDex)
        {
            PokeDex[1] = new Pokémon("Bulbasaur", false, null, Grass, Poison, 5, null);
            PokeDex[2] = new Pokémon("Ivysaur", false, null, Grass, Poison, 16, null);
            PokeDex[3] = new Pokémon("Venusaur", false, null, Grass, Poison, 32, null);
            PokeDex[4] = new Pokémon("Squirtle", false, null, Water, null, 5, null);
            PokeDex[5] = new Pokémon("Wartortle", false, null, Water, null, 16, null);


            PokéDex = PokeDex;
            return PokeDex;
        }

        static General.Types Bug = new General.Types();
        static General.Types Dark = new General.Types();
        static General.Types Dragon = new General.Types();
        static General.Types Electric = new General.Types();
        static General.Types Fairy = new General.Types();
        static General.Types Fighting = new General.Types();
        static General.Types Fire = new General.Types();
        static General.Types Flying = new General.Types();
        static General.Types Ghost = new General.Types();
        static General.Types Grass = new General.Types();
        static General.Types Ground = new General.Types();
        static General.Types Ice = new General.Types();
        static General.Types Normal = new General.Types();
        static General.Types Poison = new General.Types();
        static General.Types Psychic = new General.Types();
        static General.Types Rock = new General.Types();
        static General.Types Steel = new General.Types();
        static General.Types Water = new General.Types();

    }
}

