using TextQuest.Entities.Interactables;
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

        Worldcontroller worldcontroller;

        public static Level currentLevel = new(null);



        public GameManager()
        {
            Raylib.InitWindow(SCREEN_WIDTH, SCREEN_HEIGHT, "TextQuest");

            Raylib.SetTargetFPS(60);

            renderer = new();

            inventoryManager = new();

            worldcontroller = new(inventoryManager);

            consoleManager = new(worldcontroller);


            uiManager = new(consoleManager, inventoryManager);

            currentLevel = new Level(new Interactable[] { new Pickup(10, 10, 10, 10, "stick") });

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


                renderer.Render();

                uiManager.Render();

                Raylib.EndDrawing();
                #endregion
            }
        }
    }
}
