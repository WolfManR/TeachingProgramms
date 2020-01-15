using System;
using System.Threading.Tasks;
using System.IO;

namespace ThreadTestApp
{
    public static class HW6
    {
        static int x = 50; //half size for read purpose
        static int y = 50;
        static int[,] matrica1 = new int[x, y];
        static int[,] matrica2 = new int[x, y];
        static int[,] resultMatrica = new int[x, y];
        static Random r = new Random();
        public static void Work()
        {
            MatricaWorkAsync();
            DirectoryCalculating();
        }

        static async void MatricaWorkAsync()
        {
            void FillMatrica(ref int[,] matrica, Random rand)
            {
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        matrica[i, j] = rand.Next(10);
                    }
                }
            }
            void PrintMatrica(int[,] matrica)
            {
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        Console.Write($"{matrica[i, j],3} ");
                    }
                    Console.WriteLine();
                }
            }
            async Task MultiplyAsync()
            {
                await Task.Run(() =>
                {
                    for (int i = 0; i < x; i++)
                    {
                        for (int j = 0; j < y; j++)
                        {
                            resultMatrica[i, j] = matrica1[i, j] * matrica2[i, j];
                        }
                    }
                });
            }

            FillMatrica(ref matrica1, r);
            FillMatrica(ref matrica2, r);
            await MultiplyAsync();
            PrintMatrica(resultMatrica);
        }


        static async void DirectoryCalculating()
        {
            DirectoryInfo directory = new DirectoryInfo("input");
            if (!directory.Exists)
            {
                directory.Create();
                Console.WriteLine("Put Info files in directory \"input\" that now created");
                return;
            }
            FileInfo[] files = directory.GetFiles("*.txt");
            if (files.Length == 0)
            {
                Console.WriteLine("There no files");
                await Task.Run(() =>
                {
                    for (int i = 0; i < 100; i++)
                    {
                        using (StreamWriter sw = new StreamWriter($"{directory.FullName}/input{i}.txt"))
                        {
                            sw.WriteLine($"{r.Next(1, 3)} {r.NextDouble()} {r.NextDouble()}");
                        }
                    }
                });
                Console.WriteLine("Template Files Created, you can edit them and relaunch program");
            }
            else
            {
                await Task.Run(() =>
                {
                    using (StreamWriter sw = File.CreateText($"result.dat"))
                    {
                        for (int i = 0; i < files.Length; i++)
                        {
                            using (StreamReader sr = files[i].OpenText())
                            {
                                var line = sr.ReadLineAsync().Result.Split(' ');
                                switch (line[0])
                                {
                                    case "1":
                                        sw.WriteLine($"{i} {double.Parse(line[1]) * double.Parse(line[2])}");
                                        break;
                                    case "2":
                                        sw.WriteLine($"{i} {double.Parse(line[1]) / double.Parse(line[2])}");
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                });
                Console.WriteLine("Work Done");
            }
        }
    }
}
