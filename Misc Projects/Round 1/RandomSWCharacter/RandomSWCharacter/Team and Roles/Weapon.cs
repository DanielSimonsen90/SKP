using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomSWCharacter
{
    interface IWeapon
    {
        IWeapon RandomizeWeapon(bool isImperial);
    }
    public class Weapon : IWeapon
    {
        public Weapon()
        {

        }
        public Weapon(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public IWeapon RandomizeWeapon(bool IsImperial)
        {
            Random rand = new Random();
            if (rand.Next(100) <= 50)
                if (IsImperial)
                    return new Lightsaber("Red");
                else
                    return new Lightsaber(new Lightsaber("Random").RandomizeColor());
            else
                return new Weapon("Gun");
        }
    }
}
