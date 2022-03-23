using TextQuest.Entities;
using TextQuest.Entities.Interactables;

namespace TextQuest.Structures
{
    public class Level
    {
        private List<Gameobject> gameobjects = new();

        public List<Pickup> pickups = new();

        public Level(Gameobject[]? gameobjects = null, Pickup[]? pickups = null)
        {
            if (gameobjects != null)
                this.gameobjects.AddRange(gameobjects);

            if (pickups != null)
                this.pickups.AddRange(pickups);

            List<string> names = new();

            foreach (var interactable in GetInteractables())
            {
                if (names.Contains(interactable.Name))
                {
                    Logger.Log($"Interactable name duplicate: {interactable.Name}", this, "ERROR");
                }
                else
                {
                    names.Add(interactable.Name);
                }
            }

        }

        public List<string> GetInteractableNameList()
        {
            List<string> nameList = new();

            foreach (var interactable in GetInteractables())
            {
                nameList.Add(interactable.Name);
            }

            return nameList;
        }

        public Interactable? GetInteractableFromName(string name)
        {
            return GetInteractables().Find((obj) => obj.Name == name);
        }

        public Pickup? GetPickupFromName(string name)
        {
            return pickups.Find((obj) => obj.Name == name);
        }

        public List<Gameobject> GetGameObjects()
        {
            List<Gameobject> result = new();
            result.AddRange(gameobjects);
            result.AddRange(GetInteractables());
            return result;
        }

        public List<Interactable> GetInteractables()
        {
            List<Interactable> result = new();
            result.AddRange(pickups);
            return result;
        }

        // public void RemoveInteractable(Interactable interactable)
        // {
        //     if (interactables.Remove(interactable) == false || gameobjects.Remove(interactable) == false)
        //     {
        //         Logger.Log("Unable to remove non-existing interactable " + interactable.Name, this, "ERROR");
        //         return;
        //     }
        // }
    }
}