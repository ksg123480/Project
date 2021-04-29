using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel.Com2Interop;
using Wb31.Client;

namespace _0506FormClient
{
    class RPCControl
    {
        #region 싱글톤
        public static RPCControl Singleton { get; private set; }

         static RPCControl()    //객체 사용시 최초 한번만 호출
        {
            Singleton = new RPCControl();
        }
        
        private RPCControl() 
        {
            try
            {

                client = new WbClient(LogMessage, RecvData);
                client.CreateClient("127.0.0.1", 9000); //교수님 :61.81.99.67  / 127.0.0.1

                paser = new PacketPaser(); 
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //this.Close();  //폼을 죽이는게 아니라 자신의 프로세스를 종료
            }
        }

        #endregion

        private WbClient client;// 통신쪽
        private PacketPaser paser; //패킷쪽

        #region WbClient ==> Program(Form)
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
           
            paser.DataPaser(msg);
        }
        #endregion

        #region  Program(Form) ==> WbClient
        public void SendData(String msg)
        {
            client.Send(msg);
        }
        #endregion

        public void DlgFormRef(LoginForm form)
        {
            paser.DlgFormRef(form);
        }

        public void ChatFormRef(ChatForm form)
        {
            paser.ChatFormRef(form);
        }
    }
}
