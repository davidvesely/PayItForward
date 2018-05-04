using System;
using System.Collections.Generic;

namespace PayItForward.ConsoleClient.UnitTests.Logger
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Xunit;

    public class PrintInfoList_Should
    {
        private List<ILoggable> loggables;
        private IConsoleWrapper consoleWrapper;

        public PrintInfoList_Should()
        {
            this.loggables = new List<ILoggable>();
            this.consoleWrapper = new ConsoleWrapper();
    }

        [Fact]
        public void PrintConcreteString()
        {
            List<PayItForward.ConsoleClient.ILoggable> users = new List<PayItForward.ConsoleClient.ILoggable>()
            {
                new ConsoleClient.User("Viki", "Penkova", 21),
                new ConsoleClient.User("Aleks", "Stoycheva", 25)
            };
            StringBuilder expected = new StringBuilder();
            
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                ConsoleClient.Logger basicLoggerInfo = new BasicLoggerInfo("BasicLoggerInfo", this.consoleWrapper);
                this.consoleWrapper.Print("First name:Viki\nLast name:Penkova\nFirst name:Aleks\nLast name:Stoycheva\n");

                foreach (var user in users)
                {
                    expected.Append(user.LogBasicText);
                }

                Assert.Equal(expected.ToString(), sw.ToString());
            }
        }
    }
}
