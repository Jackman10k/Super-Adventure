using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Advice { get; set; }
        public Item ItemRequiredToEnter { get; set; }
        public Quest QuestAvailableHere { get; set; }
        public Monster MonsterLivingHere { get; set; }
        public Location LocationToNorth { get; set; }
        public Location LocationToEast { get; set; }
        public Location LocationToSouth { get; set; }
        public Location LocationToWest { get; set; }
        public string LocationToNorthDescription { get; set; }
        public string LocationToEastDescription { get; set; }
        public string LocationToSouthDescription { get; set; }
        public string LocationToWestDescription { get; set; }
        public bool HasSavePoint { get; set; }
        public Vendor VendorWorkingHere { get; set; }
        public Inn InnAvailableHere { get; set; }
        public List<NPC> NPCsLivingHere { get; set; }

        public Location(int id, string name, string description, string advice,
            Item itemRequiredToEnter = null, Quest questAvailableHere = null, Monster monsterLivingHere = null, bool hasSavePoint = false)
        {
            ID = id;
            Name = name;
            Description = description;
            Advice = advice;
            ItemRequiredToEnter = itemRequiredToEnter;
            QuestAvailableHere = questAvailableHere;
            MonsterLivingHere = monsterLivingHere;
            HasSavePoint = hasSavePoint;

            NPCsLivingHere = new List<NPC>();
        }
    }
}