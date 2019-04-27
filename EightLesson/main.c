#include <stdio.h>

// директивы для работы со случайными числами
#include <stdlib.h>
#include <time.h>

/*
	директивы препроцессора помагают заменить одни слова другими
	в таком случае они называются элиасами
*/
#define bool int
#define true 1
#define false 0

// также можно определить с помощью директив константы которыми можно пользоваться во всём коде программы

// определение констант максимального значения массива и максимальное колличество чисел, которые сгенерирует генератор случайных чисел
#define ARRAY_LENGTH 10
#define NUMBER_AMOUNT 1000000

int main() {

	int array[ARRAY_LENGTH];
	array[0] = 1;
	array[1] = 2;
	// ....

	int array1[5] = { 0,1,2,3,4 };


	srand(time(NULL));
	int frequency[ARRAY_LENGTH] = { 0 };
	int a, i;
	for (i = 0; i < NUMBER_AMOUNT; i++)
	{
		a = rand() % ARRAY_LENGTH;
		frequency[a]++;
	}

	for (i = 0; i < ARRAY_LENGTH; i++)
	{
		printf("Numbers %d generated %6d (%5.2f%%) times\n", i, frequency[i], ((float)frequency[i] / NUMBER_AMOUNT * 100));
	}




	return 0;
}