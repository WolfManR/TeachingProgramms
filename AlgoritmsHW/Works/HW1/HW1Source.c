/*
 * HW1Source.c
 *
 *  Created on: 25 ����. 2019 �.
 *      Author: Ivan Barmin
 *
 *  1. ������ ��� � ���� ��������. ���������� � ������� ������ ����� ���� �� ������� I=m/(h*h); ��� m-����� ���� � �����������, h - ���� � ������.
 *
	3. �������� ��������� ������ ���������� ���� ������������� ����������:
		b. *��� ������������� ������� ����������.

	4. �������� ��������� ���������� ������ ��������� ����������� ���������.

	6. ������ ������� �������� (�� 1 �� 150 ���) � ������� ��� ������ � ����������� ������ ����, ����� ��� ����.

	7. ������� �������� ���������� ���� ����� ��������� ����� (x1,y1,x2,y2). ��������� ����������, ��������� �� � ���� � ������ ����� ��� ���.

	9. ���� ����� ������������� ����� N � K. ��������� ������ �������� �������� � ���������, ����� ������� �� ������� ������ N �� K, � ����� ������� �� ����� �������.

	10. ���� ����� ����� N (> 0). � ������� �������� ������� ������ � ������ ������� �� ������� ����������, ������� �� � ������ ����� N �������� �����.
	���� �������, �� ������� True, ���� ��� � ������� False.

	14. * ����������� �����. ����������� ����� ���������� �����������, ���� ��� ����� ��������� ������ ������ ��������. ��������, 25 \ :sup: 2 = 625.
	�������� ���������, ������� ������� �� ����� ��� ����������� �����, � �������� 1_000_000
 */
#include <stdio.h>
#include <string.h>
typedef struct{
	char ToDo[400];
	int Number;
}Task;

void TaskMenu();

int Task1_main();
int Task3_main();

int HW1_main(){
	setvbuf(stdout, NULL, _IONBF, 0);
	Task tasks[8];

	tasks[0].Number=1;
	strcpy(tasks[0].ToDo,"������ ��� � ���� ��������. ���������� � ������� ������ ����� ���� �� ������� I=m/(h*h); ��� m-����� ���� � �����������, h - ���� � ������.");

	tasks[1].Number=3;
	strcpy(tasks[1].ToDo,"�������� ��������� ������ ���������� ���� ������������� ����������:\n	b. *��� ������������� ������� ����������.");

	tasks[2].Number=4;
	strcpy(tasks[2].ToDo,"�������� ��������� ���������� ������ ��������� ����������� ���������.");

	tasks[3].Number=6;
	strcpy(tasks[3].ToDo,"������ ������� �������� (�� 1 �� 150 ���) � ������� ��� ������ � ����������� ������ ����, ����� ��� ����.");

	tasks[4].Number=7;
	strcpy(tasks[4].ToDo,"������� �������� ���������� ���� ����� ��������� ����� (x1,y1,x2,y2). ��������� ����������, ��������� �� � ���� � ������ ����� ��� ���.");

	tasks[5].Number=9;
	strcpy(tasks[5].ToDo,"���� ����� ������������� ����� N � K. ��������� ������ �������� �������� � ���������, ����� ������� �� ������� ������ N �� K, � ����� ������� �� ����� �������.");

	tasks[6].Number=10;
	strcpy(tasks[6].ToDo,"���� ����� ����� N (> 0). � ������� �������� ������� ������ � ������ ������� �� ������� ����������, ������� �� � ������ ����� N �������� �����.\n	���� �������, �� ������� True, ���� ��� � ������� False.");

	tasks[7].Number=14;
	strcpy(tasks[7].ToDo,"* ����������� �����. ����������� ����� ���������� �����������, ���� ��� ����� ��������� ������ ������ ��������. ��������, 25^2 = 625.\n	�������� ���������, ������� ������� �� ����� ��� ����������� �����, � �������� 1_000_000");
	TaskMenu(tasks,8);

	int userInput=0;
	printf("Enter Task to play: ");
	scanf("%d",&userInput);
	switch(userInput){
	case 1:
		Task1_main();
		break;
	case 3:
		Task3_main();
		break;
	default:
		printf("Something go wrong\n");
		break;
	}
	return 0;
}

void TaskMenu(Task* array, int arrLength){
	for(int i = 0; i < arrLength; i++){
		printf("Task: %d\n  ToDo: %s\n\n",(array + i)->Number, (array+i)->ToDo);
	}
	printf("Exit: 0\n");
}
