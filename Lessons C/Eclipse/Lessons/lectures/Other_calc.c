int calc() {
	float first, second;
	int operator;
	printf("Enter first operator: ");
	scanf_s("%f", &first);
	printf("\nenter  1 for+\n       2 for -\n       * for -\n       4 for /\n");
	scanf("%d", &operator);

	if (operator == 4) {
		do {
			printf("\nenter second operand: ");
			scanf("%f", &second);
		} while (second == 0);
	}
	else {
		printf("\nenter second operand: ");
		scanf("%f", &second);
	}
	float result;
	char operatorSign;
	int wrong = 0;
	switch (operator)
	{
	case 1:
		operatorSign = '+';
		result = first + second;
		break;
	case 2:
		operatorSign = '-';
		result = first - second;
		break;
	case 3:
		operatorSign = '*';
		result = first * second;
		break;
	case 4:
		operatorSign = '/';
		result = first / second;
		break;
	default:
		wrong = 1;
		break;
	}

	if (!wrong)
	{
		printf("%f %c %f = %f", first, operatorSign, second, result);
	}
	else printf("wrong operation");
	return 0;
}
