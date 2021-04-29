//wbsock.h
#pragma once

#include <winsock2.h>	
#pragma comment(lib,"ws2_32.lib")

//�ܺο��� �����ϴ� �Լ�.
int wbsock_init();

SOCKET wbsock_createsocket(int port);

void wbsock_run(SOCKET sock);

void wbsock_closesocket(SOCKET sock);

void wbsock_exit();

//wbsock ���ο� �Լ�
void err_quit(const char* msg);

void err_display(const char* msg);