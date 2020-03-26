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
using System.Windows.Shapes;
using UserLogin;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginValidation login = new LoginValidation(txtLoginUsername.Text, txtLoginPassword.Text, this.ActionOnError);

            Student student = null;
            User user = null;
            if (LoginValidation.ValidateUserInput(ref user))
            {
                MainWindow mainWindow = new MainWindow();
                student = StudentValidation.GetStudentDataByUser(user);

                if (student == null)
                {
                    MessageBox.Show("User '" + user.username + "' does not have field facultyNumber.");
                    txtLoginPassword.Text = "";
                    return;
                }
                mainWindow.PopulateData(student);
                mainWindow.Show();
                //display info
            }
            else
            {
                //MessageBox.Show("Invalid username or password");
                txtLoginPassword.Text = "";
            }
        }

        private void ActionOnError(string msg)
        {
            MessageBox.Show(msg);
        } 
    }
}
