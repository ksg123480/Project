//-------------------------------------------------------------
//	[  UDPServer.cpp ]
//-------------------------------------------------------------

#include <stdlib.h>	
#include <stdio.h>

#include "wbsock.h"


#define SERVER_PORT 9000

int main(int argc, char* argv[])
{

	wbsock_init();// 초기화

	int sock = wbsock_createsocket(SERVER_PORT);//소켓생성 

	wbsock_run(sock);//서버돌림

	wbsock_closesocket(sock);

	wbsock_exit();
	
	return 0;
}
