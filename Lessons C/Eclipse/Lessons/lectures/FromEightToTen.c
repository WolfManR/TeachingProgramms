// директивы дл€ работы со случайными числами
#include <stdlib.h>
#include <time.h>

/*
	директивы препроцессора помагают заменить одни слова другими
	в таком случае они называютс€ элиасами
*/
#define bool int
#define true 1
#define false 0

// также можно определить с помощью директив константы которыми можно пользоватьс€ во всЄм коде программы

// определение констант максимального значени€ массива и максимальное колличество чисел, которые сгенерирует генератор случайных чисел
#define ARRAY_LENGTH 10
#define NUMBER_AMOUNT 1000000

void printArray(int* array, int length) {
	for (int i = 0; i < length; i++) printf("%d", array[i]);
}


float average(int* array, int length) {
	float result = 0;
	for (int i = 0; i < length; i++)
		result += *(array + i);
	return result;
}

void voidFunction();  // прототип вызываемой функции в другом файле
void advancedArray();

int EightToTen_main() {

	voidFunction(); // вызов функции из другого файла


	 // массив представл€ет собой единую структуру €чеек в пам€ти, в которой размещаетс€ группа однотипных данных
	int array[ARRAY_LENGTH];
	array[0] = 1;			   // доступ к данным осуществл€етс€ через указатель на €чейку пам€ти
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

	// јрифметика указателей и передача массива в функцию
	i = 0;
	int arr[ARRAY_LENGTH];
	while (i < ARRAY_LENGTH) {
		printf("Enter value no.%d", i);
		scanf_s("%d", arr + i);                  // arr+i дл€ прохождени€ по элементам массива
		i++;
	}
	printf("\nOur array is: ");
	printArray(arr, ARRAY_LENGTH);           // вызов функции и передача массива
	printf("\nAnd the average is: ");
	printf("%f\n", average(arr, ARRAY_LENGTH));


	advancedArray();

	return 0;
}
