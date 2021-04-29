//wbsock.h
#pragma once

#include <winsock2.h>	
#pragma comment(lib, "ws2_32.lib")

//3. �Լ� ������ ����
typedef void (*LOMESSAGE)(const char* info, const char* msg);

typedef void (*SHORTMESSAGE)(const char* ip, int port, char* msg, int size);


//�ܺο��� �����ϴ� �Լ�.
//4. �Լ��� �ּҸ� �����ϴ� ���� ���� 
int wbsock_init(LOMESSAGE logfun, SHORTMESSAGE smessage);

SOCKET wbsock_createsocket(int port);

void wbsock_run(SOCKET sock);

void wbsock_closesocket(SOCKET sock);

void wbsock_exit();


//wbsock ���ο� �Լ�
void err_quit(const char* msg);

void err_display(const char* msg);