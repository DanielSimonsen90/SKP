using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;

namespace BigProject
{
    //Potion
    [XmlRoot(ElementName = "Health")]
    public class HealthPotion
    {
        [XmlAttribute(AttributeName = "Amount")]
        public int amount { get; set; }
        [XmlAttribute(AttributeName = "healingDone")]
        public int healingdone { get; set; }

        private UserData Child;
        public void setParent(UserData Parent)
        {
            Child = Parent;
        }
    }
    [XmlRoot(ElementName = "Shield")]
    public class ShieldPotion
    {
        [XmlAttribute(AttributeName = "Amount")]
        public int amount { get; set; }
        [XmlAttribute(AttributeName = "externalShield")]
        public int externalShield { get; set; }

        private UserData Child;
        public void setParent(UserData Parent)
        {
            Child = Parent;
        }
    }
    [XmlRoot(ElementName = "Potion")]
    public class Potion
    {
        [XmlElement(ElementName = "Health")]
        public List<HealthPotion> Health { get; set; }
        [XmlElement(ElementName = "Shield")]
        public List<ShieldPotion> Shield { get; set; }

        private UserData Child;
        public void setParent(UserData Parent)
        {
            Child = Parent;
        }
    }

    //Equipment
    [XmlRoot(ElementName = "Melee")]
    public class Melee
    {
        [XmlAttribute(AttributeName = "Weapon")]
        public string weapon { get; set; }
        [XmlAttribute(AttributeName = "dmgBoost")]
        public double dmgboost { get; set; }
        [XmlAttribute(AttributeName = "Durability")]
        public double durability { get; set; }

