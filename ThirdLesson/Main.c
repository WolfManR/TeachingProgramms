#include <stdio.h>  

int main(int argc, const char* argv[]) {
	// ���������� ���������
	
	prinf("Check this: y/n\n");
	char bool;
	scanf_s("%c", &bool);
	
	// �������� if else
	if (bool = 'y') printf("It's Checked");
	else printf("As you wana");
	printf("\n");

	int a = 20;
	int b = 10;
	// ��������� ��������
	(a > b) ? printf("a=%d", a) : printf("b=%d", b);
	printf("\n");
	// ������ �������������: printf("%s",(1>0)?"true":"false");

	/*
	  �������� ���������:
	  �����������: >, <, ==, >=, <=

	  ��������: &&, ||, !, ^
	
	*/

	printf("/n");
	return 0;
}