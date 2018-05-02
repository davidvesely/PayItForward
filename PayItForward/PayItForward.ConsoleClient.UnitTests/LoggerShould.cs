namespace PayItForward.ConsoleClient.UnitTests
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class LoggerShould
    {
        private BasicLoggerInfo loggerObjAsBasicLoggerInfo = new BasicLoggerInfo("BasicLoggerInfo");
        private Logger loggerObjAsDetailedLoggerInfo = new DetailedLoggerInfo("DetailedLoggerInfo");
        private Logger loggerObjAsColorfullLoggerInfo = new ColorfulLoggerInfo("ColorfulLoggerPrint", ConsoleColor.Blue);

        [Fact]
        public void TestConsoleColor()
        {
            Assert.True(new ColorfulLoggerInfo("Anyway", ConsoleColor.Blue).GetConsoleColor
                == (this.loggerObjAsColorfullLoggerInfo as ColorfulLoggerInfo).GetConsoleColor);
        }

        [Fact]
        public void HaveAllexpectedUsersInLoggerList()
        {
            var expectedUsers = new List<User>()
            {
                new User("Viki", "Penkova", 21),
                new User("Aleks", "Stoycheva", 24),
                new User("Peter", "Petkov", 25)
            };

            foreach (var user in expectedUsers)
            {
                Assert.Contains(user, expectedUsers);
            }
        }

        [Fact]
        public void CheckForTypeEquality()
        {
            Assert.IsType<BasicLoggerInfo>(this.loggerObjAsBasicLoggerInfo);
            Assert.IsType<DetailedLoggerInfo>(this.loggerObjAsDetailedLoggerInfo);
            Assert.IsType<ColorfulLoggerInfo>(this.loggerObjAsColorfullLoggerInfo);
        }

        [Fact]
        public void CheckForAssignebleTypes()
        {
            Assert.IsAssignableFrom<Logger>(this.loggerObjAsColorfullLoggerInfo);
            Assert.IsAssignableFrom<Logger>(this.loggerObjAsDetailedLoggerInfo);
            Assert.IsAssignableFrom<Logger>(this.loggerObjAsBasicLoggerInfo);
        }

        [Fact]
        public void ShouldCreateSeparateInstances()
        {
            BasicLoggerInfo loggerObjAsBasicLoggerInfo = new BasicLoggerInfo("BasicLoggerInfo");

            Assert.NotSame(this.loggerObjAsBasicLoggerInfo, loggerObjAsBasicLoggerInfo);
        }

        [Fact]
        public void NotAllowNullName()
        {
            Assert.Throws<ArgumentNullException>(() => new BasicLoggerInfo(null));
            Assert.Throws<ArgumentNullException>(() => new DetailedLoggerInfo(null));
            Assert.Throws<ArgumentNullException>(() => new ColorfulLoggerInfo(null, ConsoleColor.Blue));
        }

        [Fact]
        public void 
    }
}
