using TextQuest.Entities;
using TextQuest.Entities.Interactables;
using TextQuest.Systems.Utilities;

namespace TextQuest.Systems;

public class InventoryManager
{
    public void AddToInventory(Pickup pickup)
    {
        Logger.Log("Add to inventory: " + pickup.Name, this);
    }
}
