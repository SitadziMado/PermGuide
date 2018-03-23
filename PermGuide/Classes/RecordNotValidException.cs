using System;
using System.Runtime.Serialization;

namespace PermGuide.Classes
{
    [Serializable]
    public class RecordNotValidException : Exception
    {
        public RecordNotValidException() : base("Время действия данной сущности истекло.")
        {
        }

        public RecordNotValidException(string message) : base(message)
        {
        }

        public RecordNotValidException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RecordNotValidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}