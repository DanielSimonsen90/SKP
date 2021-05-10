using System;

namespace RandomSWCharacter
{
    /// <summary>
    /// The Role <see cref="Character"/> plays in <see cref="Team"/>
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Role containing <see cref="RandomSWCharacter.Weapon"/>
        /// </summary>
        /// <param name="Name">Name of <see cref="Role"/></param>
        /// <param name="weapon">Weapon class, <see cref="RandomSWCharacter.Weapon"/></param>
        public Role(string Name, Weapon weapon)
        {
            this.Name = Name;
            Weapon = weapon;
        }
        /// <summary>
        /// Role containing <see cref="RandomSWCharacter.Lightsaber"/>
        /// </summary>
        /// <param name="Name">Name of <see cref="Role"/></param>
        /// <param name="lightsaber">Lightsaber class, <see cref="RandomSWCharacter.Lightsaber"/></param>
        public Role (string Name, Lightsaber lightsaber)
        {
            this.Name = Name;
            Lightsaber = lightsaber;
        }
        /// <summary>
        /// Used for randomizing weapon-type in <see cref="Weapon.RandomizeWeapon(bool)"/>
        /// </summary>
        /// <param name="Name">Name of <see cref="Role"/></param>
        /// <param name="RandomWeapon">Returned value of <see cref="Weapon.RandomizeWeapon(bool)"/>, set to either <see cref="Lightsaber"/> or <see cref="Weapon"/></param>
        public Role(string Name, object RandomWeapon)
        {
            this.Name = Name;
            
            try { Lightsaber = (Lightsaber)RandomWeapon; IsJedi = true; }
            catch { Weapon = (Weapon)RandomWeapon; }
        }

        /// <summary>
        /// Lightsaber of Role
        /// </summary>
        public readonly Lightsaber Lightsaber;
        /// <summary>
        /// Weapon of Role
        /// </summary>
        public readonly Weapon Weapon;
        /// <summary>
        /// Name of Role
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// If 
        /// </summary>
        public bool IsJedi { get; set; }
    }
}