using System.Collections.Generic;
using CodePasswordDLL;

namespace WpfTestMailSender
{
    public static class VariablesClass
    {
        public static Dictionary<string,string> Senders { get => dicSenders; }
        private static Dictionary<string, string> dicSenders = new Dictionary<string, string>()
        {
            { "79257443993@yandex.ru",CodePassword.getPassword("1234l;i") },
            { "sok74@yandex.ru",CodePassword.getPassword(";liq34tjk") }
        };

    }
}
