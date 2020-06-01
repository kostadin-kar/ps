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
            LoginValidation login = new LoginValidation(Username, Password, this.ActionOnError);

            User user = null;
            if (LoginValidation.ValidateUserInput(ref user))
            {
                string error = "";
                Student student = StudentValidation.GetStudentDataByUser(user, ref error);

                if (student == null)
                {
                    MessageBox.Show(error);
                    Password = "";
                    OnPropertyChanged("Password");
                    return;
                }
                OnSuccessfulLogin(student);
            }
            else
            {
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
