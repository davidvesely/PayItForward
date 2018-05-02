namespace PayItForward.ConsoleClient
{
    using System.Collections.Generic;
    using System.Text;

    public class BasicLoggerInfo : Logger
    {
        public BasicLoggerInfo(string name)
            : base(name)
        {
        }

        public override string UsersInfo()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var user in this.Users)
            {
                builder.Append($"First name:{user.FirstName}\nLast name:{user.LastName}\n");
            }

            return builder.ToString();
        }
    }
}
