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
            var game = new Game( 2, 8); //2 players 64 numbers


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
        public void Players()
        {
            int players = 3;
            var game = new Game(players, boardSize: 10);

            for(int i = 0; i < 1000; i++)
                for(int j = 0; j < players; j++)
                    game.Move(j, 1);

            Assert.AreEqual(0, game.Winner);
        }

    }
}