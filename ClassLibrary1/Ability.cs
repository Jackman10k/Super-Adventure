using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Ability
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsOffensiveAbility { get; set; }
        public bool IsSupportAbility { get; set; }
        public string AttackType { get; set; }
        public string ElementalType { get; set; }
        public string AffectedStat { get; set; }
        public int BasePower { get; set; }
        public int CostToUse { get; set; }

        public Ability(int id, string name, string description, bool isOffensiveAbility, bool isSupportAbility, string attackType,
            string elementalType, int basePower, int costToUse, string affectedStat = "N/A")
        {
            ID = id;
            Name = name;
            Description = description;
            IsOffensiveAbility = isOffensiveAbility;
            IsSupportAbility = isSupportAbility;
            AttackType = attackType;
            ElementalType = elementalType;
            BasePower = basePower;
            CostToUse = costToUse;
            AffectedStat = affectedStat;
        }
    }
}
