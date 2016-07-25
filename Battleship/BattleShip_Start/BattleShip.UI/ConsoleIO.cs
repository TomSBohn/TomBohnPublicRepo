using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using static System.Int32;

namespace BattleShip.UI
{
    /// <summary>
    /// Input and output with the user
    /// </summary>
    public class ConsoleIO
    {
        public static Coordinate PromptCoordinate()
        {
            Dictionary<char, int> xCoordValues = new Dictionary<char, int>();
            xCoordValues.Add('A', 1);
            xCoordValues.Add('B', 2);
            xCoordValues.Add('C', 3);
            xCoordValues.Add('D', 4);
            xCoordValues.Add('E', 5);
            xCoordValues.Add('F', 6);
            xCoordValues.Add('G', 7);
            xCoordValues.Add('H', 8);
            xCoordValues.Add('I', 9);
            xCoordValues.Add('J', 10);
            string input = PromptString("Enter a Coordinate (ex. A1)");

            bool okay = false;
            int y = 0;
            okay = int.TryParse(input.Substring(1), out y);
            if (okay == false)
            {
                ConsoleIO.DisplayMessage("Try something like B2 or C3");
            }

           
            char xChar = input.ToUpper()[0];
            int x = 0;
            if (xCoordValues.ContainsKey(xChar))
            {
                x = xCoordValues[xChar];
            }
            else
            {
                ConsoleIO.DisplayMessage("Try something like B2 or C3");
            }
           
            return new Coordinate(x, y);
        }

        public static ShipDirection PromptDirection()
        {
            string dirInput = PromptOptions("Enter Direction 0-up,1-down,2-left,3-right", new[] {"0", "1", "2", "3"});
            int i = int.Parse(dirInput);
            //casting integer into shipDirection
            return (ShipDirection) i;
            
        }
        public static string PromptOptions(string message, string[] options)
        {
            bool isValid = false;
            string input;
            do
            {
                input = PromptString(message,true);
                foreach (var option in options)
                {
                    if (option == input)
                    {
                        isValid = true;
                        break;
                    }
                }
                if (isValid)
                {
                    DisplayMessage("Please try a valid input.");
                }
            } while (isValid == false);
            return input;
        }

        public static void DisplayBoardSetup(Board board)
        {

            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  A|B|C|D|E|F|G|H|I|J ");
            for (int i = 1; i < 11; i++)
            {
                Console.Write(i.ToString().PadLeft(2));
                for (int j = 1; j < 11; j++)
                {
                    string marker = "~ ";
                    var ships = from s in board.GetShips()
                        where s != null && s.BoardPositions.Any(b => b.XCoordinate == j && b.YCoordinate == i)
                        select s;
                    if (ships.Any())
                    {
                        switch (ships.FirstOrDefault().ShipType)
                        {
                            case ShipType.Destroyer:
                                marker = "D ";
                                break;
                            case ShipType.Submarine:
                                marker = "S ";
                                break;
                            case ShipType.Cruiser:
                                marker = "C ";
                                break;
                            case ShipType.Battleship:
                                marker = "B ";
                                break;
                            case ShipType.Carrier:
                                marker = "A ";
                                break;
                            default:
                                break;
                        }
                    }
                    
                                Console.Write(marker);

                    
                }
                Console.WriteLine();
            }
            
        }

        public static void DisplayShotHistory(Board board)
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  A|B|C|D|E|F|G|H|I|J");
            for (int i = 1; i < 11; i++)
            {
                Console.Write(i.ToString().PadLeft(2));
                for (int j = 1; j < 11; j++)
                {
                    string marker = "~ ";
                    var coordinate = new Coordinate(j, i);
                    if (!board.ShotHistory.ContainsKey(coordinate))
                    {
                        Console.Write(marker);
                        continue;
                    }
                    ShotHistory shotTaken = board.ShotHistory[coordinate];
                    switch (shotTaken)
                    {
                        case ShotHistory.Hit:
                            Console.ForegroundColor = ConsoleColor.Red;
                            marker = "H ";
                            break;
                        case ShotHistory.Miss:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            marker = "M ";
                            break;
                        case ShotHistory.Unknown:
                            marker = "~ ";
                            break;
                        default:
                            marker = "~ ";
                            break;
                    }
                    Console.Write(marker);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Displays a message to the user
        /// </summary>
        /// <param name="message">Input a message to the user</param>
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static string PromptString(string message, bool isRequired)
        {
            if (!isRequired)
            {
                Console.WriteLine(message);
                return Console.ReadLine();
            }
            return PromptString(message);
        }

        /// <summary>
        /// Used to get a string form the user
        /// </summary>
        /// <param name="message">Input message to display to the user</param>
        /// <returns></returns>
        public static string PromptString(string message)
        {
            string result = "";
            do
            {
                DisplayMessage(message);
                result = Console.ReadLine();
            } while (result == "");
            return result;
        }

        public static void Clear()
        {
            Console.Clear();
        }

        
    }
}