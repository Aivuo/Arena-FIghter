using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Fight
{
    class Orc : Enemy
    {
        public Orc()
        {
            Random rnd = new Random();

            health = rnd.Next(8, 15);
            strength = rnd.Next(5, 10);
            dexterity = rnd.Next(5, 10);
            silver = rnd.Next(5, 16);
        }
    }
}
