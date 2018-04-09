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
            bool gameRunning = true;
            Player player = null;

            while (gameRunning)
            {
                gameRunning = StartMenu(player);
            }
        }

        private static bool StartMenu(Player player)
        {
            //bool playGame = true;
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
                            Console.WriteLine("You have not created a player yet!");
                            Console.ReadKey();
                        }
                        break;
                    case "3":
                        return false;
                        //playGame = false;
                        //break;
                }
            }
        }

        private static Player CreateCharacter()
        {
            Player player = new Player();

            return player;
        }

        private static void RunGame(Player player)
        {
            string menuChoice = "0";
            string[] stats = new string[]{"Strenght", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma"};

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1: Check stats" +
                    "\n 2: Return to menu");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        Console.Clear();
                        foreach (var stat in stats)
                        {
                            Console.WriteLine(stat + ": " + player.GetStats(stat));
                        }
                        Console.ReadKey();
                        break;
                    case "2":
                        //StartMenu(player);
                        return;
                        //break;
                } 
            }
        }
    }
}
