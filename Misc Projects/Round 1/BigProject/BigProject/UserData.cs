using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;

namespace BigProject
{
    #region Potion
    [XmlRoot(ElementName = "Health")]
    public class HealthPotion
    {
        [XmlAttribute(AttributeName = "Amount")]
        public int amount { get; set; }
        [XmlAttribute(AttributeName = "healingDone")]
        public int healingdone { get; set; }

        private HealthPotion Child;
        public void setChild(Potion Parent)
        {
            Child = Parent.Health;
        }
    }
    [XmlRoot(ElementName = "Shield")]
    public class ShieldPotion
    {
        [XmlAttribute(AttributeName = "Amount")]
        public int amount { get; set; }
        [XmlAttribute(AttributeName = "externalShield")]
        public int externalShield { get; set; }

        private ShieldPotion Child;
        public void setChild(Potion Parent)
        {
            Child = Parent.ShieldPotion;
        }
    }
    [XmlRoot(ElementName = "Potion")]
    public class Potion
    {
        [XmlElement(ElementName = "Health")]
        public HealthPotion Health { get; set; }
        public List<HealthPotion> HealthPotionList { get; set; }
        [XmlElement(ElementName = "Shield")]
        public ShieldPotion ShieldPotion { get; set; }
        public List<ShieldPotion> ShieldPotionList { get; set; }

        private Potion Child;
        public void setParent(Equipment Parent)
        {
            Child = Parent.Potion;
            if (Health != null)
                Health.setChild(Child);
            if (ShieldPotion != null)
                ShieldPotion.setChild(Child);
        }
    }
    #endregion

    #region Equipment
    [XmlRoot(ElementName = "Melee")]
    public class Melee
    {
        [XmlAttribute(AttributeName = "Weapon")]
        public string weapon { get; set; }
        [XmlAttribute(AttributeName = "dmgBoost")]
        public double dmgboost { get; set; }
        [XmlAttribute(AttributeName = "Durability")]
        public double durability { get; set; }
        [XmlAttribute(AttributeName = "needsAmmo")]
        public bool needsAmmo { get; set; }
        [XmlAttribute(AttributeName = "ammoAmount")]
        public int ammoAmount { get; set; }
        [XmlAttribute(AttributeName = "ammoPerReload")]
        public int ammoPerReload { get; set; }

        private Melee Child;
        public void setChild(Equipment Parent)
        {
            Child = Parent.Melee;
        }
    }
    [XmlRoot(ElementName = "Medium")]
    public class Medium
    {
        [XmlAttribute(AttributeName = "Weapon")]
        public string weapon { get; set; }
        [XmlAttribute(AttributeName = "dmgBoost")]
        public double dmgboost { get; set; }
        [XmlAttribute(AttributeName = "Durability")]
        public double durability { get; set; }
        [XmlAttribute(AttributeName = "needsAmmo")]
        public bool needsAmmo { get; set; }
        [XmlAttribute(AttributeName = "ammoAmount")]
        public int ammoAmount { get; set; }
        [XmlAttribute(AttributeName = "ammoPerReload")]
        public int ammoPerReload { get; set; }

        private Medium Child;
        public void setChild(Equipment Parent)
        {
            Child = Parent.Medium;
        }
    }
    [XmlRoot(ElementName = "Long")]
    public class Long
    {
        [XmlAttribute(AttributeName = "Weapon")]
        public string weapon { get; set; }
        [XmlAttribute(AttributeName = "dmgBoost")]
        public double dmgboost { get; set; }
        [XmlAttribute(AttributeName = "Durability")]
        public double durability { get; set; }
        [XmlAttribute(AttributeName = "needsAmmo")]
        public bool needsAmmo { get; set; }
        [XmlAttribute(AttributeName = "ammoAmount")]
        public int ammoAmount { get; set; }
        [XmlAttribute(AttributeName = "ammoPerReload")]
        public int ammoPerReload { get; set; }

