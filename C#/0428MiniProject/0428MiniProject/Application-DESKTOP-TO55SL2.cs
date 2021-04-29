using _0428MiniProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0428MiniProject
{
    class Application
    {
        public bool Init()
        {
            WbGlobal.Logo();

            return true;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                ConsoleKey key = WbMenu.MainMenu();
                if (key == ConsoleKey.F1)
                    MemberRun();
                else if (key == ConsoleKey.F2)
                    SeatRun();
                else if (key == ConsoleKey.Escape)
                    return;
                else
                    Console.WriteLine("잘못 입력하셨습니다.");
                WbGlobal.Pause();
            }
        }

        private void MemberRun()
        {
            while(true)
            {
                Console.Clear();
                switch (WbMenu.MemberMenu())
                {
                    case ConsoleKey.F1: MemberManager.Singleton.AddMember(); break;//학생등록
                    case ConsoleKey.F2: MemberManager.Singleton.SelectMemberId(); break;//학생검색(아이디-Key)
                    case ConsoleKey.F3: MemberManager.Singleton.SelectMemberGroup(); break;//학생검색(조별-다수)
                    case ConsoleKey.F4: MemberManager.Singleton.SelectMemberSub(); break;//학생검색(학과별-다수)
                    case ConsoleKey.F5: MemberManager.Singleton.UpdateMember(); break;//학생 정보 수정(아이디->조편성)
                    case ConsoleKey.F6: MemberManager.Singleton.DeleteMember(); break;//학생 정보 삭제 (아이디)
                    case ConsoleKey.Escape: return;
                }
                WbGlobal.Pause();
            }
        }

        private void SeatRun()
        {
            while (true)
            {
                Console.Clear();
                SeatManager.Singleton.PrintAll();
                switch (WbMenu.SeatMenu())
                {
                    case ConsoleKey.F1:
                        SeatManager.Singleton.AddSeat();
                        break;
                    case ConsoleKey.F2:
                        SeatManager.Singleton.MoveSeat();
                        break;
                    case ConsoleKey.F3:
                        SeatManager.Singleton.ChangeSeat();
                        break;
                    case ConsoleKey.F4:
                        SeatManager.Singleton.DeleteSeat();
                        break;
                    case ConsoleKey.F5:
                        SeatManager.Singleton.SelectSeat();
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        Console.WriteLine("잘못입력했소");
                        break;
                }
                WbGlobal.Pause();
            }

        }

        public void Exit()
        {
            WbGlobal.Ending();
        }
    }
}
