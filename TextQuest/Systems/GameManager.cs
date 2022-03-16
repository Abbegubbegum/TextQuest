using TextQuest.Systems.Utilities;
using TextQuest.Entities;
using TextQuest.Structures;

namespace TextQuest.Systems
{
    public class GameManager
    {
        public const int SCREEN_WIDTH = 1800;
        public const int SCREEN_HEIGHT = 800;

        public const int GAME_WIDTH = SCREEN_WIDTH / 3 * 2;
        public const int GAME_HEIGHT = SCREEN_HEIGHT;

        Renderer renderer;

        UIManager uiManager;

        ConsoleManager consoleManager;

        InventoryManager inventoryManager;

        TextInputManager inputManager;

        Level currentLevel;



        public GameManager()
        {
            Raylib.InitWindow(SCREEN_WIDTH, SCREEN_HEIGHT, "TextQuest");

            Raylib.SetTargetFPS(60);

            renderer = new();

            inputManager = new();

            consoleManager = new(inputManager);

            inventoryManager = new();

            uiManager = new(consoleManager, inventoryManager);

            currentLevel = new Level(new IGameobject[] { new Player(100, 100) });
        }

        public void Run()
        {
            while (!Raylib.WindowShouldClose())
            {
                #region LOGIC

                consoleManager.Update();

                if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                {
                    consoleManager.EnterCommand();
                }

                if (Raylib.IsKeyPressed(KeyboardKey.KEY_TAB))
                {
                    Logger.Toggle();
                }

                #endregion

                #region DRAWING
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                //Background
                Raylib.DrawRectangle(0, 0, GAME_WIDTH, GAME_HEIGHT, Color.GREEN);

                renderer.Render(currentLevel);

                uiManager.Render();

                Raylib.EndDrawing();
                #endregion
            }
        }
    }
}
