using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Fight
{


    class Goblin : Enemy
    {
        public Goblin()
        {
            Random rnd = new Random();

            currentHp = rnd.Next(5, 10);
            strength = rnd.Next(2, 5);
            dexterity = rnd.Next(8, 15);
            silver = rnd.Next(0, 11);

        }

    }

}
