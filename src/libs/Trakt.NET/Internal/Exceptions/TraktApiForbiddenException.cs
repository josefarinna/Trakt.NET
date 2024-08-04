namespace TraktNET
{
    public sealed partial class TraktApiForbiddenException
    {
        internal TraktApiForbiddenException(ExceptionParameters parameters, Exception? innerException = null)
            : base(parameters, innerException)
        {
        }
    }
}
