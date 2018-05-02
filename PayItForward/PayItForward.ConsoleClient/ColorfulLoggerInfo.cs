namespace PayItForward.ConsoleClient
{
    using System;
    using System.Collections.Generic;

    public class ColorfulLoggerInfo : DetailedLoggerInfo
    {
        public ColorfulLoggerInfo(string name, ConsoleColor color)
            : base(name)
        {
            this.GetConsoleColor = color;
        }

        public override string UsersInfo()
        {
            return base.UsersInfo();
        }
    }
}
