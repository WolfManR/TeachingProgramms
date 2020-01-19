using System;
using Math;


namespace ConsoleProgram
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("Здравствуйте вас приветствует математическая программа");

            Console.WriteLine("пожалуйста введите число. ");
            string userInput = Console.ReadLine();
            if (userInput == "q") return;

            if (int.TryParse(userInput, out int userNumber))
            {
                Mathematics mathematics = new Mathematics();
                mathematics.CalcAll(userNumber);


                Console.WriteLine($"Факториал равен { mathematics.Factorial }");
                Console.WriteLine($"Сумма от 1 до { userNumber } равна { mathematics.Sum }");
                Console.WriteLine($"Максимальное четное число меньше { userNumber } равно { mathematics.MaxEven }");
            }
            else Console.WriteLine("Вы ввели не число");

            Console.ReadKey();
            return 0;
        }
    }
}


namespace Math
{
    public sealed class Mathematics
    {
        #region Fields

        private int _factorial = 1;
        private int _sum = 0;
        private int _maxEven = 0;

        #endregion


        #region Properties

        public int Factorial => _factorial;

        public int Sum => _sum;

        public int MaxEven => _maxEven;

        #endregion


        #region Methods

        /// <summary>
        /// Calcs All values of Mathematics class
        /// </summary>
        /// <param name="max">maximum number</param>
        public void CalcAll(int max)
        {
            for (int i = 1; i <= max; i++)
            {
                _factorial *= i;
                _sum += i;
                if (i % 2 == 0) _maxEven = i;
            }
        }

        #endregion
    }
}