using System;

namespace OtherHWTasks
{
    public class HW3_Lesson3Project:ITaskWork
    {
        public void Work()
        {
            Source s = new Source();
            Observer1 o1 = new Observer1();
            Observer2 o2 = new Observer2();
            NewDelegate<object> d1 = new NewDelegate<object>(o1.Do);
            s.Run += d1;
            s.Run += o2.Do;
            s.Start();
            s.Run -= d1;
            s.Start();
        }
    }

    public delegate void MyDelegate(object o);
    public delegate void NewDelegate<in T>(T o);
    class Source
    {
        public event NewDelegate<object> Run;

        public void Start()
        {
            Console.WriteLine("RUN");
            if (Run != null) Run(this);
        }
    }
    class Observer1 // Наблюдатель 1
    {
        public void Do(object o)
        {
            Console.WriteLine("Первый. Принял, что объект {0} побежал", o);
        }
    }
    class Observer2 // Наблюдатель 2
    {
        public void Do(object o)
        {
            Console.WriteLine("Второй. Принял, что объект {0} побежал", o);
        }
    }
}
