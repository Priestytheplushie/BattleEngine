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
            PlayerTurn();
        }
        void PlayerTurn()
        {
            TurnCount++;
            UI.Typewriter($"Turn: {TurnCount}");
            Console.WriteLine(); 
            string choice = "None";
            while (choice == "None")
            {
                UI.Typewriter("What will you do?");
                Console.WriteLine("1. Fight");
                Console.WriteLine("2. Observe");
                Console.WriteLine("3. Defend");
                Console.WriteLine();
                choice = Console.ReadLine() ?? "None";
                if (choice == "1")
                {
                    Random random = new Random();
                    double playerDamage = Player.Strength;
                    if (random.Next(0, 10) > 8)
                    {
                        playerDamage = playerDamage * 2;
                        UI.Typewriter("CRITICAL HIT!\n");
                    }
                    Enemy.TakeDamage(playerDamage);
                    UI.Typewriter($"You strike {Enemy.Name} for {playerDamage} damage!");
                    Console.WriteLine();
                }
                else if (choice == "2")
                {
                    Console.WriteLine();
                    Console.WriteLine($"1. {Enemy.Name}");
                    Console.WriteLine($"2. {Player.Name}");
                    choice = Console.ReadLine() ?? "1.";
                    Console.WriteLine();
                    if (choice == "1")
                    {
                        Enemy.Check();
                    }
                    else if (choice == "2")
                    {
                        Player.ViewStats();
                    }
                    else
                    {
                        UI.Typewriter("Invalid Input...");
                    }
                }
                else if (choice == "3")
                {
                    UI.Typewriter("You raise your arms in Defense!\n");
                    UI.Typewriter("You reduce the DAMAGE you'll take next turn...");
                    Player.Defense += 1;
                }
                else
                {
                    UI.Typewriter("Invalid Input: Try [1-3]");
                }
            }
            if (Player.Health > 0 && Enemy.Health > 0)
            {
                EnemyTurn();
            }
            else if (Player.Health < 0)
            {
                GameOver("You got killed....");
            }
            else if (Enemy.Health < 0)
            {
                UI.Typewriter("YOU WON!");
                UI.Typewriter("+0 XP");
            }
        }
    }
}