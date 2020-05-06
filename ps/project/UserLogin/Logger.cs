using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UserLogin
{
    public class Logger
    {
        public const string DATETIME_FORMAT = "yyyy/MM/dd HH:mm:ss";

        private static List<string> currentSessionActivities = new List<string>();

        public static void LogActivity(string activity)
        {
            string activityLine = activity;
            if (activity.StartsWith("Error login attempt"))
            {
                activityLine += Environment.NewLine;
            }
            else
            {
                activityLine = string.Format("Date: {0}; User: {1}; Role: {2}; Action: {3}",
                    DateTime.Now, LoginValidation.currentUserUsername, LoginValidation.currentUserRole, activity);
            }

            LogContext context = new LogContext();
            context.Logs.Add(new Log(context.GetNextLogId(), activityLine));
            context.SaveChanges();

            currentSessionActivities.Add(activityLine);
        }

        public static string ViewLogs()
        {
            LogContext context = new LogContext();
            return string.Join(Environment.NewLine, context.Logs.ToList());
        }

        public static void ViewCurrentSessionActivities()
        {
            StringBuilder builder = new StringBuilder();
            foreach (string activity in currentSessionActivities)
            {
                builder.Append(activity);
            }
            Console.WriteLine(builder.ToString());
        }

        private static int GetLoginAttempts(string username)
        {
            LogContext context = new LogContext();

            foreach (Log line in context.Logs.ToList())
            {
                Regex usernameRegex = new Regex("Username: '(.*)', Date: '(.*)', Attempt: '(.*)'");
                Match match = usernameRegex.Match(line.ToString());
                if (match.Success)
                {
                    string usernameMatch = match.Groups[1].Value;
                    if (usernameMatch == username)
                    {
                        int attemptMatch = int.Parse(match.Groups[3].Value);
                        return attemptMatch;
                    }
                }
            }
            return 0;
        }

        private static string GetLastLoginAttemptLog(string username)
        {
            LogContext context = new LogContext();

            foreach (Log line in context.Logs.ToList())
            {
                Regex usernameRegex = new Regex("Username: '(.*)', Date: '(.*)', Attempt: '(.*)'");
                Match match = usernameRegex.Match(line.ToString());
                if (match.Success)
                {
                    string usernameMatch = match.Groups[1].Value;
                    if (usernameMatch == username)
                    {
                        return line.ToString();
                    }
                }
            }
            return null;
        }

        public static void IncrementLoginAttemts(string username)
        {
            int attempts = GetLoginAttempts(username);
            string msg = string.Format("Error login attempt; Username: '{0}', Date: '{1}', Attempt: '{2}'",
                LoginValidation.currentUserUsername, DateTime.Now.ToString(DATETIME_FORMAT), ++attempts);
            LogActivity(msg);
            Console.WriteLine(msg);
        }

        private static bool AssertTimeHasPassedSinceSeveralAttempts(string username, string dateMatch)
        {
            DateTime lastTime = DateTime.ParseExact(dateMatch, DATETIME_FORMAT, null);
            DateTime currentTime = DateTime.Now;
            TimeSpan diff = currentTime - lastTime;
            double minutesDiff = diff.TotalMinutes;

            if (minutesDiff > 3)
            {
                string msgTombstone = string.Format("Error TOMBSTONE login attempt; Username: '{0}', Date: '{1}', Attempt: '0'",
                    LoginValidation.currentUserUsername, DateTime.Now.ToString(DATETIME_FORMAT));
                LogActivity(msgTombstone);
                Console.WriteLine(msgTombstone);
                return true;
            }

            string msg = string.Format("User '{0}' cannot log in since three minutes have not passed since last failed login attempt: '{1}'",
                username, lastTime.ToString(DATETIME_FORMAT));
            Console.WriteLine(msg);
            LogActivity(msg);
            return false;
        }

        public static bool CanUserLogIn(string username)
        {
            int attempts = GetLoginAttempts(username);
            if (attempts >= 3)
            {
                string log = GetLastLoginAttemptLog(username);
                Regex usernameRegex = new Regex("Username: '(.*)', Date: '(.*)', Attempt: '(.*)'");
                Match match = usernameRegex.Match(log);
                if (match.Success)
                {
                    string dateMatch = match.Groups[2].Value;
                    return AssertTimeHasPassedSinceSeveralAttempts(username, dateMatch);
                }
            }

            //IncrementLoginAttemts(username);
            return true;
        }

        public static bool ShouldUserLog(string username)
        {
            LogContext context = new LogContext();

            foreach (Log line in context.Logs.ToList())
            {
                if (line.ToString().StartsWith("Error login attempt"))
                {
                    Regex usernameRegex = new Regex("Username: '(.*)', Date: '(.*)', Attempt: '(.*)'");
                    Match match = usernameRegex.Match(line.ToString());
                    if (match.Success)
                    {
                        string usernameMatch = match.Groups[1].Value;

                        if (username == usernameMatch)
                        {
                            int attemptMatch = int.Parse(match.Groups[3].Value);

                            if (attemptMatch == 3)
                            {
                                string dateMatch = match.Groups[2].Value;
                                DateTime lastTime = DateTime.ParseExact(dateMatch, DATETIME_FORMAT, null);
                                DateTime currentTime = DateTime.Now;
                                TimeSpan diff = currentTime - lastTime;
                                double minutesDiff = diff.TotalMinutes;
                                if (minutesDiff > 3)
                                {
                                    LogActivity(string.Format("Error login attempt; Username: '{0}', Date: '{1}', Attempt: '0'",
                                        LoginValidation.currentUserUsername, DateTime.Now.ToString(DATETIME_FORMAT), ++attemptMatch));
                                    return true;
                                    // return true, tumbstone log message
                                }
                                //reject enterance
                                string msg = string.Format("User '{0}' cannot log in since three minutes have not passed since last failed login attempt: '{1}'",
                                        username, lastTime.ToString(DATETIME_FORMAT));
                                Console.WriteLine(msg);
                                LogActivity(msg);

                                return false;
                            }
                            else
                            {
                                string msg = string.Format("Error login attempt; Username: '{0}', Date: '{1}', Attempt: '{2}'",
                                    LoginValidation.currentUserUsername, DateTime.Now.ToString(DATETIME_FORMAT), ++attemptMatch);
                                Console.WriteLine(msg);
                                LogActivity(msg);
                                //add log to increment attempt counter, return true
                            }
                            return true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Unsuccessful match failure.");
                    }
                }
            }
            return true;
        }
    }
}
