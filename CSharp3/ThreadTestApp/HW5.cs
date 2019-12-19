using System;
using System.IO;
using System.Numerics;
using System.Text;
using System.Threading;

namespace ThreadTestApp
{
    public static class HW5
    {
        public static void Work()
        {
            Console.WriteLine("Enter Factorial Number");
            Factorial fact = new Factorial(int.Parse(Console.ReadLine()));
            Thread factThread = new Thread(new ThreadStart(fact.CalcFactorial));
            factThread.Start();

            Console.WriteLine("Enter Number to calc sum of integer values before it");
            Sum sum = new Sum(int.Parse(Console.ReadLine()));
            Thread sumThread = new Thread(new ThreadStart(sum.CalcSum));
            sumThread.Start();

            Console.WriteLine("Enter FileName of csv file");
            string csvFileName = Console.ReadLine();
            Console.WriteLine("Enter FileName of txt file");
            string txtFileName = Console.ReadLine();
            Console.WriteLine("Enter Split Character");
            char SplitChar = char.Parse(Console.ReadLine());

            CSV csv = new CSV(csvFileName,txtFileName,SplitChar);

            Thread ParserThread = new Thread(new ThreadStart(csv.CSVParseToTXT));
            ParserThread.Start();


            Console.ReadLine();
        }
    }

    public class Factorial
    {
        readonly int n;
        public Factorial(int fact)
        {
            n = fact;
        }
        public void CalcFactorial()
        {
            BigInteger result = n;
            for (int i = n-1; i > 0; i--) result *= i;
            Console.WriteLine($"Factorial of {n} is {result}");
        }
    }

    public class Sum
    {
        readonly int n;
        public Sum(int number)
        {
            n = number;
        }
        public void CalcSum()
        {
            int result = 0;
            for (int i = 0; i < n; i++) result += i;
            Console.WriteLine($"Sum of integer values before {n} is {result}");
        }
    }


    public class CSV
    {
        string CSVFileName;
        string TXTFileName;
        char SplitChar;
        public CSV(string csv_FileName,string txt_FileName,char splitChar)
        {
            CSVFileName = csv_FileName;
            TXTFileName = txt_FileName;
            SplitChar = splitChar;
        }

        public void CSVParseToTXT()
        {
            using (StreamReader csvReader = new StreamReader(CSVFileName+".csv"))
            {
                using(StreamWriter txtWriter=new StreamWriter(TXTFileName+".txt"))
                {
                    while (!csvReader.EndOfStream)
                    {
                        try
                        {
                            StringBuilder builder = new StringBuilder();
                            foreach (var item in csvReader.ReadLine().Split(SplitChar))
                            {
                                builder.Append(item + "   ");
                            }
                            txtWriter.WriteLine(builder.ToString());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Something Bad Happend!");
                        }
                    }
                }
            }
            Console.WriteLine("Work of Parser Done!");
        }
    }

}
