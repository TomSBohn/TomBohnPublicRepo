using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TomsTicTacToe
{
    public class Program
    {
        public static void Main(string[] args, int move)
        {
            //starting screen

            GameBoard gb = new GameBoard();
            Console.WriteLine("Welcome to Tic Tac Toe");
            Console.WriteLine("Player 1. Please enter your name: ");
            List<string> players = new List<string>();
            players.Add(Console.ReadLine());

            Console.WriteLine("Player 2. Please enter your name: ");
            players.Add(Console.ReadLine());

            string[] boardArray = new string[9] {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
            string board = GameBoard.drawBoard(boardArray);
            Console.WriteLine(board);
            bool isGameOver = false;
            do
            {
                for (int i = 0; i < players.Count; i++)
                {
                    int j = 0;
                    bool moveOK = false;

                    Console.WriteLine($"{players[i]} please make your move.");

                    moveOK = int.TryParse(Console.ReadLine(), out j);
                    if (moveOK == false)
                    {
                        Console.WriteLine("Please enter 1-9"); 
                    }
                   
                    string marker = "X";
                    if (i == 0)
                    {
                        marker = "O";
                    }
                    boardArray[move - 1] = marker;
                    Console.WriteLine(GameBoard.drawBoard(boardArray));
                    if (WinCheck.checkWin(boardArray) == true)
                    {
                        isGameOver = true;
                        break;
                    }

                }
            } while (!isGameOver);


        }
    }
}

// allow 3 overwrites as long as it is not a winning move?
