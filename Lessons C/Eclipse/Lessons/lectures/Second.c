// это однострочный комментарий

/*
  это многострочный комментарий
*/


//  Директивы препроцессора нужны для подключения внешних файлов кода
#include <stdio.h>


// Функция для старта программы обязана иметь имя main и возвращать int
int Second_main() {
	/*
		printf() - функция описанная в stdio.h, используемая для вывода текста на консоль

		в строках для их форматирования используются:
		 экранные заполнители:
		  \n - символ новой строки
		  \t - символ табуляции
		  \\ - символ \
		  \0 - символ конца строки
	*/
	printf("Hello World!\n");
	printf("This is a new row with \ttab\n");
	printf("This row with \\ symbol\n");
	printf("This row without \0end\n");

	printf("\n");
	/*
		 заполнители переменных:
		  %d - int
		  %s - строки
		  %c - char
		  %p - указатели
		  %f - float
		  %lf - double
		  %x - шестнадцатичеричный
		  %% - символ процента

		 для числовых типов используется следующая маска ввода
		  %05d для записи значений с лидирующими нулями "00050"
		  %5d вместо нулей используются пробелы "   50"
		  %.2f указывает сколько знаков должно быть после запятой "50.00"
	*/
	short shrt = 345;
	int num = 50;
	char sym = 'A';
	char sym2 = 75;
	float flo = 50.02f;
	double dbl = 50.24;
	// нет типа boolean, используется как int равное 1 - true, 0 - false

	// типы имеющие unsigned:   char, int

	printf("This is int %d \n", num);
	printf("This is int %05d with pre 0 \n", num);
	printf("This is int %5d with pre   \n", num);
	printf("%c \n", sym);
	printf("%c \n", sym2);
	printf("This is float %f \n", flo);
	printf("This is float %.2f with after numbers \n", flo);
	printf("This is float %.2lf with after numbers \n", flo);

	// передача переменной по значению
	printf("%d \n", num);
	// передача адресса переменной
	printf("%p \n", &num);

	printf("Tipe any number: ");
	int inputNum;
	// функция пользовательского ввода в консоли
	scanf_s("%d", &inputNum);
	// принимает тип значения переменной и адресс переменной для записи значения
	// printf("\nyou tipe this %d number and we multiply it %d", inputNum/*,inputNum*2 ВНУТРИСТРОЧНЫЙ КОММЕНТАРИЙ*/);
	printf("\nyou tipe this %d number and we multiply it", inputNum);


	// Арифметические операции
	/*
	стандартные: +, -, *, /, %

	бинарные:
	  & - и
	  | - или
	  ! - не
	  ^ - исключающее или
	  << >> - сдвиг влево и вправо

	инкремент - ++var, var++
	декремент - --var, var--

	операции с присвоением изменённого значения в первую переменную(+=, -=, *=, ...)
	*/

	int variable = 70;
	printf("var is: %d\n", variable);
	variable += 50;
	variable++;
	++variable;
	printf("now var is: %d\n", variable);

	printf("\n");

	// Бинарная арифметика
	/*
	  1 & 0 = 0
	  1 | 0 = 1
	  0 ^ 1 = 1
	  !1 = 0
	*/
	int a = 11; // a= 00001011
	int b = 15;	// b= 00001111
	printf("a=%d,b=%d\n", a, b);

	a = a ^ b; // 00000100
	b = b ^ a; // 00001011
	a = a ^ b; // 00001111
	printf("a=%d,b=%d\n", a, b);

	a = a << 3; // a умножить на 2 в степени 3
	b = b >> 2; // b поделить на 2 во 2 степени

	printf("a=%d,b=%d\n", a, b);


	// Метод main обязательно должен возвращать 0, как успешное завершение программы
	return 0;
}
