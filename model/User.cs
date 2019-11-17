namespace eclass_updater.model
{
    public class User
    {
        public readonly string userName;
        public readonly string password;
        public Course[] courses;

        public User(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
    }
}
