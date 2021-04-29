using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0429
{
    class WbDB : IDisposable
    {
        //DB연결객체
        private bool isconnect;

        public WbDB()
        {
            //DB연결코드
            isconnect = true;
        }

        ~WbDB()
        {
            Dispose();
        }

        //자원의 소멸처리를 위한 약속된 함수
        public void Dispose()
        {
            //DB연결해제
            isconnect = false;

            GC.SuppressFinalize(this);
            //가비지컬랙터.나더이상 소멸처리안해도되
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // NewMethod();
            exam2();
        }

        //객체 소멸에 대한 고찰?
        private static void exam2()
        {
            WbDB db = new WbDB();   //DB 연결
            db.Dispose();                    //DB 연결해체
        }
        //열거형에대한 고찰?
        private static void exam1()
        {
            DialogResult r;
            r = MessageBox.Show("테스트","캡션", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(r == DialogResult.Yes)
            {

            }
            else if(r == DialogResult.No)
            {

            }
        }
        //object 클래스의 멤버 함수 override
        private static void NewMethod()
        {
            WbDate d1 = new WbDate()
            {
                Year = 2020,
                Month = 4,
                Day = 29
            };

            WbDate d2 = d1;

            WbDate d3 = new WbDate()
            {
                Year = 2020,
                Month = 4,
                Day = 29
            };

            //============결과 검증 ================
            Console.WriteLine(d1.Equals(d2));                   //True
            Console.WriteLine(object.ReferenceEquals(d1, d2));   //True

            //부모로부터 물려받은 Equals는 RE의 성질을 갖는다.
            //따라서 사용하려면 재정의를 해야 한다. 
            Console.WriteLine(d1.Equals(d3));                   //True
            Console.WriteLine(object.ReferenceEquals(d1, d3));  //False

            //toString
            //객체명을 출력하면 암시적으로 ToString()을 호출한다.
            //부모로부터 물려받은ToString() : 자신의 네임스페이스.클래스명
            Console.WriteLine(d1.ToString());
            Console.WriteLine(d1);
        }
    }
}
