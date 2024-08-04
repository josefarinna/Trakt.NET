namespace TraktNET
{
    public sealed partial class TraktApiDeniedException
    {
        internal TraktApiDeniedException(ExceptionParameters parameters, Exception? innerException = null)
            : base(parameters, innerException)
        {
        }
    }
}
