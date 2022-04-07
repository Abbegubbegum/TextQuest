using TextQuest.Entities.Interactables;
using TextQuest.Systems;

namespace TextQuest.Entities
{
    public class Interactable : Gameobject
    {
        //All interactables need a name for commands
        public string Name { get; init; }

        public Interactable(int x, int y, int width, int height, string name, Color c = default) : base(x, y, width, height, c)
        {
            Name = name;
        }

        //Base override functions which gives out the "incorrect action" response if they are called
        //This is so the player can try to use these actions on any interactable but only the ones that have overrided are the correct ones
        public virtual void Interact(Worldcontroller worldcontroller)
        {
            Logger.Log("Bruh you dumb, thats not what you do");
        }

        public virtual bool UseItemOn(Pickup item)
        {
            Logger.Log("Bruh you dumb, thats not what you do");
            return false;
        }
    }
}
