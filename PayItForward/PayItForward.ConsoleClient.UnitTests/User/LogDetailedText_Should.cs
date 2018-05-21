namespace PayItForward.ConsoleClient
{
    using System;
    using Xunit;

    public class LogDetailedText_Should
    {
        private User loggable;
        private Guid id;

        public LogDetailedText_Should()
        {
            this.id = Guid.NewGuid();
            this.loggable = new User("Petia", "Asenova", id);
        }

        [Fact]
        public void ReturnConcreteString()
        {
            string expected = $"First name:Petia\nLast name:Asenova\nId:{this.id}\nAmounts:0\n";
            Assert.Equal(expected, this.loggable.LogDetailedText);
        }
    }
}