        private Long Child;
        public void setChild(Equipment Parent)
        {
            Child = Parent.Long;
        }
    }
    [XmlRoot(ElementName = "Equipment")]
    public class Equipment
    {
        [XmlElement(ElementName = "Melee")]
        public Melee Melee { get; set; }
        public List<Melee> MeleeList { get; set; }
        [XmlElement(ElementName = "Medium")]
        public Medium Medium { get; set; }
        public List<Medium> MediumList { get; set; }
        [XmlElement(ElementName = "Long")]
        public Long Long { get; set; }
        public List<Long> LongList { get; set; }
        [XmlElement(ElementName = "Potion")]
        public Potion Potion { get; set; }
        public List<Potion> PotionList { get; set; }

        private Equipment Child;
        public void setWarrior(Warrior Parent)
        {
            Child = Parent.Equipment;
            if (Melee != null)
                Melee.setChild(Child);
            if (Medium != null)
                Medium.setChild(Child);
            if (Long != null)
                Long.setChild(Child);
            if (Potion != null)
            {
                foreach (HealthPotion health in Potion.HealthPotionList)
                    health.setChild(Child.Potion);
                foreach (ShieldPotion shieldpotion in Potion.ShieldPotionList)
                    shieldpotion.setChild(Child.Potion);
            }
        }
        public void setSoldier(Soldier Parent)
        {
            Child = Parent.Equipment;
            if (Melee != null)
                Melee.setChild(Child);
            if (Medium != null)
                Medium.setChild(Child);
            if (Long != null)
                Long.setChild(Child);
            if (Potion != null)
            {
                foreach (HealthPotion health in Potion.HealthPotionList)
                    health.setChild(Child.Potion);
                foreach (ShieldPotion shieldpotion in Potion.ShieldPotionList)
                    shieldpotion.setChild(Child.Potion);
            }
        }
        public void setMage(Mage Parent)
        {
            Child = Parent.Equipment;
            if (Melee != null)
                Melee.setChild(Child);
            if (Medium != null)
                Medium.setChild(Child);
            if (Long != null)
                Long.setChild(Child);
            if (Potion != null)
            {
                foreach (HealthPotion health in Potion.HealthPotionList)
                    health.setChild(Child.Potion);
                foreach (ShieldPotion shieldpotion in Potion.ShieldPotionList)
                    shieldpotion.setChild(Child.Potion);
            }
        }
        public void setEngineer(Engineer Parent)
        {
            Child = Parent.Equipment;
            if (Melee != null)
                Melee.setChild(Child);
            if (Medium != null)
                Medium.setChild(Child);
            if (Long != null)
                Long.setChild(Child);
            if (Potion != null)
            {
                foreach (HealthPotion health in Potion.HealthPotionList)
                    health.setChild(Child.Potion);
                foreach (ShieldPotion shieldpotion in Potion.ShieldPotionList)
                    shieldpotion.setChild(Child.Potion);
            }
        }
    }
    #endregion

    #region Rank
    [XmlRoot(ElementName = "Range")]
    public class Range
    {
        [XmlAttribute(AttributeName = "Short")]
        public int Short { get; set; }
        [XmlAttribute(AttributeName = "Medium")]
        public int Medium { get; set; }
        [XmlAttribute(AttributeName = "Long")]
        public int Long { get; set; }

        private Range Child;
        public void setChild(Range Parent)
        {
            Child = Parent;
        }
    }
    [XmlRoot(ElementName = "Warrior")]
    public class Warrior
    {
        [XmlElement(ElementName = "Range")]
        public Range Range { get; set; }
        public List<Range> RangeList { get; set; }
        [XmlElement(ElementName = "Equipment")]
        public Equipment Equipment { get; set; }
        public List<Equipment> EquipmentList { get; set; }
        [XmlAttribute(AttributeName = "Rank")]
        public int rank { get; set; }


        private Warrior Child;
        public void setParent(Rank Parent)
        {
            Child = Parent.Warrior;
            if (Equipment != null)
            {
                foreach (Melee closeRange in Equipment.MeleeList)
                    closeRange.setChild(Child.Equipment);
                foreach (Medium mediumRange in Equipment.MediumList)
                    mediumRange.setChild(Child.Equipment);
                foreach (Long longRange in Equipment.LongList)
                    longRange.setChild(Child.Equipment);
                foreach (Potion potions in Equipment.PotionList)
                    potions.setParent(Child.Equipment);
            }
        }
    }
    [XmlRoot(ElementName = "Soldier")]
    public class Soldier
    {
        [XmlElement(ElementName = "Range")]
        public Range Range { get; set; }
        public List<Range> RangeList { get; set; }
        [XmlElement(ElementName = "Equipment")]
        public Equipment Equipment { get; set; }
        public List<Equipment> EquipmentList { get; set; }
        [XmlAttribute(AttributeName = "Rank")]
        public int rank { get; set; }

