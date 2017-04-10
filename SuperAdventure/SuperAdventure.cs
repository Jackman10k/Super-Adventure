using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

using Engine;

namespace SuperAdventure
{
    public partial class SuperAdventure : Form
    {
        private const string PLAYER_DATA_FILE_NAME = "PlayerData.xml";
        private Player _player;
        private Monster _currentMonster;

        public SuperAdventure()
        {
            InitializeComponent();

            //Creating player character from save data if the data exists
            if (File.Exists(PLAYER_DATA_FILE_NAME))
            {
                _player = Player.CreatePlayerFromXmlString(File.ReadAllText(PLAYER_DATA_FILE_NAME));
            }

            //Creating the default player if no save data is found
            else
            {
                _player = Player.CreateDefaultPlayer();
            }

            MoveTo(_player.CurrentLocation);

            //Preparing UI labels for use
            lblCurrentHitPoints.DataBindings.Add("Text", _player, "CurrentHitPoints");
            lblMaximumHitPoints.DataBindings.Add("Text", _player, "MaximumHitPoints");
            lblGold.DataBindings.Add("Text", _player, "Gold");
            lblExperience.DataBindings.Add("Text", _player, "ExperiencePoints");
            lblLevel.Text = _player.Level.ToString();
            lblCurrentAbilityPoints.DataBindings.Add("Text", _player, "CurrentAbilityPoints");
            lblMaximumAbilityPoints.DataBindings.Add("Text", _player, "MaximumAbilityPoints");
            lblToNextLevel.Text = ExperienceDifferenceCalculator(_player.ExperiencePoints, _player.Level);

            //Databinding for player inventory
            dgvInventory.RowHeadersVisible = false;
            dgvInventory.AutoGenerateColumns = false;

            dgvInventory.DataSource = _player.Inventory;

            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                Width = 197,
                DataPropertyName = "Description"
            });

            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Quantity",
                DataPropertyName = "Quantity"
            });

            //Databinding for quest list
            dgvQuests.RowHeadersVisible = false;
            dgvQuests.AutoGenerateColumns = false;

            dgvQuests.DataSource = _player.Quests;

            dgvQuests.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                Width = 197,
                DataPropertyName = "Name"
            });

            dgvQuests.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Done?",
                DataPropertyName = "IsCompleted"
            });

            //Databinding for weapons combobox
            cboWeapons.DataSource = _player.Weapons;
            cboWeapons.DisplayMember = "Name";
            cboWeapons.ValueMember = "Id";

            if (_player.CurrentWeapon != null)
            {
                cboWeapons.SelectedItem = _player.CurrentWeapon;
            }

            cboWeapons.SelectedIndexChanged += cboWeapons_SelectedIndexChanged;

            //Databinding for consumables combobox
            cboConsumables.DataSource = _player.Consumables;
            cboConsumables.DisplayMember = "Name";
            cboConsumables.ValueMember = "Id";

            if (_player.CurrentItem != null)
            {
                cboConsumables.SelectedItem = _player.CurrentItem;
            }

            cboConsumables.SelectedIndexChanged += cboConsumables_SelectedIndexChanged;

            //Databinding for ability combobox
            cboAbilities.DataSource = _player.AbilityList;
            cboAbilities.DisplayMember = "Name";
            cboAbilities.ValueMember = "Id";

            if (_player.CurrentAbility != null)
            {
                cboAbilities.SelectedItem = _player.CurrentAbility;
            }

            _player.PropertyChanged += PlayerOnPropertyChanged;

            HideEquipDescription();
        }

        private void btnNorth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToNorth);
        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToEast);
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToSouth);
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToWest);
        }

        private void MoveTo(Location newLocation)
        {
            //Checking for required items
            if (!_player.HasRequiredItemToEnterThisLocation(newLocation))
            {
                rtbMessages.Text += "You must have a " + newLocation.ItemRequiredToEnter.Name + " to enter this location." + Environment.NewLine;
                rtbTextChanged();
                return;
            }

            //Updating the player's current location
            _player.CurrentLocation = newLocation;

            //Showing/Hiding the save button
            btnSaveGame.Visible = newLocation.HasSavePoint;

            //Showing/Hiding the trade button
            btnTrade.Visible = (newLocation.VendorWorkingHere != null);

            //Showing/Hiding the Rest button
            btnRest.Visible = (newLocation.InnAvailableHere != null);

            //Showing/Hiding the talk button
            btnTalk.Visible = (newLocation.NPCsLivingHere.Count != 0);

            // Show/hide available movement buttons
            btnNorth.Visible = (newLocation.LocationToNorth != null);
            btnEast.Visible = (newLocation.LocationToEast != null);
            btnSouth.Visible = (newLocation.LocationToSouth != null);
            btnWest.Visible = (newLocation.LocationToWest != null);

            //Displaying advice for player in advice box
            rtbAdvice.Clear();
            rtbAdvice.Text += newLocation.Advice;

            //Displaying current location name and description
            rtbLocation.Text = newLocation.Name + Environment.NewLine;
            rtbLocation.Text += newLocation.Description + Environment.NewLine;

            //Clearing monster statistics box
            rtbMonsterStatistics1.Clear();
            rtbMonsterStatistics2.Clear();

            //Checking the status of quests in the new location
            CheckLocationQuest(newLocation);

            //Checking to see if a battle will commence in the new location
            DetermineMonsterEncounter(newLocation);

            //Hiding Equip box description
            HideEquipDescription();
        }

        private void CheckLocationQuest(Location currentLocation)
        {
            //Checking location for a quest
            if (currentLocation.QuestAvailableHere != null)
            {
                //Seeing if the player already has the quest, and if they've completed it
                bool playerAlreadyHasQuest = _player.HasThisQuest(currentLocation.QuestAvailableHere);
                bool playerAlreadyCompletedQuest = _player.CompletedThisQuest(currentLocation.QuestAvailableHere);

                //Seeing if the player already has the quest
                if (playerAlreadyHasQuest)
                {
                    if (!playerAlreadyCompletedQuest)
                    {
                        //Seeing if the player has all the items needed to complete the quest
                        bool playerHasAllItemsToCompleteQuest = _player.HasAllQuestCompletionItems(currentLocation.QuestAvailableHere);

                        if (playerHasAllItemsToCompleteQuest)
                        {
                            //Displaying quest-completion message
                            rtbMessages.Text += Environment.NewLine;
                            rtbMessages.Text += "You complete the '" + currentLocation.QuestAvailableHere.Name + "' quest." + Environment.NewLine;

                            //Removing quest items from inventory
                            _player.RemoveQuestCompletionItems(currentLocation.QuestAvailableHere);

                            //Giving quest rewards
                            rtbMessages.Text += "You receive: " + Environment.NewLine;
                            rtbMessages.Text += currentLocation.QuestAvailableHere.RewardExperiencePoints.ToString() + " experience points" + Environment.NewLine;
                            rtbMessages.Text += currentLocation.QuestAvailableHere.RewardGold.ToString() + " gold" + Environment.NewLine;
                            rtbMessages.Text += currentLocation.QuestAvailableHere.RewardItem.Name + Environment.NewLine;
                            rtbMessages.Text += Environment.NewLine;
                            rtbTextChanged();

                            _player.ExperiencePoints += currentLocation.QuestAvailableHere.RewardExperiencePoints;
                            CheckForLevelUp(_player.ExperiencePoints, _player.Level);
                            lblExperience.Text = _player.ExperiencePoints.ToString();
                            lblToNextLevel.Text = ExperienceDifferenceCalculator(_player.ExperiencePoints, _player.Level);
                            lblLevel.Text = _player.Level.ToString();
                            _player.Gold += currentLocation.QuestAvailableHere.RewardGold;

                            //Adding the reward item to the player's inventory
                            _player.AddItemToInventory(currentLocation.QuestAvailableHere.RewardItem);

                            //Marking the quest as completed
                            _player.MarkQuestCompleted(currentLocation.QuestAvailableHere);
                        }
                    }
                }

                else
                {
                    //The player does not already have the quest

                    //Displaying the quest-received message
                    rtbMessages.Text += "You receive the " + currentLocation.QuestAvailableHere.Name + " quest." + Environment.NewLine;
                    rtbMessages.Text += currentLocation.QuestAvailableHere.Description + Environment.NewLine;
                    rtbMessages.Text += "To complete it, return with:" + Environment.NewLine;
                    foreach (QuestCompletionItem qci in currentLocation.QuestAvailableHere.QuestCompletionItems)
                    {
                        if (qci.Quantity == 1)
                        {
                            rtbMessages.Text += qci.Quantity.ToString() + " " + qci.Details.Name + Environment.NewLine;
                        }
                        else
                        {
                            rtbMessages.Text += qci.Quantity.ToString() + " " + qci.Details.NamePlural + Environment.NewLine;
                        }
                    }
                    rtbMessages.Text += Environment.NewLine;
                    rtbTextChanged();

                    //Adding the quest to the player's quest list
                    _player.Quests.Add(new PlayerQuest(currentLocation.QuestAvailableHere));
                }
            }
        }

        private void DetermineMonsterEncounter(Location currentLocation)
        {
            //Determining if an encounter will occur
            int encounterChance = RandomNumberGenerator.NumberBetween(0, 100);

            //Checking if the location has a monster
            if ((currentLocation.MonsterLivingHere) != null && (encounterChance <= 100))
            {
                EncounteredMonster(currentLocation);
            }

            else
            {
                _currentMonster = null;

                cboWeapons.Visible = false;
                cboConsumables.Visible = false;
                cboAbilities.Visible = false;
                btnUseWeapon.Visible = false;
                btnUseConsumable.Visible = false;
                btnUseAbility.Visible = false;
            }
            //Refreshing player's ability combobox
            //UpdateAbilitiesListInUI();
        }

        private void EncounteredMonster(Location currentLocation)
        {
            rtbCombatMessages.Text += "You encounter a " + currentLocation.MonsterLivingHere.Name + "!" + Environment.NewLine;
            rtbCombatMessages.Text += "Battle begins!" + Environment.NewLine;
            rtbTextChanged();

            //Making a new monster, using the values from the standard monster in the World.Monster list
            Monster standardMonster = World.MonsterByID(currentLocation.MonsterLivingHere.ID);

            _currentMonster = new Monster(standardMonster.ID, standardMonster.Name, standardMonster.Strength, standardMonster.Defense,
                standardMonster.RewardExperiencePoints, standardMonster.RewardGold, standardMonster.CurrentHitPoints, standardMonster.MaximumHitPoints,
                standardMonster.CurrentAbilityPoints, standardMonster.MaximumAbilityPoints, standardMonster.Intelligence, standardMonster.MagicDefense);
            _currentMonster.Weaknesses = standardMonster.Weaknesses;
            _currentMonster.Resistances = standardMonster.Resistances;

            _currentMonster.Description = GetMonsterDescription();

            //Displaying monster statistics for player to see
            UpdateMonsterStatistics();

            foreach (LootItem lootItem in standardMonster.LootTable)
            {
                _currentMonster.LootTable.Add(lootItem);
            }

            //Showing battle information in UI and hiding movement options
            cboWeapons.Visible = _player.Weapons.Any();
            cboConsumables.Visible = _player.Consumables.Any();
            cboAbilities.Visible = _player.AbilityList.Any();
            btnUseWeapon.Visible = _player.Weapons.Any();
            btnUseConsumable.Visible = _player.Consumables.Any();
            btnUseAbility.Visible = _player.AbilityList.Any();
            //btnNorth.Visible = false;
            //btnEast.Visible = false;
            //btnSouth.Visible = false;
            //btnWest.Visible = false;
        }

        private string GetMonsterDescription()
        {
            if (_currentMonster.Name == "Rat")
            {
                return "Dirty. Stinkin'. Filthy.";
            }
            else if (_currentMonster.Name == "Snake")
            {
                return "Exactly what you would expect to find in infinite numbers on a farm.";
            }
            else if (_currentMonster.Name == "Giant Spider")
            {
                return "There are bigger ones in Australia.";
            }
            else
                return "ERROR! NO DESCRIPTION MADE YET!";
        }

        private void UpdateMonsterStatistics()
        {
            //Clearing the boxes so they always displays fresh information
            rtbMonsterStatistics1.Clear();
            rtbMonsterStatistics2.Clear();

            //Displaying monster statistics in the first box
            rtbMonsterStatistics1.Text += "Name: " + _currentMonster.Name + Environment.NewLine;
            rtbMonsterStatistics1.Text += "HP: " + _currentMonster.CurrentHitPoints + " / " + _currentMonster.MaximumHitPoints + Environment.NewLine;
            rtbMonsterStatistics1.Text += "Strength: " + _currentMonster.Strength + "   Defense: " + _currentMonster.Defense + Environment.NewLine;
            rtbMonsterStatistics1.Text += _currentMonster.Description + Environment.NewLine;

            //Displaying monster weaknesses in the second box
            rtbMonsterStatistics2.Text += "Weaknesses: ";
            if (_currentMonster.Weaknesses.Count == 0)
            {
                rtbMonsterStatistics2.Text += "N/A" + Environment.NewLine;
            }
            else
            {
                for (int counter = 0; counter < _currentMonster.Weaknesses.Count; counter++)
                {
                    if (counter + 1 == _currentMonster.Weaknesses.Count)
                        rtbMonsterStatistics2.Text += _currentMonster.Weaknesses[counter] + Environment.NewLine;
                    else
                        rtbMonsterStatistics2.Text += _currentMonster.Weaknesses[counter] + ", ";
                }
            }

            //Displaying monster resistances in the second box
            rtbMonsterStatistics2.Text += "Resistances: ";
            if (_currentMonster.Resistances.Count == 0)
            {
                rtbMonsterStatistics2.Text += "N/A" + Environment.NewLine;
            }
            else
            {
                for (int counter = 0; counter < _currentMonster.Resistances.Count; counter++)
                {
                    if (counter + 1 == _currentMonster.Resistances.Count)
                        rtbMonsterStatistics2.Text += _currentMonster.Resistances[counter] + Environment.NewLine;
                    else
                        rtbMonsterStatistics2.Text += _currentMonster.Resistances[counter] + ", ";
                }
            }
        }

        private void btnUseWeapon_Click(object sender, EventArgs e)
        {
            //Getting the currently selected weapon from the cboWeapons ComboBox
            Weapon currentWeapon = (Weapon)cboWeapons.SelectedItem;

            //Determining the amount of damage to do to the monster
            PlayerUsedWeapon(_player.CurrentWeapon);

            //Checking to see if the monster has been defeated
            MonsterDefeatCheck(_currentMonster);
        }

        private void PlayerUsedWeapon(Weapon weapon)
        {
            //Weapon damage formula
            int damageToMonster = RandomNumberGenerator.NumberBetween(weapon.WeaponStrength / 2, weapon.WeaponStrength) + _player.Strength
                * WeaknessCheckWeapon(weapon) / ResistanceCheckWeapon(weapon);

            //Applying the damage to the monster's CurrentHitPoints
            _currentMonster.CurrentHitPoints -= damageToMonster;

            //Displaying the result of the player's attack and updating monster statistics
            rtbCombatMessages.Text += "You hit the " + _currentMonster.Name + " for " + damageToMonster.ToString() + " points of damage." + Environment.NewLine;
            rtbTextChanged();
            UpdateMonsterStatistics();
        }

        private int WeaknessCheckWeapon(Weapon weapon)
        {
            int weaknessMultiplier = 0;

            //Checking if the attack hits any enemy weaknesses
            foreach (string weakness in _currentMonster.Weaknesses)
            {
                if (weakness == weapon.AttackType || weakness == weapon.SpecialType)
                {
                    weaknessMultiplier++;
                    rtbCombatMessages.Text += "You hit the " + _currentMonster.Name + "'s weakness!" + Environment.NewLine;
                    rtbTextChanged();
                }
            }
            if (weaknessMultiplier == 0)
                return 1;
            else
                return weaknessMultiplier * 2;
        }

        private int ResistanceCheckWeapon(Weapon weapon)
        {
            int resistanceMultiplier = 0;

            //Checking if the attack hits any enemy resistances
            foreach (string resistance in _currentMonster.Resistances)
            {
                if (resistance == weapon.AttackType || resistance == weapon.SpecialType)
                {
                    resistanceMultiplier++;
                    rtbCombatMessages.Text += "The " + _currentMonster.Name + " resists your attack!" + Environment.NewLine;
                    rtbTextChanged();
                }
            }
            if (resistanceMultiplier == 0)
                return 1;
            else
                return resistanceMultiplier * 2;
        }

        private void btnUseConsumable_Click(object sender, EventArgs e)
        {
            //Getting the currently selected potion from the combobox
            Consumable consumable = (Consumable)cboConsumables.SelectedItem;

            //Determining effect of consumable
            PlayerUsedConsumable(consumable);

            //Checking to see if the monster has been defeated
            MonsterDefeatCheck(_currentMonster);
        }

        private void PlayerUsedConsumable(Consumable consumable)
        {
            if (consumable.IsSupportItem)
            {
                switch (consumable.AffectedStat)
                {
                    case "HP":
                        //Adding healing amount to the player's current hit points
                        _player.CurrentHitPoints += consumable.BasePower;

                        //CurrentHitPoints cannot exceed player's MaximumHitPoints
                        if (_player.CurrentHitPoints > _player.MaximumHitPoints)
                            _player.CurrentHitPoints = _player.MaximumHitPoints;

                        //Displaying healing message
                        rtbCombatMessages.Text += "You drink a " + consumable.Name + Environment.NewLine;
                        break;
                    default: return;
                }
            }

            if (consumable.IsOffensiveItem)
            {
                //Damage Item damage formula
                int damageToMonster = consumable.BasePower;

                //Damaging monster
                _currentMonster.CurrentHitPoints -= damageToMonster;

                rtbCombatMessages.Text += "You use the " + consumable.Name + " on the " + _currentMonster.Name + " for " + damageToMonster + " damage!" + Environment.NewLine;
            }

            //Removing the consumable from the player's inventory
            _player.RemoveItemFromInventory(consumable, 1);
        }

        private void btnUseAbility_Click(object sender, EventArgs e)
        {
            //Getting the currently selected weapon from the cboWeapons ComboBox
            Ability currentAbility = (Ability)cboAbilities.SelectedItem;

            //Determining effects of the ability
            PlayerUsedAbility(currentAbility);

            //Checking to see if the monster has been defeated
            MonsterDefeatCheck(_currentMonster);
        }

        private void PlayerUsedAbility(Ability ability)
        {
            //Checking to see if player has enough AP to use the ability
            if (_player.CurrentAbilityPoints < ability.CostToUse)
            {
                rtbCombatMessages.Text += "You don't have enough AP to use this ability!";
                return;
            }
            else
            {
                //Subtracting ability's AP cost from player's AP pool
                _player.CurrentAbilityPoints -= ability.CostToUse;

                //If ability is supportive, it will affect player stats
                if (ability.IsSupportAbility)
                {
                    switch (ability.AffectedStat)
                    {
                        case "HP":
                            //HP Restoration formula
                            int hpRestored = RandomNumberGenerator.NumberBetween(ability.BasePower - 2, ability.BasePower) + _player.Intelligence;
                            _player.CurrentHitPoints += hpRestored;

                            //Ensuring the player cannot have more HP than allowed
                            if (_player.CurrentHitPoints > _player.MaximumHitPoints)
                                _player.CurrentHitPoints = _player.MaximumHitPoints;

                            //Showing results of ability in UI
                            rtbCombatMessages.Text += "You casted " + ability.Name + " to restore " + hpRestored + " HP!" + Environment.NewLine;
                            break;
                        default: return;
                    }
                }

                //If ability is offensive, it will do damage
                if (ability.IsOffensiveAbility)
                {
                    //Ability Damage Formula
                    int damageToMonster = RandomNumberGenerator.NumberBetween(ability.BasePower - 2, ability.BasePower)
                        * WeaknessCheckAbility(ability) / ResistanceCheckAbility(ability);

                    //Adding partial Strength and Weapon damage to abilities that use weapons
                    if (ability.AttackType == "Current Weapon")
                        damageToMonster += (_player.Strength) + (_player.CurrentWeapon.WeaponStrength / 2);
                    else if (ability.AttackType == "Magic")
                        damageToMonster += _player.Intelligence;

                    //Applying the damage to the monster's CurrentHitPoints
                    _currentMonster.CurrentHitPoints -= damageToMonster;

                    //Displaying the result of the player's attack and updating monster statistics
                    rtbCombatMessages.Text += "You used " + ability.Name + " on the " + _currentMonster.Name + " for " + damageToMonster.ToString() + " points of damage." + Environment.NewLine;
                    rtbTextChanged();
                    UpdateMonsterStatistics();
                }
            }
        }

        private int WeaknessCheckAbility(Ability ability)
        {
            int weaknessMultiplier = 0;

            //Checking if the attack hits any enemy weaknesses
            foreach (string weakness in _currentMonster.Weaknesses)
            {
                if (weakness == ability.ElementalType || weakness == ability.AttackType)
                {
                    weaknessMultiplier++;
                    rtbCombatMessages.Text += "You hit the " + _currentMonster.Name + "'s weakness!" + Environment.NewLine;
                    rtbTextChanged();
                }
            }
            if (weaknessMultiplier == 0)
                return 1;
            else
                return weaknessMultiplier * 2;
        }

        private int ResistanceCheckAbility(Ability ability)
        {
            int resistanceMultiplier = 0;

            //Checking if the attack hits any enemy resistances
            foreach (string resistance in _currentMonster.Resistances)
            {
                if (resistance == ability.ElementalType || resistance == ability.AttackType)
                {
                    resistanceMultiplier++;
                    rtbCombatMessages.Text += "The " + _currentMonster.Name + " resists your attack!" + Environment.NewLine;
                    rtbTextChanged();
                }
            }
            if (resistanceMultiplier == 0)
                return 1;
            else
                return resistanceMultiplier * 2;
        }

        private void MonsterDefeatCheck(Monster currentMonster)
        {
            if (_currentMonster.CurrentHitPoints <= 0)
            {
                MonsterIsDefeated();
            }
            else
            {
                //Monster is still alive
                MonsterAttacksPlayer();
            }
        }

        private void MonsterIsDefeated()
        {
            //Telling player the monster is dead
            rtbCombatMessages.Text += Environment.NewLine;
            rtbCombatMessages.Text += "You defeated the " + _currentMonster.Name + Environment.NewLine;

            //Giving player experience points for killing the monster
            _player.ExperiencePoints += _currentMonster.RewardExperiencePoints;
            rtbCombatMessages.Text += "You receive " + _currentMonster.RewardExperiencePoints.ToString() + " experience points." + Environment.NewLine;

            //Checking player's experience point count to see if they've leveled up.
            CheckForLevelUp(_player.ExperiencePoints, _player.Level);

            //Updating the amount of experience now needed for the next level
            lblToNextLevel.Text = ExperienceDifferenceCalculator(_player.ExperiencePoints, _player.Level);

            //Giving player gold for killing the monster
            if (_currentMonster.RewardGold > 0)
            {
                _player.Gold += _currentMonster.RewardGold;
                rtbCombatMessages.Text += "You receive " + _currentMonster.RewardGold.ToString() + " gold." + Environment.NewLine;
            }

            //Getting random loot items from the monster
            List<InventoryItem> lootedItems = new List<InventoryItem>();

            //Adding items to the lootedItems list, comparing a random number to the drop percentage
            foreach (LootItem lootItem in _currentMonster.LootTable)
            {
                if (RandomNumberGenerator.NumberBetween(1, 100) <= lootItem.DropPercentage)
                {
                    lootedItems.Add(new InventoryItem(lootItem.Details, 1));
                }
            }

            //If no items were randomly selected, then add the default loot item(s).
            if (lootedItems.Count == 0)
            {
                foreach (LootItem lootItem in _currentMonster.LootTable)
                {
                    if (lootItem.IsDefaultItem)
                    {
                        lootedItems.Add(new InventoryItem(lootItem.Details, 1));
                    }
                }
            }

            //Adding the looted items to the player's inventory
            foreach (InventoryItem inventoryItem in lootedItems)
            {
                _player.AddItemToInventory(inventoryItem.Details);

                if (inventoryItem.Quantity == 1)
                {
                    rtbCombatMessages.Text += "You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.Name + Environment.NewLine;
                    rtbTextChanged();
                }
                else
                {
                    rtbCombatMessages.Text += "You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.NamePlural + Environment.NewLine;
                    rtbTextChanged();
                }
            }

            //Adding separation after looting phase to keep the player clear on combat events
            rtbCombatMessages.Text += "====================================" + Environment.NewLine;

            //Refreshing player information and inventory controls
            lblGold.Text = _player.Gold.ToString();
            lblExperience.Text = _player.ExperiencePoints.ToString();
            lblLevel.Text = _player.Level.ToString();

            //UpdateAbilitiesListInUI();

            //Move player to current location (to create a new monster to fight)
            MoveTo(_player.CurrentLocation);
        }

        //This function checks to see if the player has leveled-up and will adjust the player's stats accordingly
        private void CheckForLevelUp(int experiencePoints, int level)
        {
            if (experiencePoints < 30)
                return;
            else if (experiencePoints >= 30 && experiencePoints < 100)
            {
                if (level != 2)
                {
                    _player.Level = 2; _player.MaximumHitPoints += 4; _player.Strength += 2; _player.Defense += 2;
                    _player.MaximumAbilityPoints += 10;

                    Ability flameStrike = new Ability(1, "Flame Strike", "Your regular attack imbued with fiery passion.", true, false, "Current Weapon", "Fire", 5, 3);
                    _player.AddAbilityToList(flameStrike);
                    Ability waterStrike = new Ability(2, "Water Strike", "I don't know the science behind this. Maybe you're sweating a lot.", true, false, "Current Weapon", "Water", 5, 3);
                    _player.AddAbilityToList(waterStrike);

                    _player.CurrentHitPoints = _player.MaximumHitPoints; _player.CurrentAbilityPoints = _player.MaximumAbilityPoints;

                    rtbMessages.Text += "You have leveled up to level 2!  You have been restored to full health!" + Environment.NewLine;
                    rtbMessages.Text += "Max HP increased by 4. Strength increased by 2. Defense increased by 2." + Environment.NewLine;
                    rtbMessages.Text += "Max AP increased by 10." + Environment.NewLine;
                    rtbMessages.Text += "You have learned the abilities Flame Strike and Water Strike!" + Environment.NewLine;
                    rtbTextChanged();
                }
                else
                    return;
            }
            else if (experiencePoints >= 100 && experiencePoints < 220)
            {
                if (level != 3)
                {
                    _player.Level = 3; _player.MaximumHitPoints += 5; _player.Strength += 2; _player.Defense += 2;
                    _player.Intelligence += 1; _player.MagicDefense += 1; _player.MaximumAbilityPoints += 2;

                    Ability minorHeal = new Ability(3, "Minor Heal", "Restorative magic for the budding injured mage.", false, true, "N/A", "Light", 5, 2, "HP");
                    _player.AddAbilityToList(minorHeal);
                    Ability beginnerBolt = new Ability(4, "Beginner Bolt", "A small zap is sometimes all you need.", true, false, "Magic", "Electric", 5, 3);
                    _player.AddAbilityToList(beginnerBolt);

                    _player.CurrentHitPoints = _player.MaximumHitPoints; _player.CurrentAbilityPoints = _player.MaximumAbilityPoints;

                    rtbMessages.Text += "You have leveled up to level 3!  You have been restored to full health!" + Environment.NewLine;
                    rtbMessages.Text += "Max HP increased by 5. Strength increased by 2. Defense increased by 2." + Environment.NewLine;
                    rtbMessages.Text += "Max AP increased by 2. Intelligence increased by 1. M. Defense increased by 1." + Environment.NewLine;
                    rtbMessages.Text += "You have learned the abilities Minor Heal and Beginner Bolt!" + Environment.NewLine;
                }
                else
                    return;
            }
            else if (experiencePoints >= 220 && experiencePoints < 450)
            {
                if (level != 4)
                {
                    _player.Level = 4; _player.MaximumHitPoints += 5; _player.Strength += 3; _player.Defense += 2;
                    _player.Intelligence += 1; _player.MagicDefense += 1; _player.MaximumAbilityPoints += 1;

                    _player.CurrentHitPoints = _player.MaximumHitPoints; _player.CurrentAbilityPoints = _player.MaximumAbilityPoints;

                    rtbMessages.Text += "You have leveled up to level 4!  You have been restored to full health!" + Environment.NewLine;
                    rtbMessages.Text += "Max HP increased by 5. Strength increased by 3. Defense increased by 2." + Environment.NewLine;
                    rtbMessages.Text += "Max AP increased by 1. Intelligence increased by 1. M. Defense increased by 1." + Environment.NewLine;
                }
                else
                    return;
            }
            else if (experiencePoints >= 450)
            {
                if (level != 5)
                {
                    _player.Level = 5; _player.MaximumHitPoints += 4; _player.Strength += 2; _player.Defense += 4;
                    _player.Intelligence += 2; _player.MagicDefense += 2; _player.MaximumAbilityPoints += 2;

                    _player.CurrentHitPoints = _player.MaximumHitPoints; _player.CurrentAbilityPoints = _player.MaximumAbilityPoints;

                    rtbMessages.Text += "You have leveled up to level 5!  You have been restored to full health!  You are at the maximum level!" + Environment.NewLine;
                    rtbMessages.Text += "Max HP increased by 5. Strength increased by 2. Defense increased by 4." + Environment.NewLine;
                    rtbMessages.Text += "Max AP increased by 2. Intelligence increased by 2. M. Defense increased by 2." + Environment.NewLine;
                }
                else
                    return;
            }
            else
                return;
        }

        //This function checks the player's experience value and level and is used to update the UI
        private string ExperienceDifferenceCalculator(int experiencePoints, int level)
        {
            if (level == 1)
            {
                int experienceDifference = 30 - experiencePoints;
                return experienceDifference.ToString();
            }
            else if (level == 2)
            {
                int experienceDifference = 100 - experiencePoints;
                return experienceDifference.ToString();
            }
            else if (level == 3)
            {
                int experienceDifference = 220 - experiencePoints;
                return experienceDifference.ToString();
            }
            else if (level == 4)
            {
                int experienceDifference = 450 - experiencePoints;
                return experienceDifference.ToString();
            }
            else
                return "Max Level!";
        }

        private void GameOverPlayerReset()
        {
            //Returning player to starting location and setting HP to 1
            MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
            _player.CurrentHitPoints = 1;
        }

        private void rtbTextChanged()
        {
            //Scrolling to bottom for Combat Messages box
            rtbCombatMessages.SelectionStart = rtbCombatMessages.Text.Length;
            rtbCombatMessages.ScrollToCaret();

            //Scrolling to bottom for Messages box
            rtbMessages.SelectionStart = rtbMessages.Text.Length;
            rtbMessages.ScrollToCaret();
        }

        private void MonsterAttacksPlayer()
        {
            //Damage calculation
            int damageToPlayer = RandomNumberGenerator.NumberBetween(_currentMonster.Strength / 2, _currentMonster.Strength) - _player.Defense;

            //Ensuring monster does at least one point of damage to the player
            if (damageToPlayer <= 0)
                damageToPlayer = 1;

            //Displaying message
            rtbCombatMessages.Text += "The " + _currentMonster.Name + " did " + damageToPlayer.ToString() + " points of damage." + Environment.NewLine;
            rtbTextChanged();

            //Subtracting damage from player
            _player.CurrentHitPoints -= damageToPlayer;

            if (_player.CurrentHitPoints <= 0)
            {
                //Displaying message
                rtbCombatMessages.Text += "The " + _currentMonster.Name + " defeated you. Returning home..." + Environment.NewLine;
                rtbTextChanged();

                //Resetting Game
                GameOverPlayerReset();
            }
        }

        private void SuperAdventure_Load(object sender, EventArgs e)
        {

        }

        private void cboAbilities_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Updating selected ability and changing UI to compensate
            _player.CurrentAbility = (Ability)cboAbilities.SelectedItem;
            ChangeAbilityAttackTypeCheck(_player.CurrentAbility);
            ShowAbilityDescription();
        }

        private void ShowAbilityDescription()
        {
            rtbEquipDescription.Clear();

            Ability currentAbility = (Ability)cboAbilities.SelectedItem;

            rtbEquipDescription.Visible = true;

            //Displaying information about the selected ability
            rtbEquipDescription.Text += currentAbility.Description + Environment.NewLine;
            rtbEquipDescription.Text += "Power: " + currentAbility.BasePower + "   Cost: " + currentAbility.CostToUse + Environment.NewLine;
            if (currentAbility.ElementalType != "N/A")
                rtbEquipDescription.Text += "Elemental Type: " + currentAbility.ElementalType + Environment.NewLine;
            if (currentAbility.AttackType != "N/A")
                rtbEquipDescription.Text += "Attack Type: " + currentAbility.AttackType + Environment.NewLine;
            if (currentAbility.AffectedStat != "N/A")
                rtbEquipDescription.Text += "Affects: " + currentAbility.AffectedStat + Environment.NewLine;
        }

        private void HideEquipDescription()
        {
            rtbEquipDescription.Clear();
            rtbEquipDescription.Visible = false;
        }

        private void cboWeapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Updating selected weapon and changing UI to compensate
            _player.CurrentWeapon = (Weapon)cboWeapons.SelectedItem;
            ChangeAbilityAttackTypeCheck(_player.CurrentAbility);
            ShowWeaponDescription();
        }

        private void ShowWeaponDescription()
        {
            rtbEquipDescription.Clear();

            Weapon currentWeapon = (Weapon)cboWeapons.SelectedItem;

            rtbEquipDescription.Visible = true;

            //Displaying information about the selected weapon
            rtbEquipDescription.Text += currentWeapon.Description + Environment.NewLine;
            rtbEquipDescription.Text += "Power: " + currentWeapon.WeaponStrength + Environment.NewLine;
            rtbEquipDescription.Text += "Attack Type: " + currentWeapon.AttackType + Environment.NewLine;
            if (currentWeapon.SpecialType != "N/A")
            {
                rtbEquipDescription.Text += currentWeapon.SpecialType + Environment.NewLine;
            }
        }

        private void cboConsumables_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Updating selected consumable and changing UI to compensate
            _player.CurrentItem = (Item)cboConsumables.SelectedItem;
            ShowConsumableDescription();
        }

        private void ShowConsumableDescription()
        {
            rtbEquipDescription.Clear();

            Consumable currentConsumable = (Consumable)cboConsumables.SelectedItem;

            rtbEquipDescription.Visible = true;

            //Displaying information about selected consumable
            rtbEquipDescription.Text += currentConsumable.Description + Environment.NewLine;
            if (currentConsumable.DamageType != "N/A")
                rtbEquipDescription.Text += "Damage Type: " + currentConsumable.DamageType + Environment.NewLine;
        }

        //This function keeps the UI updated in regards to the presence of the weapon and consumable buttons and comboboxes
        private void PlayerOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "Weapons")
            {
                cboWeapons.DataSource = _player.Weapons;

                if (!_player.Weapons.Any())
                {
                    cboWeapons.Visible = false;
                    btnUseWeapon.Visible = false;
                }
            }

            if (propertyChangedEventArgs.PropertyName == "Consumables")
            {
                cboConsumables.DataSource = _player.Consumables;

                if (!_player.Consumables.Any())
                {
                    cboConsumables.Visible = false;
                    btnUseConsumable.Visible = false;
                }
            }
        }

        //This function opens up the screen that lets the player save their game
        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            SaveScreen saveScreen = new SaveScreen(_player);
            saveScreen.StartPosition = FormStartPosition.CenterParent;
            saveScreen.ShowDialog(this);
        }

        //This function opens up the screen that lets players trade with vendors
        private void btnTrade_Click(object sender, EventArgs e)
        {
            TradingScreen tradingScreen = new TradingScreen(_player);
            tradingScreen.StartPosition = FormStartPosition.CenterParent;
            tradingScreen.ShowDialog(this);
        }

        //This function opens up the screen that lets players rest at inns
        private void btnRest_Click(object sender, EventArgs e)
        {
            InnScreen innScreen = new InnScreen(_player);
            innScreen.StartPosition = FormStartPosition.CenterParent;
            innScreen.ShowDialog(this);
        }

        /*The following functions display information about an area when the corresponding buttons are moused-over*/
        private void btnNorth_MouseEnter(object sender, System.EventArgs e)
        {
            rtbMouseOverDescription.Clear();
            rtbMouseOverDescription.Text += _player.CurrentLocation.LocationToNorth.Name + Environment.NewLine;
            rtbMouseOverDescription.Text += "===================" + Environment.NewLine;
            rtbMouseOverDescription.Text += _player.CurrentLocation.LocationToNorthDescription;
        }

        private void btnNorth_MouseLeave(object sender, System.EventArgs e)
        {
            rtbMouseOverDescription.Clear();
        }

        private void btnEast_MouseEnter(object sender, System.EventArgs e)
        {
            rtbMouseOverDescription.Clear();
            rtbMouseOverDescription.Text += _player.CurrentLocation.LocationToEast.Name + Environment.NewLine;
            rtbMouseOverDescription.Text += "===================" + Environment.NewLine;
            rtbMouseOverDescription.Text += _player.CurrentLocation.LocationToEastDescription;
        }

        private void btnEast_MouseLeave(object sender, System.EventArgs e)
        {
            rtbMouseOverDescription.Clear();
        }

        private void btnSouth_MouseEnter(object sender, System.EventArgs e)
        {
            rtbMouseOverDescription.Clear();
            rtbMouseOverDescription.Text += _player.CurrentLocation.LocationToSouth.Name + Environment.NewLine;
            rtbMouseOverDescription.Text += "===================" + Environment.NewLine;
            rtbMouseOverDescription.Text += _player.CurrentLocation.LocationToSouthDescription;
        }

        private void btnSouth_MouseLeave(object sender, System.EventArgs e)
        {
            rtbMouseOverDescription.Clear();
        }

        private void btnWest_MouseEnter(object sender, System.EventArgs e)
        {
            rtbMouseOverDescription.Clear();
            rtbMouseOverDescription.Text += _player.CurrentLocation.LocationToWest.Name + Environment.NewLine;
            rtbMouseOverDescription.Text += "===================" + Environment.NewLine;
            rtbMouseOverDescription.Text += _player.CurrentLocation.LocationToWestDescription;
        }

        private void btnWest_MouseLeave(object sender, System.EventArgs e)
        {
            rtbMouseOverDescription.Clear();
        }

        private void ChangeAbilityAttackTypeCheck(Ability ability)
        {
            if (ability != null)
            {
                //Changing ability's attacktype if it uses it
                if (ability.AttackType == "Current Weapon" || ability.AttackType == "Slash" || ability.AttackType == "Blunt" || ability.AttackType == "Stab")
                    ability.AttackType = _player.CurrentWeapon.AttackType;
            }
            else
            {
                return;
            } 
        }

        //This function opens up the screen that letsplayers see their stats in more detail
        private void btnStatDetails_Click(object sender, EventArgs e)
        {
            PlayerStatistics playerStats = new PlayerStatistics(_player, ExperienceDifferenceCalculator(_player.ExperiencePoints, _player.Level));
            playerStats.StartPosition = FormStartPosition.CenterParent;
            playerStats.ShowDialog(this);
        }

        //This function lets players talk to NPCs
        private void btnTalk_Click(object sender, EventArgs e)
        {
            NPCScreen npcScreen = new NPCScreen(_player);
            npcScreen.StartPosition = FormStartPosition.CenterParent;
            npcScreen.ShowDialog(this);
        }

        //This function will open a screen to let players combine items when that feature is complete
        private void btnCombine_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This button does not work yet.");
        }
    }
}