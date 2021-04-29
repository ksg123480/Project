using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0506FormClient
{
    class Packet
    {
        public static String AddMember(string id, string pw, string name, string phone)
        {
            String msg = null;
            msg += "WB_ADDMEMBER\a";
            msg += id + "#";
            msg += pw + "#";
            msg += name + "#";
            msg += phone;

            return msg;
        }
        public static String Login(string id, string pw)
        {
            String msg = null;
            msg += "WB_LOGIN\a";
            msg += id + "#";
            msg += pw + "#";

            return msg;
        }
    }
}
