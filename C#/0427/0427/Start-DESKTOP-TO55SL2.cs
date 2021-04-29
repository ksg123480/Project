using System;

namespace _0427
{
    class Start
    {
        

        public static void Main(String[] args)
        {
            // NewMethod();
            MemberList memlist = new MemberList(5); //객체생성
            memlist.Add(new Member("홍길동", "010-1111-1111"),3);

            memlist.PrintAll();

            //인덱서의 올바른 사용법
            memlist[3].Number = 2;
            memlist[3].Phone = "010-2222-2222";

            memlist.PrintAll();

            //잘못된 인덱서 사용
            try
            {  
                memlist[3].Number = 22;
                Console.WriteLine("수정 성공");
            }
            catch(Exception ex)
            {
                Console.WriteLine("[수정 에러]" + ex.Message);
            }
            //====================

        }

        private static void NewMethod()
        {
            Member mem = new Member("홍길동", "010-7777-7777");
            mem.Print();

            mem.Phone = "010-1111-1111";
            mem.Number = 1;

            mem.Print();
        }
    }
}
