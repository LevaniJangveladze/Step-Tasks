using AUTH.Common;
using AUTH.Enums;

namespace AUTH.Models
{
    internal class User : Entity
    {
        public string Fullname { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public USER_ROLES Role { get; private set; } = USER_ROLES.USER;

        private User(string fullname, string email, string password)
        {
            Fullname = fullname;
            Email = email;
            Password = password;
        }

        public static User Create(string name, string email, string password)
        {
            if (name.Length < 3 || name.Length > 50)
                throw new Exception("user name must be greateer then 2 and lowwer then 50");

            if (email.Length < 3 || email.Length > 50)
                throw new Exception("user email must be greateer then 2 and lowwer then 50");

            if (!email.Contains("@") || !email.Contains("."))
                throw new Exception("user email invalid format");

            if (password.Length < 8 || password.Length > 50)
                throw new Exception("user password must be greateer then 7 and lowwer then 50");

            return new User(name, email, password);
        }

        public void ChangeRole(USER_ROLES role) => Role = role;

        public void ShowInfo()
        {
            Console.WriteLine($"ID: {Id}, name: {Fullname}, email: {Email}");
        }
    }
}
