namespace PayItForward.ConsoleClient
{
    using System;
    using System.Collections.Generic;

    public abstract class CommonLoggerInfo : Logger
    {
        private List<Logger> loggers;

        public CommonLoggerInfo(string firstName, string lastName)
            : base(firstName, lastName)
        {
            this.loggers = new List<Logger>();
        }

        public string PrintFullName()
        {
            return string.Format("First name of user is: {0} {1}.", this.FirstName, this.LastName);
        }

        public string PrintFirstName()
        {
            return string.Format("First name of user is: {0}.", this.FirstName);
        }

        public string PrintLastName()
        {
            return string.Format("Last name of user is: {0}.", this.LastName);
        }

        public virtual List<Logger> AllLogers()
        {
            return this.loggers;
        }
    }
}
