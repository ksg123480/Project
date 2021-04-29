using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace _0506Server
{
    class PacketPaser
    {
       public static String DataPaser( String msg)
        {//받은 데이터 분석
            String[] token = msg.Split('\a');
            if (token[0].Equals("PACKET_MAKEACCOUNT"))
            {
                //"PACKET_MAKEACCOUNT \a홍길동#1000"
                string[] token1 = token[1].Split('#');
                return Manager.Singleton.MakeAccount(token1[0],int.Parse(token1[1]));
            }
           // “PACKET_IOACCOUNT\a아이디#입출금여부#입출금액
            else if (token[0].Equals("PACKET_IOACCOUNT"))
            {
                string[] token1 = token[1].Split('#');
                return Manager.Singleton.IOAccount(int.Parse(token1[0]),
                    bool.Parse(token1[1]), int.Parse(token1[2]));
            }
            else
                return String.Empty;
        }
    }
}
