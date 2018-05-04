using Xunit;

namespace PayItForward.ConsoleClient
{
    public class LogDetailedText_Should
    {
        private ILoggable loggable;

        public LogDetailedText_Should()
        {
            this.loggable = new User("Petia", "Asenova", 21);
        }

        [Fact]
        public void ReturnConcreteString()
        {
            string expected = "First name:Petia\nLast name:Asenova\nAge:21\nAmounts:0\n";
            Assert.Equal(expected, this.loggable.LogDetailedText);
        }
    }
}
