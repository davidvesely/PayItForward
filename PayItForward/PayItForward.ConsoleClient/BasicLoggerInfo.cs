namespace PayItForward.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BasicLoggerInfo : Logger
    {
        public BasicLoggerInfo(string name)
            : base(name)
        {
        }

        public override void PrintUserInfo()
        {
            foreach (var user in this.Users)
            {
                Console.WriteLine($"First name: {user.FirstName}\nLast name:{user.LastName}\n");
            }
        }
    }
}
