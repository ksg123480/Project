using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    class SeatSelect
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

        public Seat SelectSeat(WbSeatList seatlist)
        {
            Console.Write("검색할 좌석>>");
            int id1 = int.Parse(Console.ReadLine());

            return IdToSeat(seatlist, id1);
        }
    }
}

