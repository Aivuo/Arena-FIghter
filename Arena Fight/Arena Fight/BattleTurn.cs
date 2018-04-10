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

        string[] hittingMonster = {" hits the opponent square on!", " hits with a strong left hook!", " strikes with a downward blow!"};
        string[] missingMonster = {" misses the opponent by a mile!", " misses by just a couple of millimeters!", " swings over the opponents head!"};

        string[] monsterHitting = {" swings and hits!", " watches! And swings... It's a hit!", " good hit! That's gotta hurt!"};
        string[] monsterMissing = {"What a miss ", "How did you miss ", "Look out for your own swings "};

        public BattleTurn(Player playerIn, Enemy enemyIn)
        {
            player = playerIn;
            enemy = enemyIn;
        }

        internal string HitEachother(Random rnd)
        {
            playerRoll = rnd.Next(0, 21);
            enemyRoll = rnd.Next(0, 21);
            string battleLog;
            int damage = 0;

            //Somewhat convoluted but it gets the players highest atk stat and adds it to he players roll
            playerRoll += player.GetStats(player.GetHighestAtk());
            enemyRoll += enemy.GetStats(enemy.GetHighestAtk());

            if (playerRoll > enemy.GetStats("Dexterity"))
            {
                damage = playerRoll - enemy.GetStats("Dexterity");
                enemy.SetHealth(damage);
                battleLog = player.GetName() + hittingMonster[rnd.Next(0, 3)] + 
                    "\n" + damage + " Damage done! " +
                    "\n" + enemy.GetName() + " has " + enemy.GetStats("currentHp") + " health left";
            }
            else
            {
                battleLog = player.GetName() + missingMonster[rnd.Next(0, 3)] + "\n" + enemy.GetName() + " has " + enemy.GetStats("currentHp") + " health left";
            }

            if (enemy.GetStats("currentHp") > 0)
            {
                if (enemyRoll > player.GetStats("Dexterity"))
                {
                    damage = enemyRoll - player.GetStats("Dexterity");
                    player.ChangeStats("currentHp", "-", damage);
                    battleLog += "\n \n" + enemy.GetName() + monsterHitting[rnd.Next(0, 3)] + "\n" + damage + " Damage done!" + "\n" + player.GetName() + " has " + player.GetStats("currentHp") + " health left";
                }
                else
                {
                    battleLog += "\n \n "  + monsterMissing[rnd.Next(0, 3)] + enemy.GetName();
                }
            }

            Console.WriteLine(battleLog);
            return battleLog;
        }
    }
}
