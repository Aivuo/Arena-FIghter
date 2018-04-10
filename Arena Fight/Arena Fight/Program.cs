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
            bool playerAlive = true;

            string menuChoice = "0";
            //Used to keep check of the stats and to tell GetStats what stats to get.
            string[] stats = new string[] { "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma", "Current Health", "Silver" };
            Enemy enemy = null;
            Fight fight = null;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1: Check stats" +
                    "\n 2: Look for an enemy" +
                    "\n 3: Study your enemy" +
                    "\n 4: Fight your enemy" +
                    "\n 5: Heal (10 silver)" +
                    "\n 6: End " + player.GetName() + "'s run");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        Console.Clear();
                        player.PrintStats();
                        Console.ReadKey();
                        break;
                    case "2":
                        enemy = ChooseOpponent();
                        Console.ReadKey();
                        break;
                    case "3":
                        if(enemy != null)
                            enemy.CheckStats();
                        else
                            Console.WriteLine("You have not found an opponent yet");
                        Console.ReadKey();
                        break;
                    case "4":
                        if (enemy != null)
                        {
                            fight = new Fight(player, enemy);
                            playerAlive = fight.DoBattle();

                            if (playerAlive)
                            {
                                enemy = null;
                            }
                            else
                            {
                                player = EndTheRun(player, enemy);
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("You have not found an opponent yet");
                            Console.ReadKey();
                        }
                        break;
                    case "5":
                        Console.Clear();
                        if (player.GetStats("Silver") >= 10)
                        {
                            player.ChangeStats("Silver", "-", 10);
                            player.HealPlayer();
                            Console.WriteLine("You are now healed!");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("You do not have enough silver.");
                            Console.ReadKey();
                        }
                        break;
                    case "6":
                        //StartMenu(player); //This was stupid of me. Keeping it as a reminder. Don't call the same function in the very same function! Use a loop!
                        player = EndTheRun(player, enemy);
                        return;
                }
            }
        }

        private static Player EndTheRun(Player player, Enemy enemy)
        {
            Console.Clear();

            foreach (var log in player.GetBattleLog())
            {
                Console.WriteLine(log);
            }
            Console.WriteLine("\n \n" + player.GetName() + "'s score is: " + player.GetScore());

            Console.ReadKey();
            player = null;
            enemy = null;
            return player;
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
            Console.WriteLine("You found a foe!");
            return enemy;
        }
    }
}
