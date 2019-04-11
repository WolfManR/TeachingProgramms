// это однострочный комментарий

/*
  это многострочный комментарий
*/
 
/*
  Директивы препроцессора
  нужны для поключения внешних файлов кода
*/
#include <stdio.h>  

/*
    Функция для старта программы
	обязана иметь имя main и возвращать int
*/
int main(int argc, const char* argv[]) {  
/*
	Функция описанная в stdio.h, используемая для вывода текста на консоль

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
	 %x - 
	 %% - символ процента

	 для числовых типов используется следующая маска ввода
	 %05d для записи значений с лидирующими нулями 00050
	 %5d вместо нулей используются пробелы
	 %.2f указывает сколько знаков должно быть после запятой  50.00
*/

	int num = 50;
	char sym = 'A';
	float flo = 50.02f;
	//no boolean int равное 1 - true, 0 - false


	printf("This is int %d \n", num);
	printf("This is int %05d with pre 0 \n", num);
	printf("This is int %5d with pre   \n", num);
	printf("%c \n", sym);
	printf("This is float %f \n", flo);
	printf("This is float %.2f with after numbers \n", flo);
	
	printf("%d \n", num);
	printf("%d \n",num);

/*
	   Обязательно должна возвращать ноль, как успешное завершение программы
*/
	return 0; 
}