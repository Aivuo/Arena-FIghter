using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Fight
{
    class Player : Character
    {

        //Just base stats. Aren't sure if all are going to get used but hey.
        int level = 1;
        int maxHp = 1;
        int currentHp = 1;

        int strength = 0;
        int dexterity = 0;
        int constitution = 0;
        int intelligence = 0;
        int wisdom = 0;
        int charisma = 0;
        int silver = 0;

        //Luck is the only one never shown to the player
        int luck = 0;

        string name;
        string choice;

        List<string> battleLog;


        public Player()
        {
            SetName();
            RollStats();
        }

        private void SetName()
        {
            Console.Clear();
            Console.WriteLine("Please write your characters name: ");
            name = Console.ReadLine();
        }

        //Sets the random value once and loops until the player is happ with their stats
        private void RollStats()
        {
            Random rnd = new Random();

            while (true)
            {
                strength = rnd.Next(3, 21);
                dexterity = rnd.Next(3, 21);
                constitution = rnd.Next(3, 21);
                intelligence = rnd.Next(3, 21);
                wisdom = rnd.Next(3, 21);
                charisma = rnd.Next(3, 21);
                luck = rnd.Next(3, 21);

                Console.WriteLine("This is you: " +
                  "\n Your name: " + name +
                  "\n Strenght: " + strength +
                  "\n Dexterity: " + dexterity +
                  "\n Constitution: " + constitution +
                  "\n Intelligence: " + intelligence +
                  "\n Wisdom: " + wisdom +
                  "\n Charisma: " + charisma +
                  "\n Are you happy with theese stats? y/n"
                  );
                choice = Console.ReadLine();

                if (choice == "n" || choice == "N")
                {
                    Console.Clear();
                    //RollStats();
                }
                else
                {
                    SetStats();
                    return;
                } 
            }
        }

        //Is only called at the start. Subsequent additions to stats through level up or other changes are in ChangeStats
        private void SetStats()
        {
            maxHp = constitution * level;
            currentHp = maxHp;
        }

        //Checks an incoming string to see what value it should send back
        public int GetStats(string statCheck)
        {
            switch (statCheck)
            {
                case "Strenght":
                    return strength;
                case "Dexterity":
                    return dexterity;
                case "Constitution":
                    return constitution;
                case "Intelligence":
                    return intelligence;
                case "Wisdom":
                    return wisdom;
                case "Charisma":
                    return charisma;
                case "Luck":
                    return luck;
                case "currentHp":
                    return currentHp;
                default:
                    return 0;
            }
        }

        public string GetName()
        {
            return name;
        }

        public void ChangeStats(string changeType, string change, int changeValue)
        {
            switch (changeType)
            {
                case "Strength":
                    if (change == "+")
                        strength += changeValue;
                    else
                        strength -= changeValue;
                    break;

                case "Dexterity":
                    if (change == "+")
                        dexterity += changeValue;
                    else
                        dexterity -= changeValue;
                    break;

                case "Constitution":
                    if (change == "+")
                        constitution += changeValue;
                    else
                        constitution -= changeValue;
                    break;

                case "Intelligence":
                    if (change == "+")
                        intelligence += changeValue;
                    else
                        intelligence -= changeValue;
                    break;

                case "Wisdom":
                    if (change == "+")
                        wisdom += changeValue;
                    else
                        wisdom -= changeValue;
                    break;

                case "Charisma":
                    if (change == "+")
                        charisma += changeValue;
                    else
                        charisma -= changeValue;
                    break;

                case "currentHp":
                    if (change == "+")
                        currentHp += changeValue;
                    else
                        currentHp -= changeValue;
                    break;

                case "maxHp":
                    if (change == "+")
                        maxHp += changeValue;
                    else
                        maxHp -= changeValue;
                    break;

                default:
                    break;
            }
        }

        public string GetHighestAtk()
        {
            string highest;

            if (strength >= dexterity && strength >= intelligence)
            {
                highest = "Strength";
            }
            else if (dexterity >= strength && dexterity >= intelligence)
            {
                highest = "Dexterity";
            }
            else
                highest = "Intelligence";

            return highest;
        }

        public void SetBattleLog(List<string> battleLogIn)
        {
            battleLog = battleLogIn;
        }

        public void SetSilver(int income)
        {
            silver += income;
        }
    }
}
