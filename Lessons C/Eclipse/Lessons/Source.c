#include <stdio.h>
#include <string.h>
typedef struct {
	int Number;
	char Theme[256];
}Lessons;

void EndLessonStr(char* str) {
	printf("\nEnd Lesson %s work!\n",str);
}


int First_main();
int Second_main();
int Third_main();
int FourAndFive_main();
int Six_main();
int Seven_main();
int EightToTen_main();
int Eleven_main();
int Twelve_main();
int Thirteen_main();
int Fourteen_main();




int main() {
	printf("Type \"q\", if you wan exit: ");
	while (getch() != 'q') {
		int lesson;
		printf("\n\nChoose which lesson you wan check work\nLessons:\n");
		Lessons lessons[14];
		lessons[0].Number = 1;
		strcpy(lessons[0].Theme, "Introduction. Program \"Hello World!\"");
		lessons[1].Number = 2;
		strcpy(lessons[1].Theme, "Basic concepts");
		lessons[2].Number = 3;
		strcpy(lessons[2].Theme, "Conditions");
		lessons[3].Number = 4;
		strcpy(lessons[3].Theme, "Loops");
		lessons[4].Number = 5;
		strcpy(lessons[4].Theme, "Loops");
		lessons[5].Number = 6;
		strcpy(lessons[5].Theme, "Functions");
		lessons[6].Number = 7;
		strcpy(lessons[6].Theme, "Pointers");
		lessons[7].Number = 8;
		strcpy(lessons[7].Theme, "Arrays");
		lessons[8].Number = 9;
		strcpy(lessons[8].Theme, "Arrays");
		lessons[9].Number = 10;
		strcpy(lessons[9].Theme, "Arrays");
		lessons[10].Number = 11;
		strcpy(lessons[10].Theme, "Strings");
		lessons[11].Number = 12;
		strcpy(lessons[11].Theme, "Struct's");
		lessons[12].Number = 13;
		strcpy(lessons[12].Theme, "File systems");
		lessons[13].Number = 14;
		strcpy(lessons[13].Theme, "Dynamic memory");


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
			printf("\nEnd Lessons Four and Five work!\n");
			break;
		case 6:
			Six_main();
			EndLessonStr("Six");
			break;
		case 7:
			Seven_main();
			EndLessonStr("Seven");
			break;
		case 8:
		case 9:
		case 10:
			EightToTen_main();
			printf("\nEnd Lesson Eight to Ten work!\n");
			break;
		case 11:
			Eleven_main();
			EndLessonStr("Eleven");
			break;
		case 12:
			Twelve_main();
			EndLessonStr("Twelve");
			break;
		case 13:
			Thirteen_main();
			EndLessonStr("Thirteen");
			break;
		case 14:
			Fourteen_main();
			EndLessonStr("Fourteen");
			break;


		default:
			printf("\nThere no lesson with this number!\n");
			break;
		}

		printf("\nType \"q\", if you wan exit: ");
	}


	return 0;
}
