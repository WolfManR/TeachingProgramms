using System.Collections.Generic;

namespace WpfTestMailSender
{
    public static class VariablesClass
    {
        public static Dictionary<string,string> Senders { get => dicSenders; }
        private static Dictionary<string, string> dicSenders = new Dictionary<string, string>()
        {
            { "79257443993@yandex.ru",PasswordClass.getPassword("1234l;i") },
            { "sok74@yandex.ru",PasswordClass.getPassword(";liq34tjk") }
        };

    }
}
