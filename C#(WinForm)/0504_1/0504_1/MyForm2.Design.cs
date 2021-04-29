//MyForm2.Design.cs : 디자인
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0504_1
{
    public partial class MyForm2 : Form
    {
        /// <summary>
        /// 내가 작성하는 부분이 아니라 툴에 의해서 자동으로 생성되는
        /// 코드가 만들어지는 부분
        /// </summary>
        /// <param name="strText"></param>
        private void InitDesign(string strText)
        {
            //속성 초기화
            this.Text = strText;

            //이벤트 핸들러 등록
            this.MouseMove += new MouseEventHandler(this.Form_MouseMove);
            this.Closed += new EventHandler(this.Form_Closed);

            //화면 출력
            this.Show();
        }
    }
}
