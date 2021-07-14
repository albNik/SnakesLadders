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


        public List<Segment> Ladders { get; private set; } = new List<Segment>();
        public List<Segment> Snakes { get; private set; } = new List<Segment>();

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


        public void SetLaddersAndSnakes(IEnumerable<Segment> ladders, IEnumerable<Segment> snakes)
        {
            //We put restrictions so all segments (ladders and snakes) have distinct Top and Bottom
            //This is to avoid multiple moves or loops

            List<int> allPoints = new List<int>();
            allPoints.AddRange(ladders.Select(x => x.Top));
            allPoints.AddRange(ladders.Select(x => x.Bottom));
            allPoints.AddRange(snakes.Select(x => x.Top));
            allPoints.AddRange(snakes.Select(x => x.Bottom));

            if(allPoints.Count > allPoints.Distinct().Count())
            {
                throw new DuplicatePointsException("Every Ladder and Snake should not meet with any other");
            }

            if(allPoints.Min() < 1 || allPoints.Max() > _TotalNumbers)
            {
                throw new ArgumentOutOfRangeException($"Bottoms and Tops shoud be between 1 and {_TotalNumbers}");
            }


            Ladders = ladders.ToList();
            Snakes = snakes.ToList();
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

            if(Ladders.Any(x => x.Bottom == _PlayersScore[player]))
            {
                _PlayersScore[player] = Ladders.First(x => x.Bottom == _PlayersScore[player]).Top;
            }

            else if(Snakes.Any(x => x.Top == _PlayersScore[player]))
            {
                _PlayersScore[player] = Snakes.First(x => x.Top == _PlayersScore[player]).Bottom;
            }


            if(_PlayersScore[player] == _TotalNumbers)
                Winner = player;
        }


    }
}


