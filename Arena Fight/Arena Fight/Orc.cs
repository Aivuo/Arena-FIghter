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

            currentHp = rnd.Next(50, 66);
            strength = rnd.Next(5, 10);
            dexterity = rnd.Next(5, 10);
            silver = rnd.Next(5, 16);

            SetScore();
        }
    }
}
