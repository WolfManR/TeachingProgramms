using HWConsoleLibrary;

namespace HomeWork1
{
    public class Task5 : HomeWorkLib.ITaskWork
    {
        public void Work()
        {
            PrintMyInfo("Иван", "Бармин", "НЕ СКАЖУ!!!");
        }
        void PrintMyInfo(string firstName, string lastName, string city)
        {
            //Можно ещё уменьшить повторяемость кода с коллекциями, но это уже совсем другая история
            ConsoleMsg.WriteMsgInCenter("моё имя", firstName);
            ConsoleMsg.WriteMsgInCenter("фамилия", lastName);
            ConsoleMsg.WriteMsgInCenter("город проживания", city);
        }
    }
}
