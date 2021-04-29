namespace _0507DLL
{
     public class Cal //internal 동일한 어셈블리 안에서 
                            //만 접근할수있는 클래스(public 전환)
    {
        public float result { get; private set; }

        public void Add(int num1, int num2) { result = (float)num1 + num2; }
        public void Sub(int num1, int num2) { result = (float)num1 - num2; }
        public void Mul(int num1, int num2) { result = (float)num1 * num2; }
        public void Div(int num1, int num2) { result = (float)num1 / num2; }
    }
}
