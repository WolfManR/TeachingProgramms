/*
 * HW1Source.c
 *
 *  Created on: 25 сент. 2019 г.
 *      Author: Ivan Barmin
 *
	9. Даны целые положительные числа N и K. Используя только операции сложения и вычитания, найти частное от деления нацело N на K, а также остаток от этого деления.
 */

#include <stdio.h>

void Task9_main(){
	int n,k;
	printf("делимое число: ");
	scanf("%d",&n);
	do{
		printf("\nделитель: ");
		scanf("%d",k);
		if(k==0)printf("нельзя делить на 0");
	}while(k==0);

	int result=0;
	while(n>k){
		n-=k;
		result++;
	}
	printf("Частное: %d\nОстаток от деления: %d", result, n);
}
