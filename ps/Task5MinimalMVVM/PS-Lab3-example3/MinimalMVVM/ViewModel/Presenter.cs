using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MinimalMVVM.Model;

namespace MinimalMVVM.ViewModel
{
    public class Presenter : ObservableObject
    {
        private readonly TextConverter _textToUpperConverter = new TextConverter(s => s.ToUpper());
        private readonly TextConverter _textToLowerConverter = new TextConverter(s => s.ToLower());
        private string _someText;
        private readonly ObservableCollection<string> _history = new ObservableCollection<string>();

        private bool isUpper = true;
        private enum _titleCase
        {
            ToUpperCase,
            ToLowerCase
        }

        public string SomeText
        {
            get { return _someText; }
            set
            {
                _someText = value;
                RaisePropertyChangedEvent("SomeText");
            }
        }

        public string TitleCase
        {
            get
            {
                if (isUpper)
                {
                    return _titleCase.ToUpperCase.ToString();
                }
                else
                {
                    return _titleCase.ToLowerCase.ToString();
                }
            }
        }

        public IEnumerable<string> History
        {
            get { return _history; }
        }

        public ICommand ConvertTextCommand
        {
            get { return new DelegateCommand(ConvertText); }
        }

        public ICommand ToggleCaseCommand
        {
            get { return new DelegateCommand(ToggleCase);  }
        }

        private void ToggleCase()
        {
            isUpper = !isUpper;
            RaisePropertyChangedEvent("TitleCase");
        }

        private void ConvertText()
        {
            if (isUpper)
            {
                AddToHistory(_textToUpperConverter.ConvertText(SomeText));
            }
            else
            {
                AddToHistory(_textToLowerConverter.ConvertText(SomeText));
            }
            SomeText = String.Empty;
        }

        private void AddToHistory(string item)
        {
            if (!_history.Contains(item))
                _history.Add(item);
        }
    }
}
