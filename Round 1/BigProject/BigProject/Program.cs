using System;
using System.Security;
using System.Text;

namespace BigProject
{
    class Program
    {
        #region Login
        public static bool LoginPage(out string Username)
        {
            while (true)
            {
                Title("Welcome to The Big Project!");
                for (int x = 0; x < 3; x++)
                    Console.WriteLine();
                Console.WriteLine("[1]: Login");
                Console.WriteLine("[2]: Create Account");

                Choice = Console.ReadLine().ToLower();
                Username = "Invalid User";

                if (Choice == "1" || Choice == "login")
                    return Login(out Username);
                else if (Choice == "2" || Choice == "create" || Choice == "create account")
                    return createAccount(out Username);
                else
                    Error();
            }
        }
        public static bool Login(out string Username)
        {
            Console.Clear();
            Username = "Invalid User";

            Title("Login");

            Console.Write("Username: ");
            string loginUser = Console.ReadLine();
            Console.Write("Password: ");
            string loginPass = Console.ReadLine();

            Login login = new Login();
            UserData newUser = new UserData();

           for(int x = 0; x < newUser.nextAccountID(); x++)
            {
                if (loginUser == login.username && loginPass == login.password)
                {
                    Username = login.username;
                    Console.Clear();
                    return true;
                }
            }
            Console.WriteLine("Password was incorrect");
            Console.ReadKey();
            Console.Clear();
            return false;
        }
        private static SecureString maskInputString()
        {
            SecureString pass = new SecureString();
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                if (!char.IsControl(keyInfo.KeyChar))
                {
                    pass.AppendChar(keyInfo.KeyChar);
                    Console.Write("*");
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    pass.RemoveAt(pass.Length - 1);
                    Console.Write("\b \b");
                }
            } while (keyInfo.Key != ConsoleKey.Enter);
            return pass;
        }
        #endregion

        #region Create Account
        public static bool createAccount(out string Username)
        {
            do
            {
                //Basic Log-In details
                Console.Clear();
                Title("Create Account");
                Console.Write("New Username: ");
                Username = Console.ReadLine();
                Console.WriteLine();
                Console.Write("New Password: ");
                //maskInputString().ToString();
                string Password = Console.ReadLine();

                //Hero definition
                Console.Clear();
                string userClass = "Invalid Class";
                while (userClass == "Invalid Class")
                {
                    Title("Create Account");
                    Console.WriteLine("Choose a class:");
                    for (int x = 0; x < 3; x++)
                        Console.WriteLine();
                    Console.WriteLine("[1]: Warrior");
                    Console.WriteLine("[2]: Soldier");
                    Console.WriteLine("[3]: Mage");
                    Console.WriteLine("[4]: Engineer");
                    for (int x = 0; x < 3; x++)
                        Console.WriteLine();
                    Choice = Console.ReadLine().ToLower();

                    if (Choice == "1" || Choice == "warrior")
                        userClass = "Warrior";
                    else if (Choice == "2" || Choice == "soldier")
                        userClass = "Soldier";
                    else if (Choice == "3" || Choice == "mage")
                        userClass = "Mage";
                    else if (Choice == "4" || Choice == "engineer")
                        userClass = "Engineer";
                    else
                        Error();
                }

                Console.Clear();

                Title("Create Account - Confirmation");
                Console.WriteLine("Username: " + Username);
                Console.WriteLine("Password: " + Password);
                Console.WriteLine("Class: " + userClass);
                for (int x = 0; x < 3; x++)
                    Console.WriteLine();
                Console.WriteLine("Is this information correct?");
                Console.WriteLine();
                Choice = Console.ReadLine().ToLower();

                if (Choice == "yes")
                {
                    DateTime startDate = System.DateTime.Now;
                    UserData newPlayer = new UserData();
                    newPlayer.Login = createNewPlayer(newPlayer, Username, Password, startDate, userClass);
                    for (int x = 0; x < 3; x++)
                        Console.WriteLine();
                    Console.WriteLine("Have a terrific adventure, " + Username + "!");
                    Console.ReadKey();
                    newPlayer.Save();
                    Console.Clear();
                    return true;
                }
            } while (true);
        }
        public static Login createNewPlayer(UserData newUser, string user, string pass, DateTime start, string choiceOfClass)
        {
            Login newLogin = new Login();
            newLogin.username = user;
            newLogin.password = pass;
            newLogin.AccountID = newUser.nextAccountID();
            newLogin.startDate = start.ToString().Substring(0, 10);

            Player newPlayer = new Player();
            newPlayer = statSelecter(newPlayer, choiceOfClass);
            newLogin.Player = newPlayer;

            return newLogin;
        }

