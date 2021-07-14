using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnakesLadders.Test
{
    [TestFixture]
    public class DiceTests
    {
        [Test]
        public void TestBounds()
        {
            Dice dice = new Dice();

            for(int i = 0; i < 1000; i++)
            {
                Assert.LessOrEqual(dice.Roll(),6 );
            }
            for(int i = 0; i < 1000; i++)
            {
                Assert.GreaterOrEqual(dice.Roll(), 1);
            }
        }
    }

}
