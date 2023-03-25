namespace CursrGame
{
    public class Menu
    {
        private Player? player;
        private NPC? npc;

        public void MainMenu(Player player, NPC npc)
        {
            this.player = player;
            this.npc = npc;

            Console.Clear();
            Console.WriteLine("You are Level " + player.Level);
            Console.WriteLine("You have: " + player.Plrhealth + " HP, " + player.Plrattack + " Attack and " + player.Kills + " Kills");
            Console.WriteLine("Your enemy has: " + npc.NpcHealth + "HP and " + npc.Npcattack + " Attack \n");
        }

        public void Shop(Player player, NPC npc)
        {
            this.player = player;
            this.npc = npc;

            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine("                SHOP                 ");
            Console.WriteLine("=====================================");
            Console.WriteLine("You have " + player.Gold + " Gold");
            Console.WriteLine("1. Health Potion - 25 Gold");
            Console.WriteLine("2. Sword - 125 Gold");
            Console.WriteLine("\nType LEAVE to leave the shop.");
            Console.WriteLine("Type the item's number in order to buy an item");
            Console.WriteLine("Type info and item number in order to see more info about the item\n");

            while (true)
            {

                var shopcommand = CustomReadLine.ReadLine();
                switch (shopcommand)
                {
                    case "leave":
                    case "Leave":
                        MainMenu(player, npc);
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
                        if (player.Gold >= 125)
                        {
                            Console.WriteLine("You bought a Sword");
                            player.Plrattack += 25;
                            player.Gold -= 125;
                            Console.WriteLine("You have " + player.Gold + " Gold    ");
                        }
                        else
                        {
                            Console.WriteLine("You don't have enough gold!");
                        }
                        break;
                    case "info 1":
                        {
                            Console.WriteLine(""" 
                                          _____
                                         `.___,'
                                          (___)
                                          <   >
                                           ) (
                                          /`-.\
                                         /     \
                                        / _    _\
                                       :,' `-.' `:
                                       |         |
                                       :         ;
                                        \       /
                                         `.___.' 
                                       """);
                            Console.WriteLine("+ Restores 10 HP");
                        }
                        break;
                    case "info 2":
                        {
                            Console.WriteLine("\n" + """ 
                                                  />
                                    ()          //---------------------------------------------------------(
                                   (*)OXOXOXOXO(*>                                                          \
                                    ()          \\-----------------------------------------------------------)
                                                  \>

                                   """);
                            Console.WriteLine("\"Dragonfire\" was a sword with a hilt made of dragon bones.");
                            Console.WriteLine("+ Increases attack by 25");
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
