namespace TraktNET
{
    public sealed partial class TraktApiUserNotFoundException
    {
        internal TraktApiUserNotFoundException(ExceptionParameters parameters, Exception? innerException = null)
            : base("User Not Found - method exists, but no record found", parameters, innerException)
        {
        }
    }
}
