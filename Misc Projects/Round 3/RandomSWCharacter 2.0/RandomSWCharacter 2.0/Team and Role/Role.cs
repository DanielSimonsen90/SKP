using DanhoLibrary;
using RandomSWCharacter_2._0.Weapons;

namespace RandomSWCharacter_2._0
{
    internal class Role : IGetInfo
    {
        private Team Team { get; }
        private string Name { get; }

        private Gun Gun { get; }
        private Lightsaber Lightsaber { get; }

        private Role(string name) => Name = name;
        public Role(string name, bool _) : this(name)
        {
            if (ConsoleItems.RandomNumber(100) > 15) this.Gun = new Gun();
            else this.Lightsaber = new Lightsaber(LightsaberType.Random);
        }
        public Role(string name, Gun gun) : this(name) => Gun = gun;
        public Role(string name, Lightsaber lightsaber) : this(name) => Lightsaber = lightsaber;

        public string GetInfo() => new string[]
        {
            "-- == Role == --",
            $"Team: {Team}",
            $"Role: {Name}",
            $"Weapon: {(Gun == null ? GetInfoLightsaber() : GetInfoGun())}"
        }.Join("\n");
        private string GetInfoGun() => Gun.ToString();
        private string GetInfoLightsaber() => new string[]
        {
            "Lightsaber",
            $"Color: {Lightsaber}"
        }.Join("\n");
    }
}