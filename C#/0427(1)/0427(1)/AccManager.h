// Accoun.h

#ifndef _ACCMANAGER_H_
#define _ACCMANAGER_H_

class Account;

class AccManager
{
	Account *pArray[100];
	int index;

public:
	AccManager();
	void PrintMenu();		// 메뉴 출력
	void MakeAccount();		// 계좌 개설
	void Depoist();			// 입 금
	void Withdraw();		// 출 금
	void Inquire();			// 잔액 조회
};

#endif /* _ACCMANAGER_H_ */