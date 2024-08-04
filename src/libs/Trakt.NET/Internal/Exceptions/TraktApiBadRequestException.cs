namespace TraktNET
{
    public sealed partial class TraktApiBadRequestException
    {
        internal TraktApiBadRequestException(ExceptionParameters parameters, Exception? innerException = null)
            : base(parameters, innerException)
        {
        }
    }
}
