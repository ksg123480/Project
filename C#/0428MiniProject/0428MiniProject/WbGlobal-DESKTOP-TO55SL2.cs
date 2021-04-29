using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    class WbGlobal
    {
        #region Application에서 사용되는 함수들.
        public static void Logo()
        {
            Console.Clear();
            Console.WriteLine("*********************************************");
            Console.WriteLine(" 우송비트 고급 31기");
            Console.WriteLine(" C#언어과정");
            Console.WriteLine(" 학생 및 좌석 관리 프로그램");
            Console.WriteLine(" 2020-04-28");
            Console.WriteLine(" ccm");
            Console.WriteLine("*********************************************");
            Pause(); 
        }

        public static void Ending()
        {
            Console.Clear();
            Console.WriteLine("*********************************************");
            Console.WriteLine(" 프로그램을 종료합니다.");
            Console.WriteLine("*********************************************");
            Pause();
        }
     
        public static void Pause()
        {
            Console.Write("아무키나 누르세요");
            Console.ReadKey();
        }
        
        #endregion 
    }
}
