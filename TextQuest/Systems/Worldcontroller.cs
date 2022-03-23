using TextQuest.Structures;
using TextQuest.Entities;

namespace TextQuest.Systems
{
    public class Worldcontroller
    {
        private InventoryManager inventoryManager;

        public Worldcontroller(InventoryManager inventoryManager)
        {
            this.inventoryManager = inventoryManager;
        }

        public void Pickup(List<string> args)
        {
            string name = args[0];

            Interactable? pickup = GameManager.currentLevel.GetInteractableFromName(name);

            if (pickup == null)
            {
                Logger.Log("Interactable not found: " + name, this);
                return;
            }

            if (pickup is not Entities.Interactables.Pickup)
            {
                Logger.Log("Interactable not a pickup: " + name, this);
                return;
            }

            Logger.Log("Picking up " + name, this);
            GameManager.currentLevel.RemoveInteractable(pickup);
            inventoryManager.AddToInventory(pickup);
        }
    }
}