using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Fight
{
    class BattleTurn
    {
        private Player player;
        private Enemy enemy;
        int enemyRoll = 0;
        int playerRoll = 0;

        string[] hittingMonster = {"" };
        string[] missingMonster = { "" };

        string[] monsterHitting = { "" };
        string[] monsterMissing = { "" };

        public BattleTurn(Player playerIn, Enemy enemyIn)
        {
            player = playerIn;
            enemy = enemyIn;
        }

        internal void HitEachother(Random rnd)
        {
            playerRoll = rnd.Next(0, 21);
            enemyRoll = rnd.Next(0, 21);

            //Somewhat convoluted but it gets the players highest atk stat and adds it to he players roll
            playerRoll += player.GetStats(player.GetHighestAtk());
            enemyRoll += enemy.GetStats(enemy.GetHighestAtk());

            if (playerRoll > enemy.GetStats("Dexterity"))
            {
                enemy.SetHealth(playerRoll - enemy.GetStats("Dexterity"));
                Console.WriteLine(hittingMonster[rnd.Next(0, 3)]);
            }
        }
    }
}
