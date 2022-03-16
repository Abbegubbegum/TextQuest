namespace TextQuest.Systems
{
    public class ConsoleManager
    {
        public string InputText { get; private set; } = "";

        private TextInputManager inputManager;

        public ConsoleManager(TextInputManager inputManager)
        {
            this.inputManager = inputManager;
            this.inputManager.StartListening();
        }

        public void Update()
        {
            inputManager.Update();

            InputText = inputManager.Text;
        }

        public void EnterCommand()
        {

        }
    }
}
