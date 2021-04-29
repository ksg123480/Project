using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0504WinForm
{
    //delegate : 1. 클래스를 정의하는 문법 => 함수포인터 형식 사용
    delegate void CalResultDel(int n1, int n2, char op, float result);

    class Cal
    {
        //2. 레퍼런스 변수 선언(아직 객체가 만들어지지 않음)
        public CalResultDel DelCallback { get; set; }
     
        public float Result { get; private set; }
        //Result 값을 외부에서 가져갈수있도록 프로퍼티화

        public void Add(int n1, int n2)
        {
            Result = (float)n1 + n2;

            //Callback 호출 발생..
            //미리 등록된 함수를 호출시키는과정
            //1.암시적으로 invoke 함수를 호출시킴
            DelCallback(n1, n2, '+', Result);
            //2.명시적 호출방법
            DelCallback.Invoke(n1, n2,'+', Result);
        }

        public void Sub(int n1, int n2)
        {
            Result = (float)n1 - n2;
        }
    }
}
