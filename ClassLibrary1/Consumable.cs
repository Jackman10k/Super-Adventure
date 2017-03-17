using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Consumable : Item
    {
        public int BasePower { get; set; }
        public bool IsOffensiveItem { get; set; }
        public bool IsSupportItem { get; set; }
        public string AffectedStat { get; set; }
        public string DamageType { get; set; }

        public Consumable(int id, string name, string namePlural, string description, int price, int basePower,
            bool isOffensiveItem, bool isSupportItem, string affectedStat = "N/A", string damageType = "N/A")
            : base(id, name, namePlural, description, price)
        {
            BasePower = basePower;
            AffectedStat = affectedStat;
            IsOffensiveItem = isOffensiveItem;
            IsSupportItem = isSupportItem;
            DamageType = damageType;
        }
    }
}