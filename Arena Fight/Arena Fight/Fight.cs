using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Fight
{
    class Fight
    {
        int silver = 0;

        Player player;
        Enemy enemy;
        BattleTurn turn;
        List<string> battleLog;
        Random rnd;

        public Fight(Player playerIn, Enemy enemyIn)
        {
            player = playerIn;
            enemy = enemyIn;
        }

        public bool DoBattle()
        {
            battleLog = new List<string>();
            rnd = new Random();

            while (true)
            {
                turn = new BattleTurn(player, enemy);
                bool playerAlive = true;

                battleLog.Add(turn.HitEachother(rnd));

                if (player.GetStats("currentHp") <= 0 || enemy.GetStats("currentHp") <= 0)
                {
                    player.SetBattleLog(battleLog);

                    if (enemy.GetStats("currentHp") <= 0)
                    {
                        silver = enemy.GetStats("Silver");
                        player.SetSilver(silver);
                        Console.WriteLine(player.GetName() + " gained " + silver + " silver");
                        playerAlive = true;
                        player.SetScore(enemy.GetScore());
                    }
                    else
                        playerAlive = false;

                    Console.ReadKey();
                    return playerAlive;
                }
            }
        }
    }
}
