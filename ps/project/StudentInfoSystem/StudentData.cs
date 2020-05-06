using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    class StudentData
    {
        private static List<Student> _testStudents;

        static StudentData()
        {
            PopulateStudents();
        }

        public static List<Student> TestStudents
        {
            get { return _testStudents; }
            private set { }
        }

        private static void PopulateStudents()
        {
            _testStudents = new List<Student>();
            _testStudents.Add(new Student("Siika", "Siika", "Kaisiika", "FKST", "KSI", "Baklavarka", "redoven", 1L, 2, "7", "39"));
            _testStudents.Add(new Student("Mariika", "Iika", "Mariikova", "FKST", "KSI", "Magistyr", "redoven", 2L, 1, "8", "41"));
        }

        public static Student getStudentByFacutlyNumber(long facNumber)
        {
            StudentInfoContext context = new StudentInfoContext();
            return context.Students.Where(s => s.FacultyNumber == facNumber).First();
        }

        public static bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();
            return countStudents == 0;
        }

        public static void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach (Student st in StudentData.TestStudents)
            {
                context.Students.Add(st);
            }
            context.SaveChanges();
        }
    }
}
