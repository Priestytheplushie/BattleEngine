namespace BattleEngine 
{
    class BattleEngine 
    {
        public static int TurnCount = 0;

        void GameOver(string message)
        {
            Console.WriteLine();
            UI.Typewriter("=== GAME OVER ===");
            UI.Typewriter(message);
            UI.Wait(2);
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey(true);
            
            Environment.Exit(0);
        }
    }
}