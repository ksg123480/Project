// AccManager.cpp

#include "Account.h"
#include "AccManager.h"
#include "ContriAccount.h"
#include "FaitAccount.h"

AccManager::AccManager()
{
	index = 0;
}

void AccManager::PrintMenu()		// �޴� ���
{
	cout << "----- MENU ----- " << endl;
	cout << "1.�� ��  �� �� " << endl;
	cout << "2.��        �� " << endl;
	cout << "3.��        �� " << endl;
	cout << "4.�� ��  �� ȸ " << endl;
	cout << "5.���α׷����� " << endl;
}

void AccManager::MakeAccount()		// ���� ����
{
	int id;
	char name[20];
	int balance;
	int sel;

	cout << "������ ������ ����........" << endl;
	cout << "1.�Ϲ� ���� " << endl;
	cout << "2.�ſ� ���� " << endl;
	cout << "3.��� ���� " << endl;
	cout << " >> ";
	cin  >> sel;

	cout << "���� ���� ---------" << endl;
	cout << "����  ID: "; cin >> id;
	cout << "��    ��: "; cin >> name;
	cout << "�� �� ��: "; cin >> balance;

	if( sel == 1)	//�Ϲ� ���� ����
		pArray[index++] = new Account(id, name, balance);
	else if( sel == 2)	// �ſ� ���� ����
		pArray[index++] = new FaitAccount(id, name, balance);
	else if( sel == 3)
		pArray[index++] = new ContriAccount(id, name, balance);
	else
		cout << "���� ����" << endl;


}

void AccManager::Depoist()			// �� ��
{
	int money;
	int id;
	cout << "���� ID : " ; cin >> id;
	cout << "�Աݾ�  : " ; cin >> money;

	for( int i=0; i<index; i++)
	{
		if( pArray[i]->GetID() == id)
		{
			pArray[i]->AddMoney(money);
			cout << "�Ա� �Ϸ�" << endl;
			return;
		}
	}
	cout << "��ȿ���� ���� ID�Դϴ�. " << endl;
}

void AccManager::Withdraw()		// �� ��
{
	int money;
	int id;

	cout << "���� ID : " ; cin >> id;
	cout << "��ݾ�  : " ; cin >> money;

	for( int i=0; i< index; i++)
	{
		if( pArray[i]->GetID() == id)
		{
			if( pArray[i]->GetBalance() < money)
			{
				cout << "�ܾ� ����" << endl;
				return;
			}

			pArray[i]->MinMoney(money);
			cout << "��ݿϷ�" << endl;
			return ;
		}
	}
	cout << "��ȿ���� ���� ID�Դϴ�. " << endl;
}

void AccManager::Inquire()			// �ܾ� ��ȸ
{
	for( int i=0; i< index; i++)
	{
		pArray[i]->ShowAllData();
	}
}
