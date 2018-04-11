using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Fight
{
    class Player : Character
    {

        Weapon weapon = null;

        //Just base stats. Aren't sure if all are going to get used but hey.
        int level = 5;
        int maxHp = 1;
        int currentHp = 1;

        int strength = 0;
        int dexterity = 0;
        int constitution = 0;
        int intelligence = 0;
        int wisdom = 0;
        int charisma = 0;

        int silver = 0;
        int score = 0;

        //Luck is the only one never shown to the player
        int luck = 0;

        string name;
        string choice;
        string characterPortrait = "   _ \n" +
            "  |-| \n" +
            " < T > \n" +
            "  | | \n";


        List<string> battleLog;


        public Player()
        {
            SetName();
            RollStats();
            battleLog = new List<string>();
            battleLog.Add("\n This is the story of " + name + "\n \n");
        }

        private void SetName()
        {
            Console.Clear();
            Console.WriteLine(" Please write your characters name: ");
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

                SetStats();

                Console.WriteLine("This is you: ");
                PrintStats();
                Console.WriteLine("\n Are you happy with theese stats? y/n");

                choice = Console.ReadLine();

                if (choice == "n" || choice == "N")
                {
                    Console.Clear();
                    //RollStats();
                }
                else
                {
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
            int value = 0;

            if (weapon != null)
            {
                switch (statCheck)
                {
                    case "Strength":
                        if (weapon.GetWeaponClass() == "Strength")
                        {
                            value = strength + weapon.GetPower(); 
                        }
                        break;
                    case "Dexterity":
                        if (weapon.GetWeaponClass() == "Dexterity")
                        {
                            value = dexterity + weapon.GetPower();
                        }
                        break;
                    case "Constitution":
                        value = constitution;
                        break;
                    case "Intelligence":
                        if (weapon.GetWeaponClass() == "Intelligence")
                        {
                            value = intelligence + weapon.GetPower();
                        }
                        break;
                    case "Wisdom":
                        value = wisdom;
                        break;
                    case "Charisma":
                        value = charisma;
                        break;
                    case "Luck":
                        value = luck;
                        break;
                    case "Current Health":
                    case "currentHp":
                        value = currentHp;
                        break;
                    case "Silver":
                        value = silver;
                        break;
                    default:
                        value = 0;
                        break;
                }
            }
            else
            {
                switch (statCheck)
                {
                    case "Strength":
                        value = strength;
                        break;
                    case "Dexterity":
                        value = dexterity;
                        break;
                    case "Constitution":
                        value = constitution;
                        break;
                    case "Intelligence":
                        value = intelligence;
                        break;
                    case "Wisdom":
                        value = wisdom;
                        break;
                    case "Charisma":
                        value = charisma;
                        break;
                    case "Luck":
                        value = luck;
                        break;
                    case "Current Health":
                    case "currentHp":
                        value = currentHp;
                        break;
                    case "Silver":
                        value = silver;
                        break;
                    default:
                        value = 0;
                        break;
                }
            }

            return value;
        }

        internal void PrintStats()
        {
            Console.WriteLine(
                characterPortrait +
                "\n " + name +
                "\n Strength: " + GetStats("Strength") +
                "\n Dexterity: " + GetStats("Dexterity") +
                "\n Constitution: " + GetStats("Constitution") +
                "\n Intelligence: " + GetStats("Intelligence") +
                "\n Wisdom: " + GetStats("Wisdom") +
                "\n Charisma: " + GetStats("Charisma") +
                "\n \n Current Health: " + currentHp +
                "\n Maximum Health: " + maxHp +
                "\n \n Current Silver: " + silver);

            if (weapon != null)
            {
                Console.WriteLine("\n \n");
                weapon.PrintStats();
            }
        }

        public string GetName()
        {
            return name;
        }

        public int GetScore()
        {
            return score;
        }

        public void SetScore(int value)
        {
            score += value;
        }

        public void SetWeapon(Weapon weaponIn)
        {
            weapon = weaponIn;
            battleLog.Add("\n" + weapon.GetPrintedStats());
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
                case "Silver":
                    silver -= changeValue;
                    break;
                default:
                    break;
            }
        }

        internal void HealPlayer()
        {
            currentHp = maxHp;
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

        public List<string> GetBattleLog()
        {
            return battleLog;
        }

        public void SetBattleLog(List<string> battleLogIn)
        {
            foreach (var log in battleLogIn)
            {
                battleLog.Add(log);
            }
        }

        public void SetSilver(int income)
        {
            silver += income;
        }
    }
}
