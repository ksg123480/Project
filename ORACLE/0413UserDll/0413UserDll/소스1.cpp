//UseDll
//DLL ����� ���
//����� :.h(x)
//������ : .dll(0)
//���� : lib(x)


//LoadLibrary, FreLibrary, GetProcAddress
// �������ҋ� �ε� ��ġ������ ���� , �Լ� �ּҰ� ȹ��
#include <Windows.h>
#include <stdio.h>


//�Լ� ������ Ÿ���� ����
//ex)FUNC: Ÿ��Ű����
//				:���� : void, �Ű���������Ʈ : int, int�� �Լ����� �ּҸ� �����Ҽ�
//					�ִ� Ÿ�� Ű����
typedef void (*FUNC)(int, int);//add,sub
typedef void (*FUNC1)(int*);//getresult
int main()
{
	MessageBox(0, TEXT("DLL�ε�"), TEXT("�˸�"), MB_OK);
	
	//�ʱ�ȭ�۾�
	HMODULE hDll = LoadLibrary(TEXT("0413dll.dll"));
	//HINSTANCE exe���������� �ν��Ͻ� HMODULE dll �� �ν��Ͻ�
	if (hDll == 0)
	{
		printf("dll�� ã���� ����\n");
		return -1;//dll��ã��
	}
	printf("DLL�� �ε�� �ּ� : 0x%p\n", hDll);//�ּҰ�
	//==========UseDll==========
	FUNC Add = (FUNC)GetProcAddress(hDll, "Add");
	FUNC Sub = (FUNC)GetProcAddress(hDll, "Sub");
	FUNC1 GetResult = (FUNC1)GetProcAddress(hDll, "GetResult");

	if (Add == NULL || Sub == NULL || GetResult == NULL)
	{
		printf("�Լ� ȹ�� ����\n");
	}
	else
	{
		Add(10, 30);
		int value;
		GetResult(&value);
		printf("����� :%d\n", value);
	}

	//========================

	//����ó��
	FreeLibrary(hDll);
	return 0; 
}