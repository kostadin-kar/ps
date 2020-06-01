using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;
using LoggerCW;

namespace StudentInfoSystem
{
    class StudentValidation
    {
        public static Student GetStudentDataByUser(User user, ref string error)
        {
            long facultyNumber;
            if (!long.TryParse(user.FacultyNumber, out facultyNumber))
            {
                string errMessage = string.Format("Provided faculty number is malformed");
                error = errMessage;
                Logger.LogActivity(errMessage);
                //error invalid faculty number
                return null;
            }

            Student student = null;
            foreach (User u in UserData.TestUsers)
            {
                long tempFacultyNumber = -1;
                if (long.TryParse(u.FacultyNumber, out tempFacultyNumber) && facultyNumber == tempFacultyNumber)
                {
                    student = StudentData.getStudentByFacutlyNumber(facultyNumber);
                    Logger.LogActivity(string.Format("Student '{0}' successfully logged in", student.Name));
                    break;
                }
            }

            //error student not found
            string message = string.Format("User '{0}' does not have field facultyNumber.", user.Username);
            error = message;
            Logger.LogActivity(message);
            return student;
        }
    }
}
