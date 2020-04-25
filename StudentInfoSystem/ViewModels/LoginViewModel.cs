using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UserLogin;

namespace StudentInfoSystem.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private RelayCommand logIn;
        public event Action<Student> SuccessfulLogin;
        //public event EventHandler<Student> SuccessfulLogin;

        public LoginViewModel()
        {
            logIn = new RelayCommand(AttemptLogIn);
        }

        public string Username
        {
            get; set;
        }

        public string Password
        {
            get; set;
        }

        public RelayCommand LogIn
        {
            get { return logIn; }
        }

        protected virtual void AttemptLogIn()
        {
            if (SuccessfulLogin != null)
            {
                Student s = new Student(null, null, null, null, null, null, null, null, 0, 0, null, null);
                SuccessfulLogin(s);
            }

            LoginValidation login = new LoginValidation(Username, Password, this.ActionOnError);

            User user = null;
            if (LoginValidation.ValidateUserInput(ref user))
            {
                ////MainWindow mainWindow = new MainWindow();
                Student student = StudentValidation.GetStudentDataByUser(user);

                if (student == null)
                {
                    MessageBox.Show("User '" + user.username + "' does not have field facultyNumber.");
                    Password = "";
                    OnPropertyChanged("Password");
                    return;
                }
                //mainWindow.Student = student;
                ///MainFormVM modelView = new MainFormVM(student);
                ////mainWindow.Show();
                //display info
                SuccessfulLogin(student);
            }
            else
            {
                //MessageBox.Show("Invalid username or password");
                Password = "";
                OnPropertyChanged("Password");
            }
        }

        private void ActionOnError(string msg)
        {
            MessageBox.Show(msg);
        }
    }
}
