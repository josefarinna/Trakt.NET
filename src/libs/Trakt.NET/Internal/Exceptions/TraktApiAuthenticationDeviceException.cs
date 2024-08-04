namespace TraktNET
{
    public sealed partial class TraktApiAuthenticationDeviceException
    {
        internal TraktApiAuthenticationDeviceException(string exceptionMessage, ExceptionParameters parameters, Exception? innerException = null)
            : base(exceptionMessage, parameters, innerException)
        {
        }
    }
}
