using System;
using System.Windows.Forms;

namespace _0508ACCServer
{
    class PacketParser
    {

        public static void DataParser(String msg)
        {
            //"ACK_MAKEACCOUNT_S\a계좌번호#고객명#입금액#일시“
            try
            {
                String[] token = msg.Split('\a');
                if (token[0].Equals("ACK_MAKEACCOUNT_S"))
                {
                    String[] token1 = token[1].Split('#');
                    Bank.Singleton.MakeAccountAck(int.Parse(token1[0]), token1[1],
                        int.Parse(token1[2]), token1[3]);
                }
                else if (token[0].Equals("ACK_IOACCOUNT_S"))
                {//"ACK_IOACCOUNT_S\a계좌아이디#해당계좌최종잔액"
                    String[] token1 = token[1].Split('#');
                    Bank.Singleton.IOAccountAck(int.Parse(token1[0]), int.Parse(token1[1]));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("test");
            }

        }
    }
}
