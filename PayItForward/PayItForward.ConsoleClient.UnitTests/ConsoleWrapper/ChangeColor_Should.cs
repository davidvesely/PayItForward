namespace PayItForward.ConsoleClient
{
    using System;
    using Xunit;

    public class ChangeColor_Should
    {
        private readonly IConsoleWrapper consoleWrapper;

        public ChangeColor_Should()
        {
            this.consoleWrapper = new ConsoleWrapper();
        }

        [Fact]
        public void ChangeConsoleColorToGray()
        {
            // Arrange
            this.consoleWrapper.ChangeColor(ConsoleColor.Gray);

            // Assert
            Assert.Equal(ConsoleColor.Gray, this.consoleWrapper.GetCurrentConsoleColor());
        }
    }
}
