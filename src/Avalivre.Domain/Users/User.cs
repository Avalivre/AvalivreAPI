using System;
using Yaba.Tools.Validations;

namespace Avalivre.Domain.Users
{
    public class User
    {
        public User(string name, string email, string password, bool isAdmin = false)
        {
            this.ValidateName(name);
            this.ValidateEmail(email);
            this.ValidatePassword(password);
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.IsAdmin = isAdmin;
        }


        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool IsAdmin { get; private set; }

        public void SetName(string name)
        {
            this.ValidateName(name);
            this.Name = name;
        }

        public void SetEmail(string email)
        {
            this.ValidateEmail(email);
            this.Email = email;
        }

        public void SetPassword(string password)
        {
            this.ValidatePassword(password);
            this.Password = password;
        }

        #region Priv Methods
        private void ValidateName(string name)
        {
            Validate.NotNullOrEmpty(name);
        }

        private void ValidatePassword(string password)
        {
            Validate.NotNullOrEmpty(password);
            Validate.IsTrue(password.Length >= 8);
        }

        private void ValidateEmail(string email)
        {
            Validate.NotNullOrEmpty(email);
            Validate.IsTrue(email.Contains("@"));
            Validate.IsTrue(email.Contains(".com"));
        }
        #endregion
    }
}
