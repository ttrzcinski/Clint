using Clint.backend.enums;
using Xunit;

namespace UnitTests.backend
{
    public class AutoCommitTest
    {
        [Fact]
        public void OffIsBeforeOnTest()
        {
            Assert.True(AutoCommit.Off < AutoCommit.AutoCommit);
        }
        
        [Fact]
        public void OnIsBeforeOnAndPushTest()
        {
            Assert.True(AutoCommit.AutoCommit < AutoCommit.AutoCommitAndPush);
        }
        
        [Fact]
        public void OnAndPushIsBeforeOnAndPushWithForceTest()
        {
            Assert.True(AutoCommit.AutoCommitAndPush < AutoCommit.AutoCommitAndPushWithForce);
        }
    }
}