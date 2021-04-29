using System;

namespace _0427과제
{
    class Account
    {
        #region 계정정보
        private int id;
        private double balance;
        private String name;
        #endregion

        #region 프로퍼티
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        #endregion

        #region 생성자
        public Account() { }

        public Account(int _id, String _name, double _balance)
        {
            id = _id;
            name = _name;
            balance = _balance;
        }

        public Account(Account acc)
        {
            id = acc.Id;
            balance = acc.Balance;
            name = acc.Name;
        }
        #endregion

        #region 메서드      


        public virtual void AddMoney(double val)
        {
            Balance = Balance + val;
        }

        public virtual void ShowAllData()
        {
            Console.WriteLine("계좌 ID : " + Id);
            Console.WriteLine(" 이 름  : " + Name);
            Console.WriteLine(" 잔 액  : " + Balance);
        }

        public void MinMoney(int val)
        {
            if (Balance < val)
                throw new Exception("잔액이 부족합니다.");
            Balance = Balance - val;
        }
        #endregion


    }
}
