#include <stdio.h>

int main() {
	printf("tipe \"q\", if you wana exit: ");
	while ( getch()!= 'q') {
		int lesson;
		printf("\n\nChoose on which lesson you wana check homework work\nLessons:\n 1 : Five\n");
		printf("Number: ");
		scanf_s("%d", &lesson);
		printf("\n");
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
	}
	
	
	return 0;
}