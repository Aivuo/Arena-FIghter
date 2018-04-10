using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Fight
{
    class Enemy
    {
        protected int health = 0;
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
                "\n Health: " + health +
                "\n Strenght: " + strength +
                "\n Dexterity: " + dexterity);
        }
    }


}
