namespace HomeWorkLib
{
    public abstract partial class HomeWorkTask : ITaskWork
    {
        public abstract string Title { get; }
        public abstract int TaskNumber { get; }
        public abstract string ToDo { get; }
        public abstract void Work();
    }
}
