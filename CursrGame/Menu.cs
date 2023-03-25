namespace CursrGame
{
    internal class Menu
    {
        Player player = new Player();
        NPC npc = new NPC();
        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("You have: " + player.Plrhealth + " HP, " + player.Plrattack + " Attack and " + player.Kills + "Kills");
            Console.WriteLine("Your enemy has: " + npc.NpcHealth + "HP and " + npc.Npcattack + " Attack \n");
        }
        public void Shop()
        {
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine("                SHOP                 ");
            Console.WriteLine("=====================================");
            Console.WriteLine("You have " + player.Gold + " Gold");
            Console.WriteLine("1. Health Potion - 10 Gold");
            Console.WriteLine("2. Dagger - 30 Gold");
            Console.WriteLine("\nType LEAVE to leave the shop.");

            while (true)
            {
                var shopcommand = CustomReadLine.ReadLine();
                switch (shopcommand)
                {
                    case "leave":
                    case "Leave":
                        MainMenu();
                        return;
                    case "1":
                        if (player.Gold >= 10)
                        {
                            Console.WriteLine("You bought a health potion!");
                            player.Plrhealth += 10;
                            player.Gold -= 10;
                            Console.WriteLine("You have " + player.Gold + " Gold    ");
                        }
                        else
                        {
                            Console.WriteLine("You don't have enough gold!");
                        }
                        break;
                    case "2":
                        if (player.Gold >= 30)
                        {
                            Console.WriteLine("You bought a dagger");
                            player.Plrattack += 25;
                            player.Gold -= 30;
                            Console.WriteLine("You have " + player.Gold + " Gold    ");
                        }
                        else
                        {
                            Console.WriteLine("You don't have enough gold!");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }
            }
        }
    }
}
