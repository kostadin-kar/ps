using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    class StudentData
    {
        private static List<Student> _testStudent;

        static StudentData()
        {
            PopulateStudents();
        }

        public List<Student> TestStudent
        {
            get { return _testStudent; }
            private set { }
        }

        private static void PopulateStudents()
        {
            _testStudent = new List<Student>();
            _testStudent.Add(new Student("Siika", "Siika", "Kaisiika", "FKST", "KSI", "Baklavarka", "redoven", 1L, 2, "7", "39"));
            _testStudent.Add(new Student("Mariika", "Iika", "Mariikova", "FKST", "KSI", "Magistyr", "redoven", 2L, 1, "8", "41"));
        }

        public static Student getStudentByFacutlyNumber(long facNumber)
        {
            return _testStudent.Find(student => student.FacultyNumber == facNumber);
        }
    }
}
