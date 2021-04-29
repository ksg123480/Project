// Accoun.h

#ifndef _CONTRIACCOUNT_H_
#define _CONTRIACCOUNT_H_

#include <iostream>
using namespace std;

class ContriAccount : public Account
{
	int contribution; // ��α� �Ѿ�
public:
	ContriAccount(int id, char*name, int balance)
		:Account(id, name, balance-balance*0.01)
	{
		contribution = balance *0.01;
	}

	virtual void AddMoney(int val)
	{
		Account::AddMoney(val -val*0.01);
		contribution += val*0.01;
	}

	virtual void ShowAllData()
	{
		Account::ShowAllData();
		cout << "�� ��ξ�: " << contribution<< endl;
	}

	
};

#endif /*_CONTRIACCOUNT_H_ */