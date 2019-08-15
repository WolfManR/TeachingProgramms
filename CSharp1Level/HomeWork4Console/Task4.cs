using HomeWorkLib;

namespace HomeWork4Console
{
    public class Task4 : HomeWorkTask
    {
        public override string Title => "Account";

        public override int TaskNumber => 4;

        public override string ToDo => "Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив." +
                                       "\nСоздайте структуру Account, содержащую Login и Password.";

        public override void Work()
        {
            throw new System.NotImplementedException();
        }

        public struct Account
        {
            public string Login { get; set; }
            public string Password { get; set; }
            public Account(string login,string pass)
            {
                Login = login;
                Password = pass;
            }
        }
    }
}
