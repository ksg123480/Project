using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0508ACCServer

{
    class Packet
    {
        public static String MakeAccount( string name, int money)
        {
            String msg = null;

            msg += "PACKET_MAKEACCOUNT\a";
            msg += name + "#";
            msg += money;

            return msg;

        }

        public static String IOAccount(int id,bool isinput, int money)
        {
            String msg = null;

            msg += "PACKET_IOACCOUNT\a";
            msg += id + "#";
            msg += isinput+ "#";
            msg += money;

            return msg;

        }
    }
}
