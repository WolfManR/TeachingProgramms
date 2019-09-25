/*
 * Source.c
 *
 *  Created on: 24 сент. 2019 г.
 *      Author: Ivan Barmin
 *
 *
 */

#include <stdio.h>
#include <string.h>
typedef struct{
	int Number;
	char Theme[256];
}HW;

void HWMenu();

int HW1_main();

int main(){
	setvbuf(stdout, NULL, _IONBF, 0);
	HW homeWorks[8];
	homeWorks[0].Number=1;
	strcpy(homeWorks[0].Theme,"Simple Algorithms");
	HWMenu(homeWorks,1);
	int userInput=0;
	printf("Enter HW to play: ");
	scanf("%d",&userInput);
	switch(userInput){
	case 1:
		HW1_main();
		break;
	default:
		printf("Something go wrong\n");
		break;
	}
	//setbuf(stdout, NULL);
	//setbuf(stdin, NULL);
}
void HWMenu(HW* array, int arrLength){
	for(int i = 0; i < arrLength; i++){
		printf("HW: %d\n  Theme: %s\n\n",(array + i)->Number, (array+i)->Theme);
	}
	printf("Exit: 0\n");
}

