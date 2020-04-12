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

        private Student _student;
        public Student Student
        {
            get { return _student; }
            set
            {
                if (value == null)
                {
                    DisableControls();
                }
                else
                {
                    _student = value;
                    EnableControls();
                    PopulateData();
                }
            }
        }

        private void PopulateData()
        {
            txtName.Text = _student.name;
            txtMiddlename.Text = _student.middlename;
            txtSirname.Text = _student.sirname;
            txtFaculty.Text = _student.faculty;
            txtSpeciality.Text = _student.speciality;
            txtOKS.Text = _student.oks;
            txtStatus.Text = _student.status;
            txtFacNumber.Text = _student.facultyNumber.ToString();
            txtCourse.Text = _student.course.ToString();
            txtFlow.Text = _student.flow;
            txtGroup.Text = _student.group;
        }

        public void ClearControls()
        {
            ApplyAction(control => control.Text = "");
        }

        public void DisableControls()
        {
            ApplyAction(control => control.IsEnabled = false);
        }

        public void EnableControls()
        {
            ApplyAction(control => control.IsEnabled = true);
        }

        private void ApplyAction(Action<TextBox> action)
        {
            List<TextBox> textBoxes = new List<TextBox>();
            GetTextBoxes(Wrapper, ref textBoxes);

            foreach (TextBox textBox in textBoxes)
            {
                action.Invoke(textBox);
            }
        }

        private void GetTextBoxes(Grid grid, ref List<TextBox> textBoxes)
        {
            foreach (UIElement element in grid.Children)
            {
                if (element.GetType() == typeof(TextBox))
                {
                    textBoxes.Add((TextBox)element);
                }
                else if (element.GetType() == typeof(Grid))
                {
                    GetTextBoxes((Grid)element, ref textBoxes);
                }
                else if (element.GetType() == typeof(GroupBox))
                {
                    GetTextBoxes((Grid)((GroupBox)element).Content, ref textBoxes);
                }
            }
        }
    }
}
