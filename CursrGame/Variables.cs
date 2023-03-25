namespace CursrGame
{
    public class NPC
    {
        public int NpcHealth { get; set; }
        public int NpcAttack { get; set; }

        private static readonly Random Random = new();

        public NPC()
        {
            NpcAttack = Random.Next(1, 25);
            NpcHealth = Random.Next(1, 150);
        }
    }

    public class Player
    {
        public int PlrAttack { get; set; } = 13;
        public int PlrHealth { get; set; } = 100;
        public int Gold { get; set; } = 999;
        public int Kills { get; set; } = 0;
        public int Level { get; set; } = 1;
        public int Exp { get; set; } = 0;
        public int GiveGold { get; set; }

        private static readonly Random Random = new();

        public Player()
        {
            GiveGold = Random.Next(10, 150);
        }

        public void GainExperience(int amount)
        {
            Exp += amount;

            while (Exp >= GetExperienceNeededForLevel(Level + 1))
            {
                Level++;
                Console.WriteLine($"You leveled up! You are now level {Level}");
            }
        }

        private int GetExperienceNeededForLevel(int level)
        {
            return (int)(100 * Math.Pow(level, 1.5));
        }
    }
}
