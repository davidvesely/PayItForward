namespace PayItForward.ConsoleClient.UnitTests.Logger
{
    using System;
    using System.Collections.Generic;
    using Moq;
    using Xunit;

    public class PrintInfoList_Should
    {
        private readonly ConsoleClient.Logger basicLoggerInfo;
        private List<ILoggable> loggables;
        private Mock<IConsoleWrapper> consoleWrapperMock;

        public PrintInfoList_Should()
        {
            this.loggables = new List<ILoggable>();
            this.consoleWrapperMock = new Mock<IConsoleWrapper>();
            this.basicLoggerInfo = new BasicLoggerInfo("BasicLoggerInfo", this.consoleWrapperMock.Object);
        }

        [Fact]
        public void PrintConcreteString()
        {
            // Arrange
            ConsoleClient.ILoggable firstUser = new ConsoleClient.User("Viki", "Penkova", Guid.NewGuid());
            ConsoleClient.ILoggable secondUser = new ConsoleClient.User("Aleks", "Stoycheva", Guid.NewGuid());
            List<PayItForward.ConsoleClient.ILoggable> users = new List<PayItForward.ConsoleClient.ILoggable>
            {
                firstUser,
                secondUser
            };

            // Act
            this.basicLoggerInfo.PrintInfoList(users);

            // Assert
            this.consoleWrapperMock.Verify(x => x.Print(firstUser.LogBasicText), Times.Once);
            this.consoleWrapperMock.Verify(x => x.Print(secondUser.LogBasicText), Times.Once);
        }

        [Fact]
        public void ThrowExceptionIfListIsNull()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => this.basicLoggerInfo.PrintInfoList(null));
        }
    }
}