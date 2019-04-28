/*
	  1) ���������.
	  ��������� ������������ ���� <math.h>, ������� �������,

	  int calculateSquareEquality(int a, int b, int c, float* x1, float* x2);

	  ������� ����� ������ ���������� ��������� ����
	  a * x ^ 2 + b * x + c = 0
	  � ���������� ����� ����� ��������� � ����������,
	  ������ ������� �������� � �������� ���������� �1 � �2.

	  ������� ������ ������� -1, ���� ��������� �� ����� ������,
	  0, ���� � ��������� ���� ���� ������,
	  � 1, ���� � ��������� ��� �����.


	  2) �������.
	  ���������������� ������ �� ����� �����, ������� �������, ����������� �� ���� ���� ������.

	  ������� ������ ������� ����, ���� � ������� ��� �������� �����,
	  � ��������� ������ ������� ��� �������� ����� � ������� � ������� �������.

	  ����� ���������� �������, ���� ������ ��� ������, ������� ��� ����� �� ������� �� �����.


	  3) ��������.
	  ��� ��������, ���������� ���� integer �������� � ������ 4 �����, � ���������� ���� short ��� �����.

	  ������� �������, ������� ��������� ������ �� ��������������������� ����� (���� int),
	  � ������� ��� �� ����� ��������������������� ������� (���� short). ���, �� ����, ������ ���������� ���� �������.
	  ������ ����������� ��� ��������������� ������ �� �������� ������� ��� ����� �������� ������.

	  ����� ���� ��� �� �������� �������� �������, ������������, ����������,
	  � ������������ "������� ��������� ������� ���� 10" � ������� "���������" ������.
*/
#include <math.h>
#include <stdio.h>

int calculateSquareEquality(int a, int b, int c, float* x1, float* x2) {

	int d = b*b - 4 * a * c;
	if (d < 0) return -1;
	else if (d == 0) {
		*x1 = *x2 = (float)((-b + (float)sqrt(d)) / (2 * a));
		return 0;
	}
	else
	{
		*x1 = (-b + (float)sqrt(d)) / (2 * a);
		*x2 = (-b - (float)sqrt(d)) / (2 * a);
		return 1;
	}
}

int checkArray(int* arr, int length,int* changed ) {
	int result = 0;
	for (int i = 0; i < length; i++)
	{
		if (arr[i] % 2 != 0) {
			for (int k = 0; k < length; k++)
			{
				if (arr[k] % 2 != 0)
					arr[k] = *(arr+k) * 2;
			}
			*changed = 1;
			result = 1;
			break;
		}
	}
	if (*changed != 1) * changed = 0;
	return result;
}

short* intToShortArray(int* array) {
	short* arr[5];
	for (int i = 0; i < 5; i++)
	{
		arr[i] = (short)array[i];
	}
	return *arr;
}

int LessonTen_main() {
	printf("This is Lesson Ten Homework\n");
	int a, b, c;
	float x1, x2;
	printf("Enter numbers in square equality ax^2+bx+c=0, like a b c\n");
	scanf_s("%d %d %d", &a, &b, &c);
	switch (calculateSquareEquality(a,b,c,&x1,&x2))
	{
	case -1:
		printf("d < 0  x1 = %f, x2 = %f",x1,x2);
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
	printf("\n");
	
	
	int array[5];
	printf("enter array\n");
	for (int i = 0; i < 5; i++) {
		printf("n.%d is ",i);
		scanf_s("%d",array+i);
	}
		
	printf("base array is: ");
	for (int i = 0; i < 5; i++) printf("%d ",array[i]);
	printf("\n");

	int change=0;
	checkArray(&array,5,&change);
	printf("changed array is: ");
	for (int i = 0; i < 5; i++) printf("%d ", array[i]);
	printf("\n");


	printf("enter five integers\n");
	for (int i = 0; i < 5; i++) scanf_s("%d",array+i);
	short* arr = intToShortArray(&array);
	printf("this is array after");
	for (int i = 0; i < 5; i++) printf("%hd ", arr + i);
	printf("\n");

	return 0;
}