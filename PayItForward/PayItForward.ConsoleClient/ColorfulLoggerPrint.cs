namespace PayItForward.ConsoleClient
{
    using System;
    using System.Collections.Generic;

    public class ColorfulLoggerPrint : DetailedLoggerInfo
    {
        private ConsoleColor color;

        public ColorfulLoggerPrint(string name, ConsoleColor color)
            : base(name)
        {
            this.color = color;
        }

        public ConsoleColor GetConsoleColor { get; }

        public override List<string> UsersInfo()
        {
            return base.UsersInfo();
        }
    }
}