        private UserData Child;
        public void setParent(UserData Parent)
        {
            Child = Parent;
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

        private UserData Child;
        public void setParent(UserData Parent)
        {
            Child = Parent;
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

        private UserData Child;
        public void setParent(UserData Parent)
        {
            Child = Parent;
        }
    }
    [XmlRoot(ElementName ="Equipment")]
    public class Equipment
    {
        [XmlElement(ElementName ="Melee")]
        public List<Melee> Melee { get; set; }
        [XmlElement(ElementName = "Medium")]
        public List<Medium> Medium { get; set; }
        [XmlElement(ElementName = "Long")]
        public List<Long> Long { get; set; }
        [XmlElement(ElementName = "Potion")]
        public List<Potion> Potion { get; set; }

        private UserData Child;
        public void setParent(UserData Parent)
        {
            Child = Parent;
        }
    }

    //Rank
    [XmlRoot(ElementName = "Range")]
    public class Range
    {
        [XmlAttribute(AttributeName = "Short")]
        public int Short { get; set; }
        [XmlAttribute(AttributeName = "Medium")]
        public int Medium { get; set; }
        [XmlAttribute(AttributeName = "Long")]
        public int Long { get; set; }

        private UserData Child;
        public void setParent(UserData Parent)
        {
            Child = Parent;
        }
    }
    [XmlRoot(ElementName = "Warrior")]
    public class Warrior
    {
        [XmlAttribute(AttributeName = "Rank")]
        public int rank { get; set; }
        [XmlElement(ElementName = "Range")]
        public List<Range> Range { get; set; }
        [XmlElement(ElementName = "Equipment")]
        public List<Equipment> Equipment { get; set; }

        private UserData Child;
        public void setParent(UserData Parent)
        {
            Child = Parent;
        }
    }
    [XmlRoot(ElementName = "Soldier")]
    public class Soldier
    {
        [XmlAttribute(AttributeName = "Rank")]
        public int rank { get; set; }
        [XmlElement(ElementName = "Range")]
        public List<Range> Range { get; set; }
        [XmlElement(ElementName = "Equipment")]
        public List<Equipment> Equipment { get; set; }

        private UserData Child;
        public void setParent(UserData Parent)
        {
            Child = Parent;
        }
    }
    [XmlRoot(ElementName = "Mage")]
    public class Mage
    {
        [XmlAttribute(AttributeName = "Rank")]
        public int rank { get; set; }
        [XmlElement(ElementName = "Range")]
        public List<Range> Range { get; set; }
        [XmlElement(ElementName = "Equipment")]
        public List<Equipment> Equipment { get; set; }

        private UserData Child;
        public void setParent(UserData Parent)
        {
            Child = Parent;
        }
    }
    [XmlRoot(ElementName = "Engineer")]
    public class Engineer
    {
        [XmlAttribute(AttributeName = "Rank")]
        public int rank { get; set; }
        [XmlElement(ElementName = "Range")]
        public List<Range> Range { get; set; }
        [XmlElement(ElementName = "Equipment")]
        public List<Equipment> Equipment { get; set; }

        private UserData Child;
        public void setParent(UserData Parent)
        {
            Child = Parent;
        }
    }
    [XmlRoot(ElementName = "Rank")]
    public class Rank
    {
        [XmlElement(ElementName = "Warrior")]
        public List<Warrior> Warrior { get; set; }
        [XmlElement(ElementName = "Soldier")]
        public List<Soldier> Soldier { get; set; }
        [XmlElement(ElementName = "Mage")]
        public List<Mage> Mage { get; set; }
        [XmlElement(ElementName = "Engineer")]
        public List<Engineer> Engineer { get; set; }

        private UserData Child;
        public void setParent(UserData Parent)
        {
            Child = Parent;
        }
    }

    //Armor
    [XmlRoot(ElementName = "Helmet")]
    public class Helmet
    {
        [XmlAttribute(AttributeName = "Protection")]
        public double Protection { get; set; }
        [XmlAttribute(AttributeName = "Durability")]
        public double Durablity { get; set; }

        private UserData Child;
        public void setParent(UserData Parent)
        {
            Child = Parent;
        }
    }
    [XmlRoot(ElementName = "Chestplate")]
    public class Chestplate
    {
        [XmlAttribute(AttributeName = "Protection")]
        public double Protection { get; set; }
        [XmlAttribute(AttributeName = "Durability")]
        public double Durablity { get; set; }

        private UserData Child;
        public void setParent(UserData Parent)
        {
            Child = Parent;
        }
    }
    [XmlRoot(ElementName = "Leggings")]
    public class Leggings
    {
        [XmlAttribute(AttributeName = "Protection")]
        public double Protection { get; set; }
        [XmlAttribute(AttributeName = "Durability")]
        public double Durablity { get; set; }

        private UserData Child;
        public void setParent(UserData Parent)
        {
            Child = Parent;
        }
    }
    [XmlRoot(ElementName = "Boots")]
    public class Boots
    {
        [XmlAttribute(AttributeName = "Protection")]
        public double Protection { get; set; }
        [XmlAttribute(AttributeName = "Durability")]
        public double Durablity { get; set; }

        private UserData Child;
        public void setParent(UserData Parent)
        {
            Child = Parent;
        }
    }
    [XmlRoot(ElementName = "Shield")]
    public class Shield
    {
        [XmlAttribute(AttributeName = "Protection")]
        public double Protection { get; set; }
        [XmlAttribute(AttributeName = "Durability")]
        public double Durablity { get; set; }

        private UserData Child;
        public void setParent(UserData Parent)
        {
            Child = Parent;
        }
    }
    [XmlRoot(ElementName = "Barrier")]
    public class Barrier
    {
        [XmlAttribute(AttributeName = "Protection")]
        public double Protection { get; set; }
        [XmlAttribute(AttributeName = "Durability")]
        public double Durablity { get; set; }

        private UserData Child;
        public void setParent(UserData Parent)
        {
            Child = Parent;
        }
    }
    [XmlRoot(ElementName = "Armor")]
    public class Armor
    {
        [XmlElement(ElementName = "Helmet")]
        public List<Helmet> Helmet { get; set; }
        [XmlElement(ElementName = "Chestplate")]
        public List<Chestplate> Chestplate { get; set; }
        [XmlElement(ElementName = "Leggings")]
        public List<Leggings> Leggins { get; set; }
        [XmlElement(ElementName = "Boots")]
        public List<Boots> Boots { get; set; }
        [XmlElement(ElementName = "Shield")]
        public List<Shield> Shield { get; set; }
        [XmlElement(ElementName = "Barrier")]
        public List<Barrier> Barrier { get; set; }

        private UserData Child;
        public void setParent(UserData Parent)
        {
            Child = Parent;
        }
    }

    //Player information
    [XmlRoot(ElementName = "Player")]
    public class Player
    {
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
        [XmlElement(ElementName = "Rank")]
        public List<Rank> Rank { get; set; }
        [XmlElement(ElementName = "Armor")]
        public List<Armor> Armor { get; set; }

        private UserData Child;
        public void setParent(UserData Parent)
        {
            Child = Parent;
        }
    }

    //Login information
    [XmlRoot(ElementName = "Login")]
    public class Login
    {
        [XmlAttribute(AttributeName = "Username")]
        public string username { get; set; }
        [XmlAttribute(AttributeName = "Password")]
        public string password { get; set; }
        [XmlElement(ElementName = "Player")]
        public List<Player> Player { get; set; }

        private UserData Child;
        public void setParent(UserData Parent)
        {
            Child = Parent;
        }
    }

    //Account information
    [XmlRoot(ElementName = "Account")]
    public class Account
    {
        [XmlAttribute(AttributeName = "StartDate")]
        public DateTime startDate { get; set; }
        [XmlElement(ElementName = "Login")]
        public List<Login> Login { get; set; }
    }

    //XML Set-Up
    [XmlRoot(ElementName = "UserData")]
    public class UserData
    {
        [XmlElement(ElementName = "Account")]
        public Account Accounts { get; set; }
        public Login Login { get; set; }
        public Player Player { get; set; }
        public Rank Rank { get; set; }
        public Warrior Warrior { get; set; }
        public Soldier Soldier { get; set; }
        public Mage Mage { get; set; }
        public Engineer Engineer { get; set; }
        public Range Range { get; set; }
        public Equipment Equipment { get; set; }
        public Melee Melee { get; set; }
        public Medium Medium { get; set; }
        public Long Long { get; set; }
        public Potion Potion { get; set; }
        public HealthPotion HealthPotion { get; set; }
        public ShieldPotion ShieldPotion { get; set; }
        public Armor Armor { get; set; }
        public Helmet Helmet { get; set; }
        public Chestplate Chestplate { get; set; }
        public Leggings Leggings { get; set; }
        public Boots Boots { get; set;  }
        public Shield Shield { get; set; }
        public Barrier Barrier { get; set; }


        private static string myPath = "";

        public static UserData UserDataFromXML(String path)
        {
            myPath = path;
            XmlSerializer serializer = new XmlSerializer(typeof(UserData));
            StreamReader reader = new StreamReader(path);
            UserData newPlayer = (UserData)serializer.Deserialize(reader);
            reader.Close();
            newPlayer.setParents();
            return newPlayer;
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UserData));
            StreamWriter writer = new StreamWriter(myPath);
            serializer.Serialize(writer, this);
            writer.Close();
        }

