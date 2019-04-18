#include <stdio.h>

int main() {
	char exit;
	printf("tipe \"q\", if you wana exit");

	int lesson;
	printf("Chose on which lesson you wana check homework work\nLessons:\n 1 : Five\n");
	scanf_s("%d",&lesson );
	switch (lesson)
	{
	case 1:
		LessonFive_main();
		break;
	default:
		break;
	}
	
	return 0;
}