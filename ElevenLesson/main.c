#include <stdio.h>
#include <string.h>
#include <stdlib.h>

void helloFunction(char* name, char* out) {
	char welcome[256] = "Hello, ";
	name[0] = tolower(name[0]);
	if (strcmp("ivan", name) == 0)
		strcpy(name, "Master!");
	name[0] = toupper(name[0]);
	strcat(welcome, name);
	strcpy(out, welcome);
}

//isalpha() isdigit() isspace() isupper() islower toupper() tolower()

int main(int argc, const char* argv[]) {
	char string1[256] = "This is a string!";
	char* string2 = "This is also a string!";

	printf("%s \n", string1);
	printf("%s \n", string2);

	string1[5] = 'X';
	printf("%s \n", string1);

	char name[256];
	char result[256];
	gets(name);

	helloFunction(name, result);
	puts(result);

	//atoi() atof()
	char num[64];
	puts("Enter a number");
	gets(num);
	int number = atoi(num);
	number *= number;

	printf("We powered your number to %d", number);

	return 0;
}
