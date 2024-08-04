namespace TraktNET
{
    public sealed partial class TraktApiPersonNotFoundException
    {
        internal TraktApiPersonNotFoundException(ExceptionParameters parameters, Exception? innerException = null)
            : base("Person Not Found - method exists, but no record found", parameters, innerException)
        {
        }
    }
}
