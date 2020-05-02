using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            if (UserData.TestUsersIfEmpty())
            {
                UserData.CopyTestUsers();
            }

            LoginValidation login = BuildValidator();

            while (Logger.CanUserLogIn(LoginValidation.currentUserUsername))
            {
                User user = null;

                if (LoginValidation.ValidateUserInput(ref user))
                {
                    Console.WriteLine(user.ToString());
                    PrintCurrentUserRole();

                    if (user.Role == UserRoles.ADMIN)
                    {
                        OpenAdminMenu();
                    }
                    else
                    {
                        Console.WriteLine("Hello, " + user.Username);
                        Console.ReadKey();
                        return;
                    }
                }
                else
                {
                    Logger.IncrementLoginAttemts(LoginValidation.currentUserUsername);
                    login = BuildValidator();
                }
            }

            Console.WriteLine("Exiting... Press anykey to continue");
            Console.ReadKey();
        }

        private static LoginValidation BuildValidator()
        {
            Console.Write("Please, enter username: ");
            string username = Console.ReadLine();
            Console.Write("Please, enter password: ");
            string password = Console.ReadLine();

            return new LoginValidation(username, password, PrintErrorMessage);
        }

        private static void PrintCurrentUserRole()
        {
            string format = "Current user role is ";
            switch (LoginValidation.CurrentUserRole)
            {
                case UserRoles.ADMIN:
                    Console.WriteLine(format + UserRoles.ADMIN.ToString());
                    break;
                case UserRoles.INSPECTOR:
                    Console.WriteLine(format + UserRoles.INSPECTOR.ToString());
                    break;
                case UserRoles.PROFESSOR:
                    Console.WriteLine(format + UserRoles.PROFESSOR.ToString());
                    break;
                case UserRoles.STUDENT:
                    Console.WriteLine(format + UserRoles.STUDENT.ToString());
                    break;
                default:
                    Console.WriteLine(format + UserRoles.ANONYMOUS.ToString());
                    break;
            }
        }

        private static void PrintErrorMessage(string msg)
        {
            Console.WriteLine("ERROR: " + msg);
        }

        private static void OpenAdminMenu()
        {
            PrintMenu();
            string input = "-1";
            while (true)
            {
                Console.Write("Enter option: ");
                input = Console.ReadLine();
                try
                {
                    switch (int.Parse(input))
                    {
                        case 0:
                            return;
                        case 1:
                            AssignRole();
                            break;
                        case 2:
                            AssignActivePeriod();
                            break;
                        case 3:
                            ListUsers();
                            break;
                        case 4:
                            ViewLogs();
                            break;
                        case 5:
                            ViewCurrentSessionActivities();
                            break;
                        default:
                            Console.WriteLine(string.Format("Option '{0}' not supported", input));
                            break;
                    }
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("Please, enter valid option.");
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please, enter valid option.");
                }
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("----------\nMenu options:\n0: Exit\n1: Change user role\n2: Change user activity\n3: List users\n4: View logs\n5: View current session activities\n----------\n");
        }

        private static void AssignRole()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter new role: ");
            string input = Console.ReadLine();

            UserRoles role;
            if (!Enum.TryParse(input, out role))
            {
                Console.WriteLine(string.Format("Role '{0}' does not exist. No changes were made.", input));
                return;
            }

            UserData.AssignUserRole(username, role);
        }

        private static void AssignActivePeriod()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter new active period (format 'yyyy/MM/dd HH:mm:ss'): ");
            string activePeriodInput = Console.ReadLine();

            DateTime activePeriod;
            string[] formats = new string[] { Logger.DATETIME_FORMAT };
            if (!DateTime.TryParseExact(activePeriodInput, formats, null, System.Globalization.DateTimeStyles.AdjustToUniversal, out activePeriod))
            {
                Console.WriteLine("Wrong time format.");
                return;
            }

            UserData.SetUserActiveTo(username, activePeriod);
        }

        private static void ListUsers()
        {
            UserData.ListAllUsers();
        }

        private static void ViewLogs()
        {
            Console.WriteLine(Logger.ViewLogs());
        }

        private static void ViewCurrentSessionActivities()
        {
            Logger.ViewCurrentSessionActivities();
        }
    }
}
