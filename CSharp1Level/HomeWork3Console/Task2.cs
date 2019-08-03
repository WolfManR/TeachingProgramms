using HomeWorkLib;

namespace HomeWork3Console
{
    public class Task2 : HomeWorkTask
    {
        public override string Title => "TryParse";

        public override int TaskNumber => 2;

        public override string ToDo => "а) С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке)." +
                                       "\nТребуется подсчитать сумму всех нечетных положительных чисел." +
                                       "\nСами числа и сумму вывести на экран, используя tryParse;" +
                                       "\n\nб) Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные." +
                                       "\nПри возникновении ошибки вывести сообщение.Напишите соответствующую функцию;";

        public override void Work()
        {
            throw new System.NotImplementedException();
        }
    }
}
