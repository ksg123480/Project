using _0428MiniProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    /// <summary>
    /// List의 기능을 다 상속받음.
    /// </summary>
    class WbMemberList : List<Member>
    {
        public new void Add(Member mem)
        {
            //추가 전에 사전 작업을 수행할 수 있다.

            base.Add(mem);
        }
    }
}
