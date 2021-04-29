using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    class SeatMove
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

        public bool MoveSeat(WbSeatList seatlist)
        {
            int id1, id2;

            Console.Write("현재 좌석>>");
            id1 = int.Parse(Console.ReadLine());

            Console.Write("이동할 좌석>>");
            id2 = int.Parse(Console.ReadLine());

            Seat seat1 = IdToSeat(seatlist, id1);
            Seat seat2 = IdToSeat(seatlist, id2);

            if (seat1.Memberid == -1)
                return false;

            seat2.Memberid = seat1.Memberid;
            seat1.Memberid = -1;

            return true;
        }
    }
}
