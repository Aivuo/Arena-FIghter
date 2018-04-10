using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Fight
{
    class Enemy : Character
    {
        protected int currentHp = 0;
        protected int strength = 0;
        protected int dexterity = 0;
        protected int silver = 0;

        protected string name;
        protected string[] nameList = new string[] { "Azog", "Balcmeg", "Boldog", "Bolg", "Golfimbul", "Gorbag", "Gorgol", "Grishnákh", "Lagduf"};

        public Enemy()
        {
            Random rnd = new Random();

            name = nameList[rnd.Next(0, 8)];
        }

        public virtual void Attack()
        {

        }

        public virtual void Defend()
        {

        }

        public virtual void CheckStats()
        {
            Console.WriteLine("Name: " + name +
                "\n Health: " + currentHp +
                "\n Strength: " + strength +
                "\n Dexterity: " + dexterity);
        }

        public int GetStats(string statCheck)
        {
            int value = 0;

            switch (statCheck)
            {
                case "Strength":
                    value = strength;
                    break;
                case "Dexterity":
                    value = dexterity;
                    break;
                case "currentHp":
                    value = currentHp;
                    break;
                case "Silver":
                    value = silver;
                    break;
            }
                    return value;
        }

        public string GetHighestAtk()
        {
            string highest;

            if (strength >= dexterity)
            {
                highest = "Strength";
            }
            else
            {
                highest = "Dexterity";
            }

            return highest;
        }

        public void SetHealth(int value)
        {
            currentHp -= value;
        }
    }


}
