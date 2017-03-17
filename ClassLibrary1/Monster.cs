using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Monster : LivingCreature
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RewardExperiencePoints { get; set; }
        public int RewardGold { get; set; }
        public List<LootItem> LootTable { get; set; }

        public Monster(int id, string name, int strength, int defense, int rewardExperiencePoints, int rewardGold, int currentHitPoints, int maximumHitPoints,
            int currentAbilityPoints, int maximumAbilityPoints, int intelligence, int magicDefense)
            : base(currentHitPoints, maximumHitPoints, currentAbilityPoints, maximumAbilityPoints, strength, defense, intelligence, magicDefense)
        {
            ID = id;
            Name = name;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;
            LootTable = new List<LootItem>();
        }
    }
}