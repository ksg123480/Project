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
    public partial class ChatForm : Form
    {
        public String Id { get; private set; }
        public String Pw { get; set; }
        public String MyName { get; set; }
        public String Phone { get; set; }
        public ChatForm()
        {
            InitializeComponent();

            //자신의 레퍼런스를 RPCControl에 전달
            RPCControl.Singleton.ChatFormRef(this);
        }

        public void SendData(String id, String msg)
        {
            //받은 정보를 출력
            Id = id;

            String[] split = msg.Split('@');
            for(int i=0; i<split.Length-1; i++)
            {
                String[] split1 = split[i].Split('#');
                //아이디,이름,전화번호
                listBox1.Items.Add(String.Format("{0}, {1}, {2}",
                    split1[0], split1[1], split1[2]));
            }
            MessageBox.Show(msg);
        }

        //전송버튼
        private void button1_Click(object sender, EventArgs e)
        {
            //정보획득
            String data = textBox1.Text;

            //패킷 생성
            String msg = Packet.ShortMessage(Id, data);

            //소켓통신(전송)
            RPCControl.Singleton.SendData(msg);
        }
        public void ShortMessageAck(String id, String msg)
        {
            String str = String.Format("[{0}] {1} ({2}",
                id, msg, DateTime.Now.ToString());

            listBox2.Items.Add(str);
        }
    }
}
