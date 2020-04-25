using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem.ViewModels
{
    public class MainFormViewModel : BindableBase
    {
        public MainFormViewModel(Student student)
        {
            Student = student;
        }

        public Student Student
        {
            get; set;
        }
    }
}
