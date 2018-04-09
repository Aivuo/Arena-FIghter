﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Fight
{
    public class Player
    {
        int level = 1;
        int maxHp = 1;
        int currentHp = 1;

        int strenght = 0;
        int dexterity = 0;
        int constitution = 0;
        int intelligence = 0;
        int wisdom = 0;
        int charisma = 0;
        int luck = 0;

        string choice;

        public Player()
        {
            RollStats();
        }

        private void RollStats()
        {
            Random rnd = new Random();

            while (true)
            {
                strenght = rnd.Next(3, 21);
                dexterity = rnd.Next(3, 21);
                constitution = rnd.Next(3, 21);
                intelligence = rnd.Next(3, 20);
                wisdom = rnd.Next(3, 21);
                charisma = rnd.Next(3, 21);
                luck = rnd.Next(3, 21);

                Console.WriteLine("Your stats are: " +
                  "\n Strenght: " + strenght +
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

        public int GetStats(string statCheck)
        {
            switch (statCheck)
            {
                case "Strenght":
                    return strenght;
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
                default:
                    return 0;
            }
        }
    }
}