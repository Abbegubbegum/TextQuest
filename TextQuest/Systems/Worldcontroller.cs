using TextQuest.Structures;
using TextQuest.Entities;
using TextQuest.Entities.Interactables;

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

            Pickup? pickup = GameManager.currentLevel.GetPickupFromName(name);

            if (pickup == null)
            {
                if (GameManager.currentLevel.GetInteractableFromName(name) == null)
                {
                    Logger.Log("Pickup not found: " + name, this);
                    return;
                }
                else
                {
                    Logger.Log("Interactable not a pickup: " + name, this);
                    return;
                }
            }


            Logger.Log("Picking up " + name, this);
            // GameManager.currentLevel.RemoveGameobject(pickup);
            inventoryManager.AddToInventory(pickup);
        }
    }
}