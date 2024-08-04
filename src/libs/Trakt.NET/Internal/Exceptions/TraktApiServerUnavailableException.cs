namespace TraktNET
{
    public sealed partial class TraktApiServerUnavailableException
    {
        internal TraktApiServerUnavailableException(ExceptionParameters parameters, Exception? innerException = null)
            : base(parameters, innerException)
        {
        }
    }
}
