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
        public void TestIfListOfUsersIsEmpty()
        {
            Assert.NotEmpty(this.loggerObjAsColorfullLoggerPrint.Users);
            Assert.NotNull(this.loggerObjAsBasicLoggerInfo.Users);
        }

        [Fact]
        public void TestConsoleColor()
        {
            Assert.True(new ColorfulLoggerPrint("Anyway", ConsoleColor.Blue).GetConsoleColor
                == (this.loggerObjAsColorfullLoggerPrint as ColorfulLoggerPrint).GetConsoleColor);
        }
    }
}
