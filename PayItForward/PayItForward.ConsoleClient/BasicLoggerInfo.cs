namespace PayItForward.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BasicLoggerInfo : Logger
    {
        public BasicLoggerInfo(string name, IConsoleWrapper consoleWrapper)
            : base(name, consoleWrapper)
        {
        }

        public override void PrintInfo(ILoggable loggable)
        {
            this.ConsoleWrapper.Print(loggable.LogBasicText);
        }
    }
}
