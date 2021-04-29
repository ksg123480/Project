//wbsock.h
#pragma once

#include <winsock2.h>	
#pragma comment(lib, "ws2_32.lib")

//3. 함수 포인터 정의
typedef void (*LOMESSAGE)(const char* info, const char* msg);

typedef void (*SHORTMESSAGE)(const char* ip, int port, char* msg, int size);


//외부에서 접근하는 함수.
//4. 함수의 주소를 수신하는 인자 설정 
int wbsock_init(LOMESSAGE logfun, SHORTMESSAGE smessage);

SOCKET wbsock_createsocket(int port);

void wbsock_run(SOCKET sock);

void wbsock_closesocket(SOCKET sock);

void wbsock_exit();


//wbsock 내부용 함수
void err_quit(const char* msg);

void err_display(const char* msg);