using System;

namespace RandomSWCharacter
{
    class Robot
    {
        public Robot()
        {
            FindDroidType();
            ID = RandomizeID();
        }

        private string ClassType { get; set; }
        private int TypeNumber, DroidClass;
        public static string ID { get; set; }
        public static string DroidType { get; private set; }
        public string[] Items = { ID, DroidType };

        private void FindDroidType()
        {
            Random rand = new Random();
            DroidType = $"Class {TypeNumber = rand.Next(1, 5)}, ";
            switch (TypeNumber)
            {
                case 1:
                    DroidClass = rand.Next(3);
                    ClassType = (DroidClass == 0) ? "Medical" : (DroidClass == 1) ? "Biological Science" : (DroidClass == 2) ? "Physical Science" : "Mathematics";
                    break;
                case 2:
                    DroidClass = rand.Next(4);
                    ClassType = (DroidClass == 0) ? "Astromech" : (DroidClass == 1) ? "Exploration" : (DroidClass == 2) ? "Enviormental" : (DroidClass == 3) ? "Engineering" : "Maintenance";
                    break;
                case 3:
                    DroidClass = rand.Next(3);
                    ClassType = (DroidClass == 0) ? "Protocol" : (DroidClass == 1) ? "Tutor" : (DroidClass == 2) ? "Child Care" : "Servant";
                    break;
                case 4:
                    DroidClass = rand.Next(3);
                    ClassType = (DroidClass == 0) ? "Security" : (DroidClass == 1) ? "Gladiator" : (DroidClass == 2) ? "Battle" : "Assassin";
                    break;
                case 5:
                    DroidClass = rand.Next(2);
                    ClassType = (DroidClass == 0) ? "General Labor" : (DroidClass == 1) ? "Labor-specialist" : "Hazardous-service";
                    break;
                default:
                    ClassType = $"UNKNOWN {TypeNumber}";
                    break;
            }
            DroidType += ClassType + " Droid";
        }
        private string RandomizeID()
        {
            Random rand = new Random();
            string Letters = ClassType.ToCharArray()[0] + ClassType.ToCharArray()[ClassType.Length - 1].ToString().ToUpper();
            return $"{Letters.ToCharArray()[0]}{TypeNumber}-{Letters.ToCharArray()[1]}{DroidClass + rand.Next(10)}";
        }
    }
}