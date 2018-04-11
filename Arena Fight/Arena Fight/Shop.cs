using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Fight
{
    class Shop
    {
        List<Weapon> weapons = new List<Weapon>();
        Random rnd = new Random();
        Player player = null;

        string name;
        string weaponType;
        string[] weaponTypes = new string[] {
            "Single edged sword ",
            "Two-Handed sword ",
            "Battle axe ",
            "Short bow ",
            "Longbow ",
            "Staff ",
            "Wand " };
        string[] weaponAttributes = new string[] {
            "of Beheading",
            "of Martyrdom",
            "of Precise Strikes",
            "of the Huntsman",
            "of Moria",
            "made by the elves of old",
            "made by the Valar in the first era",
            "of Close Enough",
            "passed down through the line of Isildur",
            ", Durin's bane",
            ", never before held by mortal hands", };

        public Shop(Player playerIn)
        {
            player = playerIn;
            for (int i = 0; i < 4; i++)
            {
                name = weaponTypes[rnd.Next(0, 6)];
                weaponType = name;
                if (rnd.Next(0, 3) == 0)
                {
                    name += weaponAttributes[rnd.Next(0, 10)];
                }
                weapons.Add(new Weapon(rnd, name, weaponType));
            }
        }

        public void PrintShop()
        {
            Console.WriteLine(
                " Welcome to the shop" +
                "\n What can I interest you with today?" +
                "\n You currently have: " + player.GetStats("Silver") + " Silver");

            foreach (var weapon in weapons)
            {
                //Console.WriteLine("\n" + weapon + ":");
                weapon.PrintStats();
            }
            Console.WriteLine(
                "\n 5: Heal (10 Silver)" +
                "\n 6: Leave the shop");
        }

        public void BuyWeapon(string weaponChoice)
        {
            int choice = 0;
            int.TryParse(weaponChoice, out choice);
            choice--; 

            if (choice < 3)
            {
                int weaponValue = weapons[choice].GetValue();
                if (player.GetStats("Silver") >= weaponValue)
                {
                    player.ChangeStats("Silver", "-", weaponValue);
                    player.SetWeapon(weapons[choice]);

                    Console.WriteLine(
                        " Here you go! Your new weapon " + weapons[choice].GetName() + "\n" +
                        " Please come again!");
                }
                else
                {
                    Console.WriteLine(
                        " I'm sorry but you do not have enough Silver for that weapon.");
                }

            }
            else
            {
                if (choice == 4)
                {
                    if (player.GetStats("Silver") >= 10)
                    {
                        player.ChangeStats("Silver", "-", 10);
                        player.HealPlayer();
                        Console.WriteLine("You are now healed!");
                    }
                    else
                    {
                        Console.WriteLine("You do not have enough silver.");
                    }
                }
                else
                {
                    Console.WriteLine(" Please come again!");
                }
            }

        }
    }
}
