namespace PayItForward.ConsoleClient
{
    using System;
    using System.IO;
    using System.Text;
    using Xunit;

    public class Print_Should
    {
        private readonly IConsoleWrapper consoleWrapper;

        public Print_Should()
        {
            this.consoleWrapper = new ConsoleWrapper();
        }

        [Fact]
        public void LogATextToTheConsole()
        {
            // Arrange
            StringBuilder expected = new StringBuilder();

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                this.consoleWrapper.Print("This is test string");
                expected.Append(sw);

                // Assert
                Assert.Equal(expected.ToString(), sw.ToString());
            }
        }
    }
}
