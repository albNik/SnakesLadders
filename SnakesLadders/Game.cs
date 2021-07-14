using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakesLadders
{
    public class Game
    {
        private int[] _PlayersScore;
        private int _TotalNumbers;

        public int? Winner { get; private set; }

        public Game(int players, int boardSize)
        {
            if(players < 2)
            {
                throw new ArgumentException("Must be at least 2 players", nameof(players));
            }

            _PlayersScore = new int[players];
            _TotalNumbers = boardSize * boardSize;  // we assume squared shape
        }


        public void Move(int player, int steps)
        {
            if(Winner.HasValue)
            {
                //  throw new Exception("Game has already ended");
                return;
            }

            if(_PlayersScore[player] + steps <= _TotalNumbers)
                _PlayersScore[player] += steps;


            if(_PlayersScore[player] == _TotalNumbers)
                Winner = player;
        }


    }
}
