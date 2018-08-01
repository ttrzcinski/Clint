using Clint.backend.utilities;
using Xunit;

namespace UnitTests.backend
{
    public class StringExtTests
    {
        [Theory]
        [InlineData(null, null)]
        [InlineData("", null)]
        [InlineData(null, -1)]
        [InlineData(null, 0)]
        [InlineData("", -1)]
        public void SplitAfterNullsTest(string value, int lineLength)
        {
            var score = value.SplitAfter(lineLength);
            Assert.Null(score);
        }
    }
}