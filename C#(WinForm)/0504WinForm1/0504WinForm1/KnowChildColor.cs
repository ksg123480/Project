using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0504WinForm1
{
    public partial class KnowChildColor : Form
    {
        public String StrText { get; set; }

        public KnowChildColor(string str)
        {
            InitializeComponent();

            //직접 하드코딩할 경우는 InitalizeComponent(); 하단에
            this.Text = str;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

        }
        //무효화 처리... (가상함수, 이벤트핸들러가 아님..)
        protected override void OnPaint(PaintEventArgs e)
        {
            //Win32API의 BeginPain()로 생성한 dc
            Graphics grfx = e.Graphics;
            SolidBrush br = new SolidBrush(Color.HotPink);
            grfx.DrawString(StrText, this.Font, br, 10, 7);
            
            base.OnPaint(e);
        }
    }
}
