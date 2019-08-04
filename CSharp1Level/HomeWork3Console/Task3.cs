using System;
using HomeWorkLib;
using HomeWorkLib.ConsoleWork;

namespace HomeWork3Console
{
    public class Task3 : HomeWorkTask
    {
        public override string Title => "Дроби";

        public override int TaskNumber => 3;

        public override string ToDo => "*Описать класс дробей - рациональных чисел, являющихся отношением двух целых чисел. " +
                                       "\nПредусмотреть методы сложения, вычитания, умножения и деления дробей. " +
                                       "\nНаписать программу, демонстрирующую все разработанные элементы класса." +
                                       "\n\n**Добавить проверку, чтобы знаменатель не равнялся 0. " +
                                       "\nВыбрасывать исключение ArgumentException(\"Знаменатель не может быть равен 0\");" +
                                       "\n\nДобавить упрощение дробей.";

        public override void Work()
        {
            
            Fraction first = new Fraction() { Numerator = -2, Denominator = 5 };
            Fraction second = new Fraction() { Numerator = 1, Denominator = 4 };
            int num = 6;
            Console.WriteLine("Вы будете вводить свой вариант дробей? \n<2 - да\n>=2 - нет");
            if (Helper.ReadInt() < 2)
            {
                first = GetFractionFromUserInput("Первая дробь");
                second = GetFractionFromUserInput("Вторая дробь");
                num = int.Parse(Helper.GetValueInMsgLine("введите целое число для умножения на него первой дроби"));
            }
            
            
            PrintResults(first, second, num);
        }

        Fraction GetFractionFromUserInput(string whichFraction)
        {
            var fraction=new Fraction();
            Console.WriteLine(whichFraction);
            fraction.Hole = int.Parse(Helper.GetValueInMsgLine("Введите целое число"));
            fraction.Numerator = int.Parse(Helper.GetValueInMsgLine("Введите числитель"));
            fraction.Denominator = int.Parse(Helper.GetValueInMsgLine("Введите знаменатель"));
            return fraction;
        }
        void PrintResults(Fraction first,Fraction second, int number)
        {
            Console.WriteLine();
            Console.WriteLine("сумма " + (first + second).ToString());
            Console.WriteLine("вычитание " + (first - second).ToString());
            Console.WriteLine("умножение " + (first * second).ToString());
            Console.WriteLine("умножение на целое " + (first * number).ToString());
            Console.WriteLine("деление " + (first / second).ToString());
        }

        public class Fraction
        {
            private int denominator;
            public int Hole { get; set; } = 0;
            public int Numerator { get; set; } = 0;
            public int Denominator
            {
                get => denominator;
                set
                {
                    if (value != 0)
                        denominator = value;
                    else throw new ArgumentException("Знаменатель не может быть равен 0");
                }
            } 

            public static void LeadToACommonDenominator(Fraction left,Fraction right)
            {
                if (left.Denominator != right.Denominator)
                {
                    left.Numerator *= right.Denominator;
                    int temp = left.Denominator;
                    left.Denominator *= right.Denominator;
                    right.Numerator *= temp;
                    right.Denominator *= temp;
                }
            }
            public static void SimplerFraction(ref Fraction fraction)
            {
                //Убираю десятки
                while (fraction.Numerator / 10 != 0 & fraction.Denominator / 10 != 0 &fraction.Numerator%10==0&fraction.Denominator%10==0)
                {
                    fraction.Numerator /= 10;
                    fraction.Denominator /= 10;
                }
                //Проверяю делится ли числитель и знаменатель на друг друга
                if(fraction.Denominator%fraction.Numerator==0)
                {
                    fraction.Denominator /= fraction.Numerator;
                    fraction.Numerator /= fraction.Numerator;
                }else if (fraction.Numerator % fraction.Denominator == 0)
                {
                    fraction.Numerator /= fraction.Denominator;
                    fraction.Denominator /= fraction.Denominator;
                }
                //Убираю кратность?
                for (int i = 9; i > 1; i--)
                {
                    if (fraction.Numerator % i == 0 & fraction.Denominator % i == 0)
                    {
                        fraction.Numerator /= i;
                        fraction.Denominator /= i;
                    }
                }
                //Выделяю целое и передаю ему знак дроби
                if(fraction.Numerator%fraction.Denominator==0)
                {
                    fraction.Hole += fraction.Numerator / fraction.Denominator;
                    fraction.Numerator = 0;
                }
                else
                {
                    fraction.Hole += fraction.Numerator / fraction.Denominator;
                    var newNumerator = fraction.Numerator % fraction.Denominator;

                    if (newNumerator < 0&fraction.Hole>0)
                    {
                        fraction.Numerator = newNumerator * -1;
                        fraction.Hole *= -1;
                    }
                    else
                    {
                        fraction.Numerator= newNumerator;
                    }
                }
            }

            #region Object override's
            public override string ToString()
            {
                return (Hole == 0) ? $"{Numerator}/{Denominator}" : $"{Hole} {Numerator}/{Denominator}";
            }
            #endregion

            #region Operator's
            public static Fraction operator +(Fraction Left, Fraction Right)
            {
                var left = new Fraction() { Hole=Left.Hole,Numerator=Left.Numerator,Denominator=Left.Denominator};
                var right = new Fraction() { Hole = Right.Hole, Numerator = Right.Numerator, Denominator = Right.Denominator };
                left.Numerator += left.Denominator * left.Hole;
                right.Numerator += right.Denominator * right.Hole;
                LeadToACommonDenominator(left, right);
                return new Fraction() { Numerator = left.Numerator + right.Numerator, Denominator = left.Denominator }; ;
            }
            public static Fraction operator -(Fraction Left, Fraction Right)
            {
                var left = new Fraction() { Hole = Left.Hole, Numerator = Left.Numerator, Denominator = Left.Denominator };
                var right = new Fraction() { Hole = Right.Hole, Numerator = Right.Numerator, Denominator = Right.Denominator };
                left.Numerator += left.Denominator * left.Hole;
                right.Numerator += right.Denominator * right.Hole;
                LeadToACommonDenominator(left, right);
                return new Fraction() { Numerator = left.Numerator - right.Numerator, Denominator = left.Denominator }; ;
            }
            public static Fraction operator *(Fraction left, Fraction right)
            {
                left.Numerator += left.Denominator * left.Hole;
                right.Numerator += right.Denominator * right.Hole;
                return new Fraction() { Numerator = left.Numerator * right.Numerator, Denominator = left.Denominator * right.Denominator }; ;
            }
            public static Fraction operator *(Fraction left, int number)
            {
                left.Numerator += left.Denominator * left.Hole;
                return new Fraction() { Numerator = left.Numerator * number, Denominator = left.Denominator };
            }
            public static Fraction operator /(Fraction left, Fraction right)
            {
                left.Numerator += left.Denominator * left.Hole;
                right.Numerator += right.Denominator * right.Hole;
                return new Fraction() { Numerator = left.Numerator * right.Denominator, Denominator = left.Denominator * right.Numerator };
            }
            #endregion
        }
    }
}
