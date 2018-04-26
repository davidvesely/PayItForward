using System;
using System.Collections.Generic;
using System.Text;

namespace PayItForward.ConsoleClient
{
    public class Logger
    {
        public Logger(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public static int UserId
        {
            get
            {
                return UserId;
            }

            set
            {
                UserId = UserId++;
            }
        }

        public double AvilableMoneyAmount { get; set; }

        protected string FirstName { get; private set; }

        protected string LastName { get; private set; }
    }
}
