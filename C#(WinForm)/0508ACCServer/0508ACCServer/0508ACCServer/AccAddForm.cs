using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0508ACCServer
{
    public partial class AccAddForm : Form
    {
        public AccAddForm()
        {
            InitializeComponent();
        }

        #region 프로퍼티를 기반으로 한 컨트롤 정보제공

        public string AccName
        {
            get { return textBox1.Text; }
        }
        public int Balance
        {
            get { return int.Parse(textBox2.Text); }
        }


        #endregion
        //계좌생성버튼 핸들러
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;//기본설정
            this.Close();
        }

        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {

                textBox2.ReadOnly = false;
            }
            else  
            {
                textBox2.ReadOnly = true;
            }
        }
    }
}
