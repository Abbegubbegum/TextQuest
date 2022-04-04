using System;
using TextQuest.Systems;
using TextQuest.Structures;

namespace TextQuest.Entities.Interactables
{
    public class Door : Interactable
    {
        public Level connectedLevel;

        public Door(int x, int y, string name, Level connectedLevel) : base(x, y, 100, 200, name, Color.BROWN)
        {
            this.connectedLevel = connectedLevel;
        }

        public override void Interact(Worldcontroller worldcontroller)
        {
            worldcontroller.ChangeLevel(connectedLevel);
        }

    }
}