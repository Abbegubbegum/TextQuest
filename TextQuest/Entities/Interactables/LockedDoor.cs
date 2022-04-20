using System;
using TextQuest.Structures;
using TextQuest.Systems;

namespace TextQuest.Entities.Interactables
{
    public class LockedDoor : Door
    {
        private bool isLocked = true;
        //Reference to the correct key to unlock the door
        private readonly Key correctKey;

        public LockedDoor(int x, int y, string name, Level connectedLevel, Key key) : base(x, y, name, connectedLevel)
        {
            correctKey = key;
        }

        //Same as regular door interact but only runs if door is unlocked
        public override void Interact(Worldcontroller worldcontroller)
        {
            if (isLocked)
            {
                Logger.Log("Locked sadge");
                return;
            }

            base.Interact(worldcontroller);
        }

        //Unlocks the door if player uses a key on door
        public override bool UseItemOn(Pickup item)
        {
            if (item is Key usedKey)
            {
                if (correctKey == usedKey)
                {
                    isLocked = false;
                    Logger.Log("Good job, it's open");
                    return true;
                }
                else
                {
                    Logger.Log("Nah bro it don fit");
                }
            }
            else
            {
                Logger.Log("Not a key my guy");
            }

            return false;
        }
    }
}