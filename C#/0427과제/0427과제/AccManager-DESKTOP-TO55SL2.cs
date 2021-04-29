using System;
using System.Diagnostics;

namespace _0427과제
{
    class AccManager
    {
        #region 계정정보 배열
        private Account[] pArray;
        private int index;
        #endregion

        #region 인덱서
        public Account this[int idx]
        {
            get
            {
                if (idx < 0 || idx >= pArray.Length)
                    throw new Exception("인덱스 접근이 잘못됨");
                return pArray[idx];
            }
            set
            {
                if (idx < 0 || idx >= pArray.Length)
                    throw new Exception("인덱스 접근이 잘못됨");
                pArray[idx] = value;
            }
        }
        #endregion

        //생성자
        public AccManager()
        {
            pArray = new Account[100];
            index = 0;
        }

        #region 내부함수
        private int SelectAccount()
        {
            Console.WriteLine("개설할 계좌의 종류........");
            Console.WriteLine("1.일반 계좌 ");
            Console.WriteLine("2.신용 계좌 ");
            Console.WriteLine("3.기부 계좌 ");
            Console.Write(" >> ");
            return int.Parse(Console.ReadLine());
        }
        

        #endregion

        #region 메서드
        public void PrintMenu()     //메뉴출력
        {
            Console.WriteLine("----- MENU ----- ");
            Console.WriteLine("1.개 좌  개 설 ");
            Console.WriteLine("2.입        금 ");
            Console.WriteLine("3.출        금 ");
            Console.WriteLine("4.잔 액  조 회 ");
            Console.WriteLine("5.프로그램 종료 ");
        }

        private void AccountInput(out int id, out string name, out int balance)
        {
            Console.WriteLine("개좌 개설 ------");
            id = WbGlobal.InputInt("개좌  ID");
            name = WbGlobal.InputString("이    름");
            balance = WbGlobal.InputInt("입 금 액");
        }

        public void MakeAccount()      // 계좌 개설
        {
            int sel = SelectAccount();

            int id, balance;
            String name;
            AccountInput(out id, out name, out balance);

            try
            {
                //변수 선언
                Account acc = null;

                //초기화
                if (sel == 1)
                    acc = new Account(id, name, balance);
                else if (sel == 2)
                    acc = new FaitAccount(id, name, balance);
                else if (sel == 3)
                    acc = new ContriAccount(id, name, balance);
                else
                    throw new Exception("선택 오류");

                //연산
                pArray[index++] = acc;

                //결과출력
                Console.WriteLine("계좌개설 완료");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[계좌개설 에러]" + ex.Message);
            }
        }

        private int IdToIdx(int id)  //검색함수
        {
            for (int i = 0; i < index; i++)
            {
                if (pArray[i].Id == id)
                    return i;
            }
            throw new Exception("해당 계좌번호는 존재하지 않습니다.");
        }

        public void Depoist()          // 입 금
        {
            //변수 선언 및 초기화 
            int id = WbGlobal.InputInt("계좌 ID");
            int money = WbGlobal.InputInt("입금액");

            try
            {
                //연산
                int idx = IdToIdx(id);
                pArray[idx].AddMoney(money);

                //결과출력
                Console.WriteLine("입금 완료");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[출금에러] {0}", ex.Message);
            }
        }

        public void Withdraw()         // 출 금
        {
            //변수 선언 및 초기화 
            int id = WbGlobal.InputInt("계좌 ID");
            int money = WbGlobal.InputInt("출금액");

            try
            {
                //연산
                int idx = IdToIdx(id);
                pArray[idx].MinMoney(money);

                //결과출력
                Console.WriteLine("입금 완료");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[출금에러] {0}", ex.Message);
            }
        }

        public void Inquire()          // 잔액 조회
        {
            for (int i = 0; i < index; i++)
            {
                pArray[i].ShowAllData();
            }
        }

        #endregion
    }
}
