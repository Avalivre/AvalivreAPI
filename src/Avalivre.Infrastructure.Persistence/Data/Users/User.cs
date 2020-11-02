namespace Avalivre.Infrastructure.Persistence.Data.Users
{
    public class User
    {
        public User(string name, string email, string password, bool isAdmin = false)
        {
            Name = name;
            Email = email;
            Password = password;
            this.IsAdmin = isAdmin;
        }

        public int Id { get; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool IsAdmin { get; }

        public void SetName(string name)
        {
            this.Name = name;
        }

        public void SetEmail(string email)
        {
            this.Email = email;
        }

        public void SetPassword(string password)
        {
            this.Password = password;
        }
    }
}
