namespace HomeWorkLib
{
    public interface IHWTask:ITaskWork
    {
        string Title { get; }
        int TaskNumber { get; }
        string ToDo { get; }
    }
}
