using TextQuest.Systems.Utilities;

namespace TextQuest.Systems
{
    public class TextInputManager
    {
        public string Text { get; private set; } = "";
        private bool listening = false;

        private KeyboardKey currentKeyRaw = KeyboardKey.KEY_NULL;
        private char currentKey;

        private readonly KeyboardKey[] badKeys = new KeyboardKey[] { KeyboardKey.KEY_NULL, KeyboardKey.KEY_ENTER, KeyboardKey.KEY_TAB, KeyboardKey.KEY_LEFT_SHIFT, KeyboardKey.KEY_RIGHT_SHIFT, KeyboardKey.KEY_LEFT_CONTROL, KeyboardKey.KEY_RIGHT_CONTROL, KeyboardKey.KEY_LEFT_ALT, KeyboardKey.KEY_RIGHT_ALT, KeyboardKey.KEY_DELETE, KeyboardKey.KEY_BACKSPACE };

        public void Update()
        {
            if (!listening) return;

            currentKeyRaw = (KeyboardKey)Raylib.GetKeyPressed();

            if (!badKeys.Contains(currentKeyRaw))
            {
                // Console.WriteLine(currentUnicodeKey);
                currentKey = Convert.ToChar((int)currentKeyRaw);
                Logger.Log($"Writing {currentKey}", this);
                Text += currentKey.ToString().ToLower();
                // Text = currentUnicodeKey.ToString();
            }
            else if (currentKeyRaw == KeyboardKey.KEY_BACKSPACE)
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


