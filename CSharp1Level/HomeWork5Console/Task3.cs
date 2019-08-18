using HomeWorkLib;

namespace HomeWork5Console
{
    internal class Task3 : HomeWorkTask
    {
        public override string Title => "Строки перевёртыши";

        public override int TaskNumber => 3;

        public override string ToDo => "*Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой. " +
                                       "\nРегистр можно не учитывать:" +
                                       "\nа) с использованием методов C#;" +
                                       "\nб) *разработав собственный алгоритм." +
                                       "\nНапример: badc являются перестановкой abcd.";

        public override void Work()
        {
            throw new System.NotImplementedException();
        }

        public bool isRearrangement(string first,string second)
        {
            if (first.Length == second.Length) second = "";
            
            return false;
        }
    }
}