namespace PayItForward.ConsoleClient
{
    using System;
    using System.Collections.Generic;

    public abstract class Logger
    {
        private readonly IConsoleWrapper consoleWrapper;

        public Logger(string name, IConsoleWrapper consoleWrapper)
        {
            this.consoleWrapper = consoleWrapper;
            this.Name = name;
            this.Users = new List<User>()
            {
                new User("Viki", "Penkova", 21),
                new User("Aleks", "Stoycheva", 24),
                new User("Peter", "Petkov", 25)
            };

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
        }

        public ConsoleColor ConsoleColor { get; set; }

        protected IConsoleWrapper ConsoleWrapper
        {
            get
            {
                return this.consoleWrapper;
            }
        }

        protected List<User> Users { get; }

        protected string Name { get; private set; }

        public string LoggerName()
        {
            return $"Logger Name: {this.Name}\n";
        }

        public abstract void PrintUsersInfo();
    }
}
