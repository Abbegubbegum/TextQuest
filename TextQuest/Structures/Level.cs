using TextQuest.Entities;

namespace TextQuest.Structures
{
    public class Level
    {
        public List<Gameobject> gameobjects = new();

        public List<Interactable> interactables = new();

        public Level(Interactable[]? interactables = null, Gameobject[]? gameobjects = null)
        {
            if (interactables != null)
                this.interactables.AddRange(interactables);

            List<string> names = new();

            foreach (var interactable in this.interactables)
            {
                if (names.Contains(interactable.Name))
                {
                    Logger.Log($"Interactable name duplicate: {interactable.Name}", this, "ERROR");
                }
                else
                {
                    names.Add(interactable.Name);
                }

                this.gameobjects.Add(interactable);
            }

            if (gameobjects != null)
                this.gameobjects.AddRange(gameobjects);
        }

        public void RemoveInteractable(Interactable interactable)
        {
            if (interactables.Remove(interactable) == false || gameobjects.Remove(interactable) == false)
            {
                Logger.Log("Unable to remove non-existing interactable " + interactable.Name, this, "ERROR");
                return;
            }


        }

        public List<string> GetNameList()
        {
            List<string> nameList = new();

            foreach (var interactable in interactables)
            {
                nameList.Add(interactable.Name);
            }

            return nameList;
        }

        public Interactable? GetInteractableFromName(string name)
        {
            return interactables.Find((obj) => obj.Name == name);
        }
    }
}