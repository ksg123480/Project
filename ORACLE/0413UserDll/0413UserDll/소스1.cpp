//UseDll
//DLL 명시적 사용
//선언부 :.h(x)
//구현부 : .dll(0)
//정보 : lib(x)


//LoadLibrary, FreLibrary, GetProcAddress
// 내가원할떄 로딩 원치않을떄 해지 , 함수 주소값 획득
#include <Windows.h>
#include <stdio.h>


//함수 포인터 타입을 정의
//ex)FUNC: 타입키워드
//				:리턴 : void, 매개변수리스트 : int, int인 함수으리 주소를 저장할수
//					있는 타입 키워드
typedef void (*FUNC)(int, int);//add,sub
typedef void (*FUNC1)(int*);//getresult
int main()
{
	MessageBox(0, TEXT("DLL로딩"), TEXT("알림"), MB_OK);
	
	//초기화작업
	HMODULE hDll = LoadLibrary(TEXT("0413dll.dll"));
	//HINSTANCE exe실행파일의 인스턴스 HMODULE dll 의 인스턴스
	if (hDll == 0)
	{
		printf("dll을 찾을수 없다\n");
		return -1;//dll못찾음
	}
	printf("DLL이 로드된 주소 : 0x%p\n", hDll);//주소값
	//==========UseDll==========
	FUNC Add = (FUNC)GetProcAddress(hDll, "Add");
	FUNC Sub = (FUNC)GetProcAddress(hDll, "Sub");
	FUNC1 GetResult = (FUNC1)GetProcAddress(hDll, "GetResult");

	if (Add == NULL || Sub == NULL || GetResult == NULL)
	{
		printf("함수 획득 오류\n");
	}
	else
	{
		Add(10, 30);
		int value;
		GetResult(&value);
		printf("결과값 :%d\n", value);
	}

	//========================

	//종료처리
	FreeLibrary(hDll);
	return 0; 
}