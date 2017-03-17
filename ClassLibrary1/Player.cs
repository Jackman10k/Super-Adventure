using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Xml;

namespace Engine
{
    public class Player : LivingCreature
    {
        private int _gold;
        private int _experiencePoints;

        public int Gold
        {
            get { return _gold; }
            set
            {
                _gold = value;
                OnPropertyChanged("Gold");
            }
        }

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set
            {
                _experiencePoints = value;
                OnPropertyChanged("ExperiencePoints");
            }
        }

        public int Level { get; set; }
        public Location CurrentLocation { get; set; }
        public Weapon CurrentWeapon { get; set; }
        public Item CurrentItem { get; set; }
        public Ability CurrentAbility { get; set; }
        public BindingList<InventoryItem> Inventory { get; set; }
        public BindingList<PlayerQuest> Quests { get; set; }

        public List<Weapon> Weapons
        {
            get { return Inventory.Where(x => x.Details is Weapon).Select(x => x.Details as Weapon).ToList(); }
        }

        public List<Consumable> Consumables
        {
            get { return Inventory.Where(x => x.Details is Consumable).Select(x => x.Details as Consumable).ToList(); }
        }

        private Player(int currentHitPoints, int maximumHitPoints, int gold, int experiencePoints, int level, int strength, int defense,
            int currentAbilityPoints, int maximumAbilityPoints, int intelligence, int magicDefense)
            : base(currentHitPoints, maximumHitPoints, currentAbilityPoints, maximumAbilityPoints, strength, defense, intelligence, magicDefense)
        {
            Gold = gold;
            ExperiencePoints = experiencePoints;
            Level = level;

            Inventory = new BindingList<InventoryItem>();
            Quests = new BindingList<PlayerQuest>();
        }

