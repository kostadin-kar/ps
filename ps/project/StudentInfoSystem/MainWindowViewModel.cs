﻿using StudentInfoSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    class MainWindowViewModel : BindableBase
    {
        private LoginViewModel loginViewModel = new LoginViewModel();
        private MainFormViewModel mainFormViewModel = new MainFormViewModel();

        public MainWindowViewModel()
        {
            LoginViewModel.SuccessfulLogin += NavToStudentInfo;
            CurrentViewModel = loginViewModel;
        }

        private BindableBase _currentViewModel;
        public BindableBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        private void NavToStudentInfo(Student student)
        {
            mainFormViewModel.Student = student;
            CurrentViewModel = mainFormViewModel;
        }
    }
}
