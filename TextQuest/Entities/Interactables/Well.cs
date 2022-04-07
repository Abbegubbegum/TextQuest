using TextQuest.Systems;

namespace TextQuest.Entities.Interactables
{
    public class Well : Interactable
    {
        private Key keyToBeAdded;

        public Well(int x, int y, string name, Key keyToBeAdded) : base(x, y, 100, 100, name, Color.BLACK)
        {
            this.keyToBeAdded = keyToBeAdded;
        }

        //Check if fishing rod is used, if so add the key to the current level
        public override bool UseItemOn(Pickup item)
        {
            if (item.Name == "fishingrod")
            {
                c = Color.BLUE;
                GameManager.currentLevel.AddInteractable(keyToBeAdded);
                return true;
            }

            return false;
        }
    }
}