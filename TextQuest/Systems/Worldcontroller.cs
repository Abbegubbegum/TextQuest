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

            Interactable? interactable = GameManager.currentLevel.GetInteractableFromName(name);

            if (interactable == null)
            {
                Logger.Log("Interactable not found: " + name);
                return;
            }

            if (interactable is Pickup pickupObject)
            {
                Logger.Log("Picking up " + name);
                GameManager.currentLevel.RemoveInteractable(pickupObject);
                inventoryManager.AddToInventory(pickupObject);
            }
            else
            {
                Logger.Log("Interactable not a pickup " + name);
            }
        }


        public void Interact(List<string> args)
        {
            string name = args[0];

            Interactable? interactable = GameManager.currentLevel.GetInteractableFromName(name);

            if (interactable == null)
            {
                Logger.Log("Interactable not found: " + name);
                return;
            }

            interactable.Interact(this);
        }


        public void ChangeLevel(Level nextLevel)
        {
            GameManager.currentLevel = nextLevel;
        }

        public void Use(List<string> args)
        {
            Pickup? item = inventoryManager.GetPickupFromName(args[0]);
            Interactable? target = GameManager.currentLevel.GetInteractableFromName(args[1]);

            if (item == null)
            {
                Logger.Log("Item not in inventory: " + args[0]);
            }

            if (target == null)
            {
                Logger.Log("Object doesn't exist or not interactable: " + args[1]);
            }

            if (item == null || target == null)
            {
                return;
            }

            if (target.UseItemOn(item))
            {
                inventoryManager.RemoveFromInventory(item);
            }
        }

        public void Check(List<string> args)
        {
            List<string> names = GameManager.currentLevel.GetInteractableNameList();

            Logger.Log("In the scene: ");
            foreach (string name in names)
            {
                Logger.Log(name);
            }
        }
    }
}