namespace HomeWorkLib
{
    public abstract class HomeWorkTask : IHWTaskData,IHWTaskWork
    {
        public abstract string Title { get; }
        public abstract int TaskNumber { get; }
        public abstract string ToDo { get; }

        public abstract void Work();
    }
}
