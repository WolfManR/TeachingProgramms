#include <stdio.h>  

int main(int argc, const char* argv[]) {
	// Логическое сравнение


	char ch;
	printf("Check this: y/n\n");
	scanf("%c", &ch);
	
	// операция if else
	if (ch == 'y') printf("It's Checked");
	else printf("As you wana");
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