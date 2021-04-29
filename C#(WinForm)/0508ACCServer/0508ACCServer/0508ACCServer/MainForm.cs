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


    public partial class MainForm : Form
    {
        List<Account> acclist = new List<Account>();// Account객체를 리스트로 생성
        public bool isp;
        public int iomo;
        public MainForm()
        {
            InitializeComponent();
            Bank.Singleton.MainFormRef = this;
        }

        private void OnMenuFileExit(object sender, EventArgs e)
        {//파일 프로그램 종료
            this.Close();
        }

        private void OnMenuInfo(object sender, EventArgs e)
        {//프로그램 정보
            String str = String.Format("{0}\n{1}\n{2}",
                "계좌 관리프로그램 Ver1.0", "woosongbit", "2020-05-08");
            MessageBox.Show(str, "정보");
        }

        private void OnMenuAddAccount(object sender, EventArgs e)
        {

            AccAddForm form = new AccAddForm(); //모달 AccAddForm 띄우기
            // form.ShowDialog(); 뭐냐 얘는
            if (form.ShowDialog() == DialogResult.OK)
            {
                String name = form.AccName;//AccAddForm 에서 이름 얻어오기
                int money = form.Balance;  //AccAddForm 에서 입금액 얻어오기

                Bank.Singleton.MakeAccount(name, money);// 뱅크가 이떄만들어지고 서버에 접속

            }
        }
        public void MakeAccountAck(Account acc, String dt)
        {
            //리스트뷰에 출력
            ListViewItem lvi = new ListViewItem(acc.Id.ToString());
            lvi.SubItems.Add(acc.Balance.ToString());
            lvi.SubItems.Add(dt);

            listView1.Items.Add(lvi);

            acclist.Add(acc);
            int sum = 0;
            for (int i = 0; i < acclist.Count(); i++)
            {
                sum = sum + acclist[i].Balance;
            }
            label1.Text = String.Format("총 합계 금액" + sum.ToString());
        }



        private void OnMenuInputOutput(object sender, EventArgs e)
        {


            AccIOForm form = new AccIOForm(acclist);
            if (form.ShowDialog() == DialogResult.OK)
            {

                int id = form.AccId;
                int money = form.IoBalance;
                bool isinput = form.IsInput;// 트루면 입금 , false면 출금임!

                isp = isinput;
                iomo = money;

                Bank.Singleton.IOAccount(id, isinput, money);
            }


        }


        public void IOAccountAck(Account acc)
        {


            for (int i = 0; i < acclist.Count(); i++)
            {
                if (acclist[i].Id == acc.Id)
                {
                    acclist[i].Balance = acc.Balance;
                }

            }

            //리스트뷰에 출력


            ListViewItem lvi = new ListViewItem(acc.Dt.ToString());
            if (isp == true)
            {
                lvi.SubItems.Add(iomo.ToString());
                lvi.SubItems.Add("0");
            }
            else if (isp == false)
            {

                lvi.SubItems.Add("0");
                lvi.SubItems.Add(iomo.ToString());
            }

            lvi.SubItems.Add(acc.Balance.ToString());

            listView2.Items.Add(lvi);

            label5.Text = acc.Id.ToString();
            label6.Text = acc.Balance.ToString();
            label7.Text = acc.Dt.ToString();


        }



        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection select = listView1.SelectedItems;

            foreach (ListViewItem item in select)
            {
                label5.Text = item.SubItems[0].Text;
                label6.Text = item.SubItems[1].Text + "\r\n";
                label7.Text = item.SubItems[2].Text + "\r\n";
            }

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
