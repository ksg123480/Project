using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0427실습
{
    class Account
    {
        private int id;         //  아이디
        private String name;    //  이름
        private int balance;    //  잔액

        #region 프로퍼티
        public String Name
        {
            get { return name; }
            set { name = value; } //필요에 의해 은닉할 수 있다.
        }
        public int Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        #endregion

        public Account(int _id, String _name, int _balance)
        {
            Id = _id;
            Name = _name;
            Balance = _balance;
        }

        public Account(Account acc)
        {
            this.Id = acc.Id;
            this.Name = acc.Name;
            this.Balance = acc.Balance;
        }

        public virtual void AddMoney(int val)
        {
            Balance += val;
        }

        public void MinMoney(int val)
        {
            Balance -= val;
        }
        public virtual void ShowAllData()
        {
            Console.Write("[계좌 ID] : " + id+"\t");
            Console.Write("[이   름] : " + name + "\t");
            Console.Write("[잔   액] : " + balance + "\n");
        }
    }
}
