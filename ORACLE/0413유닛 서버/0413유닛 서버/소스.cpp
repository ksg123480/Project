//-------------------------------------------------------------
//	[  UDPServer.cpp ]
//-------------------------------------------------------------

#include <stdlib.h>	
#include <stdio.h>

#include "wbsock.h"


#define SERVER_PORT 9000

int main(int argc, char* argv[])
{

	wbsock_init();// �ʱ�ȭ

	int sock = wbsock_createsocket(SERVER_PORT);//���ϻ��� 

	wbsock_run(sock);//��������

	wbsock_closesocket(sock);

	wbsock_exit();
	
	return 0;
}
