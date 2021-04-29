using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0506Server
{
    class PacketParser
    {
       public static String DataParser(List<Member> memlist, String msg)
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
            else
                return String.Empty;
        }
        private static String AddMember(List<Member> memlist, String msg)
        {
            //데이터 처리
            String[] token = msg.Split('#');
            memlist.Add(new Member(token[0], token[1], token[2], token[3]));

            //패킷 생성
            return Packet.AddMember(true,token[0], token[1]);
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
                    return Packet.Login(true,mem.Id,mem.Pw,mem.Name, mem.Phone);
                }
            }
            //패킷 생성
            return Packet.Login(false, token[0], "", ""," ");
        }
    }
}
