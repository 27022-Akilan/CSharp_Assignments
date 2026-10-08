namespace SampleProject
{
    /// <summary>
    /// Represents user details and user Creation.
    /// </summary>
    public class User
    {
        private static int userId = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        public User(string userName)
        {
            this.UserId = userId++;
            this.UserName = userName;

            this.OnUserCreation?.Invoke(this);
        }

        /// <summary>
        /// Event that is triggered when the user info is created.
        /// </summary>
        public event Action<User>? OnUserCreation;

        /// <summary>
        /// Gets the user Id.
        /// </summary>
        /// <value>Id of the user.</value>
        public int UserId { get; }

        /// <summary>
        /// Gets the Name of the User.
        /// </summary>
        /// <value>Name of the user.</value>
        public string? UserName { get; }

        /// <summary>
        /// Displays the users information.
        /// </summary>
        public void DisplayUserDetails()
        {
            Console.WriteLine($"User Id : {this.UserId} User Name : {this.UserName}");
        }
    }
}
