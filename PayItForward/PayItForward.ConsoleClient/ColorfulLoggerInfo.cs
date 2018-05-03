namespace PayItForward.ConsoleClient
{
    using System;
    using System.Collections.Generic;

    public class ColorfulLoggerInfo : DetailedLoggerInfo
    {
        public ColorfulLoggerInfo(string name, ConsoleColor color, IConsoleWrapper consoleWrapper)
            : base(name, consoleWrapper)
        {
            this.ConsoleColor = color;
        }

        public override void PrintUsersInfo()
        {
            ConsoleColor previousColor = this.ConsoleWrapper.GetCurrentConsoleColor();
            this.ConsoleWrapper.ChangeColor(this.ConsoleColor);
            base.PrintUsersInfo();
            this.ConsoleWrapper.ChangeColor(previousColor);
        }
    }
}
