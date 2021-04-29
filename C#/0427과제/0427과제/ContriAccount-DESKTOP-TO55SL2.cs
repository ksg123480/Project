using System;

namespace _0427과제
{
    class ContriAccount : Account
    {
        private double contribution;

        #region 프로퍼티
        public double Contribution
        {
            get { return contribution; }
            set { contribution = value; }
        }
        #endregion

        #region 생성자와 메서드
        public ContriAccount(int _id, String _name, double _balance)
            : base(_id, _name, _balance - _balance * 0.01)
        {
            contribution = 0;
            Contribution = Balance * 0.01;
        }

        public override void AddMoney(double val)
        {
            base.AddMoney(val - val * 0.01);
            Contribution = Contribution + val * 0.01;
        }

        public override void ShowAllData()
        {
            base.ShowAllData();
            Console.WriteLine("총 기부액 : " + Contribution);
        }
        #endregion
    }
}
