// AccManager.cpp

#include "Account.h"
#include "AccManager.h"
#include "ContriAccount.h"
#include "FaitAccount.h"

AccManager::AccManager()
{
	index = 0;
}

void AccManager::PrintMenu()		// 메뉴 출력
{
	cout << "----- MENU ----- " << endl;
	cout << "1.개 좌  개 설 " << endl;
	cout << "2.입        금 " << endl;
	cout << "3.출        금 " << endl;
	cout << "4.잔 액  조 회 " << endl;
	cout << "5.프로그램종료 " << endl;
}

void AccManager::MakeAccount()		// 계좌 개설
{
	int id;
	char name[20];
	int balance;
	int sel;

	cout << "개설할 계좌의 종류........" << endl;
	cout << "1.일반 계좌 " << endl;
	cout << "2.신용 계좌 " << endl;
	cout << "3.기부 계좌 " << endl;
	cout << " >> ";
	cin  >> sel;

	cout << "개좌 개설 ---------" << endl;
	cout << "개좌  ID: "; cin >> id;
	cout << "이    름: "; cin >> name;
	cout << "입 금 액: "; cin >> balance;

	if( sel == 1)	//일반 계좌 개설
		pArray[index++] = new Account(id, name, balance);
	else if( sel == 2)	// 신용 계좌 개설
		pArray[index++] = new FaitAccount(id, name, balance);
	else if( sel == 3)
		pArray[index++] = new ContriAccount(id, name, balance);
	else
		cout << "선택 오류" << endl;


}

void AccManager::Depoist()			// 입 금
{
	int money;
	int id;
	cout << "계좌 ID : " ; cin >> id;
	cout << "입금액  : " ; cin >> money;

	for( int i=0; i<index; i++)
	{
		if( pArray[i]->GetID() == id)
		{
			pArray[i]->AddMoney(money);
			cout << "입금 완료" << endl;
			return;
		}
	}
	cout << "유효하지 않은 ID입니다. " << endl;
}

void AccManager::Withdraw()		// 출 금
{
	int money;
	int id;

	cout << "계좌 ID : " ; cin >> id;
	cout << "출금액  : " ; cin >> money;

	for( int i=0; i< index; i++)
	{
		if( pArray[i]->GetID() == id)
		{
			if( pArray[i]->GetBalance() < money)
			{
				cout << "잔액 부족" << endl;
				return;
			}

			pArray[i]->MinMoney(money);
			cout << "출금완료" << endl;
			return ;
		}
	}
	cout << "유효하지 않은 ID입니다. " << endl;
}

void AccManager::Inquire()			// 잔액 조회
{
	for( int i=0; i< index; i++)
	{
		pArray[i]->ShowAllData();
	}
}
