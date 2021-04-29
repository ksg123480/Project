using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0504_1
{
    class Program
    {
        static void Main(string[] args)
        {
            NewMethod2();
        }

        //Main 함수의 역할은 Application 객체를 통해 Main폼을 실행
        //하고 MessageLoop를 돌리는 기능

        private static void NewMethod2()
        {
            Application.Run(new MyForm2("내가만든폼"));
        }
        //멤버변수
        static string[] strText = { "빨", "주", "노", "초", "파", "남", "보" };
        private static void NewMethod1()
        {
            //Form을 저장할 수 있는 7개의 배열을 생성
            Form[] wnd = new Form[7];

            for (int i = 0; i < 7; i++)
            {
                wnd[i] = new Form();
                wnd[i].Text = strText[i];
                wnd[i].SetBounds((i + 1) * 10, (i + 1) * 10, 100, 100);
                wnd[i].MaximizeBox = false;
                wnd[i].Show();
                Console.WriteLine("{0} 번째 윈도우 출력 성공!!!", i);
            }

            Application.Run(wnd[0]);   //7개 중 0번째가 mainFrom!!!!
        }
        //Form 초기화 및 실행
        private static void NewMethod()
        {
            Form obj = new Form();
            obj.Text = "Form클래스를 이용한 윈폼";
            obj.SetBounds(10, 10, 300, 150);
            obj.MaximizeBox = false;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Opacity = 0.5;

            Application.Run(obj);
        }
    }
}
