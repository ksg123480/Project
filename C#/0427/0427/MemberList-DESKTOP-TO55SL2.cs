using System;

namespace _0427
{
    class MemberList
    {
        private Member [] memlist;// 멤버클래스를 memlist로

        public MemberList(int size = 10)
        {
            memlist = new Member[size];
        }

        public Member this[int idx]
        {
            get 
            {
                if (idx < 0 || idx >= memlist.Length)
                    throw new Exception("인덱스 접근이 잘못됨");
                return memlist[idx]; 
            }
            set 
            {
                if (idx < 0 || idx >= memlist.Length)
                    throw new Exception("인덱스 접근이 잘못됨");
                memlist[idx] = value; 
            }
        }

        public void Add(Member mem, int idx)
         {
            memlist[idx] = mem;
        }

        public void PrintAll()
        {
            for (int i =0; i<memlist.Length; i++)
            {
                Member mem = memlist[i];
                if(mem != null)
                mem.Print();
            }
        }
    }
}
