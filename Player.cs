namespace BattleEngine {
    class Player {
        public double Health = 50;
        public int Strength = 0;
        public int Speed = 0;
        public int Defense = 0;
        public int Intelligence = 0; 
        public string Name;

        public Player(string name) {
            Name = name;
            Random random = new Random();
            Health = random.Next(50,150);
            Strength = random.Next(5,15);
            Speed = random.Next(-5, 15);
            Defense = random.Next(0, 10);
            Intelligence = random.Next(10,300);
        }

        public void TakeDamage(double damage)
        {
            Health -= damage;
        }

        public void ViewStats()
        {
            UI.Typewriter("Player Stats");
            Console.WriteLine("---------------");
            UI.Typewriter($"Strength: {this.Strength}");
            UI.Typewriter($"Health: {this.Health}");
            UI.Typewriter($"Speed: {this.Speed}");
            UI.Typewriter($"Intelligence: {this.Intelligence}");
            UI.Typewriter($"Defense: {this.Defense}");
            Console.WriteLine("---------------");
        }
    }
}