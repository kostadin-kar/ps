using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class UserData
    {
        static UserData()
        {
            ResetTestUserData();
        }

        private static List<User> _testUsers;
        public static List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }
            set
            {
            }
        }

        private static void ResetTestUserData()
        {
            if (_testUsers == null || _testUsers.Count == 0)
            {
                PopulateUsers();
            }
        }

        private static void PopulateUsers()
        {
            UserContext context = new UserContext();
            _testUsers = context.Users.ToList();

            //_testUsers = new List<User>();
            //_testUsers.Add(new User("Pesho", "admin", "N/A", UserRoles.ADMIN, DateTime.Now, DateTime.MaxValue));
            //_testUsers.Add(new User("Siika", "12345", "1", UserRoles.STUDENT, DateTime.Now, DateTime.MaxValue));
            //_testUsers.Add(new User("Mariika", "54321", "2", UserRoles.STUDENT, DateTime.Now, DateTime.MaxValue));
        }

        public static User IsUserPassCorrect(string username, string password)
        {
            UserContext context = new UserContext();
            return context.Users
                .Where(u => u.Username == username && u.Password == password)
                .FirstOrDefault();
        }

        public static void SetUserActiveTo(string username, DateTime activeTo)
        {
            UserContext context = new UserContext();
            User user = context.Users.Where(u => u.Username == username).First();

            if (user != null)
            {
                user.IsActiveUntil = activeTo;
                Console.WriteLine(string.Format("User '{0}'s' active period changed to '{1}' successfully.",
                    username, activeTo.ToString(Logger.DATETIME_FORMAT)));
                Logger.LogActivity(string.Format("Active time changed successfully for user '{0}'.", username));

                return;
            }

            Console.WriteLine(string.Format("User '{0}' does not exist. No changes were made", username));
        }

        public static void AssignUserRole(string username, UserRoles role)
        {
            UserContext context = new UserContext();
            User user = context.Users.Where(u => u.Username == username).First();

            if (user != null)
            {
                user.Role = role;
                context.SaveChanges();

                Console.WriteLine(string.Format("User '{0}'s' role changed to '{1}' successfully.", username, role.ToString()));
                Logger.LogActivity(string.Format("Role changed successfully for user '{0}'.", username));

                return;
            }

            Console.WriteLine(string.Format("User '{0}' does not exist. No changes were made", username));
        }

        public static void ListAllUsers()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("\n*******************\n");

            UserContext context = new UserContext();
            context.Users.Select(u => builder.Append(u.ToString() + "*******************\n"));

            Console.WriteLine(builder.ToString());
        }


        public static bool TestUsersIfEmpty()
        {
            UserContext context = new UserContext();
            IEnumerable<User> queryUsers = context.Users;
            int countUsers = queryUsers.Count();
            return countUsers == 0;
        }

        public static void CopyTestUsers()
        {
            UserContext context = new UserContext();
            foreach (User user in UserData.TestUsers)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();
        }
    }
}