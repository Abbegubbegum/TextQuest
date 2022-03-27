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
        private readonly int textMargin = 5;

        private Rectangle inventoryRec;
        private readonly int inventoryBoxLineThickness = 2;


        public UIManager(ConsoleManager consoleManager, InventoryManager inventoryManager)
        {
            this.consoleManager = consoleManager;
            this.inventoryManager = inventoryManager;

            //Sets the console box to fill up the left of the game 
            consoleRec = new Rectangle(GameManager.GAME_WIDTH, 0, GameManager.SCREEN_WIDTH - GameManager.GAME_WIDTH, GameManager.SCREEN_HEIGHT);

            //Sets the console input box to take up the lowest part of the console box with a height of consoleInputHeight
            consoleInputRec = new Rectangle(consoleRec.x, consoleRec.y + consoleRec.height - consoleInputHeight, consoleRec.width, consoleInputHeight);

            inventoryRec = new Rectangle(0, GameManager.GAME_HEIGHT, GameManager.GAME_WIDTH, GameManager.SCREEN_HEIGHT - GameManager.GAME_HEIGHT);
        }

        public void Render()
        {
            //Make sure the console is black
            Raylib.DrawRectangleRec(consoleRec, Color.BLACK);
            Raylib.DrawRectangleRec(inventoryRec, Color.BLACK);

            Raylib.DrawText(consoleManager.InputText, (int)(consoleInputRec.x + textMargin), (int)(consoleInputRec.y + textMargin), 32, Color.WHITE);

            Rectangle inventoryBox = new(0, inventoryRec.y, inventoryRec.width / inventoryManager.inventoryCapacity, inventoryRec.height);


            for (int i = 0; i < 6; i++)
            {
                inventoryBox.x = inventoryRec.width / inventoryManager.inventoryCapacity * i;

                Raylib.DrawRectangleLinesEx(inventoryBox, inventoryBoxLineThickness, Color.WHITE);

                Raylib.DrawText($"{i + 1}.", (int)inventoryBox.x + textMargin, (int)inventoryBox.y + textMargin, 32, Color.WHITE);

                if (inventoryManager.inventory.Count > i)
                {
                    inventoryManager.inventory[i].MoveCenterTo(inventoryBox.x + inventoryBox.width / 2, inventoryBox.y + inventoryBox.height / 2);
                    inventoryManager.inventory[i].Draw();
                }
            }

        }
    }
}
