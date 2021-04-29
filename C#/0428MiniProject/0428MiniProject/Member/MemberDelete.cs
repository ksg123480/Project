using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    class MemberDelete
    {
        public int DeleteMember(WbMemberList memlist)
        {
            int id;
            while (true)
            {
                Console.WriteLine("============학생정보삭제============\n");
                Console.Write("아이디 : ");
                id = int.Parse(Console.ReadLine());
                foreach (Member mem in memlist)
                {
                    if (mem.Id == id)
                        return memlist.IndexOf(mem);  //IndexOf if절의 조건에 맞는 인덱서를 반환해줌
                }
                Console.WriteLine("등록되지 않은 아이디입니다. 재입력하세요");
            }

        }
    }
}

