using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerCW
{
    public class LogContext : DbContext
    {
        public DbSet<Log> Logs
        {
            get; set;
        }

        public LogContext() : base(Properties.Settings.Default.DbContext)
        {
        }

        public int GetNextLogId()
        {
            return Logs.Count() + 1;
        }
    }
}
