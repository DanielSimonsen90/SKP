using DanhoLibrary;

namespace RandomSWCharacter_2._0.Weapons
{
    class Gun
    {
        public override string ToString() =>
            new string[] { "Handgun", "Machinegun", "Sniper", "Shutgun", "Knife" }.GetRandomItem();
    }
}
