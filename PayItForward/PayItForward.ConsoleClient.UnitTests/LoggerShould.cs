namespace PayItForward.ConsoleClient.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
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
        public void TestUsersInfoFunction()
        {
            string expected = string.Empty;
            StringBuilder builder = new StringBuilder();

            if (this.loggerObjAsBasicLoggerInfo is BasicLoggerInfo)
            {
                builder.Append($"First name:Viki\nLast name:Penkova\nFirst name:Aleks\nLast name:Stoycheva\nFirst name:Peter\nLast name:Petkov\n");
                Assert.Equal(this.loggerObjAsBasicLoggerInfo.UsersInfo(), builder.ToString());
            }
            else if (this.loggerObjAsDetailedLoggerInfo is DetailedLoggerInfo)
            {
                builder.Append($"First name:Viki\nLast name:Penkova\nAge:21\nAmounts:0\n" +
                    $"First name:Aleks\nLast name:Stoycheva\nAge:24\nAmounts:0\n" +
                    $"First name:Peter\nLast name:Petkov\nAge:25\nAmounts:0\n");
                Assert.Equal(this.loggerObjAsDetailedLoggerInfo.UsersInfo(), builder.ToString());
            }
            else if (this.loggerObjAsColorfullLoggerInfo is ColorfulLoggerInfo)
            {
                builder.Append($"First name:Viki\nLast name:Penkova\nAge:21\nAmounts:0\n" +
                    $"First name:Aleks\nLast name:Stoycheva\nAge:24\nAmounts:0\n" +
                    $"First name:Peter\nLast name:Petkov\nAge:25\nAmounts:0\n");
                Assert.True(this.loggerObjAsColorfullLoggerInfo.GetConsoleColor == ConsoleColor.Blue &&
                    this.loggerObjAsColorfullLoggerInfo.UsersInfo().Equals(builder.ToString()));
            }
            else
            {
                Assert.Null(this);
            }
        }
    }
}
