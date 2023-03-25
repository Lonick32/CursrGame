namespace CursrGame
{

    public class NPC
    {
        public int NpcHealth { get; set; }
        public int Npcattack { get; set; }
        public NPC()
        {
            Random random = new Random();
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
        public int GiveGold { get; set; }

        public Player()
        {
            Random random = new Random();

            Plrattack = 10;
            Plrhealth = 100;
            Gold = 999;
            Kills = 0;
            GiveGold = random.Next(10, 150);
        }
    }


}
