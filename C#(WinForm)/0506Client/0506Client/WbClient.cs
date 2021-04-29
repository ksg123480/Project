using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace _0506Client
{
    public enum LogType { CONNECT, DISCONNECT, ERROR }

    public delegate void DelLogMessage(LogType lt, String ip, int port);

    public delegate void DelRecvData(Socket sock, String msg);


    class WbClient
    {
        private Socket server;

        #region Callback 처리부분
        private DelLogMessage logmsg;
        private DelRecvData rdata;

        public WbClient(DelLogMessage lm, DelRecvData rd)
        {
            logmsg = lm;
            rdata = rd;
        }
        #endregion


        /// <summary>
        /// 서버접속처리 및 WorkThread 생성
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public bool CreateClient(String ip, int port)
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), port);

            server = new Socket(AddressFamily.InterNetwork,
                                     SocketType.Stream, ProtocolType.Tcp);

            server.Connect(ipep);  // 127.0.0.1 서버 7000번 포트에 접속시도


            //WorkThread 실행
            Thread tr = new Thread(new ThreadStart(WorkThread));
            tr.IsBackground = true;
            tr.Start();
            return true;
        }

        public void GetRemoteIpPort(Socket sock, out String ip, out int port)
        {
            IPEndPoint ep = (IPEndPoint)sock.RemoteEndPoint;
            ip = ep.Address.ToString();
            port = ep.Port;
        }


        private void WorkThread()
        {
            byte[] data;
            while (true)
            {
                int retval = ReceiveData(server, out data);

                IPEndPoint ip = (IPEndPoint)server.RemoteEndPoint;
                rdata(server, Encoding.Default.GetString(data, 0, retval));
            }
        }

        public int Send(String msg)
        {
            byte[] bymsg = Encoding.Default.GetBytes(msg);
            SendData(server, bymsg);
            return msg.Length;
        }

        public void Close()
        {
            server.Close();
        }

        #region Send & Data 처리부
        private void SendData(Socket sock, byte[] data)
        {
            try
            {
                int total = 0;
                int size = data.Length;
                int left_data = size;
                int send_data = 0;

                // 1. 전송할 데이터의 크기 전달
                byte[] data_size = new byte[4];
                data_size = BitConverter.GetBytes(size);
                send_data = sock.Send(data_size);

                // 2. 실제 데이터 전송
                while (total < size)
                {
                    send_data = sock.Send(data, total, left_data, SocketFlags.None);
                    total += send_data;
                    left_data -= send_data;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private int ReceiveData(Socket sock, out byte[] data)
        {
            try
            {
                int total = 0;
                int size = 0;
                int left_data = 0;
                int recv_data = 0;

                // 수신할 데이터 크기 알아내기 
                byte[] data_size = new byte[4];
                recv_data = sock.Receive(data_size, 0, 4, SocketFlags.None);
                size = BitConverter.ToInt32(data_size, 0);
                left_data = size;

                data = new byte[size];

                // 실제 데이터 수신
                while (total < size)
                {
                    recv_data = sock.Receive(data, total, left_data, 0);
                    if (recv_data == 0) break;
                    total += recv_data;
                    left_data -= recv_data;
                }
                return size;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
