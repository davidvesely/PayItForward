namespace PayItForward.ConsoleClient
{
    public class User
    {
        private static int userId;

        public User(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public static int UserId
        {
            get
            {
                return userId++;
            }
        }

        public double AvilableMoneyAmount { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
    }
}
