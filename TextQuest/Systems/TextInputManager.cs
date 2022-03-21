namespace TextQuest.Systems
{
    public class TextInputManager
    {
        public string Text { get; private set; } = "";
        private bool listening = false;

        private int currentKeyRaw = 0;
        private char currentKey;

        private readonly int[] allowedKeys = { 32, 90, 88, 67, 86, 66, 78, 77, 65, 83, 68, 70, 71, 72, 74, 75, 76, 81, 87, 69, 82, 84, 89, 85, 73, 79, 80 };

        public void Update()
        {
            if (!listening) return;

            currentKeyRaw = Raylib.GetKeyPressed();

            if (allowedKeys.Contains(currentKeyRaw))
            {
                currentKey = Convert.ToChar(currentKeyRaw);
                Text += currentKey.ToString().ToLower();
                // Text = currentUnicodeKey.ToString();
            }
            else if (currentKeyRaw == (int)KeyboardKey.KEY_BACKSPACE)
            {
                try
                {
                    Text = Text.Remove(Text.Length - 1);
                }
                catch
                {

                }
            }
        }

        public void StartListening()
        {
            listening = true;
        }

        public void StopListening()
        {
            listening = false;
        }

        public void ResetText()
        {
            Text = "";
        }
    }
}


