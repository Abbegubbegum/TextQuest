using TextQuest.Systems;

namespace TextQuest.Entities.Interactables
{
    public class Pickup : Interactable
    {
        public Pickup(int x, int y, int width, int height, string name, Color c = default) : base(x, y, width, height, name, c)
        {
        }
    }
}