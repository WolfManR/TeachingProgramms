using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTestApp
{
    namespace ParallelTest
    {
        #region Parallel Base
        static class ParallelBase
        {
            static void Main()
            {
                Parallel.Invoke(ParallelMethod, ParallelMethod, ParallelMethod, () =>
                {
                    Console.WriteLine($"Task: {Task.CurrentId} start.");
                    Thread.Sleep(5000);
                    Console.WriteLine($"Task: {Task.CurrentId} done.");
                });
            }

            static void ParallelMethod()
            {
                Console.WriteLine($"Task: {Task.CurrentId} start.");
                Thread.Sleep(5000);
                Console.WriteLine($"Task: {Task.CurrentId} done.");
            }
        }
        #endregion

        #region Parallel For
        static class ParallelFor
        {
            static void Main()
            {
                Parallel.For(1, 10, ParallelMethod);
            }
            static void ParallelMethod(int iteration)
            {
                Console.WriteLine($"Iteration: {iteration} start.");
                Thread.Sleep(5000);
                Console.WriteLine($"Iteration: {iteration} done.");
            }
        }
        #endregion

        #region Parallel ForEach
        static class ParallelForeach
        {
            static void Main()
            {
                List<int> collection = new List<int>() { 1, 2, 3, 5, 7, 9, 11, 13, 15, 17 };
                ParallelLoopResult state = Parallel.ForEach(collection, ParallelMethod);
                if (!state.IsCompleted) Console.WriteLine($"Terminated when collection index = {state.LowestBreakIteration}");
            }
            static void ParallelMethod(int item,ParallelLoopState state)
            {
                Console.WriteLine($"Item: {item}. Task: {Task.CurrentId}");
                if (item == 9) state.Break();
                Thread.Sleep(1000);
            }
        }
        #endregion
    }
}
