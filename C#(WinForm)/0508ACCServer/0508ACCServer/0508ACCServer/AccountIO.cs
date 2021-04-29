using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0508ACCServer
{
    class AccountIO
    {
        public int Id { get; private set; }
        public int Input { get; private set; }
        public int Output { get; private set; }
        public int Balance { get; private set; }
        public DateTime Dt { get; private set; }

        public AccountIO(int _id, int _in,int _out, int _balance )
        {
            Id = _id;
            Input = _in;
            Output = _out;
            Balance = _balance;
            Dt = DateTime.Now;
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4}",
                Id, Input,Output ,Balance, Dt.ToString());
        }
    }
}

