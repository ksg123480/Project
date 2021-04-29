using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0506FormClient
{
    class PacketParser
    {
        public static void DataParser(String msg)
        {
            String[] token = msg.Split('\a');
            if (token[0].Equals("WB_ADDMEMBER_ACK_S"))
            {
                AddMember_S(token[1]);
            }
            else if (token[0].Equals("WB_ADDMEMBER_ACK_F"))
            {
                AddMember_F(token[1]);
            }
            else if (token[0].Equals("WB_LOGIN_S"))
            {
                WB_LOGIN_S(token[1]);
            }
            else if (token[0].Equals("WB_LOGIN_F"))
            {
                WB_LOGIN_F(token[1]);
            }
            else
                return;
        }

        private static void AddMember_S(String msg)
        {
            //데이터 처리
            String[] token = msg.Split('#');
            MessageBox.Show(String.Format("{0}님 회원가입 완료!",
                token[1]));
        }

        private static void AddMember_F(String msg)
        {
            //데이터 처리
            String[] token = msg.Split('#');
            MessageBox.Show(String.Format(" {0}님 \n회원가입 실패...",
                token[2]));
        }

        private static void WB_LOGIN_S(String msg)
        {
            //데이터 처리
            String[] token = msg.Split('#');
            MessageBox.Show(String.Format(" {0}님 \n어서오세요",
                token[2]));
        }

        private static void WB_LOGIN_F(String msg)
        {
            //데이터 처리
            String[] token = msg.Split('#');
            MessageBox.Show(String.Format("없는 아이디 입니다"));
        }
    }
}
