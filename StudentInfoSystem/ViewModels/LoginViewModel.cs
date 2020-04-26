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
        public static event Action<Student> SuccessfulLogin = delegate { };
        //public event EventHandler<Student> SuccessfulLogin;

        private static readonly LoginViewModel _instance = new LoginViewModel();
        public LoginViewModel()
        {
            logIn = new RelayCommand(AttemptLogIn);
        }
        public static LoginViewModel GetInstance()
        {
            return _instance;
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

        private void AttemptLogIn()
        {
            //if (SuccessfulLogin != null)
            //{
            //    Student s = new Student(null, null, null, null, null, null, null, null, 0, 0, null, null);
            //    SuccessfulLogin(s);
            //}

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
                OnSuccessfulLogin(student);
            }
            else
            {
                //MessageBox.Show("Invalid username or password");
                Password = "";
                OnPropertyChanged("Password");
            }
        }

        private static void OnSuccessfulLogin(Student student)
        {
            SuccessfulLogin(student);
        }

        private void ActionOnError(string msg)
        {
            MessageBox.Show(msg);
        }
    }
}
