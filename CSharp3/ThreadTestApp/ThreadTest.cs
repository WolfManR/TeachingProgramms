using System;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace ThreadTestApp
{
    public static class ThreadTest
    {
        #region First Test
        static void FirstThreadTest()
        {
            Thread thread = new Thread(new ThreadStart(ThreadMethod))
            {
                Priority = ThreadPriority.Highest,
                Name = "Вторичный поток"
            };
            thread.Start();
            Console.WriteLine("Ждём окончания работы потока.");
            Console.ReadKey();
        }
        static void ThreadMethod()
        {
            Thread.Sleep(2000);
            Console.WriteLine($"{Thread.CurrentThread.Name} завершён.");
        }
        #endregion

        #region Second Test
        static void SecondThreadTest()
        {
            int sleepTime = 2000;
            Thread thread = new Thread(new ParameterizedThreadStart(ThreadMethod));
            thread.Name = "Вторичный поток";
            thread.Start(sleepTime);

            Console.WriteLine("Ждём окончания работы потока.");
        }
        static void ThreadMethod(object sleepTime)
        {
            Thread.Sleep((int)sleepTime);
            Console.WriteLine($"{Thread.CurrentThread.Name} завершён.");
        }
        #endregion

        #region Third Test
        static void ThirdThreadTest()
        {
            ThreadClass threadClass = new ThreadClass(2000, "Поток завершен.");
            Thread thread = new Thread(new ThreadStart(threadClass.ThreadClassMethod))
            {
                Priority = ThreadPriority.Highest,
                Name = "Вторичный поток"
            };
            thread.Start();
            Console.WriteLine("Ждем окончания работы потока.");
        }
        public class ThreadClass
        {
            private int _sleepTime;
            private string _message;
            public ThreadClass(int sleepTime, string message)
            {
                _sleepTime = sleepTime;
                _message = message;
            }
            public void ThreadClassMethod()
            {
                Thread.Sleep(_sleepTime);
                Console.WriteLine(_message);
            }
        }
        #endregion

        #region Four Test
        static void FourThreadTest()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(FourThreadMethod) { Name = i.ToString() };
                thread.Start();
            }

            Console.ReadLine();
        }
        static object lockObject = new object();
        static void FourThreadMethod()
        {
            lock (lockObject)
            {
                int value = 0;

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Поток {0}: {1}", Thread.CurrentThread.Name, value);
                    value++;
                    Thread.Sleep(200);
                }
            }
        }
        #endregion

        #region Fifth Test
        static void FifthThreadTest()
        {
            ClassWithSynchronizationAttribute obj = new ClassWithSynchronizationAttribute();
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(obj.ThreadMethod) { Name = i.ToString() };
                thread.Start();
            }

            Console.ReadLine();
        }
        [Synchronization]
        public class ClassWithSynchronizationAttribute
        {
            private int _value;
            public void ThreadMethod()
            {
                Console.WriteLine("  Поток {0}: _value = {1}", Thread.CurrentThread.Name, _value);
                _value++;
                Thread.Sleep(2000);
            }
        }
        #endregion

        #region Six Test
        static void SixThreadTest()
        {
            ThreadPool.SetMinThreads(2, 2);
            ThreadPool.SetMaxThreads(5, 5);
            for (int i = 0; i < 5; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(SixThreadMethod));
            }
            Console.ReadLine();
        }
        static void SixThreadMethod(object state)
        {
            lock (lockObject)
            {
                int value = 0;

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Поток {0}: {1}", Thread.CurrentThread.Name, value);
                    value++;
                    Thread.Sleep(200);
                }
            }
        }
        #endregion
    }
}
