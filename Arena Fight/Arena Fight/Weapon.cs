using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Fight
{
    class Weapon
    {
        string weaponName;
        string weaponClass;
        string printedWeapon;
        int weaponValue = 0;
        int weaponPower = 0;

        public Weapon(Random rnd, string name, string type)
        {
            weaponName = name;


            switch (type)
            {
                case "Single edged sword ":
                case "Two-Handed sword ":
                case "Battle axe ":
                    weaponClass = "Strength";
                    break;
                case "Short bow ":
                case "Longbow ":
                    weaponClass = "Dexterity";
                    break;
                case "Staff ":
                case "Wand ":
                    weaponClass = "Intelligence";
                    break;
                default:
                    weaponClass = "Don't know!";
                    break;
            }

            weaponPower = rnd.Next(1, 11);

            switch (weaponPower)
            {
                case 1:
                case 2:
                    weaponValue = rnd.Next(4, 9);
                    break;
                case 3:
                case 4:
                    weaponValue = rnd.Next(10, 31);
                    break;
                case 5:
                case 6:
                    weaponValue = rnd.Next(30, 41);
                    break;
                case 7:
                case 8:
                    weaponValue = rnd.Next(40, 51);
                    break;
                case 9:
                case 10:
                    weaponValue = rnd.Next(50, 61);
                    break;
                default:
                    break;
            }

            printedWeapon = weaponName + "\n" +
                            "It is a " + weaponClass + " based weapon" + "\n" +
                            "It costs " + weaponValue + " silver";

        }

        public string PrintStats()
        {
            Console.WriteLine(printedWeapon);
        }

        public string GetPrintedStats()
        {
            return printedWeapon;
        }

        internal int GetValue()
        {
            return weaponValue;
        }

        public int GetPower()
        {
            return weaponPower;
        }

        public string GetWeaponClass()
        {
            return weaponClass;
        }

        internal string GetName()
        {
            return weaponName;
        }
    }
}