        public static Player CreateDefaultPlayer()
        {
            Player player = new Player(10, 10, 20, 0, 1, 1, 1, 0, 0, 1, 1);
            player.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_RUSTY_SWORD), 1));
            player.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_HEALING_POTION), 1));
            player.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_ROMAN_CANDLE), 1));
            player.CurrentLocation = World.LocationByID(World.LOCATION_ID_HOME);

            return player;
        }

        public static Player CreatePlayerFromXmlString(string xmlPlayerData)
        {
            try
            {
                XmlDocument playerData = new XmlDocument();

                playerData.LoadXml(xmlPlayerData);

                int currentHitPoints = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/CurrentHitPoints").InnerText);
                int maximumHitPoints = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/MaximumHitPoints").InnerText);
                int currentAbilityPoints = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/CurrentAbilityPoints").InnerText);
                int maximumAbilityPoints = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/MaximumAbilityPoints").InnerText);
                int strength = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/Strength").InnerText);
                int defense = Convert.ToInt32(playerData.SelectSingleNode("Player/Stats/Defense").InnerText);
                int intelligence = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/Intelligence").InnerText);
                int magicDefense = Convert.ToInt32(playerData.SelectSingleNode("Player/Stats/MagicDefense").InnerText);
                int gold = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/Gold").InnerText);
                int experiencePoints = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/ExperiencePoints").InnerText);
                int level = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/Level").InnerText);

                Player player = new Player(currentHitPoints, maximumHitPoints, gold, experiencePoints, level, strength, defense, currentAbilityPoints,
                    maximumAbilityPoints, intelligence, magicDefense);

                int currentLocationID = Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/CurrentLocation").InnerText);
                player.CurrentLocation = World.LocationByID(currentLocationID);

                foreach (XmlNode node in playerData.SelectNodes("/Player/InventoryItems/InventoryItem"))
                {
                    int id = Convert.ToInt32(node.Attributes["ID"].Value);
                    int quantity = Convert.ToInt32(node.Attributes["Quantity"].Value);

                    for (int i = 0; i < quantity; i++)
                    {
                        player.AddItemToInventory(World.ItemByID(id));
                    }
                }

                foreach (XmlNode node in playerData.SelectNodes("/Player/AbilityList/Ability"))
                {
                    int id = Convert.ToInt32(node.Attributes["ID"].Value);
                    string name = node.Attributes["Name"].Value;
                    string description = node.Attributes["Description"].Value;
                    bool isOffensiveAbility = Convert.ToBoolean(node.Attributes["IsOffensiveAbility"].Value);
                    bool isSupportAbility = Convert.ToBoolean(node.Attributes["IsSupportAbility"].Value);
                    string attackType = node.Attributes["AttackType"].Value;
                    string elementalType = node.Attributes["ElementalType"].Value;
                    int basePower = Convert.ToInt32(node.Attributes["BasePower"].Value);
                    int costToUse = Convert.ToInt32(node.Attributes["CostToUse"].Value);
                    string affectedStat = node.Attributes["AffectedStat"].Value;

                    Ability ability = new Ability(id, name, description, isOffensiveAbility, isSupportAbility, attackType, elementalType, basePower, costToUse,
                        affectedStat);

                    player.AddAbilityToList(ability);
                }

                foreach (XmlNode node in playerData.SelectNodes("/Player/PlayerQuests/PlayerQuest"))
                {
                    int id = Convert.ToInt32(node.Attributes["ID"].Value);
                    bool isCompleted = Convert.ToBoolean(node.Attributes["IsCompleted"].Value);

                    PlayerQuest playerQuest = new PlayerQuest(World.QuestByID(id));
                    playerQuest.IsCompleted = isCompleted;

                    player.Quests.Add(playerQuest);
                }

                return player;
            }
            catch
            {
                // If there was an error with the XML data, return a default player object
                return Player.CreateDefaultPlayer();
            }
        }

        public bool HasRequiredItemToEnterThisLocation(Location location)
        {
            if (location.ItemRequiredToEnter == null)
            {
                // There is no required item for this location, so return "true"
                return true;
            }

            // See if the player has the required item in their inventory
            return Inventory.Any(ii => ii.Details.ID == location.ItemRequiredToEnter.ID);
        }

        public bool HasThisQuest(Quest quest)
        {
            return Quests.Any(pq => pq.Details.ID == quest.ID);
        }

        public bool CompletedThisQuest(Quest quest)
        {
            foreach (PlayerQuest playerQuest in Quests)
            {                
                if (playerQuest.Details.ID == quest.ID)
                {
                    return playerQuest.IsCompleted;
                }
            }

            return false;
        }

        public bool HasAllQuestCompletionItems(Quest quest)
        {
            // See if the player has all the items needed to complete the quest here
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                // Check each item in the player's inventory, to see if they have it, and enough of it
                if (!Inventory.Any(ii => ii.Details.ID == qci.Details.ID && ii.Quantity >= qci.Quantity))
                {
                    return false;
                }
            }

            // If we got here, then the player must have all the required items, and enough of them, to complete the quest.
            return true;
        }

        public void RemoveQuestCompletionItems(Quest quest)
        {
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                InventoryItem item = Inventory.SingleOrDefault(ii => ii.Details.ID == qci.Details.ID);

                if (item != null)
                {
                    RemoveItemFromInventory(item.Details, qci.Quantity);
                }
            }
        }

        public void AddItemToInventory(Item itemToAdd, int quantity = 1)
        {
            InventoryItem item = Inventory.SingleOrDefault(ii => ii.Details.ID == itemToAdd.ID);

            if (item == null)
            {
                // They didn't have the item, so add it to their inventory, with a quantity of 1
                Inventory.Add(new InventoryItem(itemToAdd, quantity));
            }
            else
            {
                // They have the item in their inventory, so increase the quantity by one
                item.Quantity += quantity;
            }

            RaiseInventoryChangedEvent(itemToAdd);
        }

        public void MarkQuestCompleted(Quest quest)
        {
            // Find the quest in the player's quest list
            PlayerQuest playerQuest = Quests.SingleOrDefault(pq => pq.Details.ID == quest.ID);

            if (playerQuest != null)
            {
                playerQuest.IsCompleted = true;
            }
        }

        public void AddAbilityToList(Ability abilityToAdd)
        {
            AbilityList.Add(abilityToAdd);
        }

        private void RaiseInventoryChangedEvent(Item item)
        {
            if (item is Weapon)
            {
                OnPropertyChanged("Weapons");
            }

            if (item is Consumable)
            {
                OnPropertyChanged("Consumables");
            }
        }

        public void RemoveItemFromInventory(Item itemToRemove, int quantity = 1)
        {
            InventoryItem item = Inventory.SingleOrDefault(ii => ii.Details.ID == itemToRemove.ID);

            if (item == null)
            {
                // The item is not in the player's inventory, so ignore it.
                // We might want to raise an error for this situation
            }
            else
            {
                // They have the item in their inventory, so decrease the quantity
                item.Quantity -= quantity;

                // Don't allow negative quantities.
                // We might want to raise an error for this situation
                if (item.Quantity < 0)
                {
                    item.Quantity = 0;
                }

                // If the quantity is zero, remove the item from the list
                if (item.Quantity == 0)
                {
                    Inventory.Remove(item);
                }

                // Notify the UI that the inventory has changed
                RaiseInventoryChangedEvent(itemToRemove);
            }
        }

        public string ToXmlString()
        {
            XmlDocument playerData = new XmlDocument();

            //Creating the top-level XML node
            XmlNode player = playerData.CreateElement("Player");
            playerData.AppendChild(player);

            //Creating the "Stats" child node to hold the other player statistics nodes
            XmlNode stats = playerData.CreateElement("Stats");
            player.AppendChild(stats);

            //Creating the child nodes for the "Stats" node
            XmlNode currentHitPoints = playerData.CreateElement("CurrentHitPoints");
            currentHitPoints.AppendChild(playerData.CreateTextNode(this.CurrentHitPoints.ToString()));
            stats.AppendChild(currentHitPoints);

            XmlNode maximumHitPoints = playerData.CreateElement("MaximumHitPoints");
            maximumHitPoints.AppendChild(playerData.CreateTextNode(this.MaximumHitPoints.ToString()));
            stats.AppendChild(maximumHitPoints);

            XmlNode currentAbilityPoints = playerData.CreateElement("CurrentAbilityPoints");
            currentAbilityPoints.AppendChild(playerData.CreateTextNode(this.CurrentAbilityPoints.ToString()));
            stats.AppendChild(currentAbilityPoints);

            XmlNode maximumAbilityPoints = playerData.CreateElement("MaximumAbilityPoints");
            maximumAbilityPoints.AppendChild(playerData.CreateTextNode(this.MaximumAbilityPoints.ToString()));
            stats.AppendChild(maximumAbilityPoints);

            XmlNode strength = playerData.CreateElement("Strength");
            strength.AppendChild(playerData.CreateTextNode(this.Strength.ToString()));
            stats.AppendChild(strength);

            XmlNode defense = playerData.CreateElement("Defense");
            defense.AppendChild(playerData.CreateTextNode(this.Defense.ToString()));
            stats.AppendChild(defense);

            XmlNode intelligence = playerData.CreateElement("Intelligence");
            intelligence.AppendChild(playerData.CreateTextNode(this.Intelligence.ToString()));
            stats.AppendChild(intelligence);

            XmlNode magicDefense = playerData.CreateElement("MagicDefense");
            magicDefense.AppendChild(playerData.CreateTextNode(this.MagicDefense.ToString()));
            stats.AppendChild(magicDefense);

            XmlNode gold = playerData.CreateElement("Gold");
            gold.AppendChild(playerData.CreateTextNode(this.Gold.ToString()));
            stats.AppendChild(gold);

            XmlNode experiencePoints = playerData.CreateElement("ExperiencePoints");
            experiencePoints.AppendChild(playerData.CreateTextNode(this.ExperiencePoints.ToString()));
            stats.AppendChild(experiencePoints);

            XmlNode level = playerData.CreateElement("Level");
            level.AppendChild(playerData.CreateTextNode(this.Level.ToString()));
            stats.AppendChild(level);

            XmlNode currentLocation = playerData.CreateElement("CurrentLocation");
            currentLocation.AppendChild(playerData.CreateTextNode(this.CurrentLocation.ID.ToString()));
            stats.AppendChild(currentLocation);

            //Creating the "InventoryItems" child node to hold each InventoryItem node
            XmlNode inventoryItems = playerData.CreateElement("InventoryItems");
            player.AppendChild(inventoryItems);

            // Create an "InventoryItem" node for each item in the player's inventory
            foreach (InventoryItem item in this.Inventory)
            {
                XmlNode inventoryItem = playerData.CreateElement("InventoryItem");

                XmlAttribute idAttribute = playerData.CreateAttribute("ID");
                idAttribute.Value = item.Details.ID.ToString();
                inventoryItem.Attributes.Append(idAttribute);

                XmlAttribute quantityAttribute = playerData.CreateAttribute("Quantity");
                quantityAttribute.Value = item.Quantity.ToString();
                inventoryItem.Attributes.Append(quantityAttribute);

                inventoryItems.AppendChild(inventoryItem);
            }

            //Creating the "AbilityList" child node to hold the player's abilities
            XmlNode abilityList = playerData.CreateElement("AbilityList");
            player.AppendChild(abilityList);

            //Creating an "Ability" node for each of the player's learned abilities
            foreach (Ability playerAbility in this.AbilityList)
            {
                XmlNode xmlAbility = playerData.CreateElement("Ability");

                XmlAttribute idAttribute = playerData.CreateAttribute("ID");
                idAttribute.Value = playerAbility.ID.ToString();
                xmlAbility.Attributes.Append(idAttribute);

                XmlAttribute nameAttribute = playerData.CreateAttribute("Name");
                nameAttribute.Value = playerAbility.Name.ToString();
                xmlAbility.Attributes.Append(nameAttribute);

                XmlAttribute descriptionAttribute = playerData.CreateAttribute("Description");
                descriptionAttribute.Value = playerAbility.Description.ToString();
                xmlAbility.Attributes.Append(descriptionAttribute);

                XmlAttribute offensiveAttribute = playerData.CreateAttribute("IsOffensiveAbility");
                offensiveAttribute.Value = playerAbility.IsOffensiveAbility.ToString();
                xmlAbility.Attributes.Append(offensiveAttribute);

                XmlAttribute supportAttribute = playerData.CreateAttribute("IsSupportAbility");
                supportAttribute.Value = playerAbility.IsSupportAbility.ToString();
                xmlAbility.Attributes.Append(supportAttribute);

                XmlAttribute attackAttribute = playerData.CreateAttribute("AttackType");
                attackAttribute.Value = playerAbility.AttackType.ToString();
                xmlAbility.Attributes.Append(attackAttribute);

                XmlAttribute elementAttribute = playerData.CreateAttribute("ElementalType");
                elementAttribute.Value = playerAbility.ElementalType.ToString();
                xmlAbility.Attributes.Append(elementAttribute);

                XmlAttribute baseAttribute = playerData.CreateAttribute("BasePower");
                baseAttribute.Value = playerAbility.BasePower.ToString();
                xmlAbility.Attributes.Append(baseAttribute);

                XmlAttribute costAttribute = playerData.CreateAttribute("CostToUse");
                costAttribute.Value = playerAbility.CostToUse.ToString();
                xmlAbility.Attributes.Append(costAttribute);

                XmlAttribute statAttribute = playerData.CreateAttribute("AffectedStat");
                statAttribute.Value = playerAbility.AffectedStat.ToString();
                xmlAbility.Attributes.Append(statAttribute);

                abilityList.AppendChild(xmlAbility);
            }

            // Create the "PlayerQuests" child node to hold each PlayerQuest node
            XmlNode playerQuests = playerData.CreateElement("PlayerQuests");
            player.AppendChild(playerQuests);

            // Create a "PlayerQuest" node for each quest the player has acquired
            foreach (PlayerQuest quest in this.Quests)
            {
                XmlNode playerQuest = playerData.CreateElement("PlayerQuest");

                XmlAttribute idAttribute = playerData.CreateAttribute("ID");
                idAttribute.Value = quest.Details.ID.ToString();
                playerQuest.Attributes.Append(idAttribute);

                XmlAttribute isCompletedAttribute = playerData.CreateAttribute("IsCompleted");
                isCompletedAttribute.Value = quest.IsCompleted.ToString();
                playerQuest.Attributes.Append(isCompletedAttribute);

                playerQuests.AppendChild(playerQuest);
            }

            return playerData.InnerXml; // The XML document, as a string, so we can save the data to disk
        }
    }
}