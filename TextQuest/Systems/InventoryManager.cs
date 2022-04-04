using TextQuest.Entities;
using TextQuest.Entities.Interactables;
using TextQuest.Systems.Utilities;

namespace TextQuest.Systems;

public class InventoryManager
{
    public int inventoryCapacity = 6;
    public List<Pickup> inventory;

    private Dictionary<(string, string), Pickup> combinations = new();

    public InventoryManager()
    {
        inventory = new(inventoryCapacity);

        combinations.Add(("stick", "string"), new Pickup(0, 0, 20, 20, "fishingrod", Color.GOLD));

        combinations = GenerateMirrorCombinations(combinations);
    }

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

    public void Combine(List<string> args)
    {
        Pickup? item1 = GetPickupFromName(args[0]);
        Pickup? item2 = GetPickupFromName(args[1]);

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

        if (!combinations.ContainsKey((item1.Name, item2.Name)))
        {
            Logger.Log($"Combination does not exist: {item1.Name} + {item2.Name}");
            return;
        }

        RemoveFromInventory(item1);
        RemoveFromInventory(item2);
        AddToInventory(combinations[(item1.Name, item2.Name)]);


    }

    private Dictionary<(string, string), Pickup> GenerateMirrorCombinations(Dictionary<(string, string), Pickup> combinations)
    {
        Dictionary<(string, string), Pickup> mirrorCombinations = new();
        foreach (var combination in combinations)
        {
            (string, string) mirrorCombo = (combination.Key.Item2, combination.Key.Item1);
            mirrorCombinations.Add(mirrorCombo, combination.Value);
        }
        foreach (var mirrorCombination in mirrorCombinations)
        {
            combinations.Add(mirrorCombination.Key, mirrorCombination.Value);
        }

        return combinations;
    }
}
