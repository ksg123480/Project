using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0506Server
{
    class Member
    {
        public String Id { get; private set; }
        public String Pw { get; set; }
        public String Name { get; set; }
        public String Phone { get; set; }
        public bool IsLogin { get; set; }//현재 로그인이 되어있는지확인

        public Member(String id, String pw, String name, String phone)
        {
            Id = id;
            Pw = pw;
            Name = name;
            Phone = phone;
            IsLogin = false;
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}, {3}, {4}",
                Id, Pw, Name, Phone, IsLogin);
        }
    }
}
