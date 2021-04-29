using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _0506Client
{
    class Program
    {
        private WbClient client;

        public Program()
        {
            client = new WbClient(LogMessage, RecvData);
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

            Console.WriteLine(">> [{0}:{1}] {2}\t{3}",
                ip, port, msg, DateTime.Now.ToString());
        }

        #endregion

        static void Main(string[] args)
        {
            Program pr = new Program();

            pr.client.CreateClient("61.81.99.67", 9000);
            Console.WriteLine("서버에 접속...");  // 만약 서버 접속이 실패하면 예외 발생

            //송신           
            while (true)
            {
                String msg = Console.ReadLine();
                pr.client.Send(msg);
            }

            //server.Close();
        }
    }
}
