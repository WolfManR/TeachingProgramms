#include <stdio.h>  

int main(int argc, const char* argv[]) {
	// Логическое сравнение

	printf("Check this: y/n\n");
	char ch = getchar();
	
	// операция if else
	if (ch == 'y') printf("\nIt's Checked");
	else printf("\nAs you wana");
	printf("\n");

	int a = 20;
	int b = 10;
	// тернарная операция
	(a > b) ? printf("a=%d", a) : printf("b=%d", b);
	printf("\n");
	// пример использования: printf("%s",(1>0)?"true":"false");

	/*
	  операции сравнения:
	  стандартные: >, <, ==, >=, <=

	  бинарные: &&, ||, !, ^
	
	*/

	printf("/n");
	return 0;
}