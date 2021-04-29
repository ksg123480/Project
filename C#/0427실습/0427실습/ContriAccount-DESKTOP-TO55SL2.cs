using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0427실습

{
    class ContriAccount : Account
    {
        public int contribution;

        #region 프로퍼티
        public int Contribution
        {
            get { return contribution; }
            set { contribution = value; }
        }
        #endregion

        public ContriAccount(int id, String name, int balance)//기부계좌
            : base(id, name, (int)(balance - balance * 0.01))
        {
            Contribution = (int)(balance * 0.01);
        }

        public override void AddMoney(int val)
        {
            base.AddMoney((int)(val - val * 0.01));
            Contribution += (int)(val * 0.01);
        }

        public override void ShowAllData()
        {
            base.ShowAllData();
            Console.WriteLine("총 기부액 : {0}", Contribution);
        }
    }
}
