using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0506FormClient
{
    class PacketPaser
    {
        private LoginForm loginForm;
        private ChatForm chatForm;

        public void DlgFormRef(LoginForm form)
        {
            loginForm = form;
        }

        public void ChatFormRef(ChatForm form)
        {
            chatForm = form;
        }

        public void DataPaser(String msg)
        {
            try
            {
                String[] token = msg.Split('\a');
                if (token[0].Equals("WB_SHORTMESSAGE"))
                {
                    String[] token1 = token[1].Split('#');
                    chatForm.ShortMessageAck(token1[0], token1[1]);
                }
                else if (token[0].Equals("WB_ADDMEMBER_ACK_S"))
                {
                    String[] token1 = token[1].Split('#');
                    loginForm.AddMemberAck(true, token1[0], token1[1]);
                }
                else if (token[0].Equals("WB_ADDMEMBER_ACK_F"))
                {
                    String[] token1 = token[1].Split('#');
                    loginForm.AddMemberAck(false, token1[0], token1[1]); ;
                }
                else if (token[0].Equals("WB_LOGIN_ACK_S"))
                {
                    loginForm.LoginAck(true, token[1]);
                }
                else if (token[0].Equals("WB_LOGIN_ACK_F"))
                {
                    loginForm.LoginAck(false, token[1]);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