        private Soldier Child;
        public void setParent(Rank Parent)
        {
            Child = Parent.Soldier;
            if (Equipment != null)
            {
                foreach (Melee closeRange in Equipment.MeleeList)
                    closeRange.setChild(Child.Equipment);
                foreach (Medium mediumRange in Equipment.MediumList)
                    mediumRange.setChild(Child.Equipment);
                foreach (Long longRange in Equipment.LongList)
                    longRange.setChild(Child.Equipment);
                foreach (Potion potions in Equipment.PotionList)
                    potions.setParent(Child.Equipment);
            }
        }
    }
    [XmlRoot(ElementName = "Mage")]
    public class Mage
    {
        [XmlElement(ElementName = "Range")]
        public Range Range { get; set; }
        public List<Range> RangeList { get; set; }
        [XmlElement(ElementName = "Equipment")]
        public Equipment Equipment { get; set; }
        public List<Equipment> EquipmentList { get; set; }
        [XmlAttribute(AttributeName = "Rank")]
        public int rank { get; set; }

        private Mage Child;
        public void setParent(Rank Parent)
        {
            Child = Parent.Mage;
            if (Equipment != null)
            {
                foreach (Melee closeRange in Equipment.MeleeList)
                    closeRange.setChild(Child.Equipment);
                foreach (Medium mediumRange in Equipment.MediumList)
                    mediumRange.setChild(Child.Equipment);
                foreach (Long longRange in Equipment.LongList)
                    longRange.setChild(Child.Equipment);
                foreach (Potion potions in Equipment.PotionList)
                    potions.setParent(Child.Equipment);
            }
        }
    }
    [XmlRoot(ElementName = "Engineer")]
    public class Engineer
    {
        [XmlElement(ElementName = "Range")]
        public Range Range { get; set; }
        public List<Range> RangeList { get; set; }
        [XmlElement(ElementName = "Equipment")]
        public Equipment Equipment { get; set; }
        public List<Equipment> EquipmentList { get; set; }
        [XmlAttribute(AttributeName = "Rank")]
        public int rank { get; set; }

        private Engineer Child;
        public void setParent(Rank Parent)
        {
            Child = Parent.Engineer;
            if (Equipment != null)
            {
                foreach (Melee closeRange in Equipment.MeleeList)
                    closeRange.setChild(Child.Equipment);
                foreach (Medium mediumRange in Equipment.MediumList)
                    mediumRange.setChild(Child.Equipment);
                foreach (Long longRange in Equipment.LongList)
                    longRange.setChild(Child.Equipment);
                foreach (Potion potions in Equipment.PotionList)
                    potions.setParent(Child.Equipment);
            }
        }
    }
    [XmlRoot(ElementName = "Rank")]
    public class Rank
    {
        [XmlElement(ElementName = "Warrior")]
        public Warrior Warrior { get; set; }
        public List<Warrior> WarriorList { get; set; }
        [XmlElement(ElementName = "Soldier")]
        public Soldier Soldier { get; set; }
        public List<Soldier> SoldierList { get; set; }
        [XmlElement(ElementName = "Mage")]
        public Mage Mage { get; set; }
        public List<Mage> MageList { get; set; }
        [XmlElement(ElementName = "Engineer")]
        public Engineer Engineer { get; set; }
        public List<Engineer> EngineerList { get; set; }
        [XmlAttribute(AttributeName = "Equipped")]
        public string Equipped { get; set; }

