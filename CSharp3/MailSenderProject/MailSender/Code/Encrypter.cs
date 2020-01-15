using System.Linq;

namespace MailSender.Code
{
    public static class Encrypter
    {
        public static int EcrypterKey = 382;
        public static string Encript(string value, int key) => new string(value.Select(c => (char)(c + key)).ToArray());
        public static string Deencript(string value,int key) => new string(value.Select(c => (char)(c - key)).ToArray());
    }
}
