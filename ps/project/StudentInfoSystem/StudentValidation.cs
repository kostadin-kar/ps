using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    class StudentValidation
    {
        public static Student GetStudentDataByUser(User user)
        {
            long facultyNumber;
            if (!long.TryParse(user.FacultyNumber, out facultyNumber))
            {
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
                    break;
                }
            }

            //error student not found
            return student;
        }
    }
}
