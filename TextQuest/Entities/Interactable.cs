namespace TextQuest.Entities
{
    public class Interactable : Gameobject
    {
        public string Name { get; protected set; }

        public Interactable(int x, int y, int width, int height, string name) : base(x, y, width, height)
        {
            Name = name;
        }


        public virtual void Interact()
        {

        }
    }
}
