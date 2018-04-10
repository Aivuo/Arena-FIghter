using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Fight
{
    class Fight
    {
        Player player;
        Enemy enemy;
        BattleTurn turn;
        List<String> battleLog;
        Random rnd;

        public Fight(Player playerIn, Enemy enemyIn)
        {
            player = playerIn;
            enemy = enemyIn;
        }

        public void DoBattle()
        {
            while (true)
            {
                rnd = new Random();
                turn = new BattleTurn(player, enemy);

                turn.HitEachother(rnd);

                if (player.GetStats("currentHp") <= 0 || enemy.GetStats("currentHp") <= 0)
                {
                    if (enemy.GetStats("currentHp") <= 0)
                    {
                        player.SetSilver(enemy.GetStats("Silver"));
                    }

                    player.SetBattleLog(battleLog);
                }
            }
        }
    }
}
