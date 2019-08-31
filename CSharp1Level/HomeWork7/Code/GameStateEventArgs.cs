using System;

namespace HomeWork7.Code
{
    public class GameStateEventArgs : EventArgs
    {
        public readonly string msg;
        public GameStateEventArgs(string msg)
        {
            this.msg = msg;
        }
    }
}
