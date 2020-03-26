using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student
    {
        public string name;
        public string middlename;
        public string sirname;
        public string faculty;
        public string speciality;
        public string degree;
        public string oks;
        public string status;
        public long facultyNumber;
        public short course;
        public string flow;
        public string group;

        public Student(string name, string middlename, string sirname, string faculty, string speciality, string degree, string oks, string status, long facultyNumber, short course, string flow, string group)
        {
            this.name = name;
            this.middlename = middlename;
            this.sirname = sirname;
            this.faculty = faculty;
            this.speciality = speciality;
            this.degree = degree;
            this.oks = oks;
            this.status = status;
            this.facultyNumber = facultyNumber;
            this.course = course;
            this.flow = flow;
            this.group = group;
        }
    }
}
