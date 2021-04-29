//UseDll
//DLL 암시적 사용
//선언부 :.h
//구현부 : .dll
//정보 : lib
#include <stdio.h>
#include<conio.h>
//DLL사용
#include "test.h"
#pragma comment(lib,"0413dll.lib")

int main()
{
	Add(10, 20);
	int value;
	GetResult(&value);
	printf("결과출력 :%d\n", value);

	_getch();
	return 0;
}