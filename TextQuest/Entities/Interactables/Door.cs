using System;
using TextQuest.Systems;
using TextQuest.Structures;

namespace TextQuest.Entities.Interactables
{
    public class Door : Interactable
    {
        //The level that the door will bring the player to when interacted
        private readonly Level connectedLevel;

        public Door(int x, int y, string name, Level connectedLevel) : base(x, y, 100, 200, name, Color.BROWN)
        {
            this.connectedLevel = connectedLevel;
        }

        //Change the level if interacted with
        public override void Interact(Worldcontroller worldcontroller)
        {
            Worldcontroller.ChangeLevel(connectedLevel);
        }

    }
}