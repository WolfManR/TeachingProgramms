void voidFunction() {
	printf("this is voidMain\n");
}


void advancedArray() {
	printf("\n\nthis is array\n");

	const int rows = 10, cols = 10; // невозможно использовать в массиве в текущей версии visual studio
	int table[10][10];
	int r, c;

	for (r = 0; r < rows; r++)
	{
		for (c = 0; c < cols; c++)
		{
			//scanf_s("%d",&table[r][c]);
			table[r][c] = (r + 1) * (c + 1);
		}
	}

	for (r = 0; r < rows; r++)
	{
		for (c = 0; c < cols; c++) printf("%3d ", table[r][c]);
		printf("\n");
	}


	char* stringArray[3] = { "Hello","C","World!" };   // ћассив указателей может содержать любые объекты, в примере строки
	for (c = 0; c < 3; c++) printf("%s ", stringArray[c]);

	int twoDimensions[5][5];
	int threeDimensions[5][5][5];
}