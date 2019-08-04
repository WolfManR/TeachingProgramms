using System;
using HomeWorkLib;

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
            throw new NotImplementedException();
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

            public static void LeadToACommonDenominator(ref Fraction left,ref Fraction right)
            {
                left.Numerator *= right.Denominator;
                int temp = left.Denominator;
                left.Denominator *= right.Denominator;
                right.Numerator *= temp;
                right.Denominator *= temp;
            }
            public static void SimplerFraction(ref Fraction fraction)
            {
                if(fraction.Numerator%fraction.Denominator==0)
                {
                    fraction.Hole += fraction.Numerator / fraction.Denominator;
                    fraction.Numerator = 0;
                }
                else
                {
                    fraction.Hole += fraction.Numerator / fraction.Denominator;
                    fraction.Numerator %= fraction.Denominator;
                }
            }

            #region Object override's
            public override string ToString()
            {
                return (Hole == 0) ? $"{Numerator}/{Denominator}" : $"{Hole} {Numerator}/{Denominator}";
            }
            #endregion

            #region Operator's
            public static Fraction operator +(Fraction left, Fraction right)
            {
                left.Numerator += left.Denominator * left.Hole;
                right.Numerator += right.Denominator * right.Hole;
                LeadToACommonDenominator(ref left, ref right);
                return new Fraction() { Numerator = left.Numerator + right.Numerator, Denominator = left.Denominator };
            }
            public static Fraction operator -(Fraction left, Fraction right)
            {
                left.Numerator += left.Denominator * left.Hole;
                right.Numerator += right.Denominator * right.Hole;
                LeadToACommonDenominator(ref left, ref right);
                return new Fraction() { Numerator = left.Numerator - right.Numerator, Denominator = left.Denominator };
            }
            public static Fraction operator *(Fraction left, Fraction right)
            {
                left.Numerator += left.Denominator * left.Hole;
                right.Numerator += right.Denominator * right.Hole;
                return new Fraction() { Numerator = left.Numerator * right.Numerator, Denominator = left.Denominator * right.Denominator };
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
