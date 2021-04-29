using System;

namespace _0427
{
    class Member
    {
        //멤버변수
        private String name;
        private int number;
        private String phone;

        #region 프로퍼티

        public String Name
        {
            get { return name; }
           private set { name = value; }
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public String Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        #endregion

        # region 생성자
        public Member(String _name, int _number, String _phone)
        {
            Name = _name;
            Number = _number;
            Phone = _phone;
        }
        public Member(String _name, String _phone) :this(_name, 0, _phone)
        {

        }

        #endregion

        # region 메서드

        public void Print()
        {
            Console.Write("[이름]" + Name + "\t");
            Console.Write("[번호]" + Number + "\t");
            Console.WriteLine("[전번]" + Phone);
        }

        #endregion


    }
}
