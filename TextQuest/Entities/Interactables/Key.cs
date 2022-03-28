using System;

namespace TextQuest.Entities.Interactables
{
    public class Key : Pickup
    {
        public Key(int x, int y, string name) : base(x, y, 50, 50, name, Color.YELLOW)
        {
        }
    }
}