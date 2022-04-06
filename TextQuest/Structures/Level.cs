using TextQuest.Entities;

namespace TextQuest.Structures
{
    public class Level
    {
        //A List of the gameobjects that are only gameobjects, not all the gameobjects in the level
        private List<Gameobject> rawGameobjects = new();

        //A List of the interactable gameobjects in the level
        private List<Interactable> interactables = new();

        //A property to get ALL the gameobjects
        public List<Gameobject> Gameobjects
        {
            //Combines both the rawgameobjects and the interactables
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

        //Constructor which takes in arrays of the gameobjects to be added
        public Level(Interactable[]? interactables = null, Gameobject[]? gameobjects = null)
        {
            //if interactable parameter exists, add
            if (interactables != null)
                this.interactables.AddRange(interactables);

            CheckNameDuplication();

            //if gameobjects parameter exists, add
            if (gameobjects != null)
                rawGameobjects.AddRange(gameobjects);
        }

        //Helper functions
        public void AddInteractable(Interactable newInteractable)
        {
            interactables.Add(newInteractable);
            CheckNameDuplication();
        }

        private void CheckNameDuplication()
        {
            //List of all the interactable names
            List<string> names = new();

            //For each interactable in the level
            foreach (var interactable in this.interactables)
            {
                //Check if name duplicate exists and abort
                if (names.Contains(interactable.Name))
                {
                    Logger.Log($"Interactable name duplicate: {interactable.Name}", "ERROR");
                    return;
                }
                //else Add the name to the list
                else
                {
                    names.Add(interactable.Name);
                }
            }
        }

        public void RemoveInteractable(Interactable interactable)
        {
            if (interactables.Remove(interactable) == false)
            {
                Logger.Log("Unable to remove non-existing interactable " + interactable.Name, "ERROR");
            }
        }

        //Get list of all names
        public List<string> GetInteractableNameList()
        {
            List<string> nameList = new();

            foreach (var interactable in interactables)
            {
                nameList.Add(interactable.Name);
            }

            return nameList;
        }

        //nullable as it doesn't need to exist
        public Interactable? GetInteractableFromName(string name)
        {
            return interactables.Find((obj) => obj.Name == name);
        }
    }
}