using System;
using HomeWorkLib;

namespace HomeWork3Console
{
    public class Task3 : HomeWorkTask
    {
        public override string Title => "Дроби";

        public override int TaskNumber => 3;

        public override string ToDo => "*Описать класс дробей - рациональных чисел, являющихся отношением двух целых чисел. " +
                                       "\nПредусмотреть методы сложения, вычитания, умножения и деления дробей. " +
                                       "\nНаписать программу, демонстрирующую все разработанные элементы класса." +
                                       "\n\n**Добавить проверку, чтобы знаменатель не равнялся 0. " +
                                       "\nВыбрасывать исключение ArgumentException(\"Знаменатель не может быть равен 0\");" +
                                       "\nДобавить упрощение дробей.";

        public override void Work()
        {
            throw new NotImplementedException();
        }
    }
}
