namespace TraktNET
{
    public partial class TraktApiNotFoundException
    {
        internal TraktApiNotFoundException(string message, ExceptionParameters parameters, Exception? innerException = null)
            : base(message, parameters, innerException)
        {
        }

        internal TraktApiNotFoundException(ExceptionParameters parameters, Exception? innerException = null)
            : base(parameters, innerException)
        {
        }
    }
}
