namespace TraktNET
{
    public sealed partial class TraktApiGatewayTimeoutException
    {
        internal TraktApiGatewayTimeoutException(ExceptionParameters parameters, Exception? innerException = null)
            : base(parameters, innerException)
        {
        }
    }
}
