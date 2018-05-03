﻿namespace PayItForward.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DetailedLoggerInfo : BasicLoggerInfo
    {
        public DetailedLoggerInfo(string name, IConsoleWrapper consoleWrapper)
            : base(name, consoleWrapper)
        {
        }

        public override void PrintUsersInfo()
        {
            foreach (var user in this.Users)
            {
                this.ConsoleWrapper.Print($"First name:{user.FirstName}\nLast name:{user.LastName}\nAge:{user.Age}\nAmounts:{user.AvilableMoneyAmount}\n");
            }
        }
    }
}
