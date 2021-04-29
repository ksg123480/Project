using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wb31.Client;

namespace _0506FormClient
{
    public partial class LoginForm : Form
    {
        private WbClient client;

        public LoginForm()
        {
            InitializeComponent();
            try 
            {
            
            client = new WbClient(LogMessage, RecvData);
            client.CreateClient("127.0.0.1", 7000); //교수님 :61.81.99.67  / 127.0.0.1
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }
        #region WbClient ==> Program

        public void LogMessage(LogType lt, String ip, int port)
        {
            DateTime dt = DateTime.Now;

            if (lt == LogType.CONNECT)
            {
                Console.WriteLine("[접속] {0}:{1}\t{2}", ip, port, dt.ToString());
            }
            else if (lt == LogType.DISCONNECT)
            {
                Console.WriteLine("[해제] {0}:{1}\t{2}", ip, port, dt.ToString());
            }
            else if (lt == LogType.ERROR)
            {
                Console.WriteLine("[에러] " + ip + "\t" + dt.ToString());
            }
        }

        public void RecvData(Socket sock, String msg)
        {
            String ip;
            int port;
            client.GetRemoteIpPort(sock, out ip, out port);

         //   Console.WriteLine(">> [{0}:{1}] {2}\t{3}",
           //     ip, port, msg, DateTime.Now.ToString());
            //데이터처리
            PacketParser.DataParser(msg);
        }

        #endregion

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

            //패킷 생성
           String msg = Packet.Login(id, pw);
            //소켓통신(전송)
            client.Send(msg);
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
                form.GetData(out id, out pw, out name, out phone); ;
                
                //패킷 생성
                String msg = Packet.AddMember(id, pw,name,phone);

                //소켓 통신
                client.Send(msg);

            }
        }
    }
}

