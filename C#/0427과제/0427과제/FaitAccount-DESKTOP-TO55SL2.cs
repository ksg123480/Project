using System;

namespace _0427과제
{
    class FaitAccount : Account
    {
        public FaitAccount(int _id, String _name, double _balance)
            : base(_id, _name, _balance + _balance * 0.01)
        { }

        public override void AddMoney(double val)
        //부모에있는(override) AddMoney 를
        //부모함수의 정의를 재정의
        {
            base.AddMoney(val + val * 0.01);
        }
    }
}
