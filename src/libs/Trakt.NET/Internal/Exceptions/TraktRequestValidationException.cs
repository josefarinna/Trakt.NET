namespace TraktNET
{
    public sealed partial class TraktRequestValidationException
    {
        internal TraktRequestValidationException(string message, Exception? innerException = null) : base(message, innerException)
        {
        }

        internal TraktRequestValidationException(string propertyName, string message, Exception? innerException = null)
            : base(propertyName, message, innerException)
        {
        }
    }
}
