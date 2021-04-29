using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0508ACCServer
{
    class Bank//송수신 담당
    {
        #region 싱글톤

        public static Bank Singleton { get; private set; }

        static Bank()  //객체 사용시 최초 한번만 호출 
        {
            Singleton = new Bank();
        }

        private Bank()
        {
            try
            {
                // "61.81.99.67"
                client = new WbClient(LogMessage, RecvData);
                client.CreateClient("127.0.0.1", 9000);

             
            }
            catch (Exception ex)
            {
               //MessageBox.Show(ex.Message);
            }
        }
        #endregion

        WbClient client;// 객체생성
        public MainForm MainFormRef { get;set; }
        //MainForm에 대한 객체

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

        public void RecvData(Socket sock, String msg)//데이터 수신
        {
            String ip;
            int port;
            client.GetRemoteIpPort(sock, out ip, out port);

            //          Console.WriteLine(">> [{0}:{1}] {2}\t{3}",
            //              ip, port, msg, DateTime.Now.ToString());

            PacketParser.DataParser(msg);
        }

        #endregion


        #region 기능메서드

        public void MakeAccount(String name, int money)
        {
            string packet = Packet.MakeAccount(name, money);
            
            client.Send(packet); //전송 
            //"PACKET_MAKEACCOUNT\a name + "#"money"
        }


        public void MakeAccountAck(int id, string name, int money, string dt)
        {//메세지박스 출력
            MessageBox.Show(String.Format("{0},{1},{2},{3}",
                  id, name, money, dt));

            Account acc = new Account(id, name, money);
            MainFormRef.MakeAccountAck(acc, dt);
        }

        public void IOAccount(int id, bool isinput, int money)
        {
            string packet = Packet.IOAccount(id, isinput, money);
            client.Send(packet);
           //“PACKET_IOACCOUNT\a아이디#입출금여부#입출금액
        }

        public void IOAccountAck(int id, int money)
        {//메세지박스 출력
            MessageBox.Show(String.Format("{0},{1}", 
                id, money));

            Account acc = new Account(id, "", money);
            MainFormRef.IOAccountAck(acc);

        }
        #endregion

    }

}
