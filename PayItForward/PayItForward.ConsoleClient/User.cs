namespace PayItForward.ConsoleClient
{
    public class User
    {
        public User(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public int Age { get; }

        public double AvilableMoneyAmount { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
    }
}
