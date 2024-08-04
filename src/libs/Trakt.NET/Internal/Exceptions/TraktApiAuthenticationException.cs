namespace TraktNET
{
    public sealed partial class TraktApiAuthenticationException
    {
        internal TraktApiAuthenticationException(string exceptionMessage, ExceptionParameters parameters, Exception? innerException = null)
            : base(exceptionMessage, parameters, innerException)
        {
        }
    }
}
