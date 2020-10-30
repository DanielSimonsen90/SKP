using System;

namespace RandomSWCharacter
{
    /// <summary>
    /// Custom Character
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Create random <see cref="Character"/>
        /// </summary>
        /// <param name="Background">{Name, Age, Sex}</param>
        /// <param name="species">{Anchestors, Items, <see cref="Appearance"/>}</param>
        public Character(string[] Background, Species species)
        {
            Props = new string[Background.Length];
            for (int x = 0; x < Background.Length; x++)
                Props[x] = Background[x];
            Species = species;

            Team = new Team();
            Companion = new Robot();
        }

        /// <summary>
        /// Basic information properties, {Name, Age Sex}
        /// </summary>
        private static string[] Props { get; set; }
        /// <summary>
        /// Species of <see cref="Character"/>, {Items[]{Name, HomePlanet}, Anchestors, <see cref="Appearance"/>}
        /// </summary>
        private static Species Species { get; set; }
        /// <summary>
        /// Team the <see cref="Character"/> is a part of, {Name, Role, TypicalWeapon}
        /// </summary>
        private static Team Team { get; set; }
        /// <summary>
        /// Robot companion of <see cref="Character"/>, {ID, Type}
        /// </summary>
        private static Robot Companion { get; set; }
        private static readonly Random Rand = new Random();

        /// <summary>
        /// Get all information about <see cref="Character"/>
        /// </summary>
        public void GetInfo()
        {
            #region string[]
            string[] Titles = { "Basic Presentation", "Species", "Anchestors", "Team & Role", "Physical Appearance", "Robot companion", "Ship" },
                BasicInfo = { "Name", "Age", "Sex" },
                SpeciesInfo = { "Name", "Home Planet" },
                AnchesterInfo = { "Mother", "Father" },
                Appearance = { "Head", "Face", "Neck", "Chest", "Hand", "Pant", "Shoe" },
                Robot = { "ID", "Droid Type" };
            #endregion

            #region SeekInfo
            SeekInfo(BasicInfo, Props, Titles[0]);
            SeekInfo(SpeciesInfo, Species.Items, Titles[1]);
            SeekInfo(AnchesterInfo, Species.Ancestors, Titles[2]);

            #region Team & Role Delcaration
            string[] TeamRole, TeamAndRole;
            bool IsJedi = Team.Role.IsJedi;
            if (IsJedi)
            {
                var Lightsaber = Team.Role.Lightsaber;
                TeamRole = new string[] { Team.Name, Team.Role.Name, Lightsaber.Name, Lightsaber.Color };
                TeamAndRole = new string[] { "Team Name", "Role", "Weapon", "Color" };
            }
            else
            {
                var Weapon = Team.Role.Weapon;
                TeamRole = new string[] { Team.Name, Team.Role.Name, Weapon.Name };
                TeamAndRole = new string[] { "Team Name", "Role", "Weapon" };
            }
            #endregion

            SeekInfo(TeamAndRole, TeamRole, Titles[3]);
            if (IsJedi)
                Team.Role.Lightsaber.IsDual();

            SeekInfo(Appearance, Species.Appearance.Items, Titles[4]);

            if (Rand.Next(100) <= 50)
                SeekInfo(Robot, Companion.Items, Titles[5]);

            if (Rand.Next(100) <= 50)
            {
                Console.WriteLine(Titles[6]);
                Console.WriteLine($"Name: {Team.Ship}");
                Console.WriteLine();
            }
            #endregion
        }
        /// <summary>
        /// Used to display information in <see cref="GetInfo"/>
        /// </summary>
        /// <param name="Options">Title of Property in array</param>
        /// <param name="Answers">Property value in array</param>
        /// <param name="Title">Title of properties</param>
        private void SeekInfo(string[] Options, string[] Answers, string Title)
        {
            Console.WriteLine(Title);
            for (int x = 0; x < Answers.Length; x++)
                Console.WriteLine($"{Options[x]}: {Answers[x]}");
            Console.WriteLine();
        }
    }
}
