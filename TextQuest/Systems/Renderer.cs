using TextQuest.Structures;

namespace TextQuest.Systems
{
    public class Renderer
    {
        //renders all the gameobjects in a level and also a background
        public void Render(Level level)
        {
            Raylib.DrawRectangle(0, 0, GameManager.GAME_WIDTH, GameManager.GAME_HEIGHT, Color.GREEN);
            foreach (var gameobject in level.Gameobjects)
            {
                gameobject.Draw();
            }
        }
    }
}
