using System.Linq;

namespace TextQuest.Systems
{
    public class ConsoleManager
    {
        public string InputText { get; private set; } = "";

        //Dictionary which uses strings as keys and returns an action that requires a list of strings as arguments and an int of the amount of args required
        private Dictionary<string, Command> commandList = new();

        private TextInputManager inputManager;

        private Worldcontroller worldcontroller;

        private InventoryManager inventoryManager;

        public ConsoleManager(Worldcontroller worldcontroller, InventoryManager inventoryManager)
        {
            this.worldcontroller = worldcontroller;
            this.inventoryManager = inventoryManager;

            inputManager = new();
            inputManager.StartListening();

            commandList.Add("pickup", new Command(worldcontroller.Pickup, 1));
            commandList.Add("combine", new Command(inventoryManager.Combine, 2));
            commandList.Add("interact", new Command(worldcontroller.Interact, 1));
            commandList.Add("use", new Command(worldcontroller.Use, 2));
            commandList.Add("check", new Command(worldcontroller.Check, 0));
            commandList.Add("commands", new Command(Commands, 0));
        }

        public void Update()
        {
            inputManager.Update();

            InputText = inputManager.Text;
        }

        public void EnterCommand()
        {
            //Grabs all the words divided by a space from the input and removes all the empty occurances
            var keywords = InputText.Split(" ").ToList().FindAll((kw) => kw != "");

            string inputCommand = keywords[0];

            keywords.RemoveAt(0);

            if (!commandList.ContainsKey(inputCommand))
            {
                Logger.Log("Command not found: " + inputCommand);
                return;
            }

            Command command = commandList[inputCommand];

            if (keywords.Count != command.ArgCount)
            {
                Logger.Log("Argcount mismatch: " + command.ArgCount + " != " + keywords.Count);
                return;
            }

            command.Action(keywords);

            inputManager.ResetText();
        }

        public void Commands(List<string> args)
        {
            Logger.Log("Commands: ");
            foreach (var command in commandList)
            {
                Logger.Log(command.Key);
            }
        }

        private readonly struct Command
        {
            public Command(Action<List<string>> action, int argCount)
            {
                Action = action;

                ArgCount = argCount;
            }

            public Action<List<string>> Action { get; init; }

            public int ArgCount { get; init; }

        }
    }
}

