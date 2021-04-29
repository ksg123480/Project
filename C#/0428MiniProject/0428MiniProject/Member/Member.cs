using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    enum SubjectName { COM=1, IT, GAME, ETC, ERROR }
    /// <summary>
    /// 데이터 클래스
    /// - 맴버의 정보를 관리하는 클래스 
    /// </summary>
    class Member
    {
        public int Id { get; private set; }
        public String Name { get; private set; }
        public int GroupNumber { get; set; }
        public SubjectName SName { get; set; }
        
        //생성자
        public Member(int id, String name, int groupnumber, SubjectName sname)
        {
            Id = id;
            Name = name;
            GroupNumber = groupnumber;
            SName = sname;
        }

        //출력기능
        public void Print()
        {
            Console.Write("[{0}] ", Id);
            Console.WriteLine("{0}, {1}조, {2}", Name, GroupNumber, SName);
        }

        public void PrintLine()
        {
            Console.WriteLine("아이디 : {0}", Id);
            Console.WriteLine("이  름 : {0}", Name);
            Console.WriteLine("조번호 : {0}", GroupNumber);
            Console.WriteLine("학과명 : {0}", SName);
        }       
    }
}
