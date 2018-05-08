using Moq;
using System;
using Xunit;

namespace PayItForward.ConsoleClient.UnitTests.ColorfulLoggerInfo
{
    public class PrintInfo_Should
    {
        private readonly ConsoleClient.ColorfulLoggerInfo colorfulLoggerInfo;
        private readonly Mock<ConsoleWrapper> mockConsoleColor;
        private readonly ILoggable user;

        public PrintInfo_Should()
        {
            this.mockConsoleColor = new Mock<ConsoleWrapper>();
            this.user = new ConsoleClient.User("Deni", "Doncheva", 23);
            this.colorfulLoggerInfo = new ConsoleClient.ColorfulLoggerInfo("ColorfulLoggerInfo", ConsoleColor.Cyan, this.mockConsoleColor.Object);
        }

        [Fact]
        public void ChangeColorAndPrintDetailedInfo()
        {
            // Arrange 

            // Act

            // Assert

        }
    }
}
