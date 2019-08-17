using HomeWorkLib;

namespace HomeWork5Console
{
    internal class Task2 : HomeWorkTask
    {
        public override string Title => "Обработка текста";

        public override int TaskNumber => 2;

        public override string ToDo => "Разработать класс Message, содержащий следующие статические методы для обработки текста:" +
                                       "\nа) Вывести только те слова сообщения, которые содержат не более n букв." +
                                       "\nб) Удалить из сообщения все слова, которые заканчиваются на заданный символ." +
                                       "\nв) Найти самое длинное слово сообщения." +
                                       "\nг) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения." +
                                       "\n\nПродемонстрируйте работу программы на текстовом файле с вашей программой.";

        public override void Work()
        {
            throw new System.NotImplementedException();
        }
    }
}