using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherHWTasks
{
    public class HW4_Task3 : ITaskWork
    {
        public string Title => "Order By - Rework";

        public void Work()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
              {"four",4 },
              {"two",2 },
              { "one",1 },
              {"three",3 },
            };
            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            foreach (var pair in d) Console.WriteLine("{0} - {1}", pair.Key, pair.Value);

            Console.WriteLine();

            var f = dict.OrderBy( (pair)=>pair.Value );
            foreach (var pair in f) Console.WriteLine("{0} - {1}", pair.Key, pair.Value);

            Console.WriteLine();

            var k = dict.OrderBy(new Func<KeyValuePair<string, int>, int>(delegate (KeyValuePair<string, int> pair) { return pair.Value; }));
            foreach (var pair in k) Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
        }
    }
}
