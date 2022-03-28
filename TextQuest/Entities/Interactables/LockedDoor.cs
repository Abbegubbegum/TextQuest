using System;
using TextQuest.Structures;
using TextQuest.Systems;

namespace TextQuest.Entities.Interactables
{
    public class LockedDoor : Door
    {
        bool isLocked = true;
        Key correctKey;

        public LockedDoor(int x, int y, string name, Level nextLevel, Key key) : base(x, y, name, nextLevel)
        {
            correctKey = key;
        }


        public override void Interact(Worldcontroller worldcontroller)
        {
            if (isLocked)
            {
                Logger.Log("Locked sadge");
                return;
            }

            base.Interact(worldcontroller);
        }

        public override bool UsedOn(Pickup item)
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