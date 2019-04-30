#include <stdio.h>
#include <string.h>
#include <stdlib.h>

void helloFunction(char* name, char* out) {
	char welcome[256] = "Hello, ";
	name[0] = tolower(name[0]);
	if (strcmp("ivan", name) == 0)
		strcpy_s(name,8 ,"Master!");
	name[0] = toupper(name[0]);
	strcat_s(welcome,sizeof(name), name);
	strcpy_s(out,sizeof(welcome), welcome);
}

//isalpha() isdigit() isspace() isupper() islower toupper() tolower()

int main(int argc, const char* argv[]) {
	/*
	    притива string не существует, его реализацией 
		в разных €зыках представл€ет ссылка на символьные данные и,
		в каждом €зыке по своему, обеспеченный функционал дл€ работы с ними
	*/

	// представление строки в C
	// как массив определЄнной длины
	char string1[256] = "This is a string!";
	// как указатель на тип char
	char* string2 = "This is also a string!";

	printf("%s \n", string1);
	printf("%s \n", string2);

	// строка в виде массива позвол€ет измен€ть любой содержащийс€ в нЄм символ
	string1[5] = 'X';
	printf("%s \n", string1);
	// строка в виде указател€ такого не может позволить, т.к еЄ данные €вл€ютс€ неизменными
	// едиственный способ работать с такими строками, 
	// €вл€етс€ передача их в функцию котора€ вернЄт изменЄнную копию этой строки

	char name[256];
	char result[256];
	gets(name);         // принимает строку из консоли и сохран€ет еЄ в указанную переменную

	helloFunction(name, result);
	puts(result);       // принимает только строку в коде программы и выводит еЄ в консоль с добавлением символа \n в конец строки

	// atoi() - принимает строку и возвращает альтернативу еЄ в виде int
	// atof() - принимает строку и возвращает альтернативу еЄ в виде float
	char num[64];
	puts("Enter a number");
	gets(num);
	int number = atoi(num);
	number *= number;

	printf("We powered your number to %d", number);

	return 0;
}
