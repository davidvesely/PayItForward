namespace PayItForward.ConsoleClient
{
    using System;
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
            string expected = "First name:Viki\nLast name:Penkova\n";
            Assert.Equal(expected, this.loggable.LogBasicText);
        }
    }
}
