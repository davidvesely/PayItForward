using Xunit;

namespace PayItForward.ConsoleClient.UnitTests.DetailedLoggerInfo
{
    public class PrintInfoList_Should
    {
        private IConsoleWrapper consoleWrapper;

        public PrintInfoList_Should()
        {
            this.consoleWrapper = new ConsoleWrapper();
        }
    }
}
