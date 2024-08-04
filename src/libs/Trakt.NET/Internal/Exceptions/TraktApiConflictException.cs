namespace TraktNET
{
    public sealed partial class TraktApiConflictException
    {
        internal TraktApiConflictException(ExceptionParameters parameters, Exception? innerException = null)
            : base(parameters, innerException)
        {
        }
    }
}
