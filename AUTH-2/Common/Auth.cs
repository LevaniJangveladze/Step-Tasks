using AUTH.Enums;
using AUTH.Models;

namespace AUTH.Common
{
    internal class Auth
    {
        public static User? User { get; private set; } = null;

        public static void SetUser(User user) => User = user;
        public static void RemoveUser() => User = null;
        public static bool IsAuthorized() => User != null;
        public static bool HasRole(USER_ROLES role) => GetUser().Role == role;
        public static void IsAdmin()
        {
            if (!HasRole(USER_ROLES.ADMIN))
                throw new Exception("you dont have permission on this action");
        }
        public static User GetUser()
        {
            if (User == null) throw new Exception("unauthorized.");

            return User;
        }
    }
}
