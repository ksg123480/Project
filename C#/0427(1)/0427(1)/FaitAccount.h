// Accoun.h

#ifndef _FAITACCOUNT_H_
#define _FAITACCOUNT_H_

#include <iostream>
using namespace std;

class FaitAccount : public Account
{
public:
	FaitAccount( int id, char *name, int balance)
		:Account(id, name, balance+balance*0.01)
	{}

	virtual void AddMoney( int val)
	{
		Account::AddMoney(val + val*0.01);
	}
	
};

#endif /*_FAITACCOUNT_H_ */