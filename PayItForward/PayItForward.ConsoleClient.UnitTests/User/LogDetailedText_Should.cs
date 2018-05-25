namespace PayItForward.ConsoleClient
{
    using System;
    using Xunit;

    public class LogDetailedText_Should
    {
        private User user;
        private Guid id;

        public LogDetailedText_Should()
        {
            this.id = Guid.NewGuid();
            this.user = new User("Petia", "Asenova", this.id);
        }

        [Fact]
        public void ReturnConcreteString()
        {
            string expected = $"First name:Petia\nLast name:Asenova\nId:{this.id}\nAmounts:0\n";
            Assert.Equal(expected, this.user.LogDetailedText);
        }
    }
}
