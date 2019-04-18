#include <stdio.h>

int main() {
	printf("tipe \"q\", if you wana exit: ");
	char exit = getchar();
	while ( exit!= 'q') {
		int lesson;
		printf("Choose on which lesson you wana check homework work\nLessons:\n 1 : Five\n");
		scanf_s("%d", &lesson);
		switch (lesson)
		{
		case 1:
			LessonFive_main();
			printf("End Lesson Five Homework!\n");
			break;
		default:
			printf("There no lesson with this number!\n");
			break;
		}

		printf("\ntipe \"q\", if you wana exit: ");
		exit=getchar();
	}
	
	
	return 0;
}