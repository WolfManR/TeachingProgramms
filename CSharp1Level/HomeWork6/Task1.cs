using HomeWorkLib;

namespace HomeWork6
{
    internal class Task1 : HomeWorkTask
    {
        public override string Title => "Простой делегат";

        public override int TaskNumber => 1;

        public override string ToDo => "Изменить программу вывода функции так, чтобы можно было передавать функции типа double (double,double)." +
                                       "\nПродемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x)";

        public override void Work()
        {
            throw new System.NotImplementedException();
        }
    }
}