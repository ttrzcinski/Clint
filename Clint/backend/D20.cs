using System;
using System.Collections.Generic;
using System.Text;

namespace Clint.backend
{
    class D20
    {
        private int theLastScore;

        public int roll()
        {
            Random random = new Random(20);
            theLastScore = random.Next();
            return theLastScore;
        }

        public int lastScore()
        {
            return theLastScore;
        }
    }
}
