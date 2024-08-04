namespace TraktNET
{
    public sealed partial class TraktApiServerException
    {
        internal TraktApiServerException(ExceptionParameters parameters, Exception? innerException = null)
            : base(parameters, innerException)
        {
        }
    }
}