        public void setParents()
        {
            foreach (HealthPotion healthPotion in Potion.Health)
                healthPotion.setParent(this);
            foreach (ShieldPotion shieldPotion in Potion.Shield)
                shieldPotion.setParent(this);
            foreach (Potion potions in Equipment.Potion)
                potions.setParent(this);
            foreach (Melee closeRange in Equipment.Melee)
                closeRange.setParent(this);
            foreach (Medium mediumRange in Equipment.Medium)
                mediumRange.setParent(this);
            foreach (Long longRange in Equipment.Long)
                longRange.setParent(this);
            foreach (Equipment inventory in Warrior.Equipment)
                inventory.setParent(this);
            foreach (Equipment inventory in Soldier.Equipment)
                inventory.setParent(this);
            foreach (Equipment inventory in Mage.Equipment)
                inventory.setParent(this);
            foreach (Equipment inventory in Engineer.Equipment)
                inventory.setParent(this);
            foreach (Range range in Warrior.Range)
                range.setParent(this);
            foreach (Range range in Soldier.Range)
                range.setParent(this);
            foreach (Range range in Mage.Range)
                range.setParent(this);
            foreach (Range range in Engineer.Range)
                range.setParent(this);
            foreach (Warrior warrior in Rank.Warrior)
                warrior.setParent(this);
            foreach (Soldier soldier in Rank.Soldier)
                soldier.setParent(this);
            foreach (Mage mage in Rank.Mage)
                mage.setParent(this);
            foreach (Engineer engineer in Rank.Engineer)
                engineer.setParent(this);
            foreach (Rank rank in Player.Rank)
                rank.setParent(this);
            foreach (Helmet Helmet in Armor.Helmet)
                Helmet.setParent(this);
            foreach (Chestplate chestplate in Armor.Chestplate)
                Chestplate.setParent(this);
            foreach (Leggings leggings in Armor.Leggins)
                leggings.setParent(this);
            foreach (Boots boots in Armor.Boots)
                boots.setParent(this);
            foreach (Shield shield in Armor.Shield)
                shield.setParent(this);
            foreach (Barrier barrier in Armor.Barrier)
                barrier.setParent(this);
            foreach (Armor Armor in Player.Armor)
                Armor.setParent(this);
            foreach (Player player in Login.Player)
                player.setParent(this);
            foreach (Login login in Accounts.Login)
                login.setParent(this);
        }
    }
}
