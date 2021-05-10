using System;

namespace RandomSWCharacter
{
    class Team
    {
        public Team()
        {
            if (Rand.Next(100) <= 33)
            {
                Name = "Imperial";
                Roles = new Role[]
                {
                    new Role("Sith Lord", new Lightsaber("Red")) {IsJedi = true },
                    new Role("General", new Weapon().RandomizeWeapon(true)),
                    new Role("Commander", new Weapon().RandomizeWeapon(true)),
                    new Role("Padawan", new Lightsaber("Red")) {IsJedi = true },
                    new Role("Stormtrooper", new Weapon("Gun")),
                    new Role("Pilot", new Weapon("Gun"))
                };
                Lightsabers = new Lightsaber[] { new Lightsaber("Red") };
                Ships = new string[] { "Star Destroyer", "Scimitar Sith Infiltrator", "Lambda-class T-4a Shuttle", "TIE Fighter" };
            }
            else if (Rand.Next(100) <= 66)
            {
                Name = "Alliance";
                Roles = new Role[]
                {
                    new Role("Jedi Master", new Lightsaber(new Lightsaber("Random").RandomizeColor())) {IsJedi = true },
                    new Role("Jedi Knight", new Lightsaber(new Lightsaber("Random").RandomizeColor())) {IsJedi = true },
                    new Role("Padawan", new Lightsaber(new Lightsaber("Random").RandomizeColor())) {IsJedi = true },
                    new Role("Senator", new Weapon("Gun")),
                    new Role("General", new Weapon().RandomizeWeapon(false)),
                    new Role("Commander", new Weapon().RandomizeWeapon(false)),
                    new Role("Pilot", new Weapon().RandomizeWeapon(false))
                };
                Lightsabers = new Lightsaber[]
                {
                    new Lightsaber("Blue"),
                    new Lightsaber("Green")
                };
                Ships = new string[] { "N-1 Naboo Starfighter", "Jedi Starfighter", "Y-Wing", "Millennium Falcon", "X-Wing" };
            }
            else
            {
                Name = "Passive";
                Roles = new Role[]
                {
                    new Role("Farmer", new Weapon().RandomizeWeapon(false)),
                    new Role("Engineer", new Weapon().RandomizeWeapon(false)),
                    new Role("Bounty Hunter", new Weapon("Gun")),
                };
                Lightsabers = new Lightsaber[]
                {
                    new Lightsaber("Blue"),
                    new Lightsaber("Green"),
                    new Lightsaber("Red")
                };
                Ships = new string[] { "The Ghost", "Ebon Hawk", "Slave I", "TARDIS"};
            }
            Ship = Ships[Rand.Next(Ships.Length)];
            Role = Roles[Rand.Next(Roles.Length)];
        }

        public string Name { get; set; }
        public Role[] Roles { get; set; }
        public Role Role { get; private set; }
        public Lightsaber[] Lightsabers { get; set; }
        private static string[] Ships { get; set; }
        public string Ship { get; set; }
        private static readonly Random Rand = new Random();
    }
}
