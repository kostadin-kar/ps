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
        public Student GetStudentDataByUser(User user)
        {
            long facultyNumber;
            if (long.TryParse(user.facultyNumber, out facultyNumber))
            {
                //error invalid faculty number
                return null;
            }

            Student student = null;
            foreach (User u in UserData.TestUsers)
            {
                if (facultyNumber == long.Parse(u.facultyNumber))
                {
                    student = new Student();
                    break;
                }
            }

            //error student not found
            return student;
        }
    }
}
