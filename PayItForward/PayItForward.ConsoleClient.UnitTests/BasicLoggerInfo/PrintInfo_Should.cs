namespace PayItForward.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Xunit;

    public class PrintInfo_Should
    {
        private IConsoleWrapper consoleWrapper;

        public PrintInfo_Should()
        {
            this.consoleWrapper = new ConsoleWrapper();
        }

        [Fact]
        public void NotAcceptEmptyListAsArgument()
        {
            Assert.Throws<ArgumentNullException>(() => new BasicLoggerInfo(null, this.consoleWrapper).PrintInfoList(new List<ILoggable>()));
        }

        [Fact]
        public void NotAcceptNullArgument()
        {
            Assert.Throws<ArgumentNullException>(() => new BasicLoggerInfo(null, this.consoleWrapper).PrintInfoList(null));
        }

    }
}
