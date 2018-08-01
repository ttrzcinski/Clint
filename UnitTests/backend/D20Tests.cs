using Clint.backend;
using Xunit;

namespace UnitTests.backend
{
    public class D20Tests
    {
        private readonly D20 _d20;

        public D20Tests()
        {
            _d20 = new D20();
        }

        [Fact]
        public void RollInRangeTest()
        {
            var score = _d20.Roll();
            Assert.InRange(score, 1, 20);
        }

        [Fact]
        public void InitiallyScoreIsEmptyTest()
        {
            Assert.Equal(_d20.LastScore(), -1);
        }

        [Fact]
        public void ReadLastRollTest()
        {
            var score = _d20.Roll();
            Assert.Equal(_d20.LastScore(), score);
        }
    }
}
