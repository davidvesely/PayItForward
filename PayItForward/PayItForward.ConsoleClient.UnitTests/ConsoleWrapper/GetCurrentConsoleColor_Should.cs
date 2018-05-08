namespace PayItForward.ConsoleClient
{
    using System;
    using Xunit;

    public class GetCurrentConsoleColor_Should
    {
        private readonly IConsoleWrapper consoleWrapper;
        private readonly Logger colorfulLoggerInfo;

        public GetCurrentConsoleColor_Should()
        {
            this.consoleWrapper = new ConsoleWrapper();
            this.colorfulLoggerInfo = new ColorfulLoggerInfo("ColorfulLoggerInfo", ConsoleColor.Cyan, this.consoleWrapper);
        }

        [Fact]
        public void ReturnCurrentConsoleColor()
        {
            // Arrange
            this.consoleWrapper.ChangeColor(this.colorfulLoggerInfo.ConsoleColor);

            // Assert
            Assert.Equal(this.colorfulLoggerInfo.ConsoleColor, this.consoleWrapper.GetCurrentConsoleColor());
        }
    }
}
