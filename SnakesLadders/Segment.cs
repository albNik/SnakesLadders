using System;
using System.Collections.Generic;
using System.Text;

namespace SnakesLadders
{
    public class Segment
    {
        public  int Top { get; private set; }
        public int Bottom { get; private set; }

        public Segment(int top, int bottom)
        {
            if(top<=bottom)
            {
                throw new ArgumentException("Top should be always greater than bottom");
            }

            Top = top;
            Bottom = bottom;
        }
      
    }
}
