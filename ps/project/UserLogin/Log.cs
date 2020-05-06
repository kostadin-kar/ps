using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class Log
    {
        public Int32 LogId
        {
            get; set;
        }
        public string LogMessage
        {
            get; set;
        }

        public Log()
        {
        }

        public Log(int id, string message)
        {
            LogId = id;
            LogMessage = message;
        }

        public override string ToString()
        {
            return LogMessage;
        }
    }
}
