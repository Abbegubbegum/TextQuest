using System.Linq;

namespace TextQuest.Systems
{
    public class ConsoleManager
    {
        public string InputText { get; private set; } = "";

        //Dictionary which uses strings as keys and returns an action that requires a list of strings as arguments and an int of the amount of args required
        private Dictionary<string, Command> commandList = new();

        //references to componenents
        private TextInputManager inputManager;


        public ConsoleManager(Worldcontroller worldcontroller, InventoryManager inventoryManager)
        {
            //Create inputmanager
            inputManager = new();
            inputManager.StartListening();

            //Add the different commands, should be json deserialization
            commandList.Add("pickup", new Command(worldcontroller.Pickup, 1));
            commandList.Add("combine", new Command(inventoryManager.Combine, 2));
            commandList.Add("interact", new Command(worldcontroller.Interact, 1));
            commandList.Add("use", new Command(worldcontroller.Use, 2));
            commandList.Add("check", new Command(Worldcontroller.Check, 0));
            commandList.Add("commands", new Command(Commands, 0));
        }

        //Update the text input manager
        public void Update()
        {
            inputManager.Update();

            InputText = inputManager.Text;
        }

        //Enter the command and runs it
        public void EnterCommand()
        {
            //Grabs all the words divided by a space from the input and removes all the empty occurances
            var keywords = from keyword in InputText.Split(" ")
                           where keyword.Length > 0
                           select keyword;

            //Grabs first word which is the command name
            string inputCommand = keywords.First();

            //create a list with the other arguments 
            List<string> arguments = keywords.Skip(1).ToList();

            //Check if entered command exist
            if (!commandList.ContainsKey(inputCommand))
            {
                Logger.Log("Command not found: " + inputCommand);
                Logger.Log("Use Command 'commands' to see all commands");
                return;
            }

            //grab the command from the dictionary
            Command command = commandList[inputCommand];

            //Check that the required argument counts match
            if (arguments.Count != command.ArgCount)
            {
                Logger.Log("Argcount mismatch: " + command.ArgCount + " != " + arguments.Count);
                return;
            }

            //Do the action
            command.Action(arguments);

            //Clear input text
            inputManager.ResetText();
        }

        //Prints out all the commands
        public void Commands(List<string> args)
        {
            Logger.Log("Commands: ");
            foreach (var command in commandList)
            {
                Logger.Log(command.Key);
            }
        }

        //A struct for keeping an action and argcount together
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

