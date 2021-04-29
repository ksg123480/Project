//MyForm2.cs : 핸들러...
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0504_1
{
    public partial class MyForm2
    {
        public MyForm2(string strText) //생성자
        {
            InitDesign(strText);
        }

            //핸들러
            private void Form_MouseMove(object sender, MouseEventArgs e)
            {
                Console.WriteLine("MouseMove 이벤트 발생!!!");
                Console.WriteLine("(x,y)=({0},{1})", e.X, e.Y);
            }

            private void Form_Closed(object sender, EventArgs e)
            {
                Console.WriteLine("윈도우가 Closed 됩니다.");
            }
    }
}

