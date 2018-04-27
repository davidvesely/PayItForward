namespace PayItForward.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Logger
    {
        public Logger(string name)
        {
            this.Name = name;
            this.Users = new List<User>()
            {
                new User("Viki", "Penkova"),
                new User("Aleks", "Stoycheva"),
                new User("Peter", "Petkov")
            };
        }

        protected List<User> Users { get; }

        protected string Name { get; private set; }

        public virtual void PrintLoggerName()
        {
            Console.WriteLine($"Logger name:{this.Name}");
        }

        public abstract void PrintUserInfo();
    }
}
