using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0506FormClient
{
    public partial class AddMemberForm : Form
    {
        public AddMemberForm()
        {
            InitializeComponent();
        }

        public void GetData(out string id, out string pw, out string name, out string phone )
        {
            id = textBox1.Text;
            pw = textBox2.Text;
            name = textBox3.Text;
            phone = textBox4.Text;
        }
        //회원가입 버튼
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
