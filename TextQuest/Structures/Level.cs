using TextQuest.Entities;

namespace TextQuest.Structures
{
    public class Level
    {
        public List<Gameobject> gameobjects = new();

        public List<Interactable> interactables = new();

        public Level(Interactable[] interactables, Gameobject[]? gameobjects = null)
        {
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


    }
}