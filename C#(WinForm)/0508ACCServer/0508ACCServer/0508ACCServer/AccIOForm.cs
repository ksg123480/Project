using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0508ACCServer
{
    public partial class AccIOForm : Form
    {
        #region 프로퍼티를 기반으로 한 컨트롤 정보제공

        public int AccId
        {
            get { return int.Parse(comboBox1.SelectedItem.ToString()); }
        }
        public int IoBalance
        {
            get { return int.Parse(textBox1.Text); }
        }

        public bool IsInput
        {
            get { return radioButton1.Checked; }
        }

        #endregion
       

        public AccIOForm(List<Account> acclist)
        {
            InitializeComponent();

            for (int i = 0; i < acclist.Count; i++)
            {
                comboBox1.Items.Add(acclist[i].Id.ToString());

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;//기본설정
            this.Close();
        }
    }
}
