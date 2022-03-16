namespace TextQuest.Systems.Utilities
{
    public static class Logger
    {
        private static bool enabled = true;

        public static void Log(string message, object context, string type = "")
        {
            if (!enabled) return;

            Console.WriteLine($"{type} {message}, {context}");
        }

        public static void Toggle()
        {
            enabled = !enabled;
        }

    }
}
