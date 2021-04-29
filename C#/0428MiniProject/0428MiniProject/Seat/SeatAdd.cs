using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    class SeatAdd
    {
        private int InputMemberId(WbSeatList seatlist)
        {
            int memberid;
            while (true)
            {
                Console.Write("학생 아이디>>");
                memberid = int.Parse(Console.ReadLine());
                if (IdCheck(seatlist, memberid) == true)
                    break;
                Console.WriteLine("중복된 id");
            }
            return memberid;
        }

        public bool AddSeat(WbSeatList seatlist)       //수정기능
        {
            //학생id와 좌석id를 입력받아 처리...
            int memberid = InputMemberId(seatlist);

            Console.Write("좌석번호>>");
            int id = int.Parse(Console.ReadLine());

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    //비워있고 내가 원하는 좌석의 id가 맞다면
                    if (seatlist.Seats[i, j].Memberid == -1 &&
                                        seatlist.Seats[i, j].Id == id)
                        seatlist.Seats[i, j].Memberid = memberid;
                }
            }
            return true;
        }

        private bool IdCheck(WbSeatList seatlist, int id)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (seatlist.Seats[i, j].Memberid == id)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
