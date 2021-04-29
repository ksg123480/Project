using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    class MemberUpdate
    {
        public int CheckIdtoIdx(WbMemberList memlist)
        {
            int id;
            Console.WriteLine("============학생정보수정============\n");
            while (true)
            {
                Console.Write("아이디 : ");
                id = int.Parse(Console.ReadLine());
                foreach (Member mem in memlist)
                {
                    if (mem.Id == id)
                        return memlist.IndexOf(mem);
                }

                Console.WriteLine("등록되지 않은 아이디입니다. 재입력하세요");
            }
        }
        public Member UpdateMember(Member mem)
        {

            Console.WriteLine("=======변경할 정보=======");
            Console.Write("조번호(1~6) : ");
            int groupid = int.Parse(Console.ReadLine());

            Console.Write("학과([1]COM [2]IT) [3]GAME [4]ETC : ");
            int subject = int.Parse(Console.ReadLine());

            return new Member(mem.Id, mem.Name, groupid, MemberAdd.NumberToSubject(subject));
        }
    }
}

