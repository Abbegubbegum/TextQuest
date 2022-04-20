namespace TextQuest.Entities.Interactables
{
    //Class just for checking if they are pickupable, no other functionality needed
    public class Pickup : Interactable
    {
        public Pickup(int x, int y, int width, int height, string name, Color c = default) : base(x, y, width, height, name, c)
        {
        }
    }
}