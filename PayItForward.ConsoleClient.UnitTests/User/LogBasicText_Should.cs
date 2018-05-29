﻿namespace PayItForward.ConsoleClient
{
    using Xunit;

    public class LogBasicText_Should
    {
        private ILoggable loggable;

        public LogBasicText_Should()
        {
            this.loggable = new User("Viki", "Penkova", 21);
        }

        [Fact]
        public void ReturnConcreteString()
        {
            // Arrange
            string expected = "First name:Viki\nLast name:Penkova\n";

            // Assert
            Assert.Equal(expected, this.loggable.LogBasicText);
        }
    }
}
