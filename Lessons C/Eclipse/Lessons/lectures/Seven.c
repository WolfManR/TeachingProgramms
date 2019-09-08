// функция с параметрами передающимися по значению
void swapValue(int first, int second) {
	first ^= second;
	second ^= first;
	first ^= second;
}
// функция с параметрами передающимися по ссылке
void swapPointers(int* first, int* second) {
	*first ^= *second;
	*second ^= *first;
	*first ^= *second;
}


int Seven_main() {
	int a = 50;
	printf("value of a is %d\n", a);
	printf("address of a is %p\n\n", &a);
	int* pointer = &a;
	printf("value of pointer is %p\n", pointer);
	printf("address of pointer is %p\n", &pointer);
	printf("variable 'pointer' point at %d\n", *pointer); // операция называется разименование указателя
	*pointer = 70;
	printf("value of a is %d\n\n", a);

	int x = 40;
	int y = 50;
	swapValue(x, y);
	printf("swap Value funtion of x:%d , y:%d\n", x, y);

	swapPointers(&x, &y);
	printf("swap Pointers funtion of x:%d , y:%d\n\n", x, y);


	return 0;
}
