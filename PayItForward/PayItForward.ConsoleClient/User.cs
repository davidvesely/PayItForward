using EnsureThat;
using System;

namespace PayItForward.ConsoleClient
{
    public class User : ILoggable
    {
        public User(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;

            // if (firstName is null || lastName is null || age == 0)
            // {
            //    throw new ArgumentNullException("Some of the constructor arguments is null!");
            // }
            Ensure.That(firstName).IsNotNullOrEmpty();
            Ensure.That(lastName).IsNotNullOrEmpty();
            Ensure.That(age).IsInRange(0, 110);
        }

        public string LogBasicText
        {
            get
            {
                return $"First name:{this.FirstName}\nLast name:{this.LastName}\n";
            }
        }

        public string LogDetailedText
        {
            get
            {
                return this.LogBasicText + $"Age:{this.Age}\nAmounts:{this.AvilableMoneyAmount}\n";
            }
        }

        protected int Age { get; }

        protected double AvilableMoneyAmount { get; private set; }

        protected string FirstName { get; private set; }

        protected string LastName { get; private set; }
    }
}
