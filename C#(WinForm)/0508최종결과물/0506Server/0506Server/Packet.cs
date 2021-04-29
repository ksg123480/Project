using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0506Server
{
    class Packet
    {
        public static String ShortMessage(string id, string data)
        {
            String msg = null;

            msg += "WB_SHORTMESSAGE\a";
            msg += id + "#";
            msg += data;

            return msg;
        }

        public static String AddMember(bool flag, string id, string name)
        {
            String msg = null;

            if (flag == true)
            {
                msg += "WB_ADDMEMBER_ACK_S\a";
                msg += id + "#";
                msg += name;
            }
            else
            {
                msg += "WB_ADDMEMBER_ACK_F\a";
                msg += id + "#";
                msg += name;
            }

            return msg;
        }

        public static String Login(bool flag,
            string id, string pw, string name, string phone,
            List<Member> memlist)
        {
            String msg = null;
            if (flag == true)
            {
                msg += "WB_LOGIN_ACK_S\a";
                foreach (Member mem in memlist)
                {
                    msg += mem.Id + "#";
                    msg += mem.Name + "#";
                    msg += mem.Phone + "@";
                }
            }
            else
            {
                msg += "WB_LOGIN_ACK_F\a";
                msg += id;
            }

            return msg;
        }
    }
}
