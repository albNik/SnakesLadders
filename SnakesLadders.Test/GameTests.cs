using NUnit.Framework;
using System;

namespace SnakesLadders.Test
{
    [TestFixture]
    public class GameTests
    {
     

       [Test]
        public void NumberOfPlayers()
        {
            Assert.Throws<ArgumentException>(() => new Game(-1,10));
            Assert.Throws<ArgumentException>(() => new Game(1,10));
            new Game(2, 10);
            new Game(100, 10);
        }


        [Test]
        public void Players()
        {
            int players = 3;
            var game = new Game(players, 10);

            for(int i = 0; i < 1000; i++)
                for(int j = 0; j < players; j++)
                    game.Move(j, 1);

            Assert.AreEqual(0, game.Winner);
        }

    }
}