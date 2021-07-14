using System;
using System.Collections.Generic;
using System.Text;

namespace SnakesLadders
{
    /// <summary>
    /// Throw when two segments meet 
    /// </summary>
    public class DuplicatePointsException : Exception
    {
        public DuplicatePointsException()
        {
        }

        public DuplicatePointsException(string message)
            : base(message)
        {
        }

        public DuplicatePointsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
