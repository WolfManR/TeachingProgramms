/*
    1) Строки.
    Описать функцию, возвращающую строку с двоичным представлением десятичного числа,
	переданного в аргументе этой функции.


	2) Структуры.
    Описать структуру "прямоугольник", содержащую целочисленные значения длины, ширины,
	периметра и площади прямоугольника.
	Написать функцию, принимающую на вход указатель на структуру,
	подсчитывающую и записывающую площадь и периметр данного прямоугольника в структуру.


    3) Выделение памяти.
    Написать функцию - обёртку, возвращающую указатель на область памяти,
	которую затем можно использовать как массив из элементов типа integer.
	Количество элементов указывается в аргументе функции.
	Массив должен быть гарантированно инициализирован нулями.Для проверки - заполните этот массив и выведите на экран.



	После того как вы сделаете домашнее задание, ознакомьтесь, пожалуйста,
	с видеозаписью "Решение домашнего задания урок 14" в разделе "Материалы" справа.


*/
#include <string.h>

void Binary(int num,char* str) {
	char bin[64]="";
	int iter,temp = 0;
	while (temp != 0) {
		temp >>= 1;
		iter++;
	}
	while (num>0) {
		bin[--iter]=(num % 2)?'1':'0';
		printf("%d: %s\n",iter,bin);
		num /= 2;
	}

	printf("%s",bin);
strcat(str,bin);

}


typedef struct {
	int height;
	int width;
	int P;
	int S;
}rectangle;

void CalculateRectangle(rectangle* rect) {
	rect->P = 2 * (rect->height + rect->width);
	rect->S = rect->height * rect->width;

}

int* arrayInit(int size) {
	return calloc(size, sizeof(int));
}

int LessonFourteen_main() {
	printf("This is Lesson Fourteen Homework\n");
	// 1
	char* string="";
		Binary(156,&string);
	printf("end: %s\n",string);
	rectangle r = { .height = 2,.width = 3 };

	// 2
	CalculateRectangle(&r);
	printf("rectangle P:%d  S:%d\n", r.P, r.S);

	// 3
	int Size = 5;
	int* array = arrayInit(Size);
	for (int c; c < Size; c++) printf("%d ",*(array+c));
	puts("");
	for (int c; c < Size; c++)  *(array + c)=c*10;
	puts("");
	for (int c; c < Size; c++) printf("%d ", *(array + c));
	puts("");

	return 0;
}
