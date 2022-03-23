using TextQuest.Entities;

namespace TextQuest.Structures
{
    public class Level
    {
        private List<Gameobject> rawGameobjects = new();

        public List<Interactable> interactables = new();

        public List<Gameobject> Gameobjects
        {
            get
            {
                List<Gameobject> result = new();
                result.AddRange(rawGameobjects);
                result.AddRange(interactables);
                return result;
            }
            set
            {
                rawGameobjects = value;
            }
        }

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
            }

            if (gameobjects != null)
                rawGameobjects.AddRange(gameobjects);
        }

        public void RemoveInteractable(Interactable interactable)
        {
            if (interactables.Remove(interactable) == false)
            {
                Logger.Log("Unable to remove non-existing interactable " + interactable.Name, this, "ERROR");
            }
        }

        public List<string> GetInteractableNameList()
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