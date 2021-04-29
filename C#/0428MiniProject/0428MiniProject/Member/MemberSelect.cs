using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    class MemberSelect
    {
        public Member SelectMemberId(WbMemberList memlist)
        {
            int id;
            while(true)
            {
                Console.WriteLine("=====아이디검색====");
                Console.Write("아이디:");
                id = int.Parse(Console.ReadLine());
                foreach (Member mem in memlist)
                {
                    if (mem.Id == id)
                        return new Member(mem.Id, mem.Name, mem.GroupNumber, mem.SName);
                }
                Console.WriteLine("없는 아이디 입니다. 다시입력하세요");
            }
        }

        public WbMemberList SelectMemberGroup(WbMemberList memlist)
        {
            int groupnumber;
            WbMemberList grouplist = new WbMemberList();
            while (true)
            {
                Console.WriteLine("=====조별검색====");
                Console.Write("조별:");
                groupnumber = int.Parse(Console.ReadLine());
               if(groupnumber<=6)
                {  
                foreach (Member mem in memlist)
                   {
                        if (mem.GroupNumber == groupnumber)
                            grouplist.Add(mem);  
                   }
                    return grouplist;
                }
                Console.WriteLine("없는 조 입니다 다시입력하세요");
            }
        }
        public WbMemberList SelectMemberSub(WbMemberList memlist)
        {
            int sub;
            WbMemberList sublist= new WbMemberList();
            while(true)
            {
                Console.WriteLine("=====학과 별 겸색====");
                Console.Write("학과:");
                sub = int.Parse(Console.ReadLine());
                SubjectName sn = MemberAdd.NumberToSubject(sub);
                
                if (sn != SubjectName.ERROR&&sub <=4)
                {
                    foreach (Member mem in memlist)
                    {
                        if (mem.SName == sn)
                            sublist.Add(mem);
                    }
                    return sublist;
                }
                Console.WriteLine("없는 학과 입니다 다시입력하세요");
            }
        }

    }
}
