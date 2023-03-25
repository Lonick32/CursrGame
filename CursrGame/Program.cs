using CursrGame;

class Program
{
    static void Main()
    {
        bool isRunning = true;

        Thread inputThread = new(() =>
        {
            while (isRunning)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.KeyChar == 'P' || keyInfo.KeyChar == 'p')
                {
                    isRunning = false;

                }
                else if (keyInfo.KeyChar == 'Q' || keyInfo.KeyChar == 'q')
                {
                    return;
                }
            }
        });

        inputThread.Start();

        while (isRunning)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            SkullImage.Skull1();
            SkullImage.CursrLogo();
            Console.WriteLine("Press P to play or Q to quit\nType HELP for commands");
            Thread.Sleep(1000);
            Console.Clear();
            SkullImage.Skull2();
            SkullImage.CursrLogo();
            Console.WriteLine("Press P to play or Q to quit\nType HELP for commands");
            Thread.Sleep(1000);
        }

        inputThread.Join();
        Console.Clear();

        Random random = new();
        Player player = new();
        NPC npc = new();
        Menu menu = new();

        bool IsInCombat = false;


        menu.MainMenu(player, npc);


        while (true)
        {
            var command = CustomReadLine.ReadLine();

            if (command == "attack" || command == "Attack")
            {

                IsInCombat = true;
                Console.WriteLine("\nYou attack the enemy for " + player.Plrattack + " damage!");
                npc.NpcHealth -= player.Plrattack;

                if (random.Next(0, 100) < 15)
                {
                    Console.WriteLine("You dodged the enemy attack!");
                }
                else
                {
                    Console.WriteLine("The enemy attacks you for " + npc.Npcattack + " damage!");
                    player.Plrhealth -= npc.Npcattack;
                }

                Console.WriteLine("\nYou have " + player.Plrhealth + " HP left!");
                Console.WriteLine("The enemy has " + npc.NpcHealth + " HP left!\n");

                if (npc.NpcHealth <= 0)
                {
                    Console.WriteLine("You win for now...\n");
                    player.Kills += 1;
                    player.Gold += player.GiveGold;
                    player.GainExperience(random.Next(2, 100));
                    IsInCombat = false;
                    Console.Write("Do you want to try again? (y/n): ");
                    var choice = Console.ReadLine();
                    if (choice == "y")
                    {
                        npc.NpcHealth = random.Next(1, 150);
                        menu.MainMenu(player, npc);

                    }
                    else
                    {
                        Console.WriteLine("Thanks for playing!");
                        break;
                    }
                }
                else if (player.Plrhealth <= 0)
                {
                    Console.WriteLine("You lost hahaahahah");
                    IsInCombat = false;
                    Console.Write("Do you want to try again? (y/n): ");
                    var choice = Console.ReadLine();
                    if (choice == "y")
                    {
                        player.Plrhealth = 100;
                        Console.WriteLine("Your enemy has " + npc.NpcHealth + "HP and " + npc.Npcattack + " Attack");
                        Console.WriteLine("You have " + player.Plrhealth + "...again");
                    }
                    else
                    {
                        Console.WriteLine("Thanks for playing!");
                        break;
                    }
                }
            }
            else if (command == "quit" || command == "Quit")
            {
                Console.Clear();
                Console.WriteLine("You quit");
                break;
            }

            else if (command == "help" || command == "Help")
            {
                Console.WriteLine("Commands: attack, quit, help, shop");
            }
            if ((command == "shop" || command == "Shop") && IsInCombat == true)
            {
                Console.WriteLine("You cannot access the shop while in combat!");
            }
            else if ((command == "shop" || command == "Shop") && IsInCombat == false)
            {
                menu.Shop(player, npc);

            }
        }
    }
}