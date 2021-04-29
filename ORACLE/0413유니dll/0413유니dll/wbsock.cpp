//wbsock.cpp
#define _WINSOCK_DEPRECATED_NO_WARNINGS

#define DLL_SOURCE
#include <stdio.h>

#include "wbsock.h"

#define BUFSIZE 512

// ���� �ʱ�ȭ
int wbsock_init()
{
	WSADATA wsa;
	if (WSAStartup(MAKEWORD(2, 2), &wsa) != 0)
		return 0;
	else
		return 1;
}


SOCKET wbsock_createsocket(int port)
{
	// socket()
	SOCKET sock = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP);
	if (sock == INVALID_SOCKET)
	{
		err_quit("socket()");
		return 0;
	}

	// bind()
	SOCKADDR_IN			serveraddr;
	ZeroMemory(&serveraddr, sizeof(serveraddr));
	serveraddr.sin_family = AF_INET;
	serveraddr.sin_port = htons(port);
	serveraddr.sin_addr.s_addr = htonl(INADDR_ANY);
	int retval = bind(sock, (SOCKADDR*)&serveraddr, sizeof(serveraddr));
	if (retval == SOCKET_ERROR)
	{
		err_quit("bind");
		return 0;
	}

	return sock;
}


void wbsock_run(SOCKET sock)
{
	SOCKADDR_IN		clientaddr;
	int				addrlen;
	char			buf[BUFSIZE + 1];
	int retval;

	while (1)
	{
		// ������ �ޱ�
		addrlen = sizeof(clientaddr);
		retval = recvfrom(sock, buf, BUFSIZE, 0,//recv ��Ư�� �ټ�
			(SOCKADDR*)&clientaddr, &addrlen);

		//TCP, SOCKET_ERROR , 0(������ ����)-UDP xxx, ��������
		if (retval == SOCKET_ERROR)//���� ����??�״�����
		{
			err_display("recvfrom");
			continue;
		}

		// ���� ������ ���
		buf[retval] = '\0';
		printf("[UDP/%s:%d] %s\n", inet_ntoa(clientaddr.sin_addr),
			ntohs(clientaddr.sin_port), buf);

		// ������ ������
		retval = sendto(sock, buf, retval, 0,
			(SOCKADDR*)&clientaddr, sizeof(clientaddr));
		if (retval == SOCKET_ERROR)
		{
			err_display("sendto");
			continue;
		}
	}
}

void wbsock_closesocket(SOCKET sock)
{
	closesocket(sock);
}

void wbsock_exit()
{
	// ���� ����
	WSACleanup();
}
// ���� �Լ� ���� ��� �� ����
void err_quit(const char* msg)
{
	LPVOID lpMsgBuf;
	FormatMessage(
		FORMAT_MESSAGE_ALLOCATE_BUFFER |
		FORMAT_MESSAGE_FROM_SYSTEM,
		NULL, WSAGetLastError(),
		MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),
		(LPTSTR)&lpMsgBuf, 0, NULL);
	MessageBox(NULL, (LPCTSTR)lpMsgBuf, msg, MB_ICONERROR);
	LocalFree(lpMsgBuf);
	exit(-1);
}

// ���� �Լ� ���� ���
void err_display(const char* msg)
{
	LPVOID lpMsgBuf;
	FormatMessage(
		FORMAT_MESSAGE_ALLOCATE_BUFFER |
		FORMAT_MESSAGE_FROM_SYSTEM,
		NULL, WSAGetLastError(),
		MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),
		(LPTSTR)&lpMsgBuf, 0, NULL);
	printf("[%s] %s", msg, (LPCTSTR)lpMsgBuf);
	LocalFree(lpMsgBuf);
}
