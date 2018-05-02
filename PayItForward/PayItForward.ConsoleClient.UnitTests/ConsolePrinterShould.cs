namespace PayItForward.ConsoleClient.UnitTests
{
    using Microsoft.VisualStudio.TestPlatform.Utilities;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Xunit;

    public class ConsolePrinterShould
    {
        private ConsolePrinter consolePrinter = new ConsolePrinter();

        [Fact]
        public void ShouldPrintBasicLoggerInfo()
        {
            Logger basicLoggerInfo = new BasicLoggerInfo("BasicLoggerInfo");

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                this.consolePrinter.Print(basicLoggerInfo);

                string expected = basicLoggerInfo.LoggerName() + basicLoggerInfo.UsersInfo();
                Assert.Equal(expected, sw.ToString());
            }
        }
    }
}
