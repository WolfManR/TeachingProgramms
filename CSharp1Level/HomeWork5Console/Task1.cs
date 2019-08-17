using HomeWorkLib;

namespace HomeWork5Console
{
    internal class Task1 : HomeWorkTask
    {
        public override string Title => "Проверка логина на соответсвие правилу";

        public override int TaskNumber => 1;

        public override string ToDo => "Создать программу, которая будет проверять корректность ввода логина. " +
                                       "\nКорректным логином будет строка от 2 до 10 символов, " +
                                       "\nсодержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:" +
                                       "\n\nа) без использования регулярных выражений;" +
                                       "\nб) с использованием регулярных выражений.";

        public override void Work()
        {
            throw new System.NotImplementedException();
        }
    }
}