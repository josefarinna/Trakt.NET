namespace TraktNET
{
    public sealed partial class TraktApiValidationException
    {
        internal TraktApiValidationException(ExceptionParameters parameters, Exception? innerException = null)
            : base(parameters, innerException)
        {
        }
    }
}
