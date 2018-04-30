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

        public override List<string> UserInfo()
        {
            List<string> userInfo = new List<string>();
            foreach (var user in this.Users)
            {
                userInfo.Add("First name: " + user.FirstName + "\nLast name: " + user.LastName);
            }

            return userInfo;
        }
    }
}
