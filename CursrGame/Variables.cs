namespace CursrGame
{
    public class NPC
    {
        public int NpcHealth { get; set; }
        public int Npcattack { get; set; }
        public NPC()
        {
            Random random = new();
            Npcattack = random.Next(1, 25);
            NpcHealth = random.Next(1, 150);
        }
    }
    public class Player
    {

        public int Plrhealth { get; set; }
        public int Plrattack { get; set; }
        public int Gold { get; set; }
        public int Kills { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }
        public int GiveGold { get; set; }

        public Player()
        {
            Random random = new();
            Plrattack = 10;
            Plrhealth = 100;
            Gold = 999;
            Kills = 0;
            Level = 1;
            Exp = 0;
            GiveGold = random.Next(10, 150);
        }

        public void GainExperience(int amount)
        {
            Exp += amount;

            while (Exp >= GetExperienceNeededForLevel(Level + 1))
            {
                Level++;
                Console.WriteLine("You leveled up! You are now level " + Level);
            }
        }

        public int GetExperienceNeededForLevel(int level)
        {
            return (int)(100 * Math.Pow(level, 1.5));
        }
    }
}
