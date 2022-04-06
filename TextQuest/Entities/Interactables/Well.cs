using TextQuest.Systems;

namespace TextQuest.Entities.Interactables
{
    public class Well : Interactable
    {
        public Well(int x, int y, string name) : base(x, y, 100, 100, name, Color.BROWN)
        {
        }

        public override bool UseItemOn(Pickup item)
        {
            if (item.Name == "fishingrod")
            {
                c = Color.BLUE;
                return true;
            }

            return false;
        }
    }
}