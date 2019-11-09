using System;

namespace GameEngineLibraryProject.Exceptions
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
