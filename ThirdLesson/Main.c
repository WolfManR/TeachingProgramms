#include <stdio.h>  

int main(int argc, const char* argv[]) {
	// ���������� ���������


	char ch;
	printf("Check this: y/n\n");
	scanf("%c", &ch);
	
	// �������� if else
	if (ch == 'y') printf("It's Checked");
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