namespace TraktNET
{
    public sealed partial class TraktApiCloudflareException
    {
        internal TraktApiCloudflareException(ExceptionParameters parameters, Exception? innerException = null)
            : base(parameters, innerException)
        {
        }
    }
}
