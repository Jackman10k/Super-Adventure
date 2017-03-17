using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Weapon : Item
    {
        public int WeaponStrength { get; set; }
        public string AttackType { get; set; }
        public string SpecialType { get; set; }

        public Weapon(int id, string name, string namePlural, string description, int price, int weaponStrength, string attackType, string specialType, bool canOnlyHaveOne)
            : base(id, name, namePlural, description, price, canOnlyHaveOne)
        {
            WeaponStrength = weaponStrength;
            AttackType = attackType;
            SpecialType = specialType;
        }
    }
}