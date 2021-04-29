//mydb.h
#pragma once

#include<Windows.h>
#include <sql.h>
#include <sqlext.h>


BOOL mydb_DBConnect(TCHAR* id, TCHAR* pw);
void DBDisConnect();
BOOL mydb_DirectQuery(TCHAR* sql)