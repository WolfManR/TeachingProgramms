using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTestApp
{
    namespace TaskTest
    {
        #region Task Base
        static class TaskBase
        {
            static void Base()
            {
                Task task = new Task(TaskMethod);
                task.Start();
                Console.WriteLine("Ждём окончания работы задачи");
                task.Wait();
            }
            static void TaskMethod()
            {
                Console.WriteLine("Задача {0} выполняется.", Task.CurrentId);
                Thread.Sleep(2000);
                Console.WriteLine("Задача {0} завершена.", Task.CurrentId);
            }
        }
        #endregion

        #region Task Factory
        static class TaskFactory
        {
            static void Base()
            {
            Task[] tasksArr = new Task[10];
                for (int i = 0; i < tasksArr.Length; i++)
                {
                    tasksArr[i] = Task.Factory.StartNew(TaskMethod);
                }
                Console.WriteLine("Ждём окончания работы задачи");
                Task.WaitAll(tasksArr);
            }
            static void TaskMethod()
            {
                Console.WriteLine($"Задача {Task.CurrentId} выполняется.");
                Thread.Sleep(2000);
                Console.WriteLine($"Задача {Task.CurrentId} завершена.");
            }
        }
        #endregion

        #region Task With Parameters
        static class TaskWithParameter
        {
            static void Base()
            {
                int timeSpan = 2000;
                Task task1 = new Task(() => TaskMethodWithParameters(timeSpan));
                task1.Start();
                Task.Factory.StartNew(() => TaskMethodWithParameters(timeSpan));
                Console.WriteLine("Ждем окончания работы задачи.");
            }
            static void TaskMethodWithParameters(int timeSpan)
            {
                Console.WriteLine($"Задача {Task.CurrentId} выполняется.");
                Console.WriteLine($"Значение timeSpan = {timeSpan} ms.");
                Thread.Sleep(timeSpan);
                Console.WriteLine($"Задача {Task.CurrentId} завершена.");
            }
        }
        #endregion

        #region Task and It Result
        static class TaskResult
        {
            static void Base()
            {
                int x = 3;
                int y = 2;
                string message = "тестовое сообщение";
                Console.WriteLine("Запуск задач.");
                Task<int> task1 = new Task<int>(() => TaskMethodAdd(x, y));
                task1.Start();
                Task<string> task2 = Task.Factory.StartNew(() => TaskMethodStringToUpper(message));
                int resultAdd = task1.Result;
                string resultStringToUpper = task2.Result;
                Console.WriteLine($"Результат TaskMethodAdd: {resultAdd}");
                Console.WriteLine($"Результат TaskMethodString: {resultStringToUpper}");
            }
            static int TaskMethodAdd(int x, int y)
            {
                Thread.Sleep(2000);
                return x + y;
            }
            static string TaskMethodStringToUpper(string message)
            {
                Thread.Sleep(2000);
                return message.ToUpper();
            }
        }
        #endregion

        #region Method that continue after Task
        static class TaskContinue
        {
            static void Base()
            {
                int x = 3;
                int y = 2;
                Task task = new Task(() => TaskMethod(x, y));
                task.ContinueWith(TaskContinueWithMethod);
                task.Start();
                Console.WriteLine("  Ждем окончания работы задач.");
                Console.ReadKey();
            }
            static int TaskMethod(int x, int y)
            {
                Console.WriteLine("Выполняется TaskMethod.");
                Thread.Sleep(2000);
                return x + y;
            }
            static void TaskContinueWithMethod(Task task)
            {
                var taskStatus = task.Status;
                Console.WriteLine("Выполняется TaskContinueWithMethod.");
                Console.WriteLine($"Статус TaskMethod метода: {taskStatus}.");
            }
        }
        #endregion
    }
}
