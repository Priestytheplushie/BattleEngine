namespace BattleEngine
{
    class Enemy
    {
        public double Health = 100;
        public int Strength = 0;
        public int Speed = 0;
        public int Defense = 0;
        public int Intelligence = 0; 
        public string Name;
        public Enemy(string name) {
            Name = name;
        }
        public void TakeDamage(double damage)
        {
            Health -= damage;
        }

        public void Check()
        {
            UI.Typewriter($"{Name} - {Strength} Strength {Defense} Defense");
            UI.Typewriter($"{Health} Health {Intelligence} Intelligence");
        }

    }
}