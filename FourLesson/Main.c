#include <stdio.h>  

int main(int argc, const char* argv[]) {

	int a = 10;
	int b = 20;
	int even = 0;
	while (a < b) {
		if (a % 2 == 0) even++;
		a++;
	}
	printf("there are %d even numbers in sequence\n", even);

	int input;
	do {
		printf("enter the divider for 100(remember, that you cannot divide by zero)\n");
		scanf_s("%d", &input);
	} while (input == 0);
	printf("100 / %d = %d\n", input, 100 / input);
	printf("and the reminder will be %d,by the way \n", 100 % input);

	int number = 71;
	printf("input a number");
	scanf_s("%d",&number);
	int d = 0, i = 1;
	while (i <= number) {
		if (number % i++ == 0) d++;
		else continue;
		if (d == 3)break;
	}
	printf("input number %d is %s simple\n",number,(d==2)?"":"not");

	int significative = 10;
	int base = 2;
	int result = 1;
	for (i = 0; i < significative; i++) result *= base;
	printf("%d powered by %d is %d\n",base,significative,result);

	extern Calc();

	return 0;
}