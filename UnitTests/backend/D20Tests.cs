using Xunit;
using Clint.backend;

namespace UnitTests
{
    public class D20Tests
    {
        private readonly D20 d20;// = new D20();

        public D20Tests()
        {
            d20 = new D20();
        }

        [Fact]
        public void RollInRangeTest()
        {
            int score = d20.Roll();

            Assert.InRange(score,1,20);
        }

        [Fact]
        public void InitiallyScoreIsEmptyTest()
        {
            Assert.Equal(d20.LastScore(),-1);
        }

        [Fact]
        public void ReadLastRollTest()
        {
            int score = d20.Roll();

            Assert.Equal(d20.LastScore(), score);
        }
    }
}
