namespace TextQuest.Systems
{
    public class ConsoleManager
    {
        public string InputText { get; private set; } = "";

        private Dictionary<string, Action<List<string>>> commands;

        private TextInputManager inputManager;

        public ConsoleManager(TextInputManager inputManager)
        {
            this.inputManager = inputManager;
            this.inputManager.StartListening();

            commands = new Dictionary<string, Action<List<string>>>
            {
                { "pickup", Pickup }
            };
        }

        public void Update()
        {
            inputManager.Update();

            InputText = inputManager.Text;
        }

        public void EnterCommand()
        {
            List<string> keywords = InputText.Split(" ").ToList();

            string command = keywords[0];

            keywords.RemoveAt(0);

            if (!commands.ContainsKey(command)) return;

            commands[command](keywords);
        }

        public void Pickup(List<string> args)
        {
            Logger.Log("Pickup " + args[0], this);
        }
    }
}
