namespace TextQuest.Entities
{
    public class Interactable : Gameobject
    {
        public string Name { get; protected set; }

        public Interactable(int x, int y, int width, int height, string name, Color c = default) : base(x, y, width, height, c)
        {
            Name = name;
        }



        public virtual void Interact()
        {

        }
    }
}
