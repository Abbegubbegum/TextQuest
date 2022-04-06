using TextQuest.Entities.Interactables;
using TextQuest.Entities;
using TextQuest.Structures;

namespace TextQuest.Systems
{
    public class GameManager
    {
        //Public constants
        public const int SCREEN_WIDTH = 1800;
        public const int SCREEN_HEIGHT = 800;

        //Where all the game is (everything except the UI)
        public const int GAME_WIDTH = SCREEN_WIDTH / 4 * 3;
        public const int GAME_HEIGHT = SCREEN_HEIGHT - 100;

        //The different components
        Renderer renderer;

        UIManager uiManager;

        ConsoleManager consoleManager;

        InventoryManager inventoryManager;

        Worldcontroller worldcontroller;

        //A static reference to the current level
        public static Level currentLevel = new();



        public GameManager()
        {
            // Setup Raylib
            Raylib.InitWindow(SCREEN_WIDTH, SCREEN_HEIGHT, "TextQuest");
            Raylib.SetTargetFPS(60);

            //Initialize
            renderer = new();
            inventoryManager = new();

            //Send the references also
            worldcontroller = new(inventoryManager);
            consoleManager = new(worldcontroller, inventoryManager);
            uiManager = new(consoleManager, inventoryManager);

            //Initialize the levels, should really be some json deserialization
            CreateLevels();
        }

        //Just to group up level creation and sets the current level to a level
        private void CreateLevels()
        {
            //A key
            Key coolKey = new(400, 200, "key");
            //First level with some pickups and a key
            Level level1 = new(new Interactable[] { new Pickup(50, 50, 50, 100, "stick", Color.BROWN), new Pickup(300, 400, 10, 100, "string", Color.WHITE), coolKey });
            //Instantiate level 3
            Level level3 = new(new Interactable[] { new Well(300, 300, "well") });
            //Locked door with a reference to level 3
            LockedDoor lockedDoor = new(1200, 100, "bigdoor", level3, coolKey);
            //Second level contains the locked door
            Level level2 = new(new Interactable[] { lockedDoor });
            //Create two doors to connect level1 to level2
            Door door = new(800, 400, "door", level2);
            Door door2 = new(800, 400, "door", level1);
            level1.AddInteractable(door);
            level2.AddInteractable(door2);
            currentLevel = level1;
        }

        //Start the game and run the game loop
        public void Run()
        {
            //Game loop
            while (!Raylib.WindowShouldClose())
            {
                #region LOGIC

                //Update consolemanager with textinput
                consoleManager.Update();

                //global keypressed commands
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                {
                    consoleManager.EnterCommand();
                }

                //Debug stuff
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_TAB))
                {
                    Logger.Toggle();
                }

                #endregion


                #region DRAWING
                //Draw everything
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);

                //Render all gameobjects in current level
                renderer.Render(currentLevel);

                //Render UI
                uiManager.Render();

                Raylib.EndDrawing();
                #endregion
            }
        }
    }
}
