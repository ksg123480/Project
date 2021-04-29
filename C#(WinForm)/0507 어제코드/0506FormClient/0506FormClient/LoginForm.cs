using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wb31.Client;

namespace _0506FormClient
{
    public partial class LoginForm : Form
    {
        //자신이 로그인할떄 사용한 ID
        public String Id { get; private set; }
        public LoginForm()
        {
            InitializeComponent();

            //자신의 레퍼런스를 RPCControl에 전달
            RPCControl.Singleton.DlgFormRef(this);
        }
        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //로그인버튼
        private void button1_Click(object sender, EventArgs e)
        {
            //정보획득
            String id, pw;
            id = textBox1.Text;
            pw = textBox2.Text;
            Id = id;

            //패킷 생성
           String msg = Packet.Login(id, pw);
            //소켓통신(전송)
            RPCControl.Singleton.SendData(msg);
        }

        public void LoginAck(bool flag, String msg)
        {
            if (flag == true)
            {
                Thread th = new Thread(new ParameterizedThreadStart(ShowLoginForm));
                th.Start(msg);
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                MessageBox.Show("로그인 실패");
            }
        }

        private void ShowLoginForm(object msg)
        {
            String data = (String)msg;
            //this.Hide();

            //다음 창을 실행(모달) 
            ChatForm form = new ChatForm();
            form.SendData(Id, data);
            form.ShowDialog();
        }

        //회원가입 버튼
        private void button2_Click(object sender, EventArgs e)
        {
            //Do모달다이얼로그
            AddMemberForm form = new AddMemberForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                //정보 획득
                String id, pw, name, phone;
                form.GetData(out id, out pw, out name, out phone); 
                
                //패킷 생성
                String msg = Packet.AddMember(id, pw, name, phone);

                //소켓 통신(전송)
                RPCControl.Singleton.SendData(msg);

            }
        }
   
        public void AddMemberAck(bool flag, String id, String name)
        {
            if(flag == true)
            {
                MessageBox.Show("회원 가입이 성공 했습니다");
            }
            else
            {
                MessageBox.Show("회원 가입이 실패 했습니다");
            }
        }
    }
}

