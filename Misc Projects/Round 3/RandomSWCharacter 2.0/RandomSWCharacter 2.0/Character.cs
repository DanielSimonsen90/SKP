using DanhoLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomSWCharacter_2._0
{
    class Character : IGetInfo
    {
        public General General { get; } = new General();
        public Species Species { get; } = new Species();
        public Anchestors Anchestors { get; }
        public Appearance Appearance { get; }
        public Role Role { get; }
        public Robot Robot { get; } = new Robot();
        public string Ship { get; }

        public Character()
        {
            Appearance = new Appearance(Species);
            Anchestors = new Anchestors(Species);
            Team Team = Team.Teams.GetRandomItem();
            Role = Team.Roles.GetRandomItem();
            Ship = Team.Ships.GetRandomItem();
        }

        public string GetInfo()
        {
            List<string> result = new List<string>()
            {
                General.GetInfo(),
                Species.GetInfo(),
                Anchestors.GetInfo(),
                Role.GetInfo(),
                Appearance.GetInfo()
            };

            if (ConsoleItems.RandomNumber(100) >= 25) result.Add(Robot.GetInfo());
            if (ConsoleItems.RandomNumber(100) >= 50) result.Add(Ship);

            return result.ToBigBoiString("\n");
        }
    }
}
