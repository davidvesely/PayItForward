namespace PayItForward.ConsoleClient
{
    using System.Collections.Generic;
    using System.Text;

    public class DetailedLoggerInfo : BasicLoggerInfo
    {
        public DetailedLoggerInfo(string name)
            : base(name)
        {
        }

        public override string UsersInfo()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var user in this.Users)
            {
               builder.Append($"First name:{user.FirstName}\nLast name:{user.LastName}\nAge:{user.Age}\nAmounts:{user.AvilableMoneyAmount}\n");
            }

            return builder.ToString();
        }
    }
}
