using System;

namespace GameProject.GameEngine.InGameObjects
{
    public class GameObjectException : ApplicationException
    {
        private string messageDetails = String.Empty;
        public GameObjectException() { }
        public GameObjectException(string message)
        {
            messageDetails = message;
        }

        public override string Message => $"GameObject Error Message: {messageDetails}";
    }
}
