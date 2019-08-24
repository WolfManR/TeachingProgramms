namespace HomeWork7.Code
{
    public class Udvoitel
    {
        public int Current { get; private set; }
        public int Number { get; }

        public Udvoitel(int number)
        {
            this.Number = number;
            Current = 1;
        }

        public void Plus()=>Current++;
        public void Multi()=> Current *= 2;
        public void Reset()=> Current = 1;
    }
}
