using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    class WbSeatList
    {
        //객체 생성과정에서 Seat 객체가 생성되서, 저장되어 있는 상태
        //뒤에 모든 연산은 Update연산 
        public Seat[,] Seats = new Seat[4, 10];

        public WbSeatList()
        {
            int idx = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Seats[i, j] = new Seat(++idx, i, j);
                }
            }
        }


        private void PrintSeat(int i, int j)
        {
            //앞부분 숫자 출력
            if (j == 0)
                Console.Write(" {0} : ", i);

            //정보 출력
            Console.Write("{0,-4} ",
                Seats[i, j].Memberid == -1 ? Seats[i, j].Id.ToString() : " O ");

            //라인 이동
            if (j == 10)
                Console.WriteLine();
        }

        private void PrintColHeader()
        {
            Console.Write(" ");
            for (int i = 1; i < 11; i++)
                Console.Write(" {0,-4}", i);
            Console.WriteLine("\n****************************************");
        }

        private void PrintRowData()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    PrintSeat(i, j);  //한 좌석 정보 출력
                }
                Console.WriteLine();
            }
        }

        public void PrintAll()
        {
            Console.WriteLine("****************************************");
            Console.Write("   ");
            PrintColHeader();
            PrintRowData();
            Console.WriteLine("****************************************");
        }
    }
}

