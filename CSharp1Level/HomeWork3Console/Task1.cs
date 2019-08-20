using System;
using HomeWorkLib;

namespace HomeWork3
{
    public class Task1 : HomeWorkTask
    {
        public override string Title => "struct Complex";

        public override int TaskNumber => 1;

        public override string ToDo => "а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры;" +
                                        "\nб) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса;";

        public override void Work()
        {
            Console.WriteLine("Работа структуры");
            var first=new ComplexStruct(-4,5.6);
            var second = new ComplexStruct(8, 12.82);
            Console.WriteLine($"вычитание структур\n{first.ToString()} - {second.ToString()} = "+(first-second).ToString());
            Console.WriteLine("Работа класса");
            var third = new ComplexClass(-12, 2.6);
            var fourth = new ComplexClass(9, -3.82);
            Console.WriteLine($"вычитание классов\n{third.ToString()} - {fourth.ToString()} = " + (third - fourth).ToString());
            Console.WriteLine($"произведение классов\n{third.ToString()} * {fourth.ToString()} = " + (third * fourth).ToString());
        }

        struct ComplexStruct
        {
            public double RealPart { get; set; }
            public double ImaginaryPart { get; set; }
            public double ImaginaryUnit { get; }

            public ComplexStruct(double realPart, double imaginaryPart)
            {
                ImaginaryUnit = Math.Sqrt(-1);
                RealPart = realPart;
                ImaginaryPart = imaginaryPart;
            }
            public static ComplexStruct operator -(ComplexStruct left, ComplexStruct right)
            {
                return new ComplexStruct(left.RealPart - right.RealPart, left.ImaginaryPart - right.ImaginaryPart);
            }
            public override string ToString()
            {
                return (ImaginaryPart < 0) ? $"{RealPart}{ImaginaryPart}i" : $"{RealPart}+{ImaginaryPart}i";
            }
        }
        class ComplexClass
        {
            public double RealPart { get; set; }
            public double ImaginaryPart { get; set; }
            public double ImaginaryUnit { get; } = Math.Sqrt(-1);

            public ComplexClass() : this(0, 0) { }

            public ComplexClass(double realPart, double imaginaryPart)
            {
                RealPart = realPart;
                ImaginaryPart = imaginaryPart;
            }
            public static ComplexClass operator -(ComplexClass left, ComplexClass right)
            {
                return new ComplexClass(left.RealPart - right.RealPart, left.ImaginaryPart - right.ImaginaryPart);
            }
            public static ComplexClass operator *(ComplexClass left, ComplexClass right)//(a + bi)(c + di) =(ac - bd) + (bc + ad)i.
            {
                return new ComplexClass
                    (
                        left.RealPart * right.RealPart - left.ImaginaryPart * right.ImaginaryPart,
                        left.ImaginaryPart * right.RealPart + left.RealPart * right.ImaginaryPart
                    );
            }

            public override string ToString()
            {
                return (ImaginaryPart<0)?$"{RealPart}{ImaginaryPart}i":$"{RealPart}+{ImaginaryPart}i";
            }
        }
    }
}
