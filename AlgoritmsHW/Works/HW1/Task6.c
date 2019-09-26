/*
 * HW1Source.c
 *
 *  Created on: 25 сент. 2019 г.
 *      Author: Ivan Barmin
 *
	6. Ввести возраст человека (от 1 до 150 лет) и вывести его вместе с последующим словом «год», «года» или «лет».
 */
#include <stdio.h>

void Task6_main(){
	int inputAge = 0;
	do{
		printf("Введите возраст человека от 1 до 150 лет: ");
		scanf("%d",&inputAge);
	}while(inputAge < 1 || inputAge > 150);

	printf("Возраст: %d",inputAge);

}
