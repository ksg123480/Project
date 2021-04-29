using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0427실습
{
    class Start
    {
        enum Menu { MAKE = 1, DEPOSIT, WITHDRAW, INQUIRE, EXIT };

        public static void Main(string[] args)
        {
            int choice;
            AccManager manager = new AccManager(); //객체생성

            while (true)
            {
                Console.Clear();
                manager.PrintMenu();
                Console.Write("선택 : ");
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("잘못된 선택"); continue;
                }

             

                switch (choice)
                {
                    case (int)Menu.MAKE:
                        manager.MakeAccount();
                        break;
                    case (int)Menu.DEPOSIT:
                        manager.Depoist();
                        break;
                    case (int)Menu.WITHDRAW:
                        manager.Withdraw();
                        break;
                    case (int)Menu.INQUIRE:
                        manager.Inquire();
                        break;
                    case (int)Menu.EXIT:
                        return;
                    default:
                        Console.WriteLine("잘못된 선택");
                        break;
                }
            }
        }
    }
}
