using TextQuest.Entities;
using TextQuest.Systems.Utilities;

namespace TextQuest.Systems;

public class InventoryManager
{
    public void AddToInventory(Interactable pickup)
    {
        Logger.Log("Add to inventory: " + pickup.Name, this);
    }
}
