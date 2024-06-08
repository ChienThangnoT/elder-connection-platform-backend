using System.Globalization;
using System.Runtime.Serialization;

namespace Application.Exceptions
{
    [Serializable]
    internal class AlreadyExistsException : Exception
    {
        public AlreadyExistsException() : base() { }

        public AlreadyExistsException(string message) : base(message) { }

        public AlreadyExistsException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args)) { }
    }
}