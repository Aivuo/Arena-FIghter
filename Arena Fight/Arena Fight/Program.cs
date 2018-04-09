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

            while (gameRunning)
            {
                gameRunning = StartMenu();

            }


        }

        private static bool StartMenu()
        {
            string menuChoice;
            Console.Clear();
            Console.WriteLine("Chose your option: " +
                "\n 1: Generate your character" +
                "\n 2: Start your adventure" +
                "\n 3: End the game");
            menuChoice = Console.ReadLine();


            switch (menuChoice)
            {
                case "1":
                    CreateCharacter();
                    break;

                case "2":
                    RunGame();
                    break;
                default:
                    return false;
            }

            return true;
        }

        private static void CreateCharacter()
        {
            Player player = new Player();
        }

        private static void RunGame()
        {
            Console.WriteLine("Will start someday...");
            Console.ReadKey();
        }
    }
}
