using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    class MainFormVM
    {
        private Student _student;
        public Student Student
        {
            get { return _student; }
            set { _student = value; }
            //get { return _student; }
            //set
            //{
            //    if (value == null)
            //    {
            //        DisableControls();
            //    }
            //    else
            //    {
            //        _student = value;
            //        EnableControls();
            //        PopulateData();
            //    }
            //}
        }

        public MainFormVM(Student student)
        {
            Student = student;
        }
    }
}
