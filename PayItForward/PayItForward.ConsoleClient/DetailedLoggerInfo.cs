namespace PayItForward.ConsoleClient
{
    using System;

    public class DetailedLoggerInfo : BasicLoggerInfo
    {
        public DetailedLoggerInfo(string name)
            : base(name)
        {
        }

        public override void PrintUserInfo()
        {
            foreach (var user in this.Users)
            {
                Console.WriteLine($"First name: {user.FirstName}\nLast name:{user.LastName}\nId:{User.UserId}\n" +
                    $"Amounts:{user.AvilableMoneyAmount} ");
            }
        }
    }
}
