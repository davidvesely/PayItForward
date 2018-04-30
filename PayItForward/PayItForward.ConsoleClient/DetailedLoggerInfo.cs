namespace PayItForward.ConsoleClient
{
    using System;
    using System.Collections.Generic;

    public class DetailedLoggerInfo : BasicLoggerInfo
    {
        public DetailedLoggerInfo(string name)
            : base(name)
        {
        }

        public override List<string> UserInfo()
        {
            List<string> userInfo = new List<string>();
            foreach (var user in this.Users)
            {
                userInfo.Add("First name: " + user.FirstName + "\nLast name: " + user.LastName + "\nId: " + User.UserId + "\nAmounts: " + user.AvilableMoneyAmount);
            }

            return userInfo;
        }
    }
}
