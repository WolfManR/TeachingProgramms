namespace HomeWorkLib
{
    public abstract partial class HomeWorkTask : ITaskWork
    {
        public string Title { get; }
        public int TaskNumber { get; }
        public string ToDo { get; }

        public abstract void Work();
    }
}
