//UseDll
//DLL �Ͻ��� ���
//����� :.h
//������ : .dll
//���� : lib
#include <stdio.h>
#include<conio.h>
//DLL���
#include "test.h"
#pragma comment(lib,"0413dll.lib")

int main()
{
	Add(10, 20);
	int value;
	GetResult(&value);
	printf("������ :%d\n", value);

	_getch();
	return 0;
}