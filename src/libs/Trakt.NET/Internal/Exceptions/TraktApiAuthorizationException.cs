namespace TraktNET
{
    public sealed partial class TraktApiAuthorizationException
    {
        internal TraktApiAuthorizationException(ExceptionParameters parameters, Exception? innerException = null)
            : base(parameters, innerException)
        {
        }
    }
}
