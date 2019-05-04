#include <stdio.h>

int main() {
	printf("tipe \"q\", if you wana exit: ");
	while ( getch()!= 'q') {
		int lesson;
		printf("\n\nChoose on which lesson you wana check homework work\nLessons:\n");
		printf("1 : Five\n");
		printf("2 : Ten\n");
		printf("3 : Fourteen\n");

		printf("\n");
		printf("Number: ");
		scanf_s("%d", &lesson);
		printf("\n");
		switch (lesson)
		{
		case 1:
			LessonFive_main();
			printf("End Lesson Five Homework!\n");
			break;
		case 2:
			LessonTen_main();
			printf("End Lesson Ten Homework!\n");
			break;
		case 3:
			//LessonFourteen_main(); не работает из-за компилятора vs
			printf("End Lesson Fourteen Homework!\n");
			break;
		default:
			printf("There no lesson with this number!\n");
			break;
		}

		printf("\ntipe \"q\", if you wana exit: ");
	}
	
	
	return 0;
}