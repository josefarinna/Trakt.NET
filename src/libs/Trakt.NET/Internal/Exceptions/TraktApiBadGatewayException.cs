namespace TraktNET
{
    public sealed partial class TraktApiBadGatewayException
    {
        internal TraktApiBadGatewayException(ExceptionParameters parameters, Exception? innerException = null)
            : base(parameters, innerException)
        {
        }
    }
}
