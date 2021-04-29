using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    /// <summary>
    /// 사용자로부터 회원 정보를 입력받아
    /// Member 객체로 변환하여 제공하는 기능의 함수 
    /// </summary>
    class MemberAdd
    {
        //고려사항
        //ID는 중복되면 안됨.

        public Member AddMember(WbMemberList memlist)
        {
            int id;
            while (true)
            {
                Console.Write("아이디 : ");
                id = int.Parse(Console.ReadLine());
                if (IdCheck(memlist, id) == true)
                    break;
                Console.WriteLine("중복된 아이디 입니다. 재 입력이 필요하네요");                                   
            }

            Console.Write("이름 : ");
            string name = Console.ReadLine();

            Console.Write("조(1~6) : ");
            int groupid = int.Parse(Console.ReadLine());

            Console.Write("학과([1]COM [2]IT [3]GAME [4]ETC) : ");
            int subject = int.Parse(Console.ReadLine());

            return new Member(id, name, groupid, NumberToSubject(subject));
        }

        private bool IdCheck(WbMemberList memlist, int id)
        {
            foreach(Member mem in memlist)
            {
                if (mem.Id == id)
                    return false;
            }
            return true;
        }


        public static SubjectName NumberToSubject(int id)
        {
            SubjectName sn;
            switch (id)
            {
                case 1:  sn = SubjectName.COM;  break;
                case 2:  sn = SubjectName.IT;   break;
                case 3:  sn = SubjectName.GAME; break;
                case 4:  sn = SubjectName.ETC;  break;
                default: sn = SubjectName.ERROR; break;
            }
            return sn;
        }
    }
}
