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

        // VARIABLES
        int dodgeChance = random.Next(0, 100);

        while (true)
        {
            var command = CustomReadLine.ReadLine().ToLower();

            if (command == "attack")
            {

                IsInCombat = true;
                Console.WriteLine($"\nYou attack the enemy for {player.PlrAttack} damage!");
                npc.NpcHealth -= player.PlrAttack;

                if (dodgeChance < 15)
                {
                    Console.WriteLine("You dodged the enemy attack!");
                }
                else
                {
                    Console.WriteLine($"The enemy attacks you for {npc.NpcAttack} damage!");
                    player.PlrHealth -= npc.NpcAttack;
                }

                Console.WriteLine($"\nYou have {player.PlrHealth} HP left!");
                Console.WriteLine($"The enemy has {npc.NpcHealth} HP left!\n");

                if (npc.NpcHealth <= 0)
                {
                    Console.WriteLine("You win for now...\n");
                    player.Kills++;
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
                else if (player.PlrHealth <= 0)
                {
                    Console.WriteLine("You lost hahaahahah");
                    IsInCombat = false;
                    Console.Write("Do you want to try again? (y/n): ");
                    var choice = Console.ReadLine();
                    if (choice == "y")
                    {
                        player.PlrHealth = 100;
                        Console.WriteLine($"Your enemy has { npc.NpcHealth} HP and {npc.NpcAttack} Attack");
                        Console.WriteLine($"You have {player.PlrHealth} ...again");
                    }
                    else
                    {
                        Console.WriteLine("Thanks for playing!");
                        break;
                    }
                }
            }
            else if (command == "quit")
            {
                Console.Clear();
                Console.WriteLine("You quit");
                Thread.Sleep(1000);
                break;
            }

            else if (command == "help")
            {
                Console.WriteLine("Commands: attack, quit, help, shop");
            }
            if (command == "shop" && IsInCombat == true)
            {
                Console.WriteLine("You cannot access the shop while in combat!");
            }
            else if (command == "shop" && IsInCombat == false)
            {
                menu.Shop(player, npc);

            }
        }
    }
}