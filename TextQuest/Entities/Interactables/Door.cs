using System;
using TextQuest.Systems;
using TextQuest.Structures;

namespace TextQuest.Entities.Interactables
{
    public class Door : Interactable
    {
        public Level nextLevel;

        public Door(int x, int y, string name, Level nextLevel) : base(x, y, 100, 200, name, Color.BROWN)
        {
            this.nextLevel = nextLevel;
        }

        public override void Interact(Worldcontroller worldcontroller)
        {
            worldcontroller.ChangeLevel(nextLevel);
        }

    }
}