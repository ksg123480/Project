using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0506Server
{
    class Account
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Balance { get;  set; }
        public DateTime Dt { get; private set; }

        public Account(int _id, string _name, int _balance)
        {
            Id = _id;
            Name = _name;
            Balance = _balance;
            Dt = DateTime.Now;
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3}",
                Id, Name, Balance, Dt.ToString());
        }
    }
}
