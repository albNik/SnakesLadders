using System;
using System.Collections.Generic;
using System.Text;

namespace SnakesLadders
{
    public class Dice
    {
        private readonly static Random random;
        static Dice()
        {
            random = new Random();
        }

        public  int Roll()
        {
            return random.Next(1, 7);
        }
    }
}
