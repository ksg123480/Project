using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0427과제
{
    class Program
    {
        enum menu { MAKE = 1, DEPOSIT, WITHDRAW, INQUIRE, EXIT ,ERROR};

        static menu IdxToMenu(int idx)
        {
            menu menu;
            switch (idx)
            {
                case 1: menu = menu.MAKE; break;
                case 2: menu = menu.DEPOSIT; break;
                case 3: menu = menu.WITHDRAW; break;
                case 4: menu = menu.INQUIRE; break;
                case 5: menu = menu.EXIT; break;
                default: menu = menu.ERROR; break;
            }
            return menu;
        }
       
        static void Main(string[] args)
        {
            int choice;
            AccManager manager = new AccManager(); //객체생성

            while (true)
            {
                Console.Clear();   //system("cls")
                manager.PrintMenu();
                choice = WbGlobal.InputInt("선택");
                switch (IdxToMenu(choice))
                {
                    case menu.MAKE: manager.MakeAccount(); break;
                    case menu.DEPOSIT: manager.Depoist();    break;
                    case menu.WITHDRAW: manager.Withdraw();  break;
                    case menu.INQUIRE: manager.Inquire();  break;
                    case menu.EXIT: return;
                    default:  Console.WriteLine("잘못된 선택");  break;
                }
                WbGlobal.Pause();
            }
        }
    }
}
