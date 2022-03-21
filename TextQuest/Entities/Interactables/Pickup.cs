namespace TextQuest.Entities.Interactables
{
    public class Pickup : Interactable
    {
        public Pickup(int x, int y, int width, int height, string name) : base(x, y, width, height, name)
        {
        }

        public void Interact()
        {
            throw new NotImplementedException();
        }
    }
}