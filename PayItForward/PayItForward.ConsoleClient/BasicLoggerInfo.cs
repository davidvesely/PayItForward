namespace PayItForward.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BasicLoggerInfo : CommonLoggerInfo
    {
        public BasicLoggerInfo(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }

        public string UserBasicInfo()
        {
            return string.Format("First name: {0}\nLast name:{1}\nId:{2}", this.FirstName, this.LastName, UserId);
        }
    }
}
