using TextQuest.Entities.Interactables;
using TextQuest.Entities;
using TextQuest.Structures;

namespace TextQuest.Systems
{
    public class GameManager
    {
        public const int SCREEN_WIDTH = 1800;
        public const int SCREEN_HEIGHT = 800;

        public const int GAME_WIDTH = SCREEN_WIDTH / 4 * 3;
        public const int GAME_HEIGHT = SCREEN_HEIGHT - 100;

        Renderer renderer;

        UIManager uiManager;

        ConsoleManager consoleManager;

        InventoryManager inventoryManager;

        Worldcontroller worldcontroller;

        public static Level currentLevel = new();



        public GameManager()
        {
            Raylib.InitWindow(SCREEN_WIDTH, SCREEN_HEIGHT, "TextQuest");

            Raylib.SetTargetFPS(60);

            renderer = new();

            inventoryManager = new();

            worldcontroller = new(inventoryManager);

            consoleManager = new(worldcontroller, inventoryManager);


            uiManager = new(consoleManager, inventoryManager);

            CreateLevels();



        }

        private void CreateLevels()
        {
            Key coolKey = new Key(400, 200, "key");
            Level level1 = new Level(new Interactable[] { new Pickup(50, 50, 50, 100, "stick", Color.BROWN), new Pickup(300, 400, 10, 100, "string", Color.WHITE), coolKey });
            Level level3 = new Level();
            LockedDoor lockedDoor = new LockedDoor(1200, 100, "bigdoor", level3, coolKey);
            Level level2 = new Level(new Interactable[] { lockedDoor });
            Door door = new Door(800, 400, "door", level2);
            Door door2 = new Door(800, 400, "door", level1);
            level1.AddInteractable(door);
            level2.AddInteractable(door2);
            currentLevel = level1;
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


                renderer.Render(currentLevel);

                uiManager.Render();

                Raylib.EndDrawing();
                #endregion
            }
        }
    }
}
