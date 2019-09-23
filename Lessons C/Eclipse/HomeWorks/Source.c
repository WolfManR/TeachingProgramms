#include <stdio.h>
int LessonFive_main();
int LessonTen_main();
int LessonFourteen_main();
int main() {
	setvbuf(stdout, NULL, _IONBF, 0);
	printf("type \"q\", if you wan exit: ");
	char quit=' ';
	scanf("%c",&quit);

	while ( quit!= 'q') {
		int lesson;
		printf("\n\nChoose on which lesson you wan check homework work\nLessons:\n");
		printf("1 : Five\n");
		printf("2 : Ten\n");
		printf("3 : Fourteen\n");

		printf("\n");
		printf("Number: ");
		scanf("%d", &lesson);
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
			LessonFourteen_main();
			printf("End Lesson Fourteen Homework!\n");
			break;
		default:
			printf("There no lesson with this number!\n");
			break;
		}

		printf("\ntype \"q\", if you wan exit: ");
		setbuf(stdout, NULL);
		setbuf(stdin, NULL);
		scanf("%c",&quit);
	}


	return 0;
}
