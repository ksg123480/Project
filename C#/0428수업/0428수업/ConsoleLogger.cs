using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428수업
{
    class ConsoleLogger : ILogger
    {
        public ConsoleLogger(string path)
        {

        }
        public void WriteLog(string log)
        {
            Console.WriteLine("{0} {1}",
             DateTime.Now.ToShortTimeString(), log);
        }
    }
}