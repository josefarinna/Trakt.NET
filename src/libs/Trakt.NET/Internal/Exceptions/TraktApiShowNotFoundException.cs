namespace TraktNET
{
    public partial class TraktApiShowNotFoundException
    {
        internal TraktApiShowNotFoundException(string message, ExceptionParameters parameters, Exception? innerException = null)
            : base(message, parameters, innerException)
        {
        }

        internal TraktApiShowNotFoundException(ExceptionParameters parameters, Exception? innerException = null)
            : this("Show Not Found - method exists, but no record found", parameters, innerException)
        {
        }
    }
}
