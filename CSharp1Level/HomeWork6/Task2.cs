using HomeWorkLib;

namespace HomeWork6
{
    internal class Task2 : HomeWorkTask
    {
        public override string Title => "Делегат как параметр";

        public override int TaskNumber => 2;

        public override string ToDo => "Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата." +
                                       "\nа) Сделайте меню с различными функциями и предоставьте пользователю выбор, для какой функции и на каком отрезке находить минимум." +
                                       "\nб) Используйте массив(или список) делегатов, в котором хранятся различные функции." +
                                       "\nв) *Переделайте функцию Load, чтобы она возвращала массив считанных значений. Пусть она возвращает минимум через параметр.";

        public override void Work()
        {
            throw new System.NotImplementedException();
        }
    }
}