        private Rank Child;
        public void setParent(Player Parent)
        {
            Child = Parent.Rank;
            
            if (Warrior != null)
            {
                foreach (Range range in Warrior.RangeList)
                    range.setChild(Child.Warrior.Range);
                foreach (Equipment inventory in Warrior.EquipmentList)
                    inventory.setWarrior(Child.Warrior);
            }
            if (Soldier != null)
            { 
                foreach (Range range in Soldier.RangeList)
                    range.setChild(Child.Warrior.Range);
                foreach (Equipment inventory in Soldier.EquipmentList)
                    inventory.setSoldier(Child.Soldier);
            }
            if (Mage != null)
            {
                foreach (Range range in Mage.RangeList)
                    range.setChild(Child.Mage.Range);
                foreach (Equipment inventory in Mage.EquipmentList)
                    inventory.setMage(Child.Mage);
            }
            if (Engineer != null)
            {
                foreach (Range range in Engineer.RangeList)
                    range.setChild(Child.Engineer.Range);
                foreach (Equipment inventory in Engineer.EquipmentList)
                    inventory.setEngineer(Child.Engineer);
            }
        }
    }
    #endregion

    #region Armor
    [XmlRoot(ElementName = "Helmet")]
    public class Helmet
    {
        [XmlAttribute(AttributeName = "Protection")]
        public double Protection { get; set; }
        [XmlAttribute(AttributeName = "Durability")]
        public double Durablity { get; set; }

        private Helmet Child;
        public void setChild(Armor Parent)
        {
            Child = Parent.Helmet;
        }
    }
    [XmlRoot(ElementName = "Chestplate")]
    public class Chestplate
    {
        [XmlAttribute(AttributeName = "Protection")]
        public double Protection { get; set; }
        [XmlAttribute(AttributeName = "Durability")]
        public double Durablity { get; set; }

        private Chestplate Child;
        public void setChild(Armor Parent)
        {
            Child = Parent.Chestplate;
        }
    }
    [XmlRoot(ElementName = "Leggings")]
    public class Leggings
    {
        [XmlAttribute(AttributeName = "Protection")]
        public double Protection { get; set; }
        [XmlAttribute(AttributeName = "Durability")]
        public double Durablity { get; set; }

        private Leggings Child;
        public void setChild(Armor Parent)
        {
            Child = Parent.Leggings;
        }
    }
    [XmlRoot(ElementName = "Boots")]
    public class Boots
    {
        [XmlAttribute(AttributeName = "Protection")]
        public double Protection { get; set; }
        [XmlAttribute(AttributeName = "Durability")]
        public double Durablity { get; set; }

        private Boots Child;
        public void setChild(Armor Parent)
        {
            Child = Parent.Boots;
        }
    }
    [XmlRoot(ElementName = "Shield")]
    public class Shield
    {
        [XmlAttribute(AttributeName = "Protection")]
        public double Protection { get; set; }
        [XmlAttribute(AttributeName = "Durability")]
        public double Durablity { get; set; }

        private Shield Child;
        public void setChild(Armor Parent)
        {
            Child = Parent.Shield;
        }
    }
    [XmlRoot(ElementName = "Barrier")]
    public class Barrier
    {
        [XmlAttribute(AttributeName = "Protection")]
        public double Protection { get; set; }
        [XmlAttribute(AttributeName = "Durability")]
        public double Durablity { get; set; }

        private Barrier Child;
        public void setChild(Armor Parent)
        {
            Child = Parent.Barrier;
        }
    }
    [XmlRoot(ElementName = "Armor")]
    public class Armor
    {
        [XmlElement(ElementName = "Helmet")]
        public Helmet Helmet { get; set; }
        public List<Helmet> HelmetList { get; set; }
        [XmlElement(ElementName = "Chestplate")]
        public Chestplate Chestplate { get; set; }
        public List<Chestplate> ChestplateList { get; set; }
        [XmlElement(ElementName = "Leggings")]
        public Leggings Leggings { get; set; }
        public List<Leggings> LeggingsList { get; set; }
        [XmlElement(ElementName = "Boots")]
        public Boots Boots { get; set; }
        public List<Boots> BootsList { get; set; }
        [XmlElement(ElementName = "Shield")]
        public Shield Shield { get; set; }
        public List<Shield> ShieldList { get; set; }
        [XmlElement(ElementName = "Barrier")]
        public Barrier Barrier { get; set; }
        public List<Barrier> BarrierList { get; set; }

        private Armor Child;
        public void setChild(Player Parent)
        {
            Child = Parent.Armor;
        }
    }
    #endregion

