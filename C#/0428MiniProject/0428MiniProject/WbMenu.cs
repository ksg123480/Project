using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    class WbMenu
    {
        public static ConsoleKey MainMenu()
        {
            Console.WriteLine("*********************************************");
            Console.WriteLine(" [F1]  학생정보 관리");
            Console.WriteLine(" [F2]  좌석정보 관리");
            Console.WriteLine(" [ESC] 프로그램 종료");
            Console.WriteLine("*********************************************");
            return Console.ReadKey().Key;
        }

        public static ConsoleKey MemberMenu()
        {
            Console.WriteLine("[회원 관리]\n");
            Console.WriteLine("*********************************************");
            Console.WriteLine(" [F1]  학생 등록");
            Console.WriteLine(" [F2]  학생 검색(아이디-Key)");
            Console.WriteLine(" [F3]  학생 검색(조별-다수)");
            Console.WriteLine(" [F4]  학생 검색(학과별-다수)");
            Console.WriteLine(" [F5]  학생 정보 수정(아이디->조편성");
            Console.WriteLine(" [F6]  학생 정보 삭제(아이디");
            Console.WriteLine(" [ESC] 되돌아가기");
            Console.WriteLine("*********************************************");
            return Console.ReadKey().Key;
        }

        public static ConsoleKey SeatMenu()
        {
            Console.WriteLine("[좌석 관리]\n");
            Console.WriteLine("*********************************************");
            Console.WriteLine(" [F1]  자리 배치하기");
            Console.WriteLine(" [F2]  자리 이동하기(비어있는자리로)");
            Console.WriteLine(" [F3]  자리 교환하기(2명의 자리를 서로 교환)");
            Console.WriteLine(" [F4]  자리 배치삭제하기");
            Console.WriteLine(" [F5]  자리 검색하기(특정자리에 있는 사람의 정보)");
            Console.WriteLine(" [ESC] 되돌아가기");
            Console.WriteLine("*********************************************");
            return Console.ReadKey().Key;
        }
    }
}
