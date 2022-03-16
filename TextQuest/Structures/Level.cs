using TextQuest.Entities;

namespace TextQuest.Structures
{
    public class Level
    {
        public List<IGameobject> gameobjects = new();

        public Level(IGameobject[] gameobjects)
        {
            this.gameobjects.AddRange(gameobjects);
        }
    }
}