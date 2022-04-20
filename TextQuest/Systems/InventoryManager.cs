using TextQuest.Entities;
using TextQuest.Entities.Interactables;
using TextQuest.Systems.Utilities;

namespace TextQuest.Systems
{
    public class InventoryManager
    {
        public int InventoryCapacity { get; } = 6;
        public List<Pickup> inventory;

        //A dictionary that converts two item names into a new pickup
        private Dictionary<(string, string), Pickup> combinations = new();

        public InventoryManager()
        {
            //Create the list with the max capacity
            inventory = new(InventoryCapacity);

            //Adds the different combinations in the game
            combinations.Add(("stick", "string"), new Pickup(0, 0, 35, 35, "fishingrod", Color.MAGENTA));

            //Generates mirror combinations
            combinations = GenerateMirrorCombinations(combinations);
        }

        //Helper functions
        public void AddToInventory(Pickup pickup)
        {
            Logger.Log("Add to inventory: " + pickup.Name);
            inventory.Add(pickup);
        }
        public void RemoveFromInventory(Pickup pickup)
        {
            if (!inventory.Remove(pickup))
            {
                Logger.Log("Failed to remove from inventory: " + pickup.Name);
            }
        }
        public Pickup? GetPickupFromName(string name)
        {
            return inventory.Find(pickup => pickup.Name == name);
        }

        //The combine command which takes two items from the inventory to combine them
        public void Combine(List<string> args)
        {
            //Gets the two items from the arguments given
            Pickup? item1 = GetPickupFromName(args[0]);
            Pickup? item2 = GetPickupFromName(args[1]);

            //Checks if they all exist
            if (item1 == null)
            {
                Logger.Log("Pickup not in inventory: " + args[0]);
            }

            if (item2 == null)
            {
                Logger.Log("Pickup not in inventory: " + args[1]);
            }

            if (item1 == null || item2 == null)
            {
                return;
            }

            //Check if the combinations exist
            if (!combinations.ContainsKey((item1.Name, item2.Name)))
            {
                Logger.Log($"Combination does not exist: {item1.Name} + {item2.Name}");
                return;
            }

            //Removes the two items to be added from inventory and adds the result item
            RemoveFromInventory(item1);
            RemoveFromInventory(item2);
            AddToInventory(combinations[(item1.Name, item2.Name)]);
        }

        //Goes through all the combinations and adds the reverse in the string tuple
        private static Dictionary<(string, string), Pickup> GenerateMirrorCombinations(Dictionary<(string, string), Pickup> combinations)
        {
            //Creates a new dictionary 
            Dictionary<(string, string), Pickup> mirrorCombinations = new();
            //Go through each of the old combinations
            foreach (var combination in combinations)
            {
                //add the mirror combination to the other list
                (string, string) mirrorCombo = (combination.Key.Item2, combination.Key.Item1);
                mirrorCombinations.Add(mirrorCombo, combination.Value);
            }
            //Append each mirror combination to the old list
            foreach (var mirrorCombination in mirrorCombinations)
            {
                combinations.Add(mirrorCombination.Key, mirrorCombination.Value);
            }

            //return the list
            return combinations;
        }
    }
}