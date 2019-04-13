#include <stdio.h>

int main() {
	float first,second;
	int operator;
	printf("Enter first operator:");
	scanf_s("%d",&first);
	printf("\nenter  1 for+\n       2 for -\n       * for -\n       4 for /\n");
	scanf_s("%d", &operator);

	if (operator ==4) {
		do {
			printf("\nenter second operand:");
			scanf_s("%d", &second);
		}
	}

	return 0;
}