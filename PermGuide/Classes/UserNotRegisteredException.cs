using System;
using System.Runtime.Serialization;

namespace PermGuide.Classes
{
    [Serializable]
    internal class UserNotRegisteredException : Exception
    {
        public UserNotRegisteredException() : 
            base("Пользователь еще не зарегистрировался либо уже имеет аккаунт.")
        {
        }

        public UserNotRegisteredException(string message) : base(message)
        {
        }

        public UserNotRegisteredException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserNotRegisteredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}