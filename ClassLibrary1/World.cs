using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class World
    {
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Monster> Monsters = new List<Monster>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Location> Locations = new List<Location>();
        public static readonly List<Ability> Abilities = new List<Ability>();
        public static readonly List<NPC> NPCs = new List<NPC>();

        public const int ITEM_ID_RUSTY_SWORD = 1;
        public const int ITEM_ID_RAT_TAIL = 2;
        public const int ITEM_ID_PIECE_OF_FUR = 3;
        public const int ITEM_ID_SNAKE_FANG = 4;
        public const int ITEM_ID_SNAKESKIN = 5;
        public const int ITEM_ID_CLUB = 6;
        public const int ITEM_ID_HEALING_POTION = 7;
        public const int ITEM_ID_SPIDER_FANG = 8;
        public const int ITEM_ID_SPIDER_SILK = 9;
        public const int ITEM_ID_ADVENTURER_PASS = 10;
        public const int ITEM_ID_LONGSWORD = 11;
        public const int ITEM_ID_GREEN_PLANT = 12;
        public const int ITEM_ID_RED_PLANT = 13;
        public const int ITEM_ID_YELLOW_PLANT = 14;
        public const int ITEM_ID_WIND_IN_A_BOTTLE = 15;
        public const int ITEM_ID_ICE_CUBE = 16;
        public const int ITEM_ID_ARCTIC_BREEZE = 17;
        public const int ITEM_ID_ROMAN_CANDLE = 18;

        public const int UNSELLABLE_ITEM_PRICE = -1;

        public const int MONSTER_ID_RAT = 1;
        public const int MONSTER_ID_SNAKE = 2;
        public const int MONSTER_ID_GIANT_SPIDER = 3;

        public const int QUEST_ID_CLEAR_ALCHEMIST_GARDEN = 1;
        public const int QUEST_ID_CLEAR_FARMERS_FIELD = 2;

        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_AEGEN_SOUTH_END = 2;
        public const int LOCATION_ID_TOWN_SQUARE = 3;
        public const int LOCATION_ID_AEGEN_MARKETPLACE = 4;
        public const int LOCATION_ID_AEGEN_WEST_END = 5;
        public const int LOCATION_ID_GUARD_POST = 6;
        public const int LOCATION_ID_ALCHEMIST_HUT = 7;
        public const int LOCATION_ID_ALCHEMISTS_GARDEN = 8;
        public const int LOCATION_ID_FARMHOUSE = 9;
        public const int LOCATION_ID_FARM_FIELD = 10;
        public const int LOCATION_ID_BRIDGE = 11;
        public const int LOCATION_ID_SPIDER_FIELD = 12;

        public const int ABILITY_ID_PHYSICAL_ATTACK = 1;
        public const int ABILITY_ID_VENOM_FANG = 2;
        public const int ABILITY_ID_EIGHT_LEGGED_SWEEP = 3;

        public const int NPC_ID_HORATIO = 1;
        public const int NPC_ID_JENNILY = 2;

        static World()
        {
            PopulateItems();
            PopulateEnemyAbilities();
            PopulateMonsters();
            PopulateQuests();
            PopulateNPCs();
            PopulateLocations();
        }

        private static void PopulateItems()
        {
            Items.Add(new Weapon(ITEM_ID_RUSTY_SWORD, "Rusty Sword", "Rusty Swords", "A source of tetanus.  You really shouldn't carry this around.", UNSELLABLE_ITEM_PRICE, 2, "Slash", "N/A", true));
            Items.Add(new Item(ITEM_ID_RAT_TAIL, "Rat Tail", "Rat Tails", "In high demand due to an uptick in upstart alchemists.", 5));
            Items.Add(new Item(ITEM_ID_PIECE_OF_FUR, "Piece of Fur", "Pieces of Fur", "Used to make blankets for homeless people.", 2));
            Items.Add(new Item(ITEM_ID_SNAKE_FANG, "Snake Fang", "Snake Fangs", "If you touch this at the tip, you are dumb.", 6));
            Items.Add(new Item(ITEM_ID_SNAKESKIN, "Snakeskin", "Snakeskins", "Might make halfway-decent Ranger gear in a different game.", 8));
            Items.Add(new Weapon(ITEM_ID_CLUB, "Club", "Clubs", "Was used as a mating tool instead of a weapon in simpler times.", UNSELLABLE_ITEM_PRICE, 5, "Blunt", "N/A", true));
            Items.Add(new Consumable(ITEM_ID_HEALING_POTION, "Healing Potion", "Healing Potions", "Use this to not die sometimes.\nRestores 15 HP.", 5, 15, false, true, "HP"));
            Items.Add(new Item(ITEM_ID_SPIDER_FANG, "Spider Fang", "Spider Fangs", "Don't wonder why you don't get two of these for each spider you kill.", 20));
            Items.Add(new Item(ITEM_ID_SPIDER_SILK, "Spider Silk", "Spider Silks", "You might upset certain individuals if you say this is stronger than steel.", 50));
            Items.Add(new Item(ITEM_ID_ADVENTURER_PASS, "Adventurer Pass", "Adventurer Passes", "Used to access the guard tower to the east of town.", UNSELLABLE_ITEM_PRICE));
            Items.Add(new Weapon(ITEM_ID_LONGSWORD, "Longsword", "Longswords", "Longer than a shortsword.", 120, 6, "Slash", "N/A", true));
            Items.Add(new Item(ITEM_ID_GREEN_PLANT, "Green Plant", "Green Plants", "A simple plant that can make simple salves", 5));
            Items.Add(new Item(ITEM_ID_WIND_IN_A_BOTTLE, "Wind in a Bottle", "Wind in Some Bottles", "Easier to make than you think", 15));
            Items.Add(new Item(ITEM_ID_ICE_CUBE, "Ice Cube", "Ice Cubes", "Has given grammy-nominated performances in police dramas", 15));
            Items.Add(new Consumable(ITEM_ID_ROMAN_CANDLE, "Roman Candle", "Roman Candles", "With Augustus's blessing.", 50, 20, true, false, "N/A","Explosive"));
        }

        private static void PopulateEnemyAbilities()
        {
            Ability physicalAttack = new Ability(ABILITY_ID_PHYSICAL_ATTACK, "N/A", "N/A", true, false, "Physical", "None", 0, 1);            
            Ability venomFang = new Ability(ABILITY_ID_VENOM_FANG, "Venom Fang", "N/A", true, false, "Pierce", "None", 3, 1);
            Ability eightLeggedSweep = new Ability(ABILITY_ID_EIGHT_LEGGED_SWEEP, "Eight-Legged Sweep", "N/A", true, false, "Blunt", "None", 10, 1);

            Abilities.Add(physicalAttack);
            Abilities.Add(venomFang);
            Abilities.Add(eightLeggedSweep);
        }

        private static void PopulateMonsters()
        {
            Monster rat = new Monster(MONSTER_ID_RAT, "Rat", 2, 1, 3, 0, 5, 5, 1, 1, 0, 0);
            rat.LootTable.Add(new LootItem(ItemByID(ITEM_ID_RAT_TAIL), 75, false));
            rat.LootTable.Add(new LootItem(ItemByID(ITEM_ID_PIECE_OF_FUR), 75, true));
            rat.Weaknesses.Add("Fire");


            Monster snake = new Monster(MONSTER_ID_SNAKE, "Snake", 8, 7, 7, 0, 13, 13, 1, 1, 0, 0);
            snake.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SNAKE_FANG), 75, false));
            snake.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SNAKESKIN), 75, true));
            snake.Resistances.Add("Slash");

            Monster giantSpider = new Monster(MONSTER_ID_GIANT_SPIDER, "Giant Spider", 20, 20, 100, 40, 32, 32, 1, 1, 0, 0);
            giantSpider.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SPIDER_FANG), 75, true));
            giantSpider.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SPIDER_SILK), 25, false));
            giantSpider.Weaknesses.Add("Fire");

            Monsters.Add(rat);
            Monsters.Add(snake);
            Monsters.Add(giantSpider);
        }

        private static void PopulateQuests()
        {
            Quest clearAlchemistGarden =
                new Quest(
                    QUEST_ID_CLEAR_ALCHEMIST_GARDEN,
                    "Clear the alchemist's garden",
                    "Kill rats in the alchemist's garden and bring back 3 rat tails. You will receive a club and 10 gold pieces.", 20, 10);

            clearAlchemistGarden.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_RAT_TAIL), 3));

            clearAlchemistGarden.RewardItem = ItemByID(ITEM_ID_CLUB);

            Quest clearFarmersField =
                new Quest(
                    QUEST_ID_CLEAR_FARMERS_FIELD,
                    "Clear the farmer's field",
                    "Kill snakes in the farmer's field and bring back 3 snake fangs. You will receive an adventurer's pass, a longsword, and 20 gold pieces.", 20, 20);

            clearFarmersField.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_SNAKE_FANG), 3));

            clearFarmersField.RewardItem = ItemByID(ITEM_ID_ADVENTURER_PASS);

            Quests.Add(clearAlchemistGarden);
            Quests.Add(clearFarmersField);
        }

        private static void PopulateNPCs()
        {
            NPC horatio = new NPC(NPC_ID_HORATIO, "Horatio", "Hi! I'm an NPC! I'm working as intended!");
            //NPC jennily = new NPC(NPC_ID_JENNILY, "Jennily", "Hi! I'm also an NPC! I'm also working as intended!");

            NPCs.Add(horatio);
            //NPCs.Add(jennily);
        }

        private static void PopulateLocations()
        {
            //Creating each location

            //Creating Home location
            Location home = new Location(LOCATION_ID_HOME, "Home", "Your house on the outskirts of Aegen. You really need to clean up the place.",
                "Press the 'North' button to head north and go have an adventure instead of cleaning your room.");

            home.LocationToNorthDescription = "Up ahead is the small town of Aegen.  It's certainly more exciting than being here.";

            //Creating Aegen South Entrance
            Location aegenSouthEnd = new Location(LOCATION_ID_AEGEN_SOUTH_END, "Aegen South Entrance",
                "Friendly wildlife darting between green shrubs and oak trees greet you as you press on to your destination by following the"+
                " dirt road.  Isn't life grand?",
                "Hover over a directional button to get an idea of where you'll be going next.");

            aegenSouthEnd.LocationToNorthDescription = "The center of town lies ahead.  You see people you recognize going about their day.";
            aegenSouthEnd.LocationToSouthDescription = "That's where home is.  You don't want to go back there.  It's a mess.";

            //Creating Aegen Town Square location
            Location aegenTownSquare = new Location(LOCATION_ID_TOWN_SQUARE, "Town Square",
                "You see a fountain, a man of regal poise wearing very smelly, very brown clothing, and a glowing blue circle.  That's about it."+
                "  There's not much hustle and bustle that can go on with a population of, like, seven.",
                "You may find it pertinent to save your game when it's available.  Only certain areas can allow for it.");

            aegenTownSquare.LocationToNorthDescription = "On the northern edge of town lives an alchemist known for being very average at his job.";
            aegenTownSquare.LocationToEastDescription = "A place with many stores.  Stores are helpful.";
            aegenTownSquare.LocationToSouthDescription = "The southern part of town.  It leads to the house of a total slob.";
            aegenTownSquare.LocationToWestDescription = "The small housing district of small Aegen.";

            aegenTownSquare.NPCsLivingHere.Add(NPCByID(NPC_ID_HORATIO));

            aegenTownSquare.HasSavePoint = true;

            Vendor robTheRatFan = new Vendor("Rob the Rat Fan's Traveling Symposium",
                "Hi there!  I'm Rob.  I travel from town to town spreading the good word of the many benefits of rats.  I've heard rumors"+
                " of a place nearby that seems to have run into a bit of rat trouble -- like, there are hordes"+
                " of the cute critters.  You must be a huge rat fan as well.  I can smell it on you.  If you have rat stuff,"+
                " then I'll buy it off of you; I'm talking fur, tails, or whatever else you can get from the rats rumored to be around here."+
                "  The furs make for fantastic shirts that I've been known to sell to fellow fans, and the usefulness of the tails needs no"+
                " explanation.  I'll be around if you find what I'm looking for.  I'll just be preparing my presentation on why you should"+
                " use every part of the rat.");
            robTheRatFan.ItemsVendorWillBuy.Add(ItemByID(ITEM_ID_PIECE_OF_FUR));
            robTheRatFan.ItemsVendorWillBuy.Add(ItemByID(ITEM_ID_RAT_TAIL));
            aegenTownSquare.VendorWorkingHere = robTheRatFan;

            //Creating Aegen Marketplace location
            Location aegenMarketplace = new Location(LOCATION_ID_AEGEN_MARKETPLACE, "Aegen Marketplace",
                "There are a few stalls occupied by merchants peddling everything from scams to the necessities of life, but only one of them" +
                " sells anything relevant.  The local Generic Inn is always open and pushed the old inn out of business.",
                "If you ever find yourself running low on HP or otherwise just about to die, a good night's rest at an inn can cure absolutely"+
                " anything that ails you.");

            aegenMarketplace.LocationToEastDescription = "The areas east of Aegen are dangerous, leading to the need of constant vigilance.";
            aegenMarketplace.LocationToWestDescription = "You feel like you were just here.";

            Vendor reliableSudsy = new Vendor("Reliable Sudsy's Healing Curatives",
                "Well howdy!  Welcome to my store.  I have the best durn salves in all of Aegen!");
            reliableSudsy.AddItemToInventory(ItemByID(ITEM_ID_LONGSWORD));
            reliableSudsy.AddItemToInventory(ItemByID(ITEM_ID_HEALING_POTION));
            aegenMarketplace.VendorWorkingHere = reliableSudsy;

            Inn genericInn = new Inn("Generic Inn",
                "As you enter the establishment, you smell nothing.  There are no windows.  The chairs and table in the back-left corner look, even through the dim light, to be constructed of the blandest wooden material imaginable and made with just enough craftsmanship to meet safety standards.  The rug before the counter looks familiar.  You're pretty sure you have that same rug.  The young man working at the front desk wears a forced smile that reveals just how much he hates his job.",
                "\"Hello!  Welcome to Generic Inn!  You'll find our accomodations both suitable and tailored to just about anyone's budget!  I think we've met before.  Have we met?  What's it like in the outside world?  Will you be staying with us today or tonight?  I don't know what time it is.\"",
                "\"Thank you!  For every sale I make, I get to sleep for five minutes!  But my break isn't for another ten hours, so I'll just watch you sleep and get some rest by proxy.\"",
                "\"Umm... of all the things I'm allowed to remember, how to count is one of them.  You don't have enough gold.\"",
                5);
            aegenMarketplace.InnAvailableHere = genericInn;

            //Creating Aegen West End location
            Location aegenWestEnd = new Location(LOCATION_ID_AEGEN_WEST_END, "Aegen West Entrance",
                "The section of Aegen designated to housing.  You can smell the faint scent of fertilizer as you near the gate.",
                "The townspeople often talk about how the snakes to the west are more dangerous than the rats to the north." +
                "  It's always a slow day.");

            aegenWestEnd.LocationToEastDescription = "You sometimes wonder if anyone would notice if you tried to dig the coins out of"+
                " the fountain.";
            aegenWestEnd.LocationToWestDescription = "Food is good, and somebody has to grow it.";

            //Creating Alchemist Hut location
            Location alchemistHut = new Location(LOCATION_ID_ALCHEMIST_HUT, "Alchemist's Hut", "There are many strange plants on the shelves.",
                "Alchemist: \"You better close the door on your way out if you go back there.  It's both polite and death-preventing.\"");
            alchemistHut.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_ALCHEMIST_GARDEN);

            alchemistHut.LocationToNorthDescription = "The sound of squeaking and skittering threatens to tear down the back door.";
            alchemistHut.LocationToSouthDescription = "You imagine it will smell less like ground flower petals and burnt animal blood.";

            //Creating Alchemist's Garden location
            Location alchemistsGarden = new Location(LOCATION_ID_ALCHEMISTS_GARDEN, "Alchemist's Garden",
                "Countless dirty rats swarm from further in the hedge maze as they try to claw through the hut door.  Most of them don't"+
                " seem to mind your presence.  Most of them.",
                "Select your weapon or item and use it to help you defeat the vile vermin menace!");
            alchemistsGarden.MonsterLivingHere = MonsterByID(MONSTER_ID_RAT);

            alchemistsGarden.LocationToSouthDescription = "It will be tricky to get back in without letting a stampede in as well, but you can do it!";

            //Creating Farmhouse location
            Location farmhouse = new Location(LOCATION_ID_FARMHOUSE, "Farmhouse", "There is a small farmhouse, with a farmer in front.",
                "Farmer: \"Them durn snakes done lerned howta catch swords with thur tails.\"");
            farmhouse.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_FARMERS_FIELD);

            farmhouse.LocationToEastDescription = "Most of the people living here also work on the fields.";
            farmhouse.LocationToWestDescription = "The ceaseless rattling and hissing beyond the barn sounds oddly... clever.";

            //Creating Farmer's Field location
            Location farmersField = new Location(LOCATION_ID_FARM_FIELD, "Farmer's Field", "You see rows of vegetables growing here.",
                "Different enemies have different weaknesses and resistances, and you should adjust your approach accordingly.");
            farmersField.MonsterLivingHere = MonsterByID(MONSTER_ID_SNAKE);

            farmersField.LocationToEastDescription = "You see the farmer angrily flip-off the snakes that aren't paying attention to him.";

            //Creating Guard Post location
            Location guardPost = new Location(LOCATION_ID_GUARD_POST, "Guard post", "There is a large, tough-looking guard here.",
                "Guard: \"That farmer used to be an adventurer before he, well, uh... became a... farmer.  Proceed.\"",
                ItemByID(ITEM_ID_ADVENTURER_PASS));

            guardPost.LocationToEastDescription = "It seems serene enough.";
            guardPost.LocationToWestDescription = "The miniature bazaar awaits you.";

            //Creating Bridge location
            Location bridge = new Location(LOCATION_ID_BRIDGE, "Bridge", "A stone bridge crosses a wide river.",
                "If you ever find yourself stuck, you can always go kill more monsters and instantly get stronger at certain intervals instead of slowly improving like a normal human being, you weirdo.");

            bridge.LocationToEastDescription = "There are trees and giant spiders over there.";
            bridge.LocationToWestDescription = "The guard looks at you from a distance.  Or maybe he's looking at the forest.";

            //Creating Spider Field location
            Location spiderField = new Location(LOCATION_ID_SPIDER_FIELD, "Forest", "You see spider webs covering covering the trees in this forest.",
                "If you kill all the spiders, you will have no excuse to not go back home and clean your room...");
            spiderField.MonsterLivingHere = MonsterByID(MONSTER_ID_GIANT_SPIDER);

            spiderField.LocationToWestDescription = "As you walk closer to the bridge, it seems to get bigger.  How odd!";

            // Link the locations together
            home.LocationToNorth = aegenSouthEnd;

            aegenSouthEnd.LocationToNorth = aegenTownSquare;
            aegenSouthEnd.LocationToSouth = home;

            aegenTownSquare.LocationToNorth = alchemistHut;
            aegenTownSquare.LocationToSouth = aegenSouthEnd;
            aegenTownSquare.LocationToEast = aegenMarketplace;
            aegenTownSquare.LocationToWest = aegenWestEnd;

            aegenMarketplace.LocationToEast = guardPost;
            aegenMarketplace.LocationToWest = aegenTownSquare;

            aegenWestEnd.LocationToEast = aegenTownSquare;
            aegenWestEnd.LocationToWest = farmhouse;

            farmhouse.LocationToEast = aegenWestEnd;
            farmhouse.LocationToWest = farmersField;

            farmersField.LocationToEast = farmhouse;

            alchemistHut.LocationToSouth = aegenTownSquare;
            alchemistHut.LocationToNorth = alchemistsGarden;

            alchemistsGarden.LocationToSouth = alchemistHut;

            guardPost.LocationToEast = bridge;
            guardPost.LocationToWest = aegenMarketplace;

            bridge.LocationToWest = guardPost;
            bridge.LocationToEast = spiderField;

            spiderField.LocationToWest = bridge;

            // Add the locations to the static list
            Locations.Add(home);
            Locations.Add(aegenSouthEnd);
            Locations.Add(aegenTownSquare);
            Locations.Add(aegenMarketplace);
            Locations.Add(guardPost);
            Locations.Add(alchemistHut);
            Locations.Add(alchemistsGarden);
            Locations.Add(aegenWestEnd);
            Locations.Add(farmhouse);
            Locations.Add(farmersField);
            Locations.Add(bridge);
            Locations.Add(spiderField);
        }

        public static Item ItemByID(int id)
        {
            foreach (Item item in Items)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }

            return null;
        }

        public static Monster MonsterByID(int id)
        {
            foreach (Monster monster in Monsters)
            {
                if (monster.ID == id)
                {
                    return monster;
                }
            }

            return null;
        }

        public static Quest QuestByID(int id)
        {
            foreach (Quest quest in Quests)
            {
                if (quest.ID == id)
                {
                    return quest;
                }
            }

            return null;
        }

        public static Location LocationByID(int id)
        {
            foreach (Location location in Locations)
            {
                if (location.ID == id)
                {
                    return location;
                }
            }

            return null;
        }

        public static Ability AbilityByID(int id)
        {
            foreach (Ability ability in Abilities)
            {
                if (ability.ID == id)
                {
                    return ability;
                }
            }

            return null;
        }

        public static NPC NPCByID(int id)
        {
            foreach (NPC npc in NPCs)
            {
                if (npc.ID == id)
                {
                    return npc;
                }
            }

            return null;
        }
    }
}