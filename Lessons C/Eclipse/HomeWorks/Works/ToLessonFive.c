#include <stdio.h>

int LessonFive_main() {
	printf("This is lesson five homework!\n");

	/*
	Домашнее задание :

	1) Математика.
	Есть формула(расчёта резисторного делителя) Uo = Ui * (R1 / (R2 + R1)).

	Напишите формулы расчёта каждой переменной по отдельности, в формате :
	Ui = ...;
	R1 = ...;
	R2 = ...;

	2) Условия.
	Запросить у пользователя любое целое число.Написать программу которая проверит,
	входит ли введённое число в диапазон(например, от 0 до 100, включительно) и выведет на экран сообщение о результате проверки.

	3) Циклы.
	Запросить у пользователя десять чисел.Вывести на экран среднее арифметическое введённых чисел.

	4) Звёздочка.
	Запросить у пользователя количество используемых для вывода строк.
	Написать программу, которая при помощи циклов и символа^ будет рисовать на указанном количестве строк равнобедренный треугольник.

	После того как вы сделаете домашнее задание, ознакомьтесь, пожалуйста,
	с видеозаписью "Решение домашнего задания урок 5" в разделе "Материалы" справа.
	*/

	// 1
	printf("\n1:\n\n");
	printf("Base:  Uo = Ui * (R1 / (R2 + R1))\n");
	printf("\n");
	printf("Ui:    Uo / (R1 / (R2 + R1))\n");
	printf("R1:    (Uo * R2) / (Ui - Uo)\n");
	printf("R2:    (R1 * (Ui - Uo)) / Uo\n");

	// 2
	printf("\n\n2:\n\n");
	printf("Give me any integer, between 0 and 100, inclusive: ");
	int num;
	scanf_s("%d", &num);
	if (num >= 0 && num <= 100) printf("your number in the specified range");
	else printf("your number not in the specified range");

	// 3
	printf("\n\n3:\n\n");
	printf("pls, input 10 numbers\ninstruction:\n 1. enter only numbers\n 2. if you want to enter a number with a floating point,\nbefore the fractional part exempt the exclusively point\n 3. dont think i return you absolute number of average\n");
	double avr = 0;
	double summar = 0;
	printf("\nNumbers: \n");
	for (int i = 0; i < 10; i++)
	{
		printf("%d: ", i + 1);
		scanf_s("%lf", &summar);
		avr += summar;
	}
	printf("\nAverage is %.2lf\n", avr /= 10);

	// 4
	printf("\n\n4:\n\n");
	printf("enter number of lines: ");
	int lines = 0;
	scanf_s("%d", &lines);
	printf("this is you triangle:\n");

	for (int i = 0; i < lines; i++) {
		for (int j = lines-i-1; j > 0; j--) printf(" ");
		for (int k = 0; k <= i; k++) {
			if (k == i) {
				printf("^");
				break;
			}
			printf("^ ");
		}
		printf("\n");
	}


	printf("\nThis is end of lesson five homework!\n\n");
	return 0;
}
