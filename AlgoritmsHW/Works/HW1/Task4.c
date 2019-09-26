/*
 * HW1Source.c
 *
 *  Created on: 25 сент. 2019 г.
 *      Author: Ivan Barmin
 *
	4. Написать программу нахождения корней заданного квадратного уравнения.
 */

#include <stdio.h>
#include <math.h>

int calculateSquareEquation(int a, int b, int c, float* x1, float* x2) {
	double D = b * b - 4 * a * c;
	if(a==0){
		*x1 = -c / b;
		return 0;
	}
	if (D < 0) return -1;
	else if (D == 0) {
		*x1 = *x2 = -b / (2 * a);
		return 0;
	}
	else
	{
		*x1 = (-b + sqrt(D)) / (2 * a);
		*x2 = (-b - sqrt(D)) / (2 * a);
		return 1;
	}
}

void Task4_main(){
	int a, b, c;
	float x1, x2;
	printf("Введите числа квадратного уравнения ax^2+bx+c=0\n");
	printf("\nВведите \'a\': ");
	scanf("%d",&a);
	printf("\nВведите \'b\': ");
	scanf("%d",&b);
	printf("\nВведите \'c\': ");
	scanf("%d",&c);
	if (a == 0) printf("x = %f",(float)(-c/b));
	else {
		switch (calculateSquareEquation(a, b, c, &x1, &x2))
		{
		case -1:
			printf("d < 0");
			break;
		case 0:
			printf("d = 0  x1 = %5.2f, x2 = %5.2f", x1, x2);
			break;
		case 1:
			printf("d > 0  x1 = %5.2f, x2 = %5.2f", x1, x2);
			break;
		default:
			break;
		}
	}
	printf("\n");
}
