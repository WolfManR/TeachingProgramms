/*
 * HW1Source.c
 *
 *  Created on: 25 сент. 2019 г.
 *      Author: Ivan Barmin
 *
	10. Дано целое число N (> 0). С помощью операций деления нацело и взятия остатка от деления определить, имеются ли в записи числа N нечетные цифры.
	Если имеются, то вывести True, если нет — вывести False.
 */

#include <stdio.h>

void Task10_main(){
	int n=0;
	printf("Введите целое число больше нуля: ");
	scanf("%d", &n);
	int flag = 0;
	while(n>0){
		if(n % 10 % 2){
			printf("True");
			flag = 1;
			break;
		}
		n /= 10;
	}
	if(flag == 0) printf("False");
}
