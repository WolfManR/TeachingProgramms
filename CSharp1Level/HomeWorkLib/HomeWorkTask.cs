namespace HomeWorkLib
{
    public abstract partial class HomeWorkTask : ITaskWork
    {
        // узнать как в наследуемом классе изменять значение полей для чтения
        //public string Title { get; set; }
        public int TaskNumber { get; set; }
        public string ToDo { get; set; }

        public abstract void Work();
    }
}
