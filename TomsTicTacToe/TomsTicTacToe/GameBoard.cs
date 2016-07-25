using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomsTicTacToe
{
    public class GameBoard
    {
       
        public static string drawBoard(string [] boardArray)
        {
            
            int r = 0;
            string board = "";
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            for (int i = 0; i < 5; i++)
            {
                if (i%2 == 0)
                {
                    board += " " + boardArray[i + r] + " | " + boardArray[i + r + 1] + " | " + boardArray[i + r + 2] + "   \n";
                    r ++;
                }
                else if (i%3 == 0 || i == 1)
                {
                    board += "------------\n";
                }

            }
            return board;
        }
    }

}
