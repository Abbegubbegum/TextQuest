using TextQuest.Structures;

namespace TextQuest.Systems
{
    public class Renderer
    {
        public void Render(Level level)
        {
            foreach (var entity in level.gameobjects)
            {
                entity.Draw();
            }
        }
    }
}
