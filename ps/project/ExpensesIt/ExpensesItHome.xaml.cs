using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Xml;

namespace ExpensesIt
{
    /// <summary>
    /// Interaction logic for ExpensesItHome.xaml
    /// </summary>
    public partial class ExpensesItHome : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<string> PersonsChecked
        {
            get; set;
        }

        private DateTime lastChecked;
        public DateTime LastChecked
        {
            get { return lastChecked; }
            set { lastChecked = value; }
        }

        public ExpensesItHome()
        {
            InitializeComponent();
            LastChecked = DateTime.Now;
            this.DataContext = this;
            PersonsChecked = new ObservableCollection<string>();
        }

        private void Greeting_Click(object sender, RoutedEventArgs e)
        {
            string greetingMsg;
            if ((peopleListBox.SelectedItem as ListBoxItem) == null)
            {
                return;
            }
            greetingMsg = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();
            MessageBox.Show("Hi " + greetingMsg);

        }

        private void BtnViewUserExpenses_Click(object sender, RoutedEventArgs e)
        {
            //ExpenseReport expenseReport = new ExpenseReport();
            //expenseReport.Show();
            ExpenseReport expenseReport = new ExpenseReport((peopleListBox.SelectedItem as XmlElement));
            expenseReport.Show();
        }

        private void peopleListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs args)
        {
            LastChecked = DateTime.Now;

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("LastChecked"));
            }

            PersonsChecked.Add((peopleListBox.SelectedItem as System.Xml.XmlElement).Attributes["Name"].Value);
        }
    }
}
