#include <stdio.h>  

int Third_main(int argc, const char* argv[]) {
	// ���������� ���������

	printf("Check this: y/n\n");
	char ch = getchar();

	// �������� if else
	if (ch == 'y') printf("\nIt's Checked");
	else printf("\nAs you wana");
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

	printf("\n");
	return 0;
}