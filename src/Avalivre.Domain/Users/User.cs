namespace Avalivre.Domain.Users
{
    public class User
    {
        public User(string name, string email, string password, bool isAdmin = false)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
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
