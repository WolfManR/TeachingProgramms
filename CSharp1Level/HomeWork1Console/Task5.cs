using HomeWorkLib.ConsoleWork;

namespace HomeWork1Console
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
            Helper.WriteMsgInCenter("моё имя", firstName);
            Helper.WriteMsgInCenter("фамилия", lastName);
            Helper.WriteMsgInCenter("город проживания", city);
        }
    }
}
