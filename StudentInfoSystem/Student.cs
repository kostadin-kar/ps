using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student
    {
        private string name;
        private string middlename;
        private string sirname;
        private string faculty;
        private string speciality;
        private string degree;
        private string status;
        private long facultyNumber;
        private short course;
        private string flow;
        private string group;

        public string Name
        {
            get => name;
            set => name = value;
        }
        public string Middlename
        {
            get => middlename;
            set => middlename = value;
        }
        public string Sirname
        {
            get => sirname;
            set => sirname = value;
        }
        public string Faculty
        {
            get => faculty;
            set => faculty = value;
        }
        public string Speciality
        {
            get => speciality;
            set => speciality = value;
        }
        public string Degree
        {
            get => degree;
            set => degree = value;
        }
        public string Status
        {
            get => status;
            set => status = value;
        }
        public long FacultyNumber
        {
            get => facultyNumber;
            set => facultyNumber = value;
        }
        public short Course
        {
            get => course;
            set => course = value;
        }
        public string Flow
        {
            get => flow;
            set => flow = value;
        }
        public string Group
        {
            get => group;
            set => group = value;
        }

        public Student(string name, 
            string middlename, string sirname, string faculty, 
            string speciality, string degree, string status, 
            long facultyNumber, short course, string flow, string group)
        {
            this.Name = name;
            this.Middlename = middlename;
            this.Sirname = sirname;
            this.Faculty = faculty;
            this.Speciality = speciality;
            this.Degree = degree;
            this.Status = status;
            this.FacultyNumber = facultyNumber;
            this.Course = course;
            this.Flow = flow;
            this.Group = group;
        }
    }
}
