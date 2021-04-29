using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0506Server
{
    class Packet
    {
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

        public static String Login(bool flag, string id, string pw, string name, string phone)
        {
            String msg = null;
            if (flag == true)
            {
                msg += "WB_LOGIN_S\a";
                msg += id + "#";
                msg += pw + "#";
                msg += name + "#";
                msg += phone;
            }
            else
            {
                msg += "WB_LOGIN_F\a";
                msg += id;
            }

            return msg;
        }
    }
}
