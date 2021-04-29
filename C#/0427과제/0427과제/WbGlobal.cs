using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0427과제
{
    class WbGlobal
    {
        public static void Pause() //static 을 public 노출을시켜주면은
                                             //객체를 만들지않고 계속사용가능
        {
            Console.WriteLine("아무키나 누르세요.....");
            Console.ReadKey();
        }

        public static int InputInt(string msg)
        {
            int result;
            while (true)
            {
                Console.Write("{0} : ", msg);

                if (int.TryParse(Console.ReadLine(), out result) == true)
                    //TryParse 리턴 탑입:bool 형
                    return result;
            }
        }

        public static String InputString(string msg)
        {
            while (true)
            {
                Console.Write("{0} : ", msg);

                return Console.ReadLine();
            }
        }
    }
}
