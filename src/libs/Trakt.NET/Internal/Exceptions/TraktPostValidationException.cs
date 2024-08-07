namespace TraktNET
{
    public partial class TraktPostValidationException
    {
        internal TraktPostValidationException(string message, Exception? innerException = null) : base(message, innerException)
        {
        }

        internal TraktPostValidationException(string propertyName, string message, Exception? innerException = null)
            : this(message, innerException)
            => PropertyName = propertyName;
    }
}
