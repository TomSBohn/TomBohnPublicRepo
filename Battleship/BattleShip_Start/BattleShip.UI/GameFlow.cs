using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class GameFlow
    {
      
        public static void PlayersPlaceShips(List<Player> players)
        {
            foreach (var player in players)
            {
                ConsoleIO.Clear();
                ConsoleIO.DisplayMessage($"{player.Name}, please place your ships:");
                for (int i = 0; i < 5; i++)
                {
                    bool isValid = false;
                    while (!isValid)
                    {
                         ConsoleIO.DisplayBoardSetup(player.Board);
                        ShipType shipType = (ShipType)i;
                        int space = 0;
                        switch (shipType)
                        {
                            case ShipType.Destroyer:
                                space = 2;
                                break;
                            case ShipType.Cruiser:
                                space = 3;
                                break;
                            case ShipType.Submarine:
                                space = 3;
                                break;
                            case ShipType.Battleship:
                                space = 4;
                                break;
                            default:
                                space = 5;
                                break;
                        }
                        ConsoleIO.DisplayMessage($"Place your ship. It's {shipType.ToString()} which is {space} spaces.");
                        PlaceShipRequest request = new PlaceShipRequest();
                        request.ShipType = shipType;
                        request.Coordinate = ConsoleIO.PromptCoordinate();
                        request.Direction = ConsoleIO.PromptDirection();
                        ShipPlacement response = player.Board.PlaceShip(request);
                        switch (response)
                        {
                            case ShipPlacement.NotEnoughSpace:
                                ConsoleIO.DisplayMessage("There's not enough space. Try again.");
                                break;
                            case ShipPlacement.Overlap:
                                ConsoleIO.DisplayMessage("Your ships cannot overlap each other. Try again.");
                                break;
                            case ShipPlacement.Ok:
                                isValid = true;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                }
            }

        }
        public static void PlayersTakeShots(List<Player> players)
        {
            bool isVicitory = false;
            while (isVicitory == false)
            {
                for (int index = 1; index < 3; index++)
                {
                    var player = players[index-1];
                    var opponite = players[index%2];

                    ConsoleIO.DisplayMessage($"{player.Name}, please select a location to take a shot.");
                    bool isValid = false;
                    while (!isValid)
                    {

                        Coordinate coordinate = ConsoleIO.PromptCoordinate();
                        FireShotResponse response = opponite.Board.FireShot(coordinate);
                        switch (response.ShotStatus)
                        {
                            case ShotStatus.Duplicate:
                                ConsoleIO.DisplayMessage("You already tried that spot. Try again.");
                                break;
                            case ShotStatus.Hit:
                                ConsoleIO.DisplayMessage("Hit!");
                                Console.Beep(1000, 550);
                                isValid = true;
                                break;
                            case ShotStatus.HitAndSunk:
                                ConsoleIO.DisplayMessage("Hit and sunk!");
                                Console.Beep(700, 300);
                                Console.Beep(800, 300);
                                Console.Beep(1000, 550);
                                isValid = true;
                                break;
                            case ShotStatus.Invalid:
                                ConsoleIO.DisplayMessage("That's not within the board.");
                                break;
                            case ShotStatus.Miss:
                                ConsoleIO.DisplayMessage("Miss!");
                                Console.Beep(390, 550);
                                isValid = true;
                                break;
                            case ShotStatus.Victory:
                                ConsoleIO.DisplayMessage($"{player.Name}, You win!!!!");
                                isValid = true;
                                isVicitory = true;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                    ConsoleIO.DisplayShotHistory(opponite.Board);

                    if (isVicitory == true)
                    {
                        break;
                    }
//I want to clear the board on each turn, but don't know where to use ConsoleIO.Clear();

                }

            }
        }

        public static void PlayersEnterNames(out List<Player> players)
        {
            players = new List<Player>();
            players.Add(new Player()
            {
                Name = ConsoleIO.PromptString("Player 1, Enter your name", true)
            });
            players.Add(new Player()
            {
                Name = ConsoleIO.PromptString("Player 2, Enter your name", true)
            });
          
        }
    }
   }

