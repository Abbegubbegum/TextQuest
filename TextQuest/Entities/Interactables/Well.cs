using TextQuest.Systems;

namespace TextQuest.Entities.Interactables
{
    public class Well : Interactable
    {
        private readonly Key containedKey;

        public Well(int x, int y, string name, Key containedKey) : base(x, y, 100, 100, name, Color.BLACK)
        {
            this.containedKey = containedKey;
        }

        //Check if fishing rod is used, if so add the key to the current level
        public override bool UseItemOn(Pickup item)
        {
            if (item.Name == "fishingrod")
            {
                c = Color.BLUE;
                GameManager.currentLevel.AddInteractable(containedKey);
                return true;
            }

            return false;
        }
    }
}