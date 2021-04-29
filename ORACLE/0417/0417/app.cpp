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
			printf("정상적으로 명령이 수행되었습니다.\n");
		else
			printf("오류입니다.\n");
	}
}

void app_exit()
{

}

void logo()
{
	printf("SQL*Plus: Release 19.0.0.0.0 - Production on 금 4월 17 08:50:46 2020\n");
	printf("Version 19.3.0.0.0\n\n");
	printf("Copyright (c) 1982, 2019, Oracle.  All rights reserved.\n\n");
}

void ending()
{

}

//============DB 모듈을 사용하는 코드들==========
bool dblogin()
{
	char id[20], pw[20];

	while (1)
	{
		printf("사용자명 입력 : ");
		gets_s(id, sizeof(id));

		printf("비밀번호 입력 : ");
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


		//DB 연결처리 - 성공 실패....
		if (mydb_DBConnect(id, pw))
		{
			printf("\n\n다음에 접속됨 :\n");
			printf("Oracle Database 19c Enterprise Edition Release 19.0.0.0.0 - Production");
			printf("Version 19.3.0.0.0\n");
			break;
		}
		else
		{
			printf("\nERRPR\n");
			printf("ORA-01017: 사용자명/비밀번호가 부적합, 로그온할 수 없습니다");
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
		printf("정상적으로 명령이 수행되었습니다.\n");
	else
		printf("오류입니다\n");
}





//=====================================