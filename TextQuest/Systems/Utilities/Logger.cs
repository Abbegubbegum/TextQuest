namespace TextQuest.Systems.Utilities
{
    //Debug logger which should be printing to the ingame console but...
    public static class Logger
    {
        private static bool enabled = true;

        public static void Log(string message, string type = "")
        {
            if (!enabled) return;

            Console.WriteLine($"{type} {message}");
        }

        public static void Toggle()
        {
            enabled = !enabled;
        }

    }
}
