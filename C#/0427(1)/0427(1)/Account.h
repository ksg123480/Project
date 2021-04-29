// Accoun.h

#define _CRT_SECURE_NO_WARNINGS

#ifndef _ACCOUNT_H_
#define _ACCOUNT_H_

#include <iostream>
using namespace std;

class Account
{
	int id;
	int balance;
	char *name;

public:
	Account() {}
	Account(int id, char*name, int balance)
	{
		this->id		= id;
		this->balance	= balance;

		this->name = new char[strlen(name)+1];
		strcpy(this->name, name);
	}
	Account( const Account & acc)
	{
		this->id = acc.id;
		this->balance = acc.balance;
		this->name = new char[strlen(acc.name)+1];
		strcpy(this->name, acc.name);
	}
	~Account()
	{
		delete [] name;
	}

	int GetID()			{ return id; }
	int GetBalance()	{ return balance; }
	char* GetName()		{ return name;    }

	virtual void AddMoney(int val)
	{
		balance += val;
	}

	void MinMoney( int val)
	{
		balance -= val;
	}

	virtual void ShowAllData()
	{
		cout << "°èÁÂ ID : " << id << endl;
		cout << "ÀÌ   ¸§ : " << name << endl;
		cout << "ÀÜ   ¾× : " << balance << endl;
	}
};

#endif /*_ACCOUNT_H_ */