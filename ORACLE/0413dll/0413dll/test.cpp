///test.cpp
#define DLL_SOURCE

#include <stdio.h>
#include "test.h"


static int g_result;

void Add(int a, int b)
{
	g_result = a + b;
	foo(1);
}
void Sub(int a, int b)
{
	g_result = a - b;
	foo(2);
}
void GetResult(int* a)
{
	*a = g_result;
}
void foo(int flag)
{
	if (flag == 1)
		printf("µ¡¼À ¿¬»ê  ½ÇÇàµÇ¾ú´Ù.\n");
	else if (flag == 2)
		printf("»¬¼À ¿¬»ê ½ÇÇàµÇ¾ú´Ù.\n");
}

