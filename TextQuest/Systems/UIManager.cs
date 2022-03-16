using TextQuest.Systems.Utilities;

namespace TextQuest.Systems
{
    public class UIManager
    {

        private ConsoleManager consoleManager;
        private InventoryManager inventoryManager;

        private Rectangle consoleRec;
        private Rectangle consoleInputRec;
        private readonly int consoleInputHeight = 40;
        private readonly int consoleInputMargin = 5;

        public UIManager(ConsoleManager consoleManager, InventoryManager inventoryManager)
        {
            this.consoleManager = consoleManager;
            this.inventoryManager = inventoryManager;

            //Sets the console box to fill up the left of the game 
            consoleRec = new Rectangle(GameManager.GAME_WIDTH, 0, GameManager.SCREEN_WIDTH - GameManager.GAME_WIDTH, GameManager.SCREEN_HEIGHT);

            //Sets the console input box to take up the lowest part of the console box with a height of consoleInputHeight
            consoleInputRec = new Rectangle(consoleRec.x, consoleRec.y + consoleRec.height - consoleInputHeight, consoleRec.width, consoleInputHeight);
        }

        public void Render()
        {
            //Make sure the console is black
            Raylib.DrawRectangleRec(consoleRec, Color.BLACK);

            Raylib.DrawText(consoleManager.InputText, (int)(consoleInputRec.x + consoleInputMargin), (int)(consoleInputRec.y + consoleInputMargin), 32, Color.WHITE);

        }
    }
}
