using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class UserData
    {
        //private static DateTime dt = new DateTime(2017, 9, 15, 10, 30, 0);
        //private static int hour = dt.Hour;
        //private static int nowtime = DateTime.Today.Hour;
        //private static int timeAfter12Hours = DateTime.Today.AddHours(12).Day;
        ////private static DateTime t = Convert.ToDateTime();
        //private static DateTime stringToDate = DateTime.ParseExact(Console.ReadLine(), "yyyy/MM/dd", null);

        static UserData()
        {
            ResetTestUserData();
        }

        private static List<User> _testUsers;
        public static List<User> TestUsers
        {
            get {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
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
            _testUsers = new List<User>();
            _testUsers.Add(new User("Pesho", "admin", "N/A", UserRoles.ADMIN, DateTime.Now, DateTime.MaxValue));
            _testUsers.Add(new User("Siika", "12345", "1", UserRoles.STUDENT, DateTime.Now, DateTime.MaxValue));
            _testUsers.Add(new User("Mariika", "54321", "2", UserRoles.STUDENT, DateTime.Now, DateTime.MaxValue));
        }

        public static User IsUserPassCorrect(string username, string password)
        {
            foreach (User user in _testUsers)
            {
                if (user.username == username && user.password == password)
                {
                    return user;
                }
            }

            return null;
        }

        public static void SetUserActiveTo(string username, DateTime activeTo)
        {
            foreach (User user in _testUsers)
            {
                if (user.username == username)
                {
                    user.isActiveUntil = activeTo;
                    Console.WriteLine(string.Format("User '{0}'s' active period changed to '{1}' successfully.",
                        username, activeTo.ToString(Logger.DATETIME_FORMAT)));
                    Logger.LogActivity(string.Format("Active time changed successfully for user '{0}'.", username));

                    return;
                }
            }

            Console.WriteLine(string.Format("User '{0}' does not exist. No changes were made", username));
        }

        public static void AssignUserRole(string username, UserRoles role)
        {
            foreach (User user in _testUsers)
            {
                if (user.username == username)
                {
                    user.role = role;
                    Console.WriteLine(string.Format("User '{0}'s' role changed to '{1}' successfully.", 
                        username, role.ToString()));
                    Logger.LogActivity(string.Format("Role changed successfully for user '{0}'.", username));

                    return;
                }
            }

            Console.WriteLine(string.Format("User '{0}' does not exist. No changes were made", username));
        }

        public static void ListAllUsers()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("\n*******************\n");
            foreach (User user in _testUsers)
            {
                builder.Append(user.ToString() + "*******************\n");
            }
            Console.WriteLine(builder.ToString());
        }
    }
}
