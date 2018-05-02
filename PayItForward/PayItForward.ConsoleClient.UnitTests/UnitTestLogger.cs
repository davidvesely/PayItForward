namespace PayItForward.ConsoleClient.UnitTests
{
    using System;
    using Xunit;

    public class UnitTestLogger
    {
        private BasicLoggerInfo loggerObjAsBasicLoggerInfo = new BasicLoggerInfo("BasicLoggerInfo");
        private Logger loggerObjAsDetailedLoggerinfo = new DetailedLoggerInfo("DetailedLoggerInfo");
        private Logger loggerObjAsColorfullLoggerPrint = new ColorfulLoggerPrint("ColorfulLoggerPrint", ConsoleColor.Blue);

        [Fact]
        public void TestTypeOfLoggerAsAnotherLogger()
        {
            Assert.True(this.loggerObjAsColorfullLoggerPrint.GetType() == typeof(ColorfulLoggerPrint));
            Assert.False(this.loggerObjAsDetailedLoggerinfo.GetType() == typeof(Logger));
            Assert.True(this.loggerObjAsDetailedLoggerinfo.GetType() == typeof(DetailedLoggerInfo));
            Assert.False(this.loggerObjAsBasicLoggerInfo.GetType() == typeof(Logger));
        }

        [Fact]
        public void TestLoggerListOfUsers()
        {
            Assert.NotEmpty(this.loggerObjAsColorfullLoggerPrint.Users);
            Assert.True(this.loggerObjAsColorfullLoggerPrint.Users[0].FirstName == "Viki");
            Assert.True(this.loggerObjAsColorfullLoggerPrint.Users[1].FirstName == "Aleks");
            Assert.True(this.loggerObjAsColorfullLoggerPrint.Users[2].FirstName == "Peter");
        }

        [Fact]
        public void TestConsoleColor()
        {
            Assert.True(new ColorfulLoggerPrint("Anyway", ConsoleColor.Blue).GetConsoleColor
                == (this.loggerObjAsColorfullLoggerPrint as ColorfulLoggerPrint).GetConsoleColor);
        }
    }
}
