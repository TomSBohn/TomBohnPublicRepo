using System.Collections.Generic;
using BattleShip.BLL.GameLogic;

namespace BattleShip.UI
{
    public class Player
    {
        public Board Board { get; }
        public string Name { get; set; }
        public static int shipTotal = 0;

        public Player()
        {
            this.Board = new Board();
        }
        
    }
}