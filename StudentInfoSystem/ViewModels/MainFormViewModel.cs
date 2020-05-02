using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem.ViewModels
{
    public class MainFormViewModel : BindableBase
    {

        private Student student;

        public MainFormViewModel()
        {
            FillStudStatusChoices();
        }

        public Student Student
        {
            get { return student; }
            set { SetProperty(ref student, value); }
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
    }
}
