using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            string Continue = "Y";
            do
            {
                WelcomeScreen.printWelcomeScreen();

                List<Player> players;
                GameFlow.PlayersEnterNames(out players);

                GameFlow.PlayersPlaceShips(players);
                ConsoleIO.Clear();
                GameFlow.PlayersTakeShots(players);
                Continue = ConsoleIO.PromptOptions("Do you want to continue? Y/N for yes or no.", new[] {"Y", "N"});
            } while (Continue.ToUpper() =="Y");         
                }

            } 
        }
   