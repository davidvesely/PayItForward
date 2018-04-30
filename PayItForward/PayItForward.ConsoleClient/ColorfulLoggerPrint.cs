namespace PayItForward.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ColorfulLoggerPrint : DetailedLoggerInfo
    {
        private ConsoleColor color;

        public ColorfulLoggerPrint(string name, ConsoleColor color)
            : base(name)
        {
            this.color = color;
        }

        public ConsoleColor GetConsoleColor { get; }

        public override List<string> UserInfo()
        {
            return base.UserInfo();
        }
    }
}
