namespace Application.Common.Exceptions
{
    public class CbiException : Exception
    {
        public CbiException() : base() { }
        public CbiException(string message) : base(message) { }
        public CbiException(string message, string details) : base(message, new Exception(details)) { }
        public CbiException(string message, Exception innerException) : base(message, innerException) { }
    }
}
