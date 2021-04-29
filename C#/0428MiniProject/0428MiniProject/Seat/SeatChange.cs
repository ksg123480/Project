using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    class SeatChange
    {
        private Seat IdToSeat(WbSeatList seatlist, int id)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (seatlist.Seats[i, j].Id == id)
                    {
                        return seatlist.Seats[i, j];
                    }
                }
            }
            return null;
        }

        public bool ChangeSeat(WbSeatList seatlist)
        {
            int id1, id2;

            Console.Write("첫번째 좌석>>");
            id1 = int.Parse(Console.ReadLine());

            Console.Write("두번째 좌석>>");
            id2 = int.Parse(Console.ReadLine());

            Seat seat1 = IdToSeat(seatlist, id1);
            Seat seat2 = IdToSeat(seatlist, id2);

            if (seat1.Memberid == -1 || seat2.Memberid == -1)
                return false;

            int temp = seat1.Memberid;
            seat1.Memberid = seat2.Memberid;
            seat2.Memberid = temp;

            return true;
        }
    }
}
