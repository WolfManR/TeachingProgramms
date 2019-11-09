using System;

namespace GameEngineLibraryProject
{
    public class Timer
    {
        private System.Threading.Timer timer;
        public int Interval { get; set; } = 1000;
        public event EventHandler<EventArgs> Tick;
        public void Start()
        {
            if(timer == null)timer=new System.Threading.Timer((obj) => { Tick?.Invoke(null, null); }, null, 0, Interval);
        }
        public void Stop()
        {
            timer?.Dispose();
        }
    }
}
