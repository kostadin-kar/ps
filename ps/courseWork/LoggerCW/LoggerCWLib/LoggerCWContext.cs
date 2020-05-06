using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerCW
{
    public class LoggerCWContext : DbContext
    {
        private static string connectionString = null;
        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
            set
            {
                connectionString = value;
            }
        }

        public DbSet<Log> Logs
        {
            get; set;
        }

        public LoggerCWContext() : base(connectionString)
        {
        }

        public int GetNextLogId()
        {
            return Logs.Count() + 1;
        }
    }
}
