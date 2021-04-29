using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0427실습
{
    class AccManager
    {
        public int index;
        Account[] acc = new Account[100];

        public AccManager()
        {
            index = 0;
        }

        public void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("-----MENU-----");
            Console.WriteLine("1. 개 좌  개 설");
            Console.WriteLine("2. 입        금");
            Console.WriteLine("3. 출        금");
            Console.WriteLine("4. 잔 액  조 회");
            Console.WriteLine("5. 프로그램종료");
        }

        public void MakeAccount()
        {
            int id;//계좌ID
            String name;//이름
            int balance;//금액
            int sel; //계좌종류
            while (true)
            {

                Console.WriteLine(" 개설할 계좌의 종류........");
                Console.WriteLine("1. 일반 계좌 ");
                Console.WriteLine("2. 신용 계좌 ");
                Console.WriteLine("3. 기부 계좌 ");
                Console.Write(" >>  ");
                sel = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (sel == 1)
                    break;
                else if (sel == 2)
                    break;
                else if (sel == 3)
                    break;
                else
                    Console.WriteLine(" 잘못 선택");
            }

            Console.WriteLine("개좌 개설 ---------");
            Console.Write("개좌  ID: "); id = int.Parse(Console.ReadLine());
            Console.Write("이    름: "); name = Console.ReadLine();
            Console.Write("입 금 액: "); balance = int.Parse(Console.ReadLine());
            Console.WriteLine();
            if (sel == 1)
                acc[index++] = new Account(id, name, balance);//일반계좌 만든후 인덱스 증가
            else if (sel == 2)
                acc[index++] = new FaitAccount(id, name, balance);//신용계좌 만든후 인덱스 증가
            else if (sel == 3)
                acc[index++] = new ContriAccount(id, name, balance);//기부계좌 만든후 인덱스 증가
        }

        public void Depoist()
        {
            int id;
            int money;

            Console.Write("계좌 ID : "); id = int.Parse(Console.ReadLine());
            Console.Write("입금액: "); money = int.Parse(Console.ReadLine());

            for (int i = 0; i < index; i++)
            {
                if (acc[i].Id == id)
                {
                    acc[i].AddMoney(money);
                    Console.WriteLine("입금 완료");
                    return;
                }
            }
            Console.WriteLine("유효하지 않은 ID입니다.");
        }

        public void Withdraw()
        {
            int id;
            int money;

            Console.Write("계좌 ID : "); id = int.Parse(Console.ReadLine());
            Console.Write("출금액 : "); money = int.Parse(Console.ReadLine());

            for (int i = 0; i < index; i++)
            {
                if (acc[i].Id == id)
                {
                    if (acc[i].Balance < money)
                    {
                        Console.WriteLine("잔액 부족");
                        return;
                    }

                    acc[i].MinMoney(money);
                    Console.WriteLine("출금완료");
                    return;
                }
            }
            Console.WriteLine("유효하지 않은 ID입니다.");
        }

        public void Inquire()
        {
            for (int i = 0; i < index; i++)
            {
                acc[i].ShowAllData();
            }
        }
    }
}
