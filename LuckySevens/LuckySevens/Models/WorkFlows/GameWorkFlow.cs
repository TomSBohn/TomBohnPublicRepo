using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LuckySevens.Models.WorkFlows
{
    public class GameWorkFlow
    {
        private static Random dieRoller = new Random();

        public void PlayGame(Player player)
        {
            var currentWinnings = player.StartingBet;
            player.MaxWinnings = currentWinnings;

            do
            {
                int die1 = dieRoller.Next(1, 7);
                int die2 = dieRoller.Next(1, 7);

                int sum = die1 + die2;

                player.TimesRolled++;

                if (sum == 7)
                {
                    currentWinnings += 4;
                    if (player.MaxWinnings < currentWinnings)
                    {
                        player.MaxWinnings = currentWinnings;
                        player.MaxWinningsRolled = player.TimesRolled;
                    }
                }
                else
                {
                    currentWinnings -= 1;
                }


            } while (currentWinnings > 0);
        }
    }
}