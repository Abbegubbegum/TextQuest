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

            Interactable? interactable = GameManager.currentLevel.GetInteractableFromName(name);

            if (interactable == null)
            {
                Logger.Log("Interactable not found: " + name, this);
                return;
            }

            if (interactable is not Entities.Interactables.Pickup)
            {
                Logger.Log("Interactable not a pickup: " + name, this);
                return;
            }

            Entities.Interactables.Pickup pickup = (Entities.Interactables.Pickup)interactable;

            Logger.Log("Picking up " + name, this);
            GameManager.currentLevel.RemoveInteractable(pickup);
            inventoryManager.AddToInventory(pickup);
        }
    }
}