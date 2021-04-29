using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0506Server
{
    class Packet
    {
     
        public static String MakeAccount(bool flag, Account acc)
        {
            String msg = null;
            //"ACK_MAKEACCOUNT_S\a계좌번호#고객명#입금액#일시"

            if (flag == true)
            {
                msg += "ACK_MAKEACCOUNT_S\a";
                msg += acc.Id+ "#";
                msg += acc.Name +"#";
                msg += acc.Balance + "#";
                msg += acc.Dt.ToString();
            }
            else
            {
                msg += "ACK_MAKEACCOUNT_F\a";
                msg += acc.Name;
            }

            return msg;
        }
        public static String IOAccount(bool flag, AccountIO acc)
        {
            String msg = null;
            //"“ACK_IOACCOUNT_S\a계좌아이디#해당계좌최종잔액“


            if (flag == true)
            {
                msg += "ACK_IOACCOUNT_S\a";
                msg += acc.Id + "#";
                msg += acc.Balance ;
                
            }
            else
            {
                msg += "ACK_IOACCOUNT_F\a";
                msg += acc.Id;
            }

            return msg;
        }
    }
}
