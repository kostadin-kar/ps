using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserLogin;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void PopulateData(Student student)
        {
            txtName.Text = student.name;
            txtMiddlename.Text = student.middlename;
            txtSirname.Text = student.sirname;
            txtFaculty.Text = student.faculty;
            txtSpeciality.Text = student.speciality;
            txtOKS.Text = student.oks;
            txtStatus.Text = student.status;
            txtFacNumber.Text = student.facultyNumber.ToString();
            txtCourse.Text = student.course.ToString();
            txtFlow.Text = student.flow;
            txtGroup.Text = student.group;
        }
    }
}
