//wbsock.h

#pragma once
#ifdef DLL_SOURCE
#define DLLFUNC __declspec(dllexport) 
#else
#define DLLFUNC __declspec(dllimport)
#endif

#include <winsock2.h>	
#pragma comment(lib,"ws2_32.lib")

//�ܺο��� �����ϴ� �Լ�.
EXTERN_C DLLFUNC int wbsock_init();

EXTERN_C DLLFUNC SOCKET wbsock_createsocket(int port);

EXTERN_C DLLFUNC void wbsock_run(SOCKET sock);

EXTERN_C DLLFUNC void wbsock_closesocket(SOCKET sock);

EXTERN_C DLLFUNC void wbsock_exit();

//wbsock ���ο� �Լ�
void err_quit(const char* msg);

void err_display(const char* msg);