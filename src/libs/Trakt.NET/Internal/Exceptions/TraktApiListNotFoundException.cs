namespace TraktNET
{
    public sealed partial class TraktApiListNotFoundException
    {
        internal TraktApiListNotFoundException(ExceptionParameters parameters, Exception? innerException = null)
            : base("List Not Found - method exists, but no record found", parameters, innerException)
        {
        }
    }
}
