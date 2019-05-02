#include <stdio.h>
#include <string.h>
typedef struct {
	int Number;
	char Theme[256];
}Lessons;

void EndLessonStr(char* str) {
	printf("\nEnd Lesson %s work!\n",str);
}


int main() {
	printf("tipe \"q\", if you wana exit: ");
	while (getch() != 'q') {
		int lesson;
		printf("\n\nChoose which lesson you wana check work\nLessons:\n");
		Lessons lessons[14];
		lessons[0].Number = 1;
		strcpy_s(lessons[0].Theme, sizeof(char) * 38, "Introduction. Programm \"Hello World!\"");
		lessons[1].Number = 2;
		strcpy_s(lessons[1].Theme, sizeof(char) * 15, "Basic concepts");
		lessons[2].Number = 3;
		strcpy_s(lessons[2].Theme, sizeof(char) * 11, "Conditions");
		lessons[3].Number = 4;
		strcpy_s(lessons[3].Theme, sizeof(char) * 6, "Loops");
		lessons[4].Number = 5;
		strcpy_s(lessons[4].Theme, sizeof(char) * 6, "Loops");
		lessons[5].Number = 6;
		strcpy_s(lessons[5].Theme, sizeof(char) * 10, "Functions");
		lessons[6].Number = 7;
		strcpy_s(lessons[6].Theme, sizeof(char) * 9, "Pointers");
		lessons[7].Number = 8;
		strcpy_s(lessons[7].Theme, sizeof(char) * 7, "Arrays");
		lessons[8].Number = 9;
		strcpy_s(lessons[8].Theme, sizeof(char) * 7, "Arrays");
		lessons[9].Number = 10;
		strcpy_s(lessons[9].Theme, sizeof(char) * 7, "Arrays");
		lessons[10].Number = 11;
		strcpy_s(lessons[10].Theme, sizeof(char) * 8, "Strings");
		lessons[11].Number = 12;
		strcpy_s(lessons[11].Theme, sizeof(char) * 8, "Structs");
		lessons[12].Number = 13;
		strcpy_s(lessons[12].Theme, sizeof(char) * 13, "File systems");
		lessons[13].Number = 14;
		strcpy_s(lessons[13].Theme, sizeof(char) * 15, "Dynamic memory");


		for (int i = 0; i < 14; i++)
		{
			printf("%d : %s\n", lessons[i].Number, lessons[i].Theme);
		}


		printf("\n");
		printf("Number: ");
		scanf_s("%d", &lesson);
		printf("\n");

		switch (lesson)
		{
		case 1:
			First_main();
			EndLessonStr("First");
			break;
		case 2:
			Second_main();
			EndLessonStr("Two");
			break;
		case 3:
			Third_main();
			EndLessonStr("Three");
			break;
		case 4:

		case 5:
			FourAndFive_main();
			printf("End Lessons Four and Five work!\n");
			break;
		case 6:
			First_main();
			EndLessonStr("Six");
			break;
		case 7:
			First_main();
			EndLessonStr("Seven");
			break;
		case 8:

		case 9:

		case 10:
			First_main();
			printf("End Lesson Eight to Ten work!\n");
			break;
		case 11:
			First_main();
			EndLessonStr("Eleven");
			break;
		case 12:
			First_main();
			EndLessonStr("Twelve");
			break;
		case 13:
			First_main();
			EndLessonStr("Thirteen");
			break;
		case 14:
			First_main();
			EndLessonStr("Fourteen");
			break;


		default:
			printf("There no lesson with this number!\n");
			break;
		}

		printf("\ntipe \"q\", if you wana exit: ");
	}


	return 0;
}