using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerCW
{
    public class Log
    {
        public Int32 Id
        {
            get; set;
        }
        public string MessageLog
        {
            get; set;
        }

        public Log()
        {
        }

        public Log(Int32 id, string message)
        {
            Id = id;
            MessageLog = message;
        }

        public override string ToString()
        {
            return MessageLog.ToString();
        }
    }
}
