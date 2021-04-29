//app.cpp
#include "std.h"

void app_init()
{
	logo();
	dblogin();
}
void app_run()
{
	//	createmembertable();
	char msg[1000] = { '\0' };
	char temp[100];
	while (1)
	{
		printf("SQL> ");
		for (int i = 2; i < 100; i++)
		{
			gets_s(temp);
			if (temp[strlen(temp) - 1] == ';')
			{
				strcat_s(msg, temp);
				break;
			}
			printf("%d ", i);
			strcat_s(msg, temp);
		}
		if (mydb_DirectQuery(msg))
			printf("���������� ����� ����Ǿ����ϴ�.\n");
		else
			printf("�����Դϴ�.\n");
	}
}

void app_exit()
{

}

void logo()
{
	printf("SQL*Plus: Release 19.0.0.0.0 - Production on �� 4�� 17 08:50:46 2020\n");
	printf("Version 19.3.0.0.0\n\n");
	printf("Copyright (c) 1982, 2019, Oracle.  All rights reserved.\n\n");
}

void ending()
{

}

//============DB ����� ����ϴ� �ڵ��==========
bool dblogin()
{
	char id[20], pw[20];

	while (1)
	{
		printf("����ڸ� �Է� : ");
		gets_s(id, sizeof(id));

		printf("��й�ȣ �Է� : ");
		for (int i = 0; i < 20; i++)
		{
			char temp = _getch();  // conio.h
			if (temp == '\r')
			{
				pw[i] = '\0';
				break;
			}
			pw[i] = temp;
		}


		//DB ����ó�� - ���� ����....
		if (mydb_DBConnect(id, pw))
		{
			printf("\n\n������ ���ӵ� :\n");
			printf("Oracle Database 19c Enterprise Edition Release 19.0.0.0.0 - Production");
			printf("Version 19.3.0.0.0\n");
			break;
		}
		else
		{
			printf("\nERRPR\n");
			printf("ORA-01017: ����ڸ�/��й�ȣ�� ������, �α׿��� �� �����ϴ�");
		}
	}
	return true;
}

void createmembertable()
{
	char sql[] = { "CREATE TABLE MEMBER (id VARCHAR2(20) \
		    , pw VARCHAR2(20) NOT NULL  constraint emp_pw_min CHECK(LENGTH(pw) >= 3) \
			, name VARCHAR2(20) NOT NULL \
			, phone VARCHAR2(20) \
			, CONSTRAINT MEMBER_PK PRIMARY KEY(id) \
			ENABLE); " };


	if (mydb_DirectQuery(sql))
		printf("���������� ����� ����Ǿ����ϴ�.\n");
	else
		printf("�����Դϴ�\n");
}





//=====================================