#include <iostream>
using namespace std;

#include "AccManager.h"

enum { MAKE =1, DEPOSIT, WITHDRAW , INQUIRE, EXIT};

int main()
{
	int choice;
	AccManager manager;

	while(1)
	{
		manager.PrintMenu();
		cout << "선택 : " ; 
		cin  >> choice;

		switch(choice)
		{
		case MAKE: manager.MakeAccount(); break;
		case DEPOSIT: manager.Depoist();  break;
		case WITHDRAW: manager.Withdraw(); break;
		case INQUIRE: manager.Inquire(); break;
		case EXIT: return 0;
		default:
			cout << "잘못 선택" << endl; break;
		}
	}
	return 0;
}