        #region Stat Selectors
        public static Player statSelecter(Player newPlayer,string choiceOfClass)
        {
            Rank newRank = new Rank();

            //Class Differenial Stats
            if (choiceOfClass == "Warrior")
            {
                newPlayer = playerStatSelector(newPlayer, 8, 3, 3, 4);
                newRank.Equipped = choiceOfClass;
                Warrior newWarrior = new Warrior();
                newWarrior.rank = 1;
                newWarrior.Range = rangeSelector(6, 3, 1);
                newWarrior.Equipment = equipmentSelector(Choice, "Basic Sword", 45, 100, false, 1, 1, "Tomahawk", 15, 100, true, 5, 1, "Bow", 40, 100, true, 25, 1, 5, 25, 2, 10);
                newPlayer.Armor = armorSelector(3, 6, 5, 4, 4, 0);

                newRank.Warrior = newWarrior;
            }
            else if (choiceOfClass == "Soldier")
            {
                newPlayer = playerStatSelector(newPlayer, 6, 4, 4, 5);
                newRank.Equipped = choiceOfClass;
                Soldier newSoldier = new Soldier();
                newSoldier.rank = 1;
                newSoldier.Range = rangeSelector(1, 6, 3);
                newSoldier.Equipment = equipmentSelector(choiceOfClass, "Knife", 10, 100, false, 1, 1, "Machine Gun", 50, 100, true, 120, 30, null, 0, 0, false, 0, 0, 5, 25, 2, 10);
                newPlayer.Armor = armorSelector(2, 7, 5, 5, 2, 0);

                newRank.Soldier = newSoldier;
            }
            else if (choiceOfClass == "Mage")
            {
                newPlayer = playerStatSelector(newPlayer, 3, 6, 8, 7);
                newRank.Equipped = choiceOfClass;
                Mage newMage = new Mage();
                newMage.rank = 1;
                newMage.Range = rangeSelector(1, 4, 7);
                Equipment newEquipment = new Equipment();
                Medium newMedium = new Medium();
                newEquipment = equipmentSelector(choiceOfClass, "Magic Wand", 1.5, 100, false, 1, 1, "Spell Book", 50, 100, false, 1, 1, null, 0, 0, false, 0, 0, 5, 25, 2, 10);
                newEquipment.Medium.weapon = newEquipment.Melee.weapon;
                newEquipment.Medium.dmgboost = newEquipment.Melee.dmgboost;
                newEquipment.Medium.durability = newEquipment.Melee.durability;
                newEquipment.Medium.needsAmmo = newEquipment.Melee.needsAmmo;
                newEquipment.Medium.ammoAmount = newEquipment.Melee.ammoAmount;
                newEquipment.Melee.ammoPerReload = newEquipment.Melee.ammoPerReload;
                newPlayer.Armor = armorSelector(1, 4, 3, 2, 1, 3);

                newMage.Equipment = newEquipment;
                newRank.Mage = newMage;
            }
            else
            {
                newPlayer = playerStatSelector(newPlayer, 5, 7, 5, 3);
                newRank.Equipped = choiceOfClass;
                Engineer newEngineer = new Engineer();
                newEngineer.rank = 1;
                newEngineer.Range = rangeSelector(3, 7, 5);
                newEngineer.Equipment = equipmentSelector(choiceOfClass, "Hammer", 5, 100, false, 1, 1, "Revolver", 33, 100, true, 6, 60, "Drone", 10, 100, true, 20, 5, 5, 25, 2, 10);
                newPlayer.Armor = armorSelector(3, 4, 4, 3, 1, 0);

                newRank.Engineer = newEngineer;
            }

            newPlayer.Rank = newRank;
            return newPlayer;
        }
        public static Player playerStatSelector(Player newPlayer, int strength, int smarts, int movespe, int execspe)
        {
            newPlayer.level = 1;
            newPlayer.strength = strength;
            newPlayer.smarts = smarts;
            newPlayer.moveSpeed = movespe;
            newPlayer.execSpeed = execspe;

            return newPlayer;
        }
        public static Range rangeSelector(int rshort, int rmid, int rlong)
        {
            Range newPlayerRange = new Range();
            newPlayerRange = new Range();
            newPlayerRange.Short = rshort;
            newPlayerRange.Medium = rmid;
            newPlayerRange.Long = rlong;

            return newPlayerRange;
        }
        public static Equipment equipmentSelector(string choiceOfClass, string closeWeapon, double closeDamageBoost, int closeDurability, bool closeNeedsAmmo, int closeAmmoAmount, int closeAmmoPerReload, string mediumWeapon, double mediumDamageBoost, int mediumDurability, bool mediumNeedsAmmo, int mediumAmmoAmount, int mediumAmmoPerReload, string longWeapon, double longDamageBoost, int longDurability, bool longNeedsAmmo, int longAmmoAmount, int longAmmoPerReload, int potionHealthAmount, int potionHealthDone, int potionShieldAmount, int potionShieldExternal)
        {
            //New classes
            Equipment newEquipment = new Equipment();
            Melee newMelee = new Melee();
            Medium newMedium = new Medium();
            Long newLong = new Long();

            //Weapon Definitins
            newMelee.weapon = closeWeapon;
            newMedium.weapon = mediumWeapon;
            newLong.weapon = longWeapon;
            newMelee.dmgboost = closeDamageBoost;
            newMedium.dmgboost = mediumDamageBoost;
            newLong.dmgboost = longDamageBoost;
            newMelee.durability = closeDurability;
            newMedium.durability = mediumDurability;
            newLong.durability = longDurability;
            newMelee.needsAmmo = closeNeedsAmmo;
            newMedium.needsAmmo = mediumNeedsAmmo;
            newLong.needsAmmo = longNeedsAmmo;
            newMelee.ammoAmount = closeAmmoAmount;
            newMedium.ammoAmount = mediumAmmoAmount;
            newLong.ammoAmount = longAmmoAmount;
            newMelee.ammoPerReload = closeAmmoPerReload;
            newMedium.ammoPerReload = mediumAmmoPerReload;
            newLong.ammoPerReload = longAmmoPerReload;

            //Weapons into Equipment
            newEquipment.Melee = newMelee;
            newEquipment.Medium = newMedium;
            newEquipment.Long = newLong;

            //Potions
            Potion Potion = new Potion();
            HealthPotion newHealth= new HealthPotion();
            ShieldPotion newShield = new ShieldPotion();
            newHealth.amount = potionHealthAmount;
            newHealth.healingdone = potionHealthDone;
            newShield.amount = potionShieldAmount;
            newShield.externalShield = potionShieldExternal;

            //Potions into Equipment
            Potion.Health = newHealth;
            Potion.ShieldPotion = newShield;
            newEquipment.Potion = Potion;

            return newEquipment;
        }
        public static Armor armorSelector(int ahelmet, int achestplate, int aleggings, int aboots, int ashield, int abarrier)
        {
            //New armor
            Armor newArmor = new Armor();
            Helmet newHelmet = new Helmet();
            Chestplate newChestplate = new Chestplate();
            Leggings newLeggings = new Leggings();
            Boots newBoots = new Boots();
            Shield newShield = new Shield();
            Barrier newBarrier = new Barrier();

            //Armor definition
            newHelmet.Protection = ahelmet;
            newHelmet.Durablity = 100;
            newChestplate.Protection = achestplate;
            newChestplate.Durablity = 100;
            newLeggings.Protection = aleggings;
            newLeggings.Durablity = 100;
            newBoots.Protection = aboots;
            newBoots.Durablity = 100;
            newShield.Protection = ashield;
            newShield.Durablity = 100;
            newBarrier.Protection = abarrier;
            newBarrier.Durablity = 100;

            //Armor pieces on armor
            newArmor.Helmet = newHelmet;
            newArmor.Chestplate = newChestplate;
            newArmor.Leggings = newLeggings;
            newArmor.Boots = newBoots;
            newArmor.Shield = newShield;
            newArmor.Barrier = newBarrier;

            return newArmor;
        }
        #endregion

        #endregion

        public static void MainMenu(string PN)
        {
            Console.WriteLine("Hello, " + PN);
            Console.ReadKey();
        }

        #region Global Variables
        public static bool Loop = true;
        public static string Choice = "";
        public static UserData Player = UserData.UserDataFromXML("..\\..\\UserData.xml");
        public static void Error()
        {
            Console.Clear();
            Console.WriteLine("Your choice failed to be read.");
            for(int x = 0; x < 5; x++)
                Console.WriteLine();
            Console.WriteLine("Please try again");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Title(string title)
        {
            int space = (121 - title.Length) / 2 - 1;
            StringBuilder dash = new StringBuilder();
            for (int x = 0; x < space; x++)
                dash.Append("-");
            Console.Write(dash);
            Console.Write(title.PadLeft(0));
            Console.WriteLine(dash);

            for (int x = 0; x < 4; x++)
                Console.WriteLine();
        }
        #endregion

        static void Main(string[] args)
        {
            if(LoginPage(out string Username))
                MainMenu(Username);
        }
    }
}
