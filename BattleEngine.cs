namespace BattleEngine 
{
    class BattleEngine 
    {
        public int TurnCount = 0;
        public Player Player;
        public Enemy Enemy;

        public BattleEngine(Player player)
        {
            this.Player = player;
            this.Enemy = new Enemy("Beast");
            Initative();
        }

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

        void Initative()
        {
            UI.Typewriter($"A wild {Enemy.Name} appears!\n");
            UI.Typewriter("You stare each other down, waiting for someone to make\nthe next move...");
            UI.Wait(3);
            if (Enemy.Speed > Player.Speed)
            {
                UI.Typewriter($"{Enemy.Name} Seizes the oppertunitiy to attack!\n");
                EnemyTurn();
            }
            else if (Player.Speed > Enemy.Speed)
            {
                UI.Typewriter("Your reflexes allows you to take the first turn\n");
                PlayerTurn();
            }
            else
            {
                UI.Typewriter("You and the enemy stare each other down, unable to decide who\n should strike first...\n");
                UI.Wait(3);
                UI.Typewriter("The enemy lunges at you, stealing the first oppertunity to strike!\n");
                EnemyTurn();
            }
        }
        void EnemyTurn()
        {
            TurnCount++;
        }
        void PlayerTurn()
        {
            TurnCount++;
        }
    }
}