namespace TraktNET
{
    public sealed partial class TraktApiAuthenticationOAuthException
    {
        internal TraktApiAuthenticationOAuthException(string exceptionMessage, ExceptionParameters parameters, Exception? innerException = null)
            : base(exceptionMessage, parameters, innerException)
        {
        }
    }
}
