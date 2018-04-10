using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Fight
{
    class Uruk : Enemy
    {
        public Uruk()
        {
            Random rnd = new Random();

            currentHp = rnd.Next(80, 141);
            strength = rnd.Next(10, 16);
            dexterity = rnd.Next(10, 16);
            silver = rnd.Next(10, 21);

            SetScore();
        }
    }
}
