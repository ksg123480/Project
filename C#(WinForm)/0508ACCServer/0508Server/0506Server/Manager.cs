using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0506Server
{


    class Manager
    {
        #region 싱글톤

        public static Manager Singleton { get; private set; }

        static Manager()  //객체 사용시 최초 한번만 호출 
        {
            Singleton = new Manager();
        }

        private Manager()
        {
        }
        #endregion

        List<Account> accounts = new List<Account>();//Account 객체를 리스트형식으로 생성
        List<AccountIO> acclists = new List<AccountIO>(); //AccountIO객체를 리스트형식으로 생성
        static int s_id = 1000;
        public string MakeAccount(string name, int money)
        {
            Account acc = new Account(s_id, name, money);
            accounts.Add(acc);

            AccountIO accio = new AccountIO(s_id, money, 0, money);

            s_id = s_id + 10;

            //패킷 생성
            return Packet.MakeAccount(true, acc);
        }

        public string IOAccount(int id, bool isinput, int money)
        {

            int idx = 0;
            int op = 0;
            int ip = 0;
            for (int i = 0; i < accounts.Count(); i++)
            {
                if (accounts[i].Id == id)
                {
                    if (isinput == true)//입금
                    {
                        accounts[i].Balance = accounts[i].Balance + money;
                        idx = i;
                        ip = 1;
                    }
                    else if (isinput == false)//출금
                    {

                        accounts[i].Balance = accounts[i].Balance - money;
                        idx = i;
                        op = 1;
                    }
                }


            }

            AccountIO accio = new AccountIO(accounts[idx].Id, ip, op, accounts[idx].Balance);
                                                                //ID,입금,출금,최종 잔액
            return Packet.IOAccount(true, accio);

        }
    }
}
