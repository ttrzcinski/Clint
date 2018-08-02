using Clint.backend.utilities;
using Xunit;

namespace UnitTests.backend
{
    public class StringExtTests
    {
        [Theory]
        [InlineData(null, -1)]
        [InlineData(null, 0)]
        [InlineData("", -1)]
        public void SplitAfterNullsTest(string value, int lineLength)
        {
            var actual = value.SplitAfter(lineLength);
            Assert.Null(actual);
        }

        [Theory]
        [InlineData("some value", 15)]
        public void SplitAfterTooShortTest(string value, int lineLength)
        {
            var actual = value.SplitAfter(lineLength);
            Assert.NotNull(actual);
            Assert.Equal("some value", actual[0]);
        }

        [Theory]
        [InlineData("some value", 3)]
        public void SplitAfterTooLongTest(string value, int lineLength)
        {
            var actual = value.SplitAfter(lineLength);
            Assert.NotNull(actual);
            Assert.Equal("som", actual[0]);
        }
    }
}