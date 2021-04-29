using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _0506
{
    class Program
    {
        
        static void Main(string[] args)
        {
            exam1();
        }

        #region 기본적인 thread 사용법
        static void DoSomething()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("DoSomething : {0}", i);
            }
        }
        static void exam1()
        {
            Thread t1 = new Thread(new ThreadStart(DoSomething));
            t1.IsBackground = true;
            t1.Start();

            t1.Join();  //t1객체가 종료될때 까지 wait
   
        }
        #endregion
    }
}
