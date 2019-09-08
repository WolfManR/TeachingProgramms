/*
	  1) Указатели.
	  Используя заголовочный файл <math.h>, описать функцию,

	  int calculateSquareEquality(int a, int b, int c, float* x1, float* x2);

	  Которая будет решать квадратное уравнение вида
	  a * x ^ 2 + b * x + c = 0
	  и записывать корни этого уравнения в переменные,
	  адреса которых переданы в качестве указателей х1 и х2.

	  Функция должна вернуть -1, если уравнение не имеет корней,
	  0, если у уравнения есть один корень,
	  и 1, если у уравнения два корня.


	  2) Массивы.
	  Инициализировать массив из целых чисел, описать функцию, принимающую на вход этот массив.

	  Функция должна вернуть ноль, если в массиве нет нечётных чисел,
	  в противном случае удвоить все нечётные числа в массиве и вернуть единицу.

	  После выполнения функции, если массив был изменён, вывести все числа из массива на экран.


	  3) Звёздочка.
	  Как известно, переменная типа integer занимает в памяти 4 байта, а переменная типа short два байта.

	  Опишите функцию, которая принимает массив из тридцатидвухразрядных чисел (типа int),
	  и выводит его на экран шестнадцатиразрядными числами (типа short). Это, по сути, задача приведения типа массива.
	  Широко применяется для расшифровывания данных из входящих потоков или логов цифровых систем.

	  После того как вы сделаете домашнее задание, ознакомьтесь, пожалуйста,
	  с видеозаписью "Решение домашнего задания урок 10" в разделе "Материалы" справа.
*/
#include <math.h>
#include <stdio.h>

int calculateSquareEquality(int a, int b, int c, float* x1, float* x2) {
	int d = b * b - 4 * a * c;
	if (d < 0) return -1;
	else if (d == 0) {
		*x1 = *x2 = (float)(-b / (2 * a));
		return 0;
	}
	else
	{
		*x1 = (-b + (float)sqrt(d)) / (2 * a);
		*x2 = (-b - (float)sqrt(d)) / (2 * a);
		return 1;
	}
}

int checkArray(int* arr, int length, int* changed) {
	int result = 0;
	for (int i = 0; i < length; i++)
	{
		if (arr[i] % 2 != 0) {
			for (int k = 0; k < length; k++)
				if (arr[k] % 2 != 0)
					arr[k] *= 2;

			*changed = 1;
			result = 1;
			break;
		}
	}
	if (*changed != 1) * changed = 0;
	return result;
}

void intToShortArray(unsigned int* array) {
	unsigned short* arr = array;
	printf("this is array after ");
	for (int i = 0; i < 20; i++) printf("%d ", *(arr + i));
}

int LessonTen_main() {
	printf("This is Lesson Ten Homework\n");

	// 1
	int a, b, c;
	float x1, x2;
	printf("Enter numbers in square equality ax^2+bx+c=0, like a b c\n");
	scanf("%d %d %d", &a, &b, &c);
	if (a == 0) printf("x = %f",(float)(-c/b));
	else {
		switch (calculateSquareEquality(a, b, c, &x1, &x2))
		{
		case -1:
			printf("d < 0  x1 = %f, x2 = %f", x1, x2);
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

	// 2
	int array[5];
	printf("enter array\n");
	for (int i = 0; i < 5; i++) {
		printf("n.%d is ", i);
		scanf("%d", array + i);
	}

	printf("base array is: ");
	for (int i = 0; i < 5; i++) printf("%d ", array[i]);
	printf("\n");

	int change = 0;
	checkArray(&array, 5, &change);
	if (change == 1) {
		printf("changed array is: ");
		for (int i = 0; i < 5; i++) printf("%d ", array[i]);
		printf("\n");
	}
	else printf("array not changed\n");



	printf("enter five integers\n");
	unsigned int array2[10] = { 2000000,1000000,3000000,4000000,100000,200000 , 30000 , 400000 , 65535, 65536 };
	intToShortArray(array2);

	printf("\n");

	return 0;
}
