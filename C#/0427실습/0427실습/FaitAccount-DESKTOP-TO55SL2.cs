using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0427실습
{
    class FaitAccount : Account
    {
        public FaitAccount(int id, String name, int balance)//신용계좌
            : base(id, name, (int)(balance + balance * 0.01))
        {

        }

        public override void AddMoney(int val)
        {
            base.AddMoney((int)(val + val * 0.01));
        }
    }
}
