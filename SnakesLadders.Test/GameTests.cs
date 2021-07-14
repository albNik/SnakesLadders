using NUnit.Framework;
using System;

namespace SnakesLadders.Test
{
    [TestFixture]
    public class GameTests
    {


        [Test]
        public void ValidateNumberOfPlayers()
        {
            Assert.Throws<ArgumentException>(() => new Game(-1, 10));
            Assert.Throws<ArgumentException>(() => new Game(1, 10));
            new Game(2, 10);
            new Game(100, 10);
        }

        [Test]
        public void PlayUntilWin()
        {
            var game = new Game(2, 8); //2 players 64 numbers


            for(int i = 0; i < 10; i++)
            {
                game.Move(0, 20);
                Assert.AreEqual(game.Winner, null);
            }
            game.Move(0, 4);
            Assert.AreEqual(game.Winner, 0);

            game.Move(1, 64);  //player 0 has already won
            Assert.AreEqual(game.Winner, 0);
        }


        [Test]
        public void ThreePlayersSameMoves()
        {
            int players = 3;
            var game = new Game(players, boardSize: 10);

            for(int i = 0; i < 1000; i++)
                for(int j = 0; j < players; j++)
                    game.Move(j, 1);

            Assert.AreEqual(0, game.Winner);
        }


        [Test]
        public void ValidateSegments()
        {
            Assert.Throws<ArgumentException>(() => new Segment(5, 5));
            Assert.Throws<ArgumentException>(() => new Segment(5, 10));

            new Segment(5, 3);
            Assert.Pass();
        }


        [Test]
        public void ValidateConflicts()
        {
            var game = new Game(players: 5, boardSize: 10);

            var ladders = new Segment[] { new Segment(5, 1), new Segment(5, 4) };
            var snakes = new Segment[] { new Segment(3, 1), new Segment(7, 6) };
            Assert.Throws<DuplicatePointsException>(() => game.SetLaddersAndSnakes(ladders, snakes));


            ladders = new Segment[] { new Segment(5000, 10), new Segment(40, 20) };
            snakes = new Segment[] { new Segment(3, 1), new Segment(7, 6) };
            Assert.Throws<ArgumentOutOfRangeException>(() => game.SetLaddersAndSnakes(ladders, snakes));



            ladders = new Segment[] { new Segment(50, 10), new Segment(40, 20) };
            snakes = new Segment[] { new Segment(3, 1), new Segment(7, 6) };
            game.SetLaddersAndSnakes(ladders, snakes);
            Assert.Pass();
        }


        [Test]
        public void PlayGameWithOnlyLadders()
        {
            var game = new Game(players: 5, boardSize: 8);
            var ladders = new Segment[] { new Segment(20, 10), new Segment(50, 30) };

            game.SetLaddersAndSnakes(ladders, new Segment[] { });

            game.Move(0, 5);
            Assert.AreEqual(5, game.GetScoreOfPlayer(0));

            game.Move(0, 5);
            Assert.AreEqual(20, game.GetScoreOfPlayer(0));

            game.Move(0, 9);
            Assert.AreEqual(29, game.GetScoreOfPlayer(0));

            game.Move(0, 1);
            Assert.AreEqual(50, game.GetScoreOfPlayer(0));
        }


        [Test]
        public void PlayGameWithLaddersAndSnakes()
        {
            var game = new Game(players: 5, boardSize: 8);
            var ladders = new Segment[] { new Segment(20, 10), new Segment(50, 30) };
            var snakes = new Segment[] { new Segment(25, 15), new Segment(55, 35) };

            game.SetLaddersAndSnakes(ladders, snakes);

            game.Move(0, 5);
            Assert.AreEqual(5, game.GetScoreOfPlayer(0));

            game.Move(0, 5);
            Assert.AreEqual(20, game.GetScoreOfPlayer(0));

            game.Move(0, 5);
            Assert.AreEqual(15, game.GetScoreOfPlayer(0));

            game.Move(0, 20);
            Assert.AreEqual(35, game.GetScoreOfPlayer(0));
        }

    }
}