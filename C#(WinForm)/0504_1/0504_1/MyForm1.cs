using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0504_1
{
    //이벤트 구독자 클래스
    class MyForm1 : Form
    {
       public MyForm1(string strText)
        {
            //1. 멤버변수 초기화 (프로퍼티를 통한 초기화 작업)
            this.Text = strText;
            this.Top = 10;
            this.Left = 10;
            this.Width = 250;
            this.Height = 200;
            this.MaximizeBox = false;
            this.MinimizeBox = false;


            //2. 이벤트 등록
            this.Load += new EventHandler(Form_Load);
            this.FormClosing += new FormClosingEventHandler(this.Form_Closing);
            this.FormClosed += new FormClosedEventHandler(Form_Closed);
            this.MouseMove += new MouseEventHandler(this.Form_MouseMove);
            this.Show();

        }

        #region 핸들러함수
        //void XXXX(object, XXXEventArgs)
        private void Form_Load(object sender, EventArgs e)
        {
            Console.WriteLine("윈도우가 Load 됩니다.");
        }

        private void Form_Closed(object sender , FormClosedEventArgs e)
        {
            //e.CloseReason;
            Console.WriteLine("윈도우가 Closed 됩니다.");
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            DialogResult r =MessageBox.Show("종료하시겠습니까", "알림",
                MessageBoxButtons.OKCancel);
            if(r == DialogResult.Cancel)

            e.Cancel = true;
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = string.Format("마우스 좌표 : {0},{1}",
                e.X,e.Y);
        }
        #endregion
    }
}
