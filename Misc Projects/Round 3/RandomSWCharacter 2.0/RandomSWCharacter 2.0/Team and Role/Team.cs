using DanhoLibrary;
using RandomSWCharacter_2._0.Weapons;
using System.Collections.Generic;

namespace RandomSWCharacter_2._0
{
    internal class Team
    {
        public static List<Team> Teams = new List<Team>()
        {
            new Team("Imperial", "First Order", "Empire", "Seperatist")
                .SetRoles(
                    new Role("Sith Lord", new Lightsaber(LightsaberType.Bad)), 
                    new Role("Sith Apprentice", new Lightsaber(LightsaberType.Bad)), 
                    new Role("General", true), 
                    new Role("Commander", true),
                    new Role("Stormtrooper", new Gun()),
                    new Role("Pilot", new Gun())
                )
                .SetShips("Star Destroyer", "Schimitar Sith Infiltrator", "Lambda-class T-4a Shuttle", "TIE Fighter"),
            new Team("Alliance", "Resistance", "Republic", "New Resistance")
                .SetRoles(
                    new Role("Jedi Master", new Lightsaber(LightsaberType.Good)),
                    new Role("Jedi Knight", new Lightsaber(LightsaberType.Good)), 
                    new Role("Padawan", new Lightsaber(LightsaberType.Good)),
                    new Role("Senator", true),
                    new Role("General", true),
                    new Role("Commander", true), 
                    new Role("Pilot", new Gun())
                )
                .SetShips("N-1 Naboo Starfighter", "Jedi Starfighter", "X-Wing", "Y-Wing", "Millennium Falcon"),
            new Team("Passive")
                .SetRoles(
                    new Role("Farmer", new Gun()), 
                    new Role("Engineer", new Gun()), 
                    new Role("Bounty Hunter", new Gun())
                )
                .SetShips("The Ghost", "Ebon Hawk", "Slave I", "Razor Crest")
        };

        private string Name { get; }
        public Role[] Roles { get; private set; }
        public string[] Ships { get; set; }

        public Team(params string[] names) => this.Name = names.GetRandomItem();
        public Team SetRoles(params Role[] roles)
        {
            Roles = roles;
            return this;
        }
        public Team SetShips(params string[] ships)
        {
            Ships = ships;
            return this;
        }

        public override string ToString() => Name;
    }
}