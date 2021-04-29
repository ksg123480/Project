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
       public static String DataPaser(List<Member> memlist, String msg)
        {//받은 데이터 분석
            String[] token = msg.Split('\a');
            if (token[0].Equals("WB_ADDMEMBER"))
            {
                return AddMember(memlist, token[1]);
            }
            else if (token[0].Equals("WB_LOGIN"))
            {
                return Login(memlist, token[1]);
            }
            else if (token[0].Equals("WB_SHORTMESSAGE"))
            {
                String[] token1 = token[1].Split('#');
                return ShortMessage(token1[0], token1[1]);
            }
            else
                return String.Empty;
        }

        private static String ShortMessage(String id, String msg)
        {
            return Packet.ShortMessage(id, msg);
        }


        private static String AddMember(List<Member> memlist, String msg)
        {
            //데이터 처리
            String[] token = msg.Split('#');
            memlist.Add(new Member(token[0], token[1], token[2], token[3]));

            //패킷 생성
            return Packet.AddMember(true,token[0], token[2]);
        }


        private static String Login(List<Member> memlist, String msg)
        {
            //데이터 처리
            String[] token = msg.Split('#');
            foreach(Member mem in memlist)
            {
                if(mem.Id.Equals(token[0]) && mem.Pw.Equals(token[1]))
                {
                    mem.IsLogin = true;
                    return Packet.Login(true,mem.Id,mem.Pw,mem.Name, mem.Phone,memlist);
                }
            }
            //패킷 생성
            return Packet.Login(false, token[0], "", "","",memlist);
        }
    }
}
