// ��� ������������ �����������

/*
  ��� ������������� �����������
*/
 
/*
  ��������� �������������
  ����� ��� ���������� ������� ������ ����
*/
#include <stdio.h>  

/*
    ������� ��� ������ ���������
	������� ����� ��� main � ���������� int
*/
int main(int argc, const char* argv[]) {  
/*
	������� ��������� � stdio.h, ������������ ��� ������ ������ �� �������

	� ������� ��� �� �������������� ������������:
	 �������� �����������:
	 \n - ������ ����� ������
	 \t - ������ ���������
	 \\ - ������ \
	 \0 - ������ ����� ������
	 
	
*/
	printf("Hello World!\n");
	printf("This is a new row with \ttab\n");
	printf("This row with \\ symbol\n");
	printf("This row without \0end\n");

	printf("\n");
/*  
     ����������� ����������:
	 %d - int
	 %s - ������
	 %c - char
	 %p - ���������
	 %f - float
	 %lf - double
	 %x - 
	 %% - ������ ��������

	 ��� �������� ����� ������������ ��������� ����� �����
	 %05d ��� ������ �������� � ����������� ������ 00050
	 %5d ������ ����� ������������ �������
	 %.2f ��������� ������� ������ ������ ���� ����� �������  50.00
*/

	int num = 50;
	char sym = 'A';
	float flo = 50.02f;
	//no boolean int ������ 1 - true, 0 - false


	printf("This is int %d \n", num);
	printf("This is int %05d with pre 0 \n", num);
	printf("This is int %5d with pre   \n", num);
	printf("%c \n", sym);
	printf("This is float %f \n", flo);
	printf("This is float %.2f with after numbers \n", flo);
	
	printf("%d \n", num);
	printf("%d \n",num);

/*
	   ����������� ������ ���������� ����, ��� �������� ���������� ���������
*/
	return 0; 
}