/*
 * HW1Source.c
 *
 *  Created on: 25 сент. 2019 г.
 *      Author: Ivan Barmin
 *
	3. Ќаписать программу обмена значени€ми двух целочисленных переменных:
		b. *без использовани€ третьей переменной.
 */
#include <stdio.h>
// функци€ обмена значени€ми с использованием третьей переменной
void swapWithThird(int* first, int* second) {
	int temp = *first;
	*first = *second;
	*second = temp;
}

// функци€ обмена значени€ми без использовани€ третьей переменной
void swapNotWithThird(int* first, int* second) {
	*first ^= *second;
	*second ^= *first;
	*first ^= *second;
}

void Task3_main() {
	int x,y;
	printf("¬ведите значение первой переменной: ");
	scanf("%d",&x);
	printf("¬ведите значение второй переменной: ");
	scanf("%d",&y);

	int select;
	printf("¬ыберите способ перестановки:\n1 - с использованием третьей переменной\n2 - без использовани€ третьей переменной\n");
	scanf("%d",&select);
	switch(select){
	case 1:
		swapWithThird(&x, &y);
		printf("перестановка с использованием третьей переменной:\n x:%d , y:%d\n\n", x, y);
		break;
	case 2:
		swapNotWithThird(&x, &y);
		printf("перестановка без использовани€ третьей переменной:\n x:%d , y:%d\n\n", x, y);
		break;
	default:
		printf("Something go wrong");
		break;
	}
}
