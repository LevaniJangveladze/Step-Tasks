using AUTH.Common;
using AUTH.Models;

namespace AUTH.Services
{
    internal class UserServices
    {
        private Database _db;
        public UserServices(Database db) => _db = db;

        public void Register()
        {
            Console.Write("Enter you name: ");
            string name = Console.ReadLine();

            Console.Write("Enter you email: ");
            string email = Console.ReadLine();

            if (_db.Users.Any(u => u.Email == email))
                throw new Exception("accaount already exists");

            Console.Write("Enter you password: ");
            string password = Console.ReadLine();

            User user = User.Create(name, email, password);

            _db.Users.Add(user);
            Result.Success("registed successfully.");
        }
        public void Login()
        {
            Console.Write("Enter you email: ");
            string email = Console.ReadLine();

            Console.Write("Enter you password: ");
            string password = Console.ReadLine();

            User? user = _db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user == null) throw new Exception("email or password is not correct.");

            Auth.SetUser(user);

            Result.Success("logged in successfully.");
        }
        public void Logout() => Auth.RemoveUser();
        public void MakeAdmin()
        {
            Auth.GetUser().ChangeRole(Enums.USER_ROLES.ADMIN);

            Result.Success("you role chnaged successfully.");
        }
        public void ShowProfile() => Auth.GetUser().ShowInfo();
    }
}
