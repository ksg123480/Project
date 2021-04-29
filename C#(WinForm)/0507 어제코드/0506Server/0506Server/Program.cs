using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using _WbServer;

namespace _0506Server
{
    class Program
    {
        List<Member> memlist = new List<Member>();

        //멤버필드 값
        private WbServer server;

        public Program()
        {//객체생성
            server = new WbServer(LogMessage, RecvData);
        }
        public void LogMessage(LogType It, String ip, int port)
        {
            DateTime dt = DateTime.Now;

            if(It == LogType.SERVERRUN)
            { 
                Console.WriteLine("서버 시작... 클라이언트 접속 대기중...");
                Console.WriteLine("{0}:{1}\t{2}", ip,port,dt.ToString());
            }
            else if(It == LogType.CONNECT)
            {
                Console.WriteLine("[접속] {0}:{1}\t{2}", ip,port, dt.ToString());
            }
            else if (It == LogType.DISCONNECT)
            {
                Console.WriteLine("[해제] {0}:{1}\t{2}", ip, port, dt.ToString());
            }
            else if(It == LogType.ERROR)
            {
                Console.WriteLine("[에러]" + ip+ "\t" + dt.ToString());
            }
        }

        public void RecvData(Socket sock, String msg)
        {
            //1. 데이터 수신
            String ip;
            int port;
            server.GetRemoteIpPort(sock, out ip, out port);

            Console.WriteLine(">>[{0}:{1}] {2}\t{3}",
                ip, port, msg, DateTime.Now.ToString());

            //2.데이터 처리
            String packet = PacketPaser.DataPaser(memlist, msg);
            //받은 데이터를 PacketParser로 전달
            //3.결과 전송
            try
            {
                //패킷의 0번쨰 문자열을 분석해서 전체, 개인에게 보내는것을
                //분류
                String[] split = packet.Split('\a');
                if(split[0].Equals("WB_ADDMEMBER_ACK_S") ||
                   split[0].Equals("WB_ADDMEMBER_ACK_F") ||
                   split[0].Equals("WB_LOGIN_ACK_S") ||
                   split[0].Equals("WB_LOGIN_ACK_F"))
                {
                    server.SendData(sock, packet, packet.Length);
                }
                else
                { 
                    server.SendAllData(sock, packet, packet.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[전송에러]" + ex.Message);
            }
        }
      
        //=================================
        static void Main(string[] args)
        {
            Program pr = new Program(); //샘플객체 생성

            if(pr.server.CreateSocket(9000) == false)
            {
                Console.WriteLine("소켓 생성 오류");
            }

            pr.server.ServerThread.Join();
        }
    }
}
