using TextQuest.Structures;

namespace TextQuest.Systems
{
    public class Renderer
    {
        public void Render()
        {
            Raylib.DrawRectangle(0, 0, GameManager.GAME_WIDTH, GameManager.GAME_HEIGHT, Color.GREEN);
            foreach (var entity in GameManager.currentLevel.Gameobjects)
            {
                entity.Draw();
            }
        }
    }
}
