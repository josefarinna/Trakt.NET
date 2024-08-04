namespace TraktNET
{
    public sealed partial class TraktApiPreconditionFailedException
    {
        internal TraktApiPreconditionFailedException(ExceptionParameters parameters, Exception? innerException = null)
            : base(parameters, innerException)
        {
        }
    }
}
