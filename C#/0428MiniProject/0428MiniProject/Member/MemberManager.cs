using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    class MemberManager
    {
        #region 싱글톤

        public static MemberManager Singleton { get; private set; }

        static MemberManager()
        {
            Singleton = new MemberManager();
        }

        private MemberManager() { }

        #endregion

        WbMemberList memlist = new WbMemberList();

        public void AddMember()
        {
            //1.정보 획득 & 저장 객체 생성
            //           MemberAdd ma = new MemberAdd();
            //           Member member = ma.AddMember();
            //이름이 없는 객체 생성(언제 사용:딱 한번 맴버함수를 호출하고자 할때)
            Member member = new MemberAdd().AddMember(memlist);
            //멤버가 객체를 만들어서AddMember를 저장해달라고 요청
            //2.저장
            memlist.Add(member);

            //3. 결과출력
            Console.WriteLine("저장되었습니다.");
        }

        public void SelectMemberId()
        {
            Member member = new MemberSelect().SelectMemberId(memlist);

            member.PrintLine();
        }

        public void SelectMemberGroup()
        {
            WbMemberList member = new MemberSelect().SelectMemberGroup(memlist);

            foreach(Member mem in member)
            {
                mem.Print();
            }

        }

        public void SelectMemberSub()
        {
            WbMemberList member = new MemberSelect().SelectMemberSub(memlist);

            foreach (Member mem in member)
            {
                mem.Print();

            }
        }
        public void DeleteMember()
        {
            int idx = new MemberDelete().DeleteMember(memlist);

            memlist.RemoveAt(idx);  //인덱서의 배열을 지워줌

            Console.WriteLine("삭제되었습니다.");
        }

        public void UpdateMember()
        {
            int idx = new MemberUpdate().CheckIdtoIdx(memlist);
            Member member = new MemberUpdate().UpdateMember(memlist[idx]);

            memlist[idx] = member;
        }
    }
}
