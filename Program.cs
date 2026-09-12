using System.Xml.Serialization;

namespace BattleEngine
{
    class Program
    {
        public static void Main(String[] args)
        {
            Console.Write("Enter your name: \n");
            string PlayerName = Console.ReadLine() ?? "Player";
            Player player = new Player(PlayerName);
            Console.WriteLine();
            UI.Typewriter("Player Registered...\n");
            UI.Wait(2);
            UI.Typewriter("Player Stats");
            Console.WriteLine("---------------");
            UI.Typewriter($"Strength: {player.Strength}");
            UI.Typewriter($"Health: {player.Health}");
            UI.Typewriter($"Speed: {player.Speed}");
            UI.Typewriter($"Intelligence: {player.Intelligence}");
            UI.Typewriter($"Defense: {player.Defense}");
            Console.WriteLine("---------------\n");
            UI.Wait(3);
            string choice = "None";
            while (choice != "1" || choice != "3")
            {
                UI.Typewriter("BattleEngine Demo");
                Console.WriteLine("1. Battle");
                Console.WriteLine("2. View Stats");
                Console.WriteLine("3. Quit");
                Console.WriteLine();
                choice = Console.ReadLine() ?? "None";
                Console.WriteLine();
                if (choice == "1")
                {
                    BattleEngine Engine = new BattleEngine(player);
                    break;
                }
                else if (choice == "2")
                {
                    player.ViewStats();
                }
                else if (choice == "3")
                {   
                    Environment.Exit(0);
                }
                else
                {   
                    choice = "None";
                    UI.Typewriter("Invalid Input: Entger a Number [1-3]");
                }
            }
        }
    }
}