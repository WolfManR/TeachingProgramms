using HomeWorkLib;

namespace HomeWork4Console
{
    public class Task2 : HomeWorkTask
    {
        public override string Title => "StaticClass";

        public override int TaskNumber => 2;

        public override string ToDo => "Реализуйте задачу 1 в виде статического класса StaticClass;" +
                                       "\nа) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;" +
                                       "\nб) * Добавьте статический метод для считывания массива из текстового файла.Метод должен возвращать массив целых чисел;" +
                                       "\n\nв)** Добавьте обработку ситуации отсутствия файла на диске.";

        public override void Work()
        {
            throw new System.NotImplementedException();
        }
    }
}
