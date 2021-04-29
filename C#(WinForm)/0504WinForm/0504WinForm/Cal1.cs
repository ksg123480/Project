using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0504WinForm
{
    delegate void EventHandler(int n1, int n2, char op, float result);
    delegate void EventStringHandler(string msg);
    //1.딜리게이션 먼저생성
    class Cal1
    {
        public event EventHandler GetResultEvent;
        public event EventStringHandler StringEvent;
        //2.이벤트생성
       
        public float Result { get; private set; }
        //Result 값을 외부에서 가져갈수있도록 프로퍼티화

      
        public void Add(int n1, int n2)
        {
            Result = (float)n1 + n2;
            StringEvent("덧셈 연산 수행");
            GetResultEvent(n1, n2, '+', Result);
        }//3.이벤트 적절한 시기 사용

        public void Sub(int n1, int n2)
        {
            Result = (float)n1 - n2;
            StringEvent("뺄셈 연산 수행");
            GetResultEvent(n1, n2, '-', Result);
        }

    }
}

