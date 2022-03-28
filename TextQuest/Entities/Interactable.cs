using TextQuest.Entities.Interactables;
using TextQuest.Systems;

namespace TextQuest.Entities
{
    public class Interactable : Gameobject
    {
        public string Name { get; protected set; }

        public Interactable(int x, int y, int width, int height, string name, Color c = default) : base(x, y, width, height, c)
        {
            Name = name;
        }

        public virtual void Interact(Worldcontroller worldcontroller)
        {
            Logger.Log("Bruh you dumb, thats not what you do");
        }

        public virtual bool UsedOn(Pickup item)
        {
            Logger.Log("Bruh you dumb, thats not what you do");
            return false;
        }
    }
}
