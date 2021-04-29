//wbsock.h
#pragma once

#include <winsock2.h>	
#pragma comment(lib,"ws2_32.lib")

//외부에서 접근하는 함수.
int wbsock_init();

SOCKET wbsock_createsocket(int port);

void wbsock_run(SOCKET sock);

void wbsock_closesocket(SOCKET sock);

void wbsock_exit();

//wbsock 내부용 함수
void err_quit(const char* msg);

void err_display(const char* msg);