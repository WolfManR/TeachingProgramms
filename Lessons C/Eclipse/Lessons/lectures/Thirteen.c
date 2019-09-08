#include <stdio.h>

int Thirteen_main() {
	FILE* f;
	f = fopen("filename.txt", "w"); // r = read, w = write , a = append, binary - rb,wb,ab
	if (f == NULL)return 1;
	fprintf(f, "Hello, files! %s", "we did it! \n");
	fclose(f);

	char word[256];
	f = fopen("filename.txt", "r");
	while (!feof(f)) {
		fscanf(f, "%s ", &word);
		printf("%s ", word);
	}
	fclose(f);
	puts("");

	return 0;
}
