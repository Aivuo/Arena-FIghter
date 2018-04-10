using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Fight
{
    class Program
    {
        static void Main(string[] args)
        {
            //Not really needed right now. But I'm keeping it if i need to change anything. Because right now it only pulls like 0.000000000000000000000001 millisec extra.
            bool gameRunning = true;
            Player player = null;

            while (gameRunning)
            {
                gameRunning = StartMenu(player);
            }
        }

        private static bool StartMenu(Player player)
        {
            //Start menu 
            while (true)
            {
                string menuChoice = "0";

                Console.Clear();
                Console.WriteLine("Chose your option: " +
                    "\n 1: Generate your character" +
                    "\n 2: Start your adventure" +
                    "\n 3: End the game");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        player = CreateCharacter();
                        break;

                    case "2":
                        if (player != null)
                        {
                            RunGame(player);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You have not created a character yet!");
                            Console.ReadKey();
                        }
                        break;
                    //Returns false to for the entire loop and quits out
                    case "3":
                        return false;
                }
            }
        }

        //Strictly needed? No. But looks neater.
        private static Player CreateCharacter()
        {
            Player player = new Player();
            return player;
        }

        private static void RunGame(Player player)
        {
            string menuChoice = "0";
            //Used to keep check of the stats and to tell GetStats what stats to get.
            string[] stats = new string[]{"Strenght", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma"};
            Enemy enemy = null;
            Fight fight = null;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1: Check stats" +
                    "\n 2: Check on your enemy" +
                    "\n 3: Fight your enemy" +
                    "\n 4: Return to menu");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine(player.GetName());
                        foreach (var stat in stats)
                        {
                            Console.WriteLine(stat + ": " + player.GetStats(stat));
                        }
                        Console.ReadKey();
                        break;
                    case "2":
                        enemy = ChooseOpponent();
                        Console.ReadKey();
                        break;
                    case "3":
                        if (enemy != null)
                        {
                            fight = new Fight(player, enemy);
                            fight.DoBattle();
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("You have not found an opponent yet");
                            Console.ReadKey();
                        }
                        break;
                    case "4":
                        //StartMenu(player); //This was stupid of me. Keeping it as a reminder. Don't call the same function in the very same function! Use a loop!
                        return;
                } 
            }
        }

        private static Enemy ChooseOpponent()
        {
            string menuChoice;
            Enemy enemy = null;


            Console.WriteLine("You are searching for an opponent in the wilderness " +
                "\n Do you want to search for a: " +
                "\n 1: Goblin" +
                "\n 2: Orc" +
                "\n 3: Uruk" +
                "\n 4: Or do you back away from your hunt?");

            menuChoice = Console.ReadLine();

            switch (menuChoice)
            {
                case "1":
                    enemy = new Goblin();
                    break;
                case "2":
                    enemy = new Orc();
                    break;
                case "3":
                    enemy = new Uruk();
                    break;
                case "4":
                    enemy = null;
                    break;
            }

            return enemy;
        }
    }
}
