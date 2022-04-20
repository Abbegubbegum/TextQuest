using TextQuest.Structures;
using TextQuest.Entities;
using TextQuest.Entities.Interactables;

namespace TextQuest.Systems
{
    public class Worldcontroller
    {
        //references
        private InventoryManager inventoryManager;

        public Worldcontroller(InventoryManager inventoryManager)
        {
            this.inventoryManager = inventoryManager;
        }

        //The command pickup which gets one pickup from the level and adds it to the inventory
        public void Pickup(List<string> args)
        {
            //gets the pickup name input
            string name = args[0];

            //fetches it from the level
            Interactable? interactable = GameManager.currentLevel.GetInteractableFromName(name);

            //if it exists
            if (interactable == null)
            {
                Logger.Log("Interactable not found: " + name);
                return;
            }

            //if it is pickupable
            if (interactable is Pickup pickupObject)
            {
                Logger.Log("Picking up " + name);
                //Remove it from the level
                GameManager.currentLevel.RemoveInteractable(pickupObject);
                //Add it to the inventory
                inventoryManager.AddToInventory(pickupObject);
            }
            else
            {
                Logger.Log("Interactable not a pickup: " + name);
            }
        }

        //The command interact which interacts with one interactable object in the level
        public void Interact(List<string> args)
        {
            //gets the interactable name input
            string name = args[0];

            //fetches it from the level
            Interactable? interactable = GameManager.currentLevel.GetInteractableFromName(name);

            //if it exists
            if (interactable == null)
            {
                Logger.Log("Interactable not found: " + name);
                return;
            }

            //interact with it
            interactable.Interact(this);
        }

        //The command use which uses an item from the inventory on a interactable in the level
        public void Use(List<string> args)
        {
            //fetch the item from inventory
            Pickup? item = inventoryManager.GetPickupFromName(args[0]);
            //fetch the interactable from the level
            Interactable? target = GameManager.currentLevel.GetInteractableFromName(args[1]);

            //check if they exist
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

            //use the item and if it "succeds" destroy the item
            if (target.UseItemOn(item))
            {
                inventoryManager.RemoveFromInventory(item);
            }
        }

        //The command check which prints out all interactables in the level
        public void Check(List<string> args)
        {
            List<string> names = GameManager.currentLevel.GetInteractableNameList();

            Logger.Log("In the scene: ");
            foreach (string name in names)
            {
                Logger.Log(name);
            }
        }

        //Helper functions
        public void ChangeLevel(Level nextLevel)
        {
            GameManager.currentLevel = nextLevel;
        }
    }
}