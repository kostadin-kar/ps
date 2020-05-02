using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student
    {
        public int StudentId
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public string Middlename
        {
            get; set;
        }
        public string Sirname
        {
            get; set;
        }
        public string Faculty
        {
            get; set;
        }
        public string Speciality
        {
            get; set;
        }
        public string Degree
        {
            get; set;
        }
        public string Status
        {
            get; set;
        }
        public long FacultyNumber
        {
            get; set;
        }
        public short Course
        {
            get; set;
        }
        public string Flow
        {
            get; set;
        }
        public string Group
        {
            get; set;
        }

        public Student()
        {
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
