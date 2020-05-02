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

using System.Data;
using System.Data.SqlClient;

namespace StudentInfoSystem.Views
{
    /// <summary>
    /// Interaction logic for MainFormView.xaml
    /// </summary>
    public partial class MainFormView : UserControl
    {
        public MainFormView()
        {
            InitializeComponent();
            FillStudStatusChoices();
            this.DataContext = this; //this data context overrides the one from the view model, change it there when necessary
        }

        public List<string> StudStatusChoices
        {
            get; set;
        }

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();

            using (IDbConnection connection = new SqlConnection(Properties.Settings.Default.DbContext))
            {
                string sqlquery = @"SELECT StatusDescr FROM StudStatus";

                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();

                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();

                bool notEndOfResult;

                notEndOfResult = reader.Read();

                while (notEndOfResult)
                {
                    string s = reader.GetString(0);

                    StudStatusChoices.Add(s);

                    notEndOfResult = reader.Read();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool areEmpty = StudentData.TestStudentsIfEmpty();
            MessageBox.Show(areEmpty.ToString());

            if (areEmpty)
            {
                StudentData.CopyTestStudents();
            }
        }
    }
}
