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

        public override void PrintUserInfo()
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = this.color;
            base.PrintUserInfo();
            Console.ForegroundColor = previousColor;
        }
    }
}