    //Player information
    [XmlRoot(ElementName = "Player")]
    public class Player
    {
        [XmlElement(ElementName = "Rank")]
        public Rank Rank { get; set; }
        public List<Rank> RankList { get; set; }
        [XmlElement(ElementName = "Armor")]
        public Armor Armor { get; set; }
        public List<Armor> ArmorList { get; set; }
        [XmlAttribute(AttributeName = "Level")]
        public int level { get; set; }
        [XmlAttribute(AttributeName = "Strength")]
        public int strength { get; set; }
        [XmlAttribute(AttributeName = "Smarts")]
        public int smarts { get; set; }
        [XmlAttribute(AttributeName = "execSpeed")]
        public int execSpeed { get; set; }
        [XmlAttribute(AttributeName = "moveSpeed")]
        public int moveSpeed { get; set; }

        private Player Child;
        public void setParent(Login Parent)
        {
            Child = Parent.Player;
            if (Armor != null)
            {
                foreach (Helmet Helmet in Armor.HelmetList)
                    Helmet.setChild(Child.Armor);
                foreach (Chestplate chestplate in Armor.ChestplateList)
                    chestplate.setChild(Child.Armor);
                foreach (Leggings leggings in Armor.LeggingsList)
                    leggings.setChild(Child.Armor);
                foreach (Boots boots in Armor.BootsList)
                    boots.setChild(Child.Armor);
                foreach (Shield shield in Armor.ShieldList)
                    shield.setChild(Child.Armor);
                foreach (Barrier barrier in Armor.BarrierList)
                    barrier.setChild(Child.Armor);
            }

            if (Rank != null)
            {
                foreach (Warrior warrior in Rank.WarriorList)
                    warrior.setParent(Child.Rank);
                foreach (Soldier soldier in Rank.SoldierList)
                    soldier.setParent(Child.Rank);
                foreach (Mage mage in Rank.MageList)
                    mage.setParent(Child.Rank);
                foreach (Engineer engineer in Rank.EngineerList)
                    engineer.setParent(Child.Rank);
            }
        }
    }

    //Login information
    [XmlRoot(ElementName = "Login")]
    public class Login
    {
        [XmlElement(ElementName = "Player")]
        public Player Player { get; set; }
        public List<Player> PlayerList { get; set; }
        [XmlAttribute(AttributeName = "AccountID")]
        public int AccountID { get; set; }
        [XmlAttribute(AttributeName = "Username")]
        public string username { get; set; }
        [XmlAttribute(AttributeName = "Password")]
        public string password { get; set; }
        [XmlAttribute(AttributeName = "StartDate")]
        public string startDate { get; set; }

        private Login Child;
        public void setParent(UserData Parent)
        {
            Child = Parent.Login;
            foreach (Armor Armor in Player.ArmorList)
                Armor.setChild(Child.Player);
            foreach (Rank rank in Player.RankList)
                rank.setParent(Child.Player);
        }
    }

    //XML Set-Up
    [XmlRoot(ElementName = "UserData")]
    public class UserData
    {
        [XmlElement(ElementName = "Login")]
        public Login Login { get; set; }
        public static List<Login> LoginList { get; set; }

        private static string myPath = "";

        public static UserData UserDataFromXML(String path)
        {
            UserData newPlayer = null;
            try
            {
                myPath = path;
                XmlSerializer serializer = new XmlSerializer(typeof(UserData));
                StreamReader reader = new StreamReader(path);
                newPlayer = (UserData)serializer.Deserialize(reader);
                reader.Close();
                //newPlayer.setParents();
            }
            catch (FileNotFoundException)
            {
                newPlayer = new UserData();
                newPlayer.Save();
            }
            catch (Exception Exc)
            {
                Console.WriteLine("Error " + Exc.InnerException.Message);
                throw;
            }

            return newPlayer;
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UserData));
            StreamWriter writer = new StreamWriter(myPath);
            serializer.Serialize(writer, this);
            writer.Close();
        }

        public int nextAccountID()
        {
            int result = 0;
            if (LoginList != null)
            {
                foreach (Login login in LoginList)
                {
                    if (login.AccountID > result)
                        result = login.AccountID;
                    return ++result;
                }
            }
            return ++result;
        }

        public void setParents()
        {
            if(Login != null)
                foreach (Player player in Login.PlayerList)
                    player.setParent(this.Login);
        }
    }
}
