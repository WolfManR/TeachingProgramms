/*
 * HW1Source.c
 *
 *  Created on: 25 сент. 2019 г.
 *      Author: Ivan Barmin
 *
 *  1. Ввести вес и рост человека. Рассчитать и вывести индекс массы тела по формуле I=m/(h*h); где m-масса тела в килограммах, h - рост в метрах.
 *
 */
int Task1_main(){
	double weight,height;
	printf("Введите массу тела в кг");
	scanf("%lf",&weight);
	printf("Введите рост человека в метрах");
	scanf("%lf",&height);
	printf("ИМТ равен %lf", weight / (height * height));
}
