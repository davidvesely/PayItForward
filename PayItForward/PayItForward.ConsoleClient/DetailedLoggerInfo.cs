namespace PayItForward.ConsoleClient
{
    using System.Collections.Generic;

    public class DetailedLoggerInfo : BasicLoggerInfo
    {
        public DetailedLoggerInfo(string name)
            : base(name)
        {
        }

        public override List<string> UsersInfo()
        {
            List<string> userinfo = new List<string>();
            foreach (var user in this.Users)
            {
                userinfo.Add("First name: " + user.FirstName + "\nLast name: " + user.LastName + "\nAge: " + user.Age + "\nAmounts: " + user.AvilableMoneyAmount);
            }

            return userinfo;
        }
    }
}
