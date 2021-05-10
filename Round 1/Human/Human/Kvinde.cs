using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human
{
    class Kvinde
    {
        //Formal stat: Stoner -> Bad girl -> Tomgirl -> Innocent -> Oblivious -> Sofisticated
        //Sin meter

        public Kvinde(string name, string birthday, int age, string occupation, string hobby)
        {
            Name = name;
            Birthday = birthday;
            Age = age;
            Occupation = occupation;
            Hobby = hobby;
        }

        #region General information
        public string Name { get; set; }
        public string Birthday { get; set; }
        public int Age { get; set; }
        public string Occupation { get; set; }
        public string Hobby { get; set; }
        #endregion

        #region Appearance
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public static bool[] Cosmetics { get; set; }
        public static string[] CosmeticType { get; set; }
        public char Cup { get; set; }
        public string Bra { get; set; }
        private int BraHelper { get; set; }
        public string Shirt { get; set; }
        public string Pants { get; set; }
        public string Thighs { get; set; }
        public string ButtSize { get; set; }
        public string Shoes { get; set; }
        #endregion

        #region BMI
        public double Height { get; set; }
        public int Weight { get; set; }
        public int BMI { get; set; }
        public bool HasNumber { get; set; }
        #endregion

        #region Meters
        public int LikenessMeter { get; set; }
        public string Formal { get; set; }
        string GetMeters()
        {
            string[] FormalStat = { "Stoner", "Bad Girl", "Tomgirl", "Innocent", "Oblivious", "Sofisticated" };
            Random rand = new Random();

            LikenessMeter = 10;

            Formal = FormalStat[rand.Next(0, 5)];
            return Formal;
        } //Likeness | Formal
        #endregion

        #region Appearance
        public void GetLooks()
        {
            //Array Definitions
            string[] HairArr = { "Blonde", "Dirty Blonde", "Brunette", "Dark", "Red", "Ginger", "Blue", "Green", "Pink", "Purple", "White" };
            string[] EyeArr = { "Blue", "Green", "Brown", "Hazel", "Ocean" };

            //Defining Random stat
            Random rand = new Random();
            int randHair = rand.Next(0, 10);
            int randEye = rand.Next(0, 4);

            //Finalizing Variables
            HairColor = HairArr[randHair];
            EyeColor = EyeArr[randEye];

            Cosmetics = GetCosmetics(out string[] cosmeticType);
            CosmeticType = cosmeticType;
            GetNumeralInfo();
            GetClothes();
        } //Hair | Eye
        public bool[] GetCosmetics(out string[] cosmeticType)
        {
            GetMeters();
            //Cosmetics = Hat, Glasses, Earrings, Necklace, Bracelet, Ring, Tattoo, Piercing
            bool[] cosmetics = new bool[8];
            cosmeticType = new string[8] { "Hat", "Pair of Glasses", "Pair of Earrings", "Necklace", "Bracelent", "Ring", "Tattoo", "Piercing" };
            Random rand = new Random();

            //Hat
            int random = rand.Next(0, 100);
            if (random <= 64 && Formal == "Stoner")
                cosmetics[0] = true;
            else if (random <= 60 && Formal == "Tomgirl")
                cosmetics[0] = true;
            else if (Formal == "Oblivious")
                cosmetics[0] = true;
            else
                cosmetics[0] = false;

            //Glasses
            if (random <= 49 || Formal == "Bad Girl")
                cosmetics[1] = false;
            else
                cosmetics[1] = true;

            //Earrings
            if (random <= 74 && Formal == "Bad Girl")
                cosmetics[2] = true;
            else if (random <= 64 && Formal == "Innocent")
                cosmetics[2] = true;
            else if (random <= 79 && Formal == "Sofisticated")
                cosmetics[2] = true;
            else if (Formal == "Oblivious")
                cosmetics[2] = true;
            else
                cosmetics[2] = false;

            //Necklace
            if (random <= 59 && Formal == "Bad Girl")
                cosmetics[3] = true;
            else if (random <= 74 && Formal == "Innocent")
                cosmetics[3] = true;
            else if (random <= 79 && Formal == "Sofisticated")
                cosmetics[3] = true;
            else if (Formal == "Oblivious")
                cosmetics[3] = true;
            else
                cosmetics[3] = false;

            //Bracelet
            if (random <= 9 && Formal == "Stoner" || random <= 9 && Formal == "Innocent")
                cosmetics[4] = true;
            else if (random <= 49 && Formal == "Bad Girl")
                cosmetics[4] = true;
            else if (Formal == "Oblivious")
                cosmetics[4] = true;
            else
                cosmetics[4] = false;

            //Ring
            if (random <= 9 && Formal == "Stoner")
                cosmetics[5] = true;
            else if (random <= 32 && Formal == "Sofisticated")
                cosmetics[5] = true;
            else if (random <= 64 && Formal == "Innocent")
                cosmetics[5] = true;
            else if (random <= 89 && Formal == "Bad Girl")
                cosmetics[5] = true;
            else if (Formal == "Oblivious")
                cosmetics[5] = true;
            else
                cosmetics[5] = false;

            //Tattoo
            if (random <= 54 && Formal == "Stoner")
                cosmetics[6] = true;
            else if (random <= 79 && Formal == "Tomgirl")
                cosmetics[6] = true;
            else if (random <= 89 && Formal == "Bad Girl")
                cosmetics[6] = true;
            else if (Formal == "Oblivious")
                cosmetics[6] = true;
            else
                cosmetics[6] = false;

            //Piercing
            if (random <= 9 && Formal == "Tomgirl")
                cosmetics[7] = true;
            else if (random <= 34 && Formal == "Stoner")
                cosmetics[7] = true;
            else if (random <= 89 && Formal == "Bad girl")
                cosmetics[7] = true;
            else if (Formal == "Oblivious")
                cosmetics[7] = true;
            else
                cosmetics[7] = false;

            return cosmetics;
        }  //Cosmetics = Hat, Glasses, Earrings, Necklace, Bracelet, Ring, Tattoo, Piecring
        public void GetClothes()
        {
            string[] ShirtArr = { "T-Shirt", "Tank-Top", "Shirt" };
            string[] PantArr = { "Shorts", "Jeans", "Skirt" };
            string[] ShoeArr = { "Sandals", "Sneakers", "Boots", "High Heels" };

            Random rand = new Random();
            if (Formal != "Innocent" || Formal != "Sofisticated")
            {
                Shirt = ShirtArr[rand.Next(0, 2)];
                Pants = PantArr[rand.Next(0, 1)];
                Shoes = ShoeArr[rand.Next(0, 2)];
            }
            else if (Formal == "Innocent")
            {
                Shirt = ShirtArr[rand.Next(0, 2)];
                Pants = PantArr[rand.Next(0, 2)];
                Shoes = ShoeArr[rand.Next(0, 2)];
            }
            else if (Formal == "Sofisticated")
            {
                Shirt = "Suit";
                Pants = "Suit";
                Shoes = ShoeArr[rand.Next(1, 3)];
            }

        } //Shirt | Pants | Shoes
        private void GetNumeralInfo()
        {
            Random rand = new Random();
            Height = rand.Next(150, 180);
            Weight = rand.Next(40, 110);
            BMI = System.Convert.ToInt32(Weight / (Height * Height) * 10000);

            if (BMI <= 15)
            {
                Cup = 'A';
                BraHelper = 30;
                Thighs = "Small";
                ButtSize = "Small";
            }
            else if (BMI <= 20)
            {
                Cup = 'B';
                BraHelper = 32;
                Thighs = "Normal";
                ButtSize = "Normal";
            }
            else if (BMI <= 30)
            {
                Cup = 'C';
                BraHelper = 34;
                Thighs = "Big";
                ButtSize = "Big";
            }
            else //BMI 30+
            {
                Cup = 'D';
                BraHelper = 36;
                Thighs = "Thicc";
                ButtSize = "OWO";
            }

            HasNumber = false;

            Bra = BraHelper.ToString() + Cup;
        } //Height | Weight | Bra | Thighs | Butt || hasNumber
        #endregion

        #region Informational
        public string Presentation()
        {
            GetLooks();
            string presentation = "", sizeHeight = "", sizeBMI = "";
            int fineCosmetic = 10;

            if (Height <= 160)
                sizeHeight = "short";
            else if (Height <= 170)
                sizeHeight = "average";
            else if (Height <= 180)
                sizeHeight = "tall";

            if (BMI <= 20)
                sizeBMI = "tiny";
            else if (BMI <= 30)
                sizeBMI = "normal";
            else if (BMI <= 35)
                sizeBMI = "thicc";
            else
                sizeBMI = "chunky";

            string Size = sizeHeight + " " + sizeBMI;

            for (int x = 0; x <= 7; x++)
                if (Cosmetics[x] == true)
                    fineCosmetic = x;

            if (fineCosmetic != 10)
                presentation = Size + " girl, with " + EyeColor + " colored eyes, " + HairColor + " colored hair, and a fine " + CosmeticType[fineCosmetic].ToLower() + ", I'd say... She looks like she uses a " + Bra + " sized bra, with a complimentation of a " + ButtSize + " butt...";
            else
                presentation = Size + " girl, with " + EyeColor + " colored eyes, " + HairColor + " colored hair, with no cosmetic items... I'd say around " + Bra + " sized bra, with a " + ButtSize + " butt...";
            return presentation;
        }
        public void GetInfo()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Birthday: " + Birthday);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("Occupation: " + Occupation);
            Console.WriteLine("Hobby: " + Hobby);
            Console.WriteLine();
            Console.WriteLine("Hair color: " + HairColor);
            Console.WriteLine("Eye color: " + EyeColor);
            Console.WriteLine();
            for (int x = 0; x < 8; x++)
                Console.WriteLine(CosmeticType[x] + ": " + Cosmetics[x]);
            Console.WriteLine();
            Console.WriteLine("Final Brasize: " + Bra);
            Console.WriteLine("Bra Helper: " + BraHelper);
            Console.WriteLine("Cup: " + Cup);
            Console.WriteLine();
            Console.WriteLine("Shirt: " + Shirt);
            Console.WriteLine("Pant type: " + Pants);
            Console.WriteLine("Shoes: " + Shoes);
            Console.WriteLine();
            Console.WriteLine("Thighs: " + Thighs);
            Console.WriteLine("Butt: " + ButtSize);
            Console.WriteLine();
            Console.WriteLine("BMI: " + BMI);
            Console.WriteLine("Height: " + Height);
            Console.WriteLine("Weight: " + Weight);
            Console.WriteLine();
            Console.WriteLine("Likeness: " + LikenessMeter);
            Console.WriteLine("Formal stat: " + Formal);
        }
        public Kvinde Custom()
        {
            Kvinde kvinde = new Kvinde("null", "null", 0, "null", "null");
            string[] cosmeticType = new string[8] { "Hat", "Pair of Glasses", "Pair of Earrings", "Necklace", "Bracelent", "Ring", "Tattoo", "Piercing" };
            Console.Write("Name: ");
            kvinde.Name = Console.ReadLine();
            Console.Write("Birthday (xx-xx-xxxx): ");
            kvinde.Birthday = Console.ReadLine();
            kvinde.Age = 2019 - System.Convert.ToInt32(kvinde.Birthday.Substring(6, 4));
            bool Loop = false;
            do
            {
                try
                {
                    Console.WriteLine("Age: " + kvinde.Age);
                    Loop = false;
                }
                catch
                {
                    Console.WriteLine("Age wasn't a recognized number.");
                    Loop = true;
                }
            } while (Loop); //Age
            Console.Write("Occupation: ");
            kvinde.Occupation = Console.ReadLine();
            Console.Write("Hobby: ");
            kvinde.Hobby = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Hair color: ");
            kvinde.HairColor = Console.ReadLine();
            Console.Write("Eye color: ");
            kvinde.EyeColor = Console.ReadLine();
            Console.WriteLine();
            do
            {
                bool[] allCosmetics = new bool[8];
                for (int x = 0; x < 8; x++)
                {
                    try
                    {
                        Console.Write(cosmeticType[x] + ": ");
                        string choice = Console.ReadLine().ToLower();
                        if (choice == "true")
                            allCosmetics[x] = true;
                        else
                            allCosmetics[x] = false;
                    }
                    catch
                    {
                        for (int y = 0; x < 3; y++)
                            Console.WriteLine();
                        Console.WriteLine("Invalid answer - try again.");
                        Console.ReadLine();
                        x--;
                    }
                }
                try
                {
                    CosmeticType = cosmeticType;
                    Cosmetics = allCosmetics;
                    Loop = false;
                }
                catch
                {
                    Loop = true;
                }
            } while (Loop); //Cosmetics
            Console.WriteLine();
            Console.Write("Bra cup: ");
            kvinde.Cup = System.Convert.ToChar(Console.ReadLine().Substring(0, 1));
            Console.WriteLine();
            Console.Write("Bra helper: ");
            kvinde.BraHelper = int.Parse(Console.ReadLine());
            kvinde.Bra = kvinde.BraHelper.ToString() + kvinde.Cup.ToString().ToUpper();
            Console.WriteLine("Bra: " + kvinde.Bra);
            Console.WriteLine();
            Console.Write("Shirt: ");
            kvinde.Shirt = Console.ReadLine();
            Console.Write("Pants type: ");
            kvinde.Pants = Console.ReadLine();
            Console.Write("Shoe type: ");
            kvinde.Shoes = Console.ReadLine();
            Console.WriteLine();
            do
            {
                try
                {
                    Console.Write("Height: ");
                    kvinde.Height = System.Convert.ToDouble(Console.ReadLine());
                    Console.Write("Weight: ");
                    kvinde.Weight = System.Convert.ToInt32(Console.ReadLine());
                    kvinde.BMI = System.Convert.ToInt32(kvinde.Weight / (kvinde.Height * kvinde.Height) * 10000);
                    Console.WriteLine("BMI: " + kvinde.BMI);
                    Loop = false;
                }
                catch
                {
                    Console.WriteLine("Numbers not recognized. Try again.");
                    Loop = true;
                }
            } while (Loop); //BMI
            Console.WriteLine();
            do
            {
                Console.Write("Formal: ");
                kvinde.Formal = Console.ReadLine();
                string[] FormalStat = { "Stoner", "Bad Girl", "Tomgirl", "Innocent", "Oblivious", "Sofisticated" };
                Loop = true;
                for (int x = 0; x < 6; x++)
                {
                    if (kvinde.Formal == FormalStat[x])
                    {
                        x = 6;
                        Loop = false;
                    }
                    else
                    {
                        Console.WriteLine("Formal stat not recognized - try again.");
                        Loop = true;
                    }
                }
            } while (Loop); //Formal 
            Console.Clear();
            kvinde.GetInfo();
            return kvinde;
        }
        #endregion
    }
}