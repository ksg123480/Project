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
	void PrintMenu();		// �޴� ���
	void MakeAccount();		// ���� ����
	void Depoist();			// �� ��
	void Withdraw();		// �� ��
	void Inquire();			// �ܾ� ��ȸ
};

#endif /* _ACCMANAGER_H_ */