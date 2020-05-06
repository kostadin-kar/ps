using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggerCW;

namespace UserLogin
{
    public class LoginValidation
    {
        public static string currentUserUsername;
        private static string currentUserPassword;
        private static string _errorMessage;
        public static string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = string.Format("Date: {0}; User: {1}; Role: {2}; Action: {3}",
                    DateTime.Now, currentUserUsername, currentUserRole, value);
            }
        }
        public static UserRoles currentUserRole;

        public static UserRoles CurrentUserRole
        {
            get { return currentUserRole; }
            private set { }
        }

        private static ActionOnError _actionOnErrorFuction;
        public delegate void ActionOnError(string errorMsg);

        public LoginValidation(string username, string password, ActionOnError actionOnErrorFunction)
        {
            currentUserUsername = username;
            currentUserPassword = password;
            _actionOnErrorFuction = actionOnErrorFunction;
        }

        public static bool ValidateUserInput(ref User user)
        {
            if (!IsInputValid())
            {
                Console.WriteLine(ErrorMessage);
                Logger.LogActivity(ErrorMessage);
                return false;
            }

            user = UserData.IsUserPassCorrect(currentUserUsername, currentUserPassword);
            if (user == null)
            {
                _actionOnErrorFuction(string.Format("User with username '{0}' and password '{1}' does not exist",
                    currentUserUsername, currentUserPassword));
                ErrorMessage = string.Format("User with username '{0}' and password '{1}' does not exist",
                    currentUserUsername, currentUserPassword);
                Console.WriteLine(ErrorMessage);
                Logger.LogActivity(ErrorMessage);
                return false;
            }
            currentUserRole = user.Role;

            Logger.LogActivity("Successful login.");

            return true;
        }

        private static bool IsInputValid()
        {
            return ValidateUserInput(currentUserUsername, string.Format("Username")) 
                && ValidateUserInput(currentUserPassword, string.Format("Password"));
        }

        private static bool ValidateUserInput(string field, string errorFieldPlaceholder)
        {
            if (String.IsNullOrEmpty(field))
            {
                _actionOnErrorFuction(string.Format("{0} '{1}' is malformed or missing", errorFieldPlaceholder, field));
                ErrorMessage = string.Format("{0} is malformed or missing", errorFieldPlaceholder);
                return false;
            }
            if (field.Length < 5)
            {
                _actionOnErrorFuction(string.Format("{0} '{1}' length less than 5 symbols", errorFieldPlaceholder, field));
                ErrorMessage = string.Format("{0} length less than 5 symbols", errorFieldPlaceholder);
                return false;
            }
            return true;
        }

        public static bool AssertUserLoginTrials(string username)
        {
            return Logger.ShouldUserLog(username);
        }
    }
}
