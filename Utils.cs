namespace BattleEngine
{
    public static class UI
    {
        public static void Wait(double seconds)
        {
            Thread.Sleep((int)(seconds * 1000));
        }

        public static void Typewriter(string text, int delayMs = 30)
        {
            bool inAnsi = false;
            foreach (char c in text)
            {
                if (c == '\u001b') inAnsi = true;
                
                Console.Write(c);
                
                if (inAnsi)
                {
                    if (c == 'm') inAnsi = false;
                }
                else
                {
                    Thread.Sleep(delayMs);
                }
            }
            Console.WriteLine();

        }
    }
}