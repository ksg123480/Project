using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428컬렉션
{
    class Program
    {
        static void Main(string[] args)
        {
            Sample sam = new Sample(); //객체생성

            //데이터 추가
            Data d1 = new Data()
            {
                Name = "홍길동",
                Phone = "010-1111-1111"
            };
            sam.Add(d1);

            Data d2 = new Data()
            {
                Name = "김길동",
                Phone = "010-2222-2222"
            };
            sam.Add(d2);

            sam.PrintAll();

            sam.Selet("김길동");
            sam.Update("홍길동", "010-7777-7777");
            sam.PrintAll();

            Console.WriteLine("삭제 후");
            sam.Delete("김길동");
            sam.PrintAll();
        }
    }
}
