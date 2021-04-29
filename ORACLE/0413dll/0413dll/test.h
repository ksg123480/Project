//test.h
#pragma once

#ifdef DLL_SOURCE
	#define DLLFUNC __declspec(dllexport) 
#else
	#define DLLFUNC __declspec(dllimport)
#endif

#include <windows.h>

EXTERN_C DLLFUNC void Add(int a, int b);
EXTERN_C DLLFUNC void Sub(int a, int b);
EXTERN_C DLLFUNC void GetResult(int* a);
void foo(int flag);
