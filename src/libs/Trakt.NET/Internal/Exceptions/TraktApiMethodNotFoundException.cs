namespace TraktNET
{
    public sealed partial class TraktApiMethodNotFoundException
    {
        internal TraktApiMethodNotFoundException(ExceptionParameters parameters, Exception? innerException = null)
            : base(parameters, innerException)
        {
        }
    }
}
