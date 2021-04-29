using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    class SeatManager
    {
        private WbSeatList seatlist = new WbSeatList();

        #region 싱글톤
        public static SeatManager Singleton { get; private set; }

        private SeatManager() { }

        static SeatManager()
        {
            Singleton = new SeatManager();
        }

        #endregion

        public void PrintAll()
        {
            seatlist.PrintAll();
        }
        public void AddSeat()
        {
            if (new SeatAdd().AddSeat(seatlist) == true)
                Console.WriteLine("좌석 배치 완료");
            else
                Console.WriteLine("좌석 배치 오류");
        }

        public void MoveSeat()
        {
            if (new SeatMove().MoveSeat(seatlist) == true)
                Console.WriteLine("좌석 이동 완료");
            else
                Console.WriteLine("좌석 이동 오류");
        }

        public void ChangeSeat()
        {
            if (new SeatChange().ChangeSeat(seatlist) == true)
                Console.WriteLine("좌석 교환 완료");
            else
                Console.WriteLine("좌석 교환 오류");
        }

        public void DeleteSeat()
        {
            if (new SeatDelete().DeleteSeat(seatlist) == true)
                Console.WriteLine("좌석 비우기 완료");
            else
                Console.WriteLine("좌석 비우기 오류");
        }
        public void SelectSeat()
        {
            Seat seat = new SeatSelect().SelectSeat(seatlist);
            if (seat == null)
            {
                Console.WriteLine("없는 좌석아이디 입니다");
                return;
            }
            seat.PrintSeat();
        }
    }
}

