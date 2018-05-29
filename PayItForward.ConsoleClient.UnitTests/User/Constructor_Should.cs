using System;
using Xunit;

namespace PayItForward.ConsoleClient.UnitTests.User
{
    public class Constructor_Should
    {
        private IConsoleWrapper consoleWrapper;

        public Constructor_Should()
        {
            this.consoleWrapper = new ConsoleWrapper();
        }

        [Fact]
        public void NotAcceptEmptyNameInConstructor()
        {
            Assert.Throws<ArgumentNullException>(() => new PayItForward.ConsoleClient.User(null, null, 0));
        }
    }
}
