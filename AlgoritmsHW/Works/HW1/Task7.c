/*
 * HW1Source.c
 *
 *  Created on: 25 сент. 2019 г.
 *      Author: Ivan Barmin
 *
	7. Имеются числовые координаты двух полей шахматной доски (x1,y1,x2,y2). Требуется определить, относятся ли к поля к одному цвету или нет.
 */

#include <stdio.h>
int isInDescRange(int coordinate){
	if(coordinate < 1 || coordinate > 8){
		printf("Вы ввели неверное значение");
		return 1;
	}
	else return 0;
}


int isBlack(int x, int y){
	if(x%2){
		if(y%2) return 1;
	}
	else {
		if(y%2==0) return 1;
	}
	return 0;
}

void Task7_main(){
	int x1,y1,x2,y2 = 0;
	int flag = 0;
	do {
		printf("Введите координаты двух полей на шахматной доске, размерами 8*8\n");
		printf("Первое поле по оси x: ");
		scanf("%d",&x1);
		if(isInDescRange(x1)) continue;

		printf("Первое поле по оси y: ");
		scanf("%d",&y1);
		if(isInDescRange(y1)) continue;

		printf("Второе поле по оси x: ");
		scanf("%d",&x2);
		if(isInDescRange(x2)) continue;

		printf("Второе поле по оси y: ");
		scanf("%d",&y2);
		if(isInDescRange(y2)) continue;
		flag = 1;
	} while (flag == 0);
	if(x1==x2 && y1==y2) printf("True");
	else{
		if(isBlack(x1,y1)==isBlack(x2,y2)) printf("True");
		else printf("False");
	}
